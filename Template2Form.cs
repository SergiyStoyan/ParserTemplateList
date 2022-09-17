//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        sergey.stoyan@hotmail.com
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
        public Template2Form(DataGridViewRow r, TemplateListControl<Template2T, DocumentParserT> templateListControl)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
            Template2T template2 = (Template2T)r.Tag;
            Text = Application.ProductName + ": additional properties of '" + template2.Name + "'";

            FormClosed += delegate
            {
                if (debugForm != null && !debugForm.IsDisposed)
                    debugForm.Close();
            };

            this.templateListControl = templateListControl;
            this.template2Row = r;

            Template2 = template2.CreateCloneByJson();
            Active.Checked = template2.Active;
            Group.Text = template2.Group;
            Comment.Text = template2.Comment;
            OrderWeight.Value = (decimal)template2.OrderWeight;
            //Company.Text = t.Company;
            DocumentParserClassDefinition.Text = template2.DocumentParserClassDefinition;
            DocumentParserClassDefinition.SetHighlighting("C#");

            DocumentParserClass.DisplayMember = "Key";
            DocumentParserClass.ValueMember = "Value";
            var ds = templateListControl.Compiler.HardcodedDocumentParserTypes.Select(a => new { Key = a.Name, Value = a.Name }).ToList();
            //ds.AddRange(templateListControl.Compiler.CommonDocumentParserTypes.Select(a => new { Key = a.Name, Value = a.Name }));
            ds.AddRange(templateListControl.TemplateInfo.DocumentParserClassNames.Select(a => new { Key = a, Value = a }));
            List<Template2T> template2s = templateListControl.GetTemplatesFromGui().Where(a => a.Name != template2.Name).ToList();
            ds.AddRange(template2s.Where(a => true == a.DocumentParserClass?.StartsWith("#")).Select(a => a.DocumentParserClass.Remove(0, 1)).Select(a => new { Key = a, Value = a }));
            ds.Insert(0, new { Key = "", Value = "" });
            DocumentParserClass.DataSource = ds;
            if (!string.IsNullOrWhiteSpace(template2.DocumentParserClass))
                DocumentParserClass.SelectedValue = template2.DocumentParserClass;

            TemplatesHavingThisDocumentParserClass.DisplayMember = "Key";
            TemplatesHavingThisDocumentParserClass.ValueMember = "Value";
            if (!string.IsNullOrWhiteSpace(template2.DocumentParserClass))
            {
                string documentParserClass = template2.DocumentParserClass?.TrimStart('#');
                ds = template2s.Where(a => a.DocumentParserClass == "#" + documentParserClass).Select(a => new { Key = ">>> " + a.Name, Value = a.Name }).ToList();
                ds.AddRange(template2s.Where(a => a.DocumentParserClass == documentParserClass).Select(a => new { Key = a.Name, Value = a.Name }));
                TemplatesHavingThisDocumentParserClass.DataSource = ds;
                TemplatesHavingThisDocumentParserClass.SelectedItem = TemplatesHavingThisDocumentParserClass.Items.Count > 0 ? TemplatesHavingThisDocumentParserClass.Items[0] : null;
            }
            bOpenTemplateHavingThisDocumentParserClass.Click += delegate
            {
                if (!string.IsNullOrWhiteSpace((string)TemplatesHavingThisDocumentParserClass.SelectedValue))
                    templateListControl.Edit2Template((string)TemplatesHavingThisDocumentParserClass.SelectedValue);
            };
        }
        TemplateListControl<Template2T, DocumentParserT> templateListControl;
        DataGridViewRow template2Row;

        virtual public Template2T Template2
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
        Template2T template2;

        virtual protected bool setTemplate2()
        {
            try
            {
                Type documentParserType = null;
                string documentParserTypeName = null;
                List<Template2T> template2s = null;
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
                            if (template2s == null)
                                template2s = templateListControl.GetTemplatesFromGui();
                            Template2T t = template2s.Find(a => a.Name != template2.Name && a.DocumentParserClass == documentParserTypeName);
                            if (t != null)
                                throw new Exception("Template '" + t.Name + "' already defines class '" + documentParserType.Name + "'.");
                            if (null != templateListControl.TemplateInfo.DocumentParserClassNames.Find(a => a == documentParserType.Name))
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
                    if (template2s == null)
                        template2s = templateListControl.GetTemplatesFromGui();
                    if (template2s.Find(a => a.DocumentParserClass == "#" + documentParserTypeName) == null
                        && templateListControl.Compiler.HardcodedDocumentParserTypes.Find(a => a.Name == documentParserTypeName) == null
                        && templateListControl.Compiler.CommonDocumentParserTypes.Find(a => a.Name == documentParserTypeName) == null
                        )
                        throw new Exception("Class '" + DocumentParserClass.Text + "' is not defined as neither hardcoded nor hot-compiled.");
                }
                if (Template2.DocumentParserClass?.StartsWith("#") == true && Template2.DocumentParserClass != documentParserTypeName)
                {
                    string documentParserClass0 = Template2.DocumentParserClass.TrimStart('#');
                    if (template2s == null)
                        template2s = templateListControl.GetTemplatesFromGui();
                    if (template2s.Where(a => a.DocumentParserClass == documentParserClass0).Any())
                        throw new Exception2("Document parser class name cannot be changed because it is used by other templates.");
                }

                //if (string.IsNullOrWhiteSpace(Company.Text))
                //    throw new Exception2("Company cannot be empty");

                Template2.Active = Active.Checked;
                Template2.Group = Group.Text;
                Template2.Comment = Comment.Text;
                Template2.OrderWeight = (float)OrderWeight.Value;
                //template2.Company = Company.Text;
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
                //if (debugForm == null || debugForm.IsDisposed)
                //    debugForm = templateListControl.NewDebugForm();
                //debugForm.Template2 = Template2;
                //debugForm.Show();
                //debugForm.BringToFront();

                DebugForm<Template2T, DocumentParserT> debugForm = FormManager.Get<DebugForm<Template2T, DocumentParserT>>(template2Row);
                if (debugForm != null)
                    debugForm.Activate();
                else
                {
                    debugForm = templateListControl.NewDebugForm();
                    FormManager.Set<DebugForm<Template2T, DocumentParserT>>(template2Row, debugForm);
                    debugForm.Show();
                }
                debugForm.Template2 = Template2;
            }
        }
        protected DebugForm<Template2T, DocumentParserT> debugForm = null;
    }
}

