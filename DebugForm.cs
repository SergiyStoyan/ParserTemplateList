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
    abstract public partial class DebugForm<Template2T> : Form where Template2T : Template2
    {
        public DebugForm(TemplateListControl<Template2T> templateListControl)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();

            this.templateListControl = templateListControl;
        }
        TemplateListControl<Template2T> templateListControl;

        virtual public Template2T Template2
        {
            set
            {
                template2 = value;
                Text = Application.ProductName + ": debugging '" + template2.Name + "'";
                TestFile.Text = templateListControl.LocalInfo.GetInfo(template2).LastTestFile;
                debug();
            }
            protected get { return template2; }
        }
        Template2T template2;

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

        abstract protected void debug(out List<List<string>> resultsPages, out string log);

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
                Template2T t2 = templateListControl.TemplateInfo.Template2s.OrderByDescending(a => a.ModifiedTime).FirstOrDefault(a =>
                {
                    string tf = templateListControl.LocalInfo.TemplateNames2TemplateInfo[a.Name].LastTestFile;
                    return tf != null && System.IO.File.Exists(tf);
                });
                d.InitialDirectory = t2 != null ? PathRoutines.GetFileDir(templateListControl.LocalInfo.TemplateNames2TemplateInfo[t2.Name].LastTestFile) : Environment.SpecialFolder.DesktopDirectory.ToString();
            }
            else
                d.InitialDirectory = PathRoutines.GetFileDir(TestFile.Text);
            if (d.ShowDialog() != DialogResult.OK)
                return;
            TestFile.Text = d.FileName;
        }

        virtual protected void bEdit_Click(object sender, EventArgs e)
        {
            templateListControl.EditTemplate(template2.Name);
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
