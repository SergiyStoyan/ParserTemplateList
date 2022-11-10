//********************************************************************************************
//Author: Sergiy Stoyan
//        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
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
    public partial class Template2Form<Template2T, DocumentParserT> : Form where Template2T : Template2<DocumentParserT> where DocumentParserT : class
    {
        public Template2Form(DataGridViewRow template2Row, TemplateListControl<Template2T, DocumentParserT> templateListControl)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
            Template2T t2 = (Template2T)template2Row.Tag;
            Text = Application.ProductName + ": additional properties of '" + t2.Name + "'";

            FormClosed += delegate
            {
                DebugForm<Template2T, DocumentParserT> debugForm = FormManager.Get<DebugForm<Template2T, DocumentParserT>>(template2Row);
                if (debugForm != null && !debugForm.IsDisposed)
                    debugForm.Close();
            };

            Load += delegate
            {
                this.templateListControl = templateListControl;
                this.template2Row = template2Row;
                Template2 = t2.CreateCloneByJson();

                Active.Checked = Template2.Active;
                Group.Text = Template2.Group;
                Comment.Text = Template2.Comment;
                OrderWeight.Value = (decimal)Template2.OrderWeight;
                //Company.Text = t.Company;
                DocumentParserClassDefinition.Text = Template2.DocumentParserClassDefinition;
                DocumentParserClassDefinition.SetHighlighting("C#");

                DocumentParserClass.DisplayMember = "Key";
                DocumentParserClass.ValueMember = "Value";
                var ds = templateListControl.Compiler.HardcodedDocumentParserTypes.Select(a => new { Key = a.Name, Value = a.Name }).ToList();
                //ds.AddRange(templateListControl.Compiler.CommonDocumentParserTypes.Select(a => new { Key = a.Name, Value = a.Name }));
                ds.AddRange(templateListControl.Compiler.CommonDocumentParserNames.Where(a => a != templateListControl.TemplateInfo.DefaultDocumentParserClass).Select(a => new { Key = a, Value = a }));
                ds.Insert(0, new { Key = "", Value = "" });
                DocumentParserClass.DataSource = ds;
                if (!string.IsNullOrWhiteSpace(Template2.DocumentParserClass))
                    DocumentParserClass.SelectedValue = Template2.DocumentParserClass;
            };
        }
        TemplateListControl<Template2T, DocumentParserT> templateListControl;
        DataGridViewRow template2Row;

        virtual public Template2T Template2
        {
            set
            {
                template2 = value;
                DebugForm<Template2T, DocumentParserT> debugForm = FormManager.Get<DebugForm<Template2T, DocumentParserT>>(template2Row);
                if (debugForm?.CanFocus == true)
                    debugForm.Template2 = template2;
            }
            get
            {
                return template2;
            }
        }
        Template2T template2;
        //public readonly Template2T Template2;// { get; protected set; }

        virtual protected bool setTemplate2()
        {
            try
            {
                Type documentParserType = null;
                string documentParserTypeName = null;
                if (!string.IsNullOrWhiteSpace(DocumentParserClassDefinition.Text))
                {
                    DocumentParserClassDefinition.Document.MarkerStrategy.RemoveAll(marker => true);
                    try
                    {
                        documentParserType = templateListControl.Compiler.CompileSingleType(DocumentParserClassDefinition.Text);//checking
                        if (documentParserType != null)
                        {
                            if (!string.IsNullOrWhiteSpace(DocumentParserClass.Text))
                                throw new Exception("Document parser class and its definition cannot be specified at the same time.");
                            documentParserTypeName = "#" + documentParserType.Name;
                            Template2T t = templateListControl.GetTemplatesFromGui().Find(a => a.Name != Template2.Name && a.DocumentParserClass == documentParserTypeName);
                            if (t != null)
                                throw new Exception("Template '" + t.Name + "' already defines class '" + documentParserType.Name + "'.");
                            if (null != templateListControl.Compiler.CommonDocumentParserNames.Find(a => a == documentParserType.Name))
                                throw new Exception("Class '" + documentParserType.Name + "' is already defined in the common document parsers.");
                            if (null != templateListControl.Compiler.HardcodedDocumentParserTypes.Find(a => a.Name == documentParserType.Name))
                                throw new Exception("Class '" + documentParserType.Name + "' is already defined in the common document parsers.");
                        }
                    }
                    catch (PdfDocumentParser.Compiler.Exception ex)
                    {
                        foreach (PdfDocumentParser.Compiler.Error ce in ex.Data.Values)
                        {
                            ICSharpCode.TextEditor.Document.TextMarker tm = new ICSharpCode.TextEditor.Document.TextMarker(ce.P1, ce.P2 - ce.P1, ICSharpCode.TextEditor.Document.TextMarkerType.WaveLine, System.Drawing.Color.Red);
                            tm.ToolTip = ce.Message;
                            DocumentParserClassDefinition.Document.MarkerStrategy.AddMarker(tm);
                        }
                        throw;
                    }
                }
                if (documentParserType == null && !string.IsNullOrWhiteSpace(DocumentParserClass.Text))
                {
                    documentParserTypeName = DocumentParserClass.Text;
                    if (templateListControl.Compiler.HardcodedDocumentParserTypes.Find(a => a.Name == documentParserTypeName) == null
                        && templateListControl.Compiler.CommonDocumentParserTypes.Find(a => a.Name == documentParserTypeName) == null
                        )
                        throw new Exception("Class '" + DocumentParserClass.Text + "' is not defined as neither hardcoded nor hot-compiled.");
                }

                //if (string.IsNullOrWhiteSpace(Company.Text))
                //    throw new Exception2("Company cannot be empty");

                Template2.Active = Active.Checked;
                Template2.Group = Group.Text;
                Template2.Comment = Comment.Text;
                Template2.OrderWeight = (float)OrderWeight.Value;
                //Template2.Company = Company.Text;
                Template2.DocumentParserClassDefinition = DocumentParserClassDefinition.Text;
                Template2.DocumentParserClass = documentParserTypeName;
                Template2.DocumentParserType = documentParserType;
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
                DebugForm<Template2T, DocumentParserT> debugForm = FormManager.Get<DebugForm<Template2T, DocumentParserT>>(template2Row);
                if (debugForm != null)
                    debugForm.Activate();
                else
                {
                    debugForm = templateListControl.NewDebugForm(template2Row);
                    FormManager.Set<DebugForm<Template2T, DocumentParserT>>(template2Row, debugForm);
                    debugForm.Show();
                }
                debugForm.Template2 = Template2;
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            templateListControl.EditTemplate(template2Row);
        }
    }
}

