//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;

namespace Cliver.ParserTemplateList
{
    public partial class TemplateListControl<Template2T> 
    {
        #region processorThread

        public bool TryLaunchProcessorThread(string progressTask, Func<bool> preProcessorCode, MethodInvoker processorCode/*, Win.ThreadRoutines.ErrorHandler exceptionCode=null*/, MethodInvoker finallyCode = null)
        {
            if (IsProcessorRunning)
            {
                string m = "Processor is running. Would you like to abort it and restart?";
                Log.Inform(m);
                if (!Message.YesNo(m, FindForm()))
                    return false;
                if (!StopPpocessor())
                    return false;
            }

            if (!SaveFromGui(false))
                return false;

            if (preProcessorCode != null && !(bool)this.Invoke(() => { return preProcessorCode(); }))
                return false;

            lProgressTask.Invoke(() =>
            {
                lProgressTask.Text = progressTask + ":";
            });
            RunProcessorFlag = true;
            processorThread = Win.ThreadRoutines.StartTry(
                processorCode,
                (Exception e) =>
                {
                    Log.Error(e);
                    SetProgressTask("ERROR!", Color.Red);
                    ThreadRoutines.Start(() => { Message.Error(e, FindForm()); });
                },
                () =>
                {
                    finallyCode?.Invoke();
                    ProcessorStateChange?.BeginInvoke(false, null, null);
                }
            );
            ProcessorStateChange?.BeginInvoke(true, null, null);

            return true;
        }
        Thread processorThread = null;

        public bool RunProcessorFlag { get; private set; } = false;

        public event Action<bool> ProcessorStateChange;

        public bool StopPpocessor()
        {
            if (!IsProcessorRunning)
                return true;
            Log.Inform("Stopping processorThread...");
            RunProcessorFlag = false;
            if (processorThread.TryAbort(1000))
            {
                processorThread = null;
                Log.Inform("TERMINATED");
                SetProgressTask("TERMINATED", Color.Yellow);
                ThreadRoutines.Start(() => { Message.Inform("TERMINATED...", FindForm()); });
                ProcessorStateChange?.BeginInvoke(false, null, null);
            }
            return IsProcessorRunning;
        }

        public bool IsProcessorRunning
        {
            get
            {
                return processorThread?.IsAlive == true;
            }
        }

        #endregion

        #region templates management panel

        bool getBoolValue(DataGridViewRow r, string name)
        {
            bool? s = (bool?)r.Cells[name].Value;
            return s == null ? false : (bool)s;
        }

        //string getStringValue(DataGridViewRow r, string name)
        //{
        //    string s = (string)r.Cells[name].Value;
        //    return s == null ? "" : s;
        //}

        //float getFloatValue(DataGridViewRow r, string name)
        //{
        //    float? f = (float?)r.Cells[name].Value;
        //    return f == null ? 0f : (float)f;
        //}

