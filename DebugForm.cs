//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        sergey.stoyan@hotmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliver.ParserTemplateList
{
    abstract public partial class DebugForm<Template2T, DocumentParserT> : Form where Template2T : Template2 where DocumentParserT : class
    {
        public DebugForm(TemplateListControl<Template2T, DocumentParserT> templateListControl)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();

            this.templateListControl = templateListControl;

            cWrapLines_CheckedChanged(null, null);
        }
        TemplateListControl<Template2T, DocumentParserT> templateListControl;

        virtual public Template2T Template2
        {
            set
            {
                template2 = value;
                Text = Application.ProductName + ": debugging '" + template2.Name + "'";
                TestFile.Text = templateListControl.LocalInfo.GetInfo(template2).LastTestFile;
                WrapLines.Checked = value.WrapLinesInDebugger;
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
                debug(out string result, out string log);
                Result.Text = result;
                LogBox.Text = log;
                if (result == null && log == null)
                    LogBox.Text = "The template could not parse the test file.";
            }
            catch (Exception e)
            {
                Log.Error(e);
                //Message.Error(e);
                LogBox.Text = Log.GetExceptionMessage(e, !(e is Exception2));
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        abstract protected void debug(out string result, out string log);

        virtual protected void bDebug_Click(object sender, EventArgs e)
        {
            debug();
        }

        virtual protected void bClose_Click(object sender, EventArgs e)
        {
            Close();

            if (Template2 != null)
                Template2.WrapLinesInDebugger = WrapLines.Checked;
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
                ProcessRoutines.Open(Log.RootDir);
        }

        private void cWrapLines_CheckedChanged(object sender, EventArgs e)
        {
            Result.WordWrap = WrapLines.Checked;
        }
    }
}
