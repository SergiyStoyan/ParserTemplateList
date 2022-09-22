//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Cliver.PdfDocumentParser;
using System.Collections.Generic;
using System.Drawing;

namespace Cliver.ParserTemplateList
{
    /*TBD
    - do class names of individual template parsers need to be stored? - now they are only used to make sure that they are unique which is not a necessity.
    - when class name is selected in the dropbox, the compiler editor must be scrolled to have it in the top; 
     
     
     */
    public partial class DocumentParserClassDefinitionsForm<Template2T, DocumentParserT> : Form where Template2T : Template2<DocumentParserT> where DocumentParserT : class
    {
        public DocumentParserClassDefinitionsForm(TemplateListControl<Template2T, DocumentParserT> templateListControl)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
            Text = Application.ProductName + ": Document Parser Class Definitions";

            this.templateListControl = templateListControl;

            Load += delegate
            {
                load_settings();
            };

            documentParserClasses.SelectedIndexChanged += delegate
            {
                try
                {
                    string documentParserClass = (string)documentParserClasses.SelectedValue;
                    if (documentParserClass == null)
                        return;
                    SelectedDocumentParserClassIsDefault.Checked = documentParserClass == defaultDocumentParserClass;
                    List<Template2T> template2s = templateListControl.GetTemplatesFromGui();
                    templatesUsingSelectedDocumentParserClass.DataSource = documentParserClass != defaultDocumentParserClass ?
                        template2s.Where(a => a.DocumentParserClass == documentParserClass).Select(a => a.Name).ToList() :
                        template2s.Where(a => string.IsNullOrWhiteSpace(a.DocumentParserClass) || a.DocumentParserClass == documentParserClass).Select(a => a.Name).ToList();
                    Match m = Regex.Match(DocumentParserClassDefinitions.Text, @"^.*?\s?class\s+" + Regex.Escape(documentParserClass) + @"(\s.*)?$", RegexOptions.Multiline);
                    if (!m.Success)
                        throw new Exception2("There is no class '" + documentParserClass + "'.");
                    var p = DocumentParserClassDefinitions.Document.OffsetToPosition(m.Index);
                    DocumentParserClassDefinitions.ActiveTextAreaControl.ScrollTo(p.Line, p.Column);
                }
                catch (Exception e)
                {
                    Message.Error(e);
                }
            };

            bOpenSelectedTemplate.Click += delegate
            {
                if (templatesUsingSelectedDocumentParserClass.SelectedValue == null)
                    return;
                templateListControl.Edit2Template((string)templatesUsingSelectedDocumentParserClass.SelectedValue);
            };

            bValidate.Click += delegate
            {
                validate();
            };

            SelectedDocumentParserClassIsDefault.Click += delegate
            {
                if (documentParserClasses.SelectedValue == null)
                {
                    SelectedDocumentParserClassIsDefault.Checked = false;
                    return;
                }
                defaultDocumentParserClass = SelectedDocumentParserClassIsDefault.Checked ? (string)documentParserClasses.SelectedValue : null;
            };
        }
        TemplateListControl<Template2T, DocumentParserT> templateListControl;

        void load_settings()
        {
            DocumentParserClassDefinitions.Text = templateListControl.TemplateInfo.DocumentParserClassDefinitions;
            DocumentParserClassDefinitions.SetHighlighting("C#");

            defaultDocumentParserClass = templateListControl.TemplateInfo.DefaultDocumentParserClass;

            validate();
        }

        void markClasses()
        {
            DocumentParserClassDefinitions.Document.MarkerStrategy.RemoveAll(a => true);
            List<string> templateDocumentParserClassNames = templateListControl.GetTemplatesFromGui().Where(a => a.DocumentParserClass != templateListControl.TemplateInfo.DefaultDocumentParserClass).Select(a => a.DocumentParserClass).ToList();
            for (Match m = Regex.Match(DocumentParserClassDefinitions.Text, @"^.*?\s?class\s+(?'Class'\w+).*?$", RegexOptions.Multiline); m.Success; m = m.NextMatch())
            {
                Color c;
                string documentParserClass = m.Groups["Class"].Value;
                if (documentParserClass == templateListControl.TemplateInfo.DefaultDocumentParserClass)
                    c = Color.Gold;
                else if (templateDocumentParserClassNames.Contains(documentParserClass))
                    c = Color.Cyan;
                else
                    c = Color.Gray;
                ICSharpCode.TextEditor.Document.TextMarker marker = new ICSharpCode.TextEditor.Document.TextMarker(m.Index, m.Length, ICSharpCode.TextEditor.Document.TextMarkerType.SolidBlock, c);
                DocumentParserClassDefinitions.Document.MarkerStrategy.AddMarker(marker);
            }
            DocumentParserClassDefinitions.Refresh();
        }

