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

namespace Cliver.ParserTemplateList
{
    public partial class DocumentParserClassDefinitionsForm<Template2T, DocumentParserT> : Form where Template2T : Template2<DocumentParserT> where DocumentParserT : class
    {
        public DocumentParserClassDefinitionsForm(TemplateListControl<Template2T, DocumentParserT> templateListControl)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
            Text = Application.ProductName + ": Document Parser Class Definitions";

            this.templateListControl = templateListControl;
            load_settings();
        }
        TemplateListControl<Template2T, DocumentParserT> templateListControl;

        void load_settings()
        {
            DocumentParserClassDefinitions.Text = templateListControl.TemplateInfo.DocumentParserClassDefinitions;
            DocumentParserClassDefinitions.SetHighlighting("C#");
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (templateListControl.TemplateInfo.DocumentParserClassDefinitions != DocumentParserClassDefinitions.Text)
                {
                    if (!string.IsNullOrWhiteSpace(DocumentParserClassDefinitions.Text))
                    {
                        DocumentParserClassDefinitions.Document.MarkerStrategy.RemoveAll(marker => true);
                        try
                        {
                            List<Type> commonDocumentParserTypes2 = templateListControl.Compiler.CompileMultipleTypes(DocumentParserClassDefinitions.Text);
                            List<string> documentParserClassNames2 = commonDocumentParserTypes2.Select(a => a.Name).ToList();
                            List<string> ns = templateListControl.TemplateInfo.Template2s.Where(a => !string.IsNullOrWhiteSpace(a.DocumentParserClass)).Select(a => a.DocumentParserClass).Distinct().Except(templateListControl.Compiler.HardcodedDocumentParserTypes.Select(a => a.Name)).Except(documentParserClassNames2).ToList();
                            if (ns.Count > 0)
                                throw new Exception2("The following templates link not defined parsers:" +
                                    string.Join("\r\n", templateListControl.TemplateInfo.Template2s.Where(a => ns.Contains(a.DocumentParserClass)).Select(a => a.Name + " => " + a.DocumentParserClass))
                                    );
                            templateListControl.TemplateInfo.DocumentParserClassNames = documentParserClassNames2;
                            templateListControl.Compiler.CommonDocumentParserTypes = commonDocumentParserTypes2;
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
                    else
                        templateListControl.TemplateInfo.DocumentParserClassNames.Clear();

                    templateListControl.TemplateInfo.DocumentParserClassDefinitions = DocumentParserClassDefinitions.Text;
                    templateListControl.TemplateInfo.Touch();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Message.Error2(ex, this);
            }
        }
    }
}