        void initializeSelectionEngine()
        {
            useActivePattern.CheckedChanged += delegate { activePattern.Enabled = useActivePattern.Checked; };
            useNamePattern.CheckedChanged += delegate { namePattern.Enabled = useNamePattern.Checked; };
            useGroupPattern.CheckedChanged += delegate { groupPattern.Enabled = useGroupPattern.Checked; };
            useCommentPattern.CheckedChanged += delegate { commentPattern.Enabled = useCommentPattern.Checked; };
            useOrderWeightPattern.CheckedChanged += delegate { orderWeightPattern1.Enabled = orderWeightPattern2.Enabled = useOrderWeightPattern.Checked; };

            useActivePattern.Checked = Settings.General.UseActiveSelectPattern;
            useNamePattern.Checked = Settings.General.UseNameSelectPattern;
            useGroupPattern.Checked = Settings.General.UseGroupSelectPattern;
            useCommentPattern.Checked = Settings.General.UseCommentSelectPattern;
            useOrderWeightPattern.Checked = Settings.General.UseOrderWeightPattern;
            sortSelectedUp.Checked = Settings.General.SortSelectedUp;

            void showSelectedCount()
            {
                int count = 0;
                foreach (DataGridViewRow r in template2s.Rows)
                {
                    if (r.Tag == null)
                        continue;
                    if (getBoolValue(r, "Selected"))
                        count++;
                }
                selectedTemplatesCount.Text = "Selected: " + count + " templates";
            };

            void select_by_filter(object sender, EventArgs e)
            {
                float orderWeight1 = (float)orderWeightPattern1.Value;
                float orderWeight2 = (float)orderWeightPattern2.Value;
                foreach (DataGridViewRow r in template2s.Rows)
                {
                    Template2 t = (Template2)r.Tag;
                    if (t == null)
                        continue;
                    bool s = (!activePattern.Enabled || (t.Active == activePattern.Checked))
                         && (!namePattern.Enabled || (string.IsNullOrEmpty(namePattern.Text) ? string.IsNullOrEmpty(t.Template.Name) : Regex.IsMatch(t.Template.Name, namePattern.Text, RegexOptions.IgnoreCase)))
                         && (!groupPattern.Enabled || (string.IsNullOrEmpty(groupPattern.Text) ? string.IsNullOrEmpty(t.Group) : Regex.IsMatch(t.Group, groupPattern.Text, RegexOptions.IgnoreCase)))
                         && (!commentPattern.Enabled || (string.IsNullOrEmpty(commentPattern.Text) ? string.IsNullOrEmpty(t.Comment) : Regex.IsMatch(t.Comment, commentPattern.Text, RegexOptions.IgnoreCase)))
                         && (!orderWeightPattern2.Enabled || (orderWeight1 <= t.OrderWeight && t.OrderWeight <= orderWeight2));
                    r.Cells["Selected"].Value = s;
                }
                if (sortSelectedUp.Checked)
                    template2s.Sort(template2s.Columns["Selected"], ListSortDirection.Descending);

                showSelectedCount();

                Settings.General.UseActiveSelectPattern = useActivePattern.Checked;
                Settings.General.UseNameSelectPattern = useNamePattern.Checked;
                Settings.General.UseGroupSelectPattern = useGroupPattern.Checked;
                Settings.General.UseCommentSelectPattern = useCommentPattern.Checked;
                Settings.General.UseOrderWeightPattern = useOrderWeightPattern.Checked;
                Settings.General.SortSelectedUp = sortSelectedUp.Checked;
                Settings.General.Save();
            };
            selectByFilter.Click += select_by_filter;

            void select_on_Enter(object sender, KeyEventArgs e)
            {
                if (e.KeyCode != Keys.Enter)
                    return;
                e.Handled = true;
                select_by_filter(null, null);
            };
            //AcceptButton = new Button { Visible = false };//just to suppress a ding
            activePattern.KeyDown += select_on_Enter;
            namePattern.KeyDown += select_on_Enter;
            groupPattern.KeyDown += select_on_Enter;
            commentPattern.KeyDown += select_on_Enter;
            orderWeightPattern1.KeyDown += select_on_Enter;
            orderWeightPattern2.KeyDown += select_on_Enter;

            selectAll.Click += delegate
            {
                foreach (DataGridViewRow r in template2s.Rows)
                {
                    r.Cells["Selected"].Value = true;
                }
                showSelectedCount();
            };
            selectNothing.Click += delegate
            {
                foreach (DataGridViewRow r in template2s.Rows)
                {
                    r.Cells["Selected"].Value = false;
                }
                showSelectedCount();
            };
            selectInvertion.Click += delegate
            {
                foreach (DataGridViewRow r in template2s.Rows)
                {
                    r.Cells["Selected"].Value = !getBoolValue(r, "Selected");
                }
                showSelectedCount();
            };
            lRefreshSelectedCounter.Click += delegate
            {
                showSelectedCount();
            };

            applyActiveChange.Click += delegate
            {
                foreach (DataGridViewRow r in template2s.Rows)
                    if (getBoolValue(r, "Selected"))
                        r.Cells["Active"].Value = activeChange.Checked;
                TemplateInfo.Touch();
            };
            applyGroupChange.Click += delegate
            {
                foreach (DataGridViewRow r in template2s.Rows)
                    if (getBoolValue(r, "Selected"))
                        r.Cells["Group"].Value = groupChange.Text;
                TemplateInfo.Touch();
            };
            applyOrderWeightChange.Click += delegate
            {
                foreach (DataGridViewRow r in template2s.Rows)
                    if (getBoolValue(r, "Selected"))
                        r.Cells["OrderWeight"].Value = (float)orderWeightChange.Value;
                TemplateInfo.Touch();
            };
        }

