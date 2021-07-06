using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliver.PdfDocumentParser;

namespace Cliver.PdfDocumentParserTemplateList
{
    public partial class TemplateListControl: UserControl
    {
        public TemplateListControl()
        {
            InitializeComponent();

            template2s.CellPainting += delegate (object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;
                if (e.ColumnIndex == 3)
                {
                    Template2 t = (Template2)template2s.Rows[e.RowIndex].Tag;
                    if (t == null)
                        return;
                    Brush b = null;
                    if (!string.IsNullOrWhiteSpace(t.DocumentParserClass))
                        b = Brushes.LightCyan;
                    else if (!string.IsNullOrWhiteSpace(Compiler.RemoveComments(t.DocumentParserClassDefinition)))
                        b = Brushes.LightYellow;
                    if (b == null)
                        return;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~(DataGridViewPaintParts.ContentForeground));
                    Rectangle r = e.CellBounds;
                    r.Inflate(-4, -4);
                    e.Graphics.FillRectangle(b, r);
                    e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
                    e.Handled = true;
                }
            };

            //FormClosing += delegate (object sender, FormClosingEventArgs e)
            //{
            //    if (processorThread != null && processorThread.IsAlive)
            //    {
            //        if (!Win.LogMessage.AskYesNo("Processing is running. Would you like to abort it?", true))
            //        {
            //            e.Cancel = true;
            //            return;
            //        }
            //    }
            //    if (!saveCurrentScopeFromGuiIfTouched(true))
            //        e.Cancel = true;
            //};

            initializeSelectionEngine();

            Active.ValueType = typeof(bool);
            Selected.ValueType = typeof(bool);
            OrderWeight.ValueType = typeof(float);

            TemplateInfoSettings.TouchedChanged += delegate ()
            {
                this.BeginInvoke(() =>
                {
                    saveTemplates.Enabled = Settings.TemplateInfo.IsTouched();
                });
            };

            saveTemplates.Enabled = false;
            saveTemplates.Click += delegate
            {
                saveCurrentScopeFromGuiIfTouched(false);
            };

            template2s.CellValidating += delegate (object sender, DataGridViewCellValidatingEventArgs e)
            {
                try
                {
                    DataGridViewRow r = template2s.Rows[e.RowIndex];
                    Template2 t = (Template2)r.Tag;

                    switch (template2s.Columns[e.ColumnIndex].Name)
                    {
                        case "Name_":
                            {
                                if (string.IsNullOrWhiteSpace((string)e.FormattedValue))
                                {
                                    if (t != null)
                                        throw new Exception("Name cannot be empty!");
                                    return;
                                }
                                string name2 = ((string)e.FormattedValue).Trim();
                                foreach (DataGridViewRow rr in template2s.Rows)
                                {
                                    if (rr.Index != e.RowIndex && name2 == (string)rr.Cells["Name_"].Value)
                                        throw new Exception("Name '" + name2 + "' is duplicated!");
                                }
                                if ((string)r.Cells["Name_"].Value != name2)
                                    r.Cells["Name_"].Value = name2;
                            }
                            return;
                    }
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    Message.Error2(ex);
                }
            };

            template2s.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e)
            {
                try
                {
                    DataGridViewRow r = template2s.Rows[e.RowIndex];
                    Template2 t = (Template2)r.Tag;

                    switch (template2s.Columns[e.ColumnIndex].Name)
                    {
                        case "OrderWeight":
                            throw new Exception("Order must be a float number:\r\n" + e.Exception.Message);
                        case "DetectingTemplateLastPageNumber":
                            throw new Exception("DetectingTemplateLastPageNumber must be a uint number:\r\n" + e.Exception.Message);
                        case "FileFilterRegex":
                            throw new Exception("FileFilterRegex must be a regex.");
                        case "SharedFileTemplateNamesRegex":
                            throw new Exception("SharedFileTemplateNamesRegex must be a regex.");
                    }
                }
                catch (Exception ex)
                {
                    Message.Error2(ex);
                }
            };

