//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cliver.ParserTemplateList
{
    public partial class Template2Form<T2> : Form where T2:Template2
    {
        public Template2Form(T2 template2, TemplateListControl<T2> templateListControl)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
            Text = Application.ProductName + ": additional properties of '" + template2.Template.Name + "'";

            FormClosed += delegate
            {
                if (debugForm != null && !debugForm.IsDisposed)
                    debugForm.Close();
            };

            this.templateListControl = templateListControl;

            Template2 = template2;
            Active.Checked = template2.Active;
            Group.Text = template2.Group;
            Comment.Text = template2.Comment;
            OrderWeight.Value = (decimal)template2.OrderWeight;
            //Company.Text = t.Company;
            DocumentParserClassDefinition.Text = template2.DocumentParserClassDefinition;
            DocumentParserClassDefinition.SetHighlighting("C#");

            DocumentParserClass.DisplayMember = "Key";
            DocumentParserClass.ValueMember = "Value";
            //var ds = Pdf.DocumentParserCompiler.HardcodedDocumentParsers.Select(a => new { Key = a.Name, Value = a.Name }).ToList();
            //ds.Insert(0, new { Key = "", Value = "" });
            //DocumentParserClass.DataSource = ds;
            DocumentParserClass.SelectedValue = template2.DocumentParserClass;
        }
        TemplateListControl<T2> templateListControl;

        virtual public T2 Template2
        {
            set
            {
                template2 = value;
                if (debugForm?.CanFocus == true)
                    debugForm.Template2 = template2;
            }
            get
            {
                return template2;
            }
        }
        T2 template2;

        virtual protected bool setTemplate2()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(DocumentParserClassDefinition.Text))
                {
                    DocumentParserClassDefinition.Document.MarkerStrategy.RemoveAll(marker => true);
                    try
                    {
                        //bool documentParserClassDefinitionIsSet = null != Pdf.DocumentParserCompiler.Compile(DocumentParserClassDefinition.Text);//checking
                        //if (documentParserClassDefinitionIsSet && !string.IsNullOrWhiteSpace(DocumentParserClass.Text))
                        //    throw new Exception("DocumentParser class and its definition cannot be specified at the same time.");
                    }
                    catch (PdfDocumentParser.Compiler.Exception ex)
                    {
                        foreach (PdfDocumentParser.Compiler.Error ce in ex.Data.Values)
                        {
                            ICSharpCode.TextEditor.Document.TextMarker tm = new ICSharpCode.TextEditor.Document.TextMarker(ce.P1, ce.P2 - ce.P1, ICSharpCode.TextEditor.Document.TextMarkerType.WaveLine, System.Drawing.Color.Red);
                            tm.ToolTip = ce.Message;
                            DocumentParserClassDefinition.Document.MarkerStrategy.AddMarker(tm);
                        }
                        throw ex;
                    }
                }

                //if (string.IsNullOrWhiteSpace(Company.Text))
                //    throw new Exception2("Company cannot be empty");

                Template2.DocumentParserClassDefinition = DocumentParserClassDefinition.Text;
                Template2.Active = Active.Checked;
                Template2.Group = Group.Text;
                Template2.Comment = Comment.Text;
                Template2.OrderWeight = (float)OrderWeight.Value;
                //template2.Company = Company.Text;
                Template2.DocumentParserClass = DocumentParserClass.Text;
                return true;
            }
            catch (Exception ex)
            {
                Message.Error2(ex, this);
                return false;
            }
        }

        virtual protected void bOK_Click(object sender, EventArgs e)
        {
            if (!setTemplate2())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        virtual protected void bCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        virtual protected void bDebug_Click(object sender, EventArgs e)
        {
            if (setTemplate2())
            {
                if (debugForm == null || debugForm.IsDisposed)
                    debugForm = new DebugForm<T2>(templateListControl);
                debugForm.Template2 = Template2;
                debugForm.Show();
                debugForm.BringToFront();
            }
        }
        protected DebugForm<T2> debugForm = null;
    }
}