        string defaultDocumentParserClass;
        List<Type> documentParserTypes;

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private bool validate()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(DocumentParserClassDefinitions.Text))
                {
                    DocumentParserClassDefinitions.Document.MarkerStrategy.RemoveAll(marker => true);
                    try
                    {
                        List<Template2T> template2s = templateListControl.GetTemplatesFromGui();
                        documentParserTypes = templateListControl.Compiler.CompileMultipleTypes(DocumentParserClassDefinitions.Text);
                        List<string> ns = template2s.Where(a => !string.IsNullOrWhiteSpace(a.DocumentParserClass) && !a.DocumentParserClass.StartsWith("#")).Select(a => a.DocumentParserClass).Distinct()
                            .Except(templateListControl.Compiler.HardcodedDocumentParserTypes.Select(a => a.Name))
                            .Except(documentParserTypes.Select(a => a.Name).ToList())
                            .Except(template2s.Where(a => a.DocumentParserClass?.StartsWith("#") == true).Select(a => a.DocumentParserClass.TrimStart('#')))
                            .ToList();
                        if (ns.Count > 0)
                            throw new Exception2("The following templates would link not defined parsers:\r\n" +
                                string.Join("\r\n", template2s.Where(a => ns.Contains(a.DocumentParserClass)).Select(a => a.Name + " => " + a.DocumentParserClass))
                                );
                    }
                    catch (PdfDocumentParser.Compiler.Exception ex)
                    {
                        foreach (PdfDocumentParser.Compiler.Error ce in ex.Data.Values)
                        {
                            ICSharpCode.TextEditor.Document.TextMarker tm = new ICSharpCode.TextEditor.Document.TextMarker(ce.P1, ce.P2 - ce.P1, ICSharpCode.TextEditor.Document.TextMarkerType.WaveLine, System.Drawing.Color.Red);
                            tm.ToolTip = ce.Message;
                            DocumentParserClassDefinitions.Document.MarkerStrategy.AddMarker(tm);
                        }
                        throw;
                    }
                }

                markClasses();

                string selectedClass = (string)documentParserClasses.SelectedValue;
                documentParserClasses.DisplayMember = "Key";
                documentParserClasses.ValueMember = "Value";
                documentParserClasses.DataSource = documentParserTypes.Select(a => new { Key = a.Name, Value = a.Name }).ToList();
                if (selectedClass != null)
                    documentParserClasses.SelectedValue = selectedClass;
                else if (documentParserClasses.Items.Count > 0)
                    documentParserClasses.SelectedIndex = 0;

                if (!documentParserTypes.Exists(a => a.Name == defaultDocumentParserClass))
                    defaultDocumentParserClass = null;
                else
                {
                    if (documentParserClasses.SelectedValue != null)
                        SelectedDocumentParserClassIsDefault.Checked = defaultDocumentParserClass == (string)documentParserClasses.SelectedValue;
                    else
                        SelectedDocumentParserClassIsDefault.Checked = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Message.Error2(ex, this);
                return false;
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (!validate())
                return;

            if (string.IsNullOrWhiteSpace(defaultDocumentParserClass) && !Message.YesNo("No default document parser class is set! Proceed?", this, Message.Icons.Warning))
                return;

            //templateListControl.TemplateInfo.DocumentParserClassNames = documentParserTypes.Select(a => a.Name).ToList();
            templateListControl.Compiler.CommonDocumentParserTypes = documentParserTypes;
            templateListControl.Compiler.DefaultCommonDocumentParserName = defaultDocumentParserClass;
            templateListControl.TemplateInfo.DocumentParserClassDefinitions = DocumentParserClassDefinitions.Text;
            templateListControl.TemplateInfo.DefaultDocumentParserClass = defaultDocumentParserClass;
            templateListControl.TemplateInfo.Touch();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