            template2s.CellValueChanged += delegate (object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    DataGridViewRow r = template2s.Rows[e.RowIndex];
                    Template2 t = (Template2)r.Tag;
                    if (t == null)
                        return;
                    if (e.ColumnIndex < 0)//row's header
                        return;

                    switch (template2s.Columns[e.ColumnIndex].Name)
                    {
                        case "Name_":
                            t.Template.Name = (string)r.Cells["Name_"].Value;
                            break;
                        case "Active":
                            t.Active = (bool)r.Cells["Active"].Value;
                            break;
                        case "Comment":
                            t.Comment = (string)r.Cells["Comment"].Value;
                            break;
                        case "Group":
                            t.Group = (string)r.Cells["Group"].Value;
                            break;
                        case "OrderWeight":
                            t.OrderWeight = (float)r.Cells["OrderWeight"].Value;
                            break;
                    }
                    Settings.TemplateInfo.Touch();
                }
                catch (Exception ex)
                {
                    Message.Error2(ex);
                }
            };

            template2s.UserDeletingRow += delegate (object sender, DataGridViewRowCancelEventArgs e)
            {
                try
                {
                    if (e.Row == null || e.Row.Tag == null)
                        return;
                    if (!Message.YesNo("Template '" + e.Row.Cells["Name_"].Value + "' will be deleted! Proceed?"))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Win.LogMessage.Error(ex);
                }
            };

            template2s.UserDeletedRow += delegate (object sender, DataGridViewRowEventArgs e)
            {
                Settings.TemplateInfo.Touch();
            };

            TemplateManager.Templates = template2s;

            template2s.SelectionChanged += delegate (object sender, EventArgs e)
            {
                //if (templates.SelectedRows.Count < 1)
                //    return;
                //var r = templates.SelectedRows[templates.SelectedRows.Count - 1];
                //if (r.IsNewRow)//hacky forcing commit a newly added row and display the blank row
                //{
                //    try
                //    {
                //        int i = templates.Rows.Add();
                //        templates.Rows[i].Selected = true;
                //        templates.Rows[i].Cells["Active"].Value = true;
                //        templates.Rows[i].Cells["Group"].Value = "";
                //    }
                //    catch { }
                //}
            };

            template2s.CellClick += delegate (object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0)
                    return;
                DataGridViewRow r = template2s.Rows[e.RowIndex];
                if (e.ColumnIndex < 0)//row's header
                    return;

                if (r.IsNewRow)//hacky forcing commit a newly added row and display the blank row
                {
                    try
                    {
                        int i = template2s.Rows.Add();
                        r = template2s.Rows[i];
                        Template2 t = Settings.TemplateInfo.CreateInitialTemplate();
                        r.Tag = t;
                        r.Cells["Active"].Value = t.Active;
                        r.Cells["Group"].Value = t.Group;
                        r.Cells["OrderWeight"].Value = t.OrderWeight;
                        r.Cells["FileFilterRegex"].Value = t.FileFilterRegex;
                        r.Selected = true;
                    }
                    catch { }
                }

                switch (template2s.Columns[e.ColumnIndex].Name)
                {
                    case "Edit":
                        editTemplate(r);
                        break;
                    case "Copy":
                        Template2 t = (Template2)r.Tag;
                        if (t == null)
                            return;
                        Template2 t2 = t.Clone();
                        t2.Template.Name = "";
                        t2.Template.Editor.TestFile = null;
                        int i = template2s.Rows.Add(new DataGridViewRow());
                        DataGridViewRow r2 = template2s.Rows[i];
                        r2.Tag = t2;
                        r2.Cells["Name_"].Value = t2.Template.Name.Trim();
                        r2.Cells["Active"].Value = t2.Active;
                        r2.Cells["Group"].Value = t2.Group;
                        r2.Cells["OrderWeight"].Value = t2.OrderWeight;
                        editTemplate(r2);
                        break;
                    case "Edit2":
                        edit2Template(r);
                        break;
                }
            };

            progress.Maximum = 10000;

            Load += delegate
            {
                Load2Gui();
            };
        }
    }
}
