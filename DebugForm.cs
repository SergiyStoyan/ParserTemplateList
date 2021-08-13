using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliver.ParserTemplateList
{
    public partial class DebugForm<T2> : Form where T2 : Template2
    {
        public DebugForm(TemplateListControl<T2> templateListControl)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();

            this.templateListControl = templateListControl;
        }
        TemplateListControl<T2> templateListControl;

        virtual public T2 Template2
        {
            set
            {
                template2 = value;
                Text = Application.ProductName + ": debugging '" + template2.Template.Name + "'";
                TestFile.Text = templateListControl.LocalInfo.GetInfo(template2).LastTestFile;
                debug();
            }
            protected get { return template2; }
        }
        T2 template2;

        virtual protected void debug()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TestFile.Text))
                {
                    Message.Exclaim("No test file is set.", this);
                    return;
                }
                if (!System.IO.File.Exists(TestFile.Text))
                {
                    Message.Exclaim("The test file does not exist.", this);
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                debug(out List<List<string>> resultsPages, out string log);
                logBox.Text = log;
                if (resultsPages != null)
                {
                    StringBuilder sb = new StringBuilder();
                    string joinString = Result.WordWrap ? "\r\n\r\n" : "\r\n";
                    for (int i = 0; i < resultsPages.Count; i++)
                        sb.Append(">>>>  Page " + i + " >>>>\r\n\r\n" + string.Join(joinString, resultsPages[i]) + "\r\n\r\n");
                    Result.Text = sb.ToString();
                }
                else
                    logBox.Text = "The template could not parse the test file.";
            }
            catch (Exception e)
            {
                Log.Error(e);
                //Message.Error(e);
                logBox.Text = Log.GetExceptionMessage(e, !(e is Exception2));
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        virtual protected void debug(out List<List<string>> resultsPages, out string log)
        {
            resultsPages = new List<List<string>> { new List<string> { "To be overriden." } };
            log = "To be overriden.";
        }

        virtual protected void bDebug_Click(object sender, EventArgs e)
        {
            debug();
        }

        virtual protected void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        virtual protected void bTestFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (string.IsNullOrWhiteSpace(TestFile.Text))
            {
                T2 t2 = templateListControl.TemplateInfo.Template2s.OrderByDescending(a => a.ModifiedTime).FirstOrDefault(a =>
                {
                    string tf = templateListControl.LocalInfo.TemplateNames2TemplateInfo[a.Template.Name].LastTestFile;
                    return tf != null && System.IO.File.Exists(tf);
                });
                d.InitialDirectory = t2 != null ? PathRoutines.GetFileDir(templateListControl.LocalInfo.TemplateNames2TemplateInfo[t2.Template.Name].LastTestFile) : Environment.SpecialFolder.DesktopDirectory.ToString();
            }
            else
                d.InitialDirectory = PathRoutines.GetFileDir(TestFile.Text);
            if (d.ShowDialog() != DialogResult.OK)
                return;
            TestFile.Text = d.FileName;
        }

        virtual protected void bEdit_Click(object sender, EventArgs e)
        {
            templateListControl.EditTemplate(template2.Template.Name);
        }

        virtual protected void bLog_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Log.Main.File))
                System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + Log.Main.File + "\"");
            else
                System.Diagnostics.Process.Start(Log.RootDir);
        }

        private void cWrapLines_CheckedChanged(object sender, EventArgs e)
        {
            Result.WordWrap = cWrapLines.Checked;
        }
    }
}