        #endregion

        #region progress bar

        public void SetProgressTask(string message, Color? color = null)
        {
            progress.Invoke(() =>
            {
                lProgressTask.Text = message;
                lProgressTask.BackColor = color == null ? SystemColors.Control : (Color)color;
            });
        }

        public void SetProgressCurrentBlock(string message)
        {
            progress.Invoke(() =>
            {
                lProgressCurrentBlock.Text = message != null ? "processing: " + message : "";
            });
        }

        public void OnProgress(string message)
        {
            progress.Invoke(() =>
            {
                lProgress.Text = message;
            });
        }

        public void OnProgress(string unitsName, int processedN, int totalN)
        {
            if (processedN >= 0)
            {
                if (totalN < 0)
                    progress.Invoke(() =>
                    {
                        progress.Value = 0;
                        lProgress.Text = "starting...";
                    });
                else if (totalN == 0)
                    progress.Invoke(() =>
                    {
                        progress.Value = 0;
                        lProgress.Text = "processed: " + processedN + (unitsName == null ? "" : " " + unitsName);
                    });
                else //if (processedN < totalN)
                    progress.Invoke(() =>
                    {
                        progress.Value = (int)(progress.Maximum * ((float)processedN / totalN));
                        lProgress.Text = "processed: " + processedN + (unitsName == null ? "" : " " + unitsName) + " of " + totalN;
                    });
                //else //if (processedN >= totalN)
                //    progress.Invoke(() =>
                //    {
                //        progress.Value = progress.Maximum;
                //        lProgress.Text = "completed";
                //    });
            }
            else //if (processedN < 0)
                progress.Invoke(() =>
                {
                    lProgress.Text = "FAILED... (last state: " + lProgress.Text + ")";
                });
        }

        #endregion

        public string TemplateTestFileDefaultFolder;

        public event Func<bool> SavingFromGui;
        public event Action Loading2Gui;

        public class FormManager
        {
            static Dictionary<Type, Dictionary<DataGridViewRow, Form>> formTypes2rows2form = new Dictionary<Type, Dictionary<DataGridViewRow, Form>>();

            static public T Get<T>(DataGridViewRow row) where T : Form
            {
                Dictionary<DataGridViewRow, Form> rows2form = getRows2form(typeof(T));
                rows2form.TryGetValue(row, out Form form);
                if (form?.IsDisposed == true)
                {
                    rows2form.Remove(row);
                    form = null;
                }
                return (T)form;
            }

            static Dictionary<DataGridViewRow, Form> getRows2form(Type formType)
            {
                if (!formTypes2rows2form.TryGetValue(formType, out Dictionary<DataGridViewRow, Form> rows2form))
                {
                    rows2form = new Dictionary<DataGridViewRow, Form>();
                    formTypes2rows2form[formType] = rows2form;
                }
                return rows2form;
            }

            static public void Set(DataGridViewRow row, Form form)
            {
                Dictionary<DataGridViewRow, Form> rows2form = getRows2form(form.GetType());
                form.FormClosed += delegate
                {
                    rows2form.Remove(row);
                };
                rows2form[row] = form;
            }
        }
    }
}