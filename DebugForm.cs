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
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
        }

        virtual public Template2 Template2
        {
            set
            {
                template2 = value;
                Text = Application.ProductName + ": debugging '" + template2.Template.Name + "'";
                TestFile.Text = Settings.LocalInfo.GetInfo(template2).LastTestFile;
                debug();
            }
        }
        Template2 template2;

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
                Result.Text = "";
                logBox.Text = "";
                //template2.DocumentParser = null;
                //FieldValues fieldValues = Pdf.Parser.Parse(TestFile.Text, new List<Template2> { template2 }, true);
                //if (fieldValues != null)
                //{
                //    StringBuilder sb = new StringBuilder();
                //    foreach (var p in fieldValues.Records.GroupBy(a => a.PageI))
                //        sb.Append(">>>>  Page " + p.Key + " >>>>\r\n\r\n" + string.Join("\r\n", p.Select(a => a.Item)) + "\r\n\r\n");
                //    Result.Text = sb.ToString();
                //}
                //else
                //    logBox.Text = "The template could not parse the test file.";
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
                Template2 t2 = Settings.TemplateInfo.Template2s.OrderByDescending(a => a.ModifiedTime).FirstOrDefault(a =>
                {
                    string tf = Settings.LocalInfo.TemplateNames2TemplateInfo[a.Template.Name].LastTestFile;
                    return tf != null && System.IO.File.Exists(tf);
                });
                d.InitialDirectory = t2 != null ? PathRoutines.GetFileDir(Settings.LocalInfo.TemplateNames2TemplateInfo[t2.Template.Name].LastTestFile) : Environment.SpecialFolder.DesktopDirectory.ToString();
            }
            else
                d.InitialDirectory = PathRoutines.GetFileDir(TestFile.Text);
            if (d.ShowDialog() != DialogResult.OK)
                return;
            TestFile.Text = d.FileName;
        }

        virtual protected void bEdit_Click(object sender, EventArgs e)
        {
            MainForm.This.EditTemplate(template2.Template.Name);
        }

        virtual protected void bLog_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Log.Main.File))
                System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + Log.Main.File + "\"");
            else
                System.Diagnostics.Process.Start(Log.RootDir);
        }
    }
}
