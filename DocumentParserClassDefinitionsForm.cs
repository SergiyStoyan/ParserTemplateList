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

            Load += delegate
            {
                load_settings();
            };
        }
        TemplateListControl<Template2T, DocumentParserT> templateListControl;

        void load_settings()
        {
            DocumentParserClassDefinitions.Text = templateListControl.TemplateInfo.DocumentParserClassDefinitions;
            DocumentParserClassDefinitions.SetHighlighting("C#");
            markUnusedClasses();
        }

        void markUnusedClasses()
        {
            List<string> ns = templateListControl.TemplateInfo.DocumentParserClassNames.Except(templateListControl.GetTemplatesFromGui().Select(a => a.DocumentParserClass).Distinct()).ToList();
            //if (ns.Count > 0)
            //    throw new Exception2("The following document parser classes are not used:\r\n" + string.Join("\r\n", ns));
            foreach (string n in ns)
            {
                for (Match m = Regex.Match(DocumentParserClassDefinitions.Text, @"^.*?\sclass\s+" + Regex.Escape(n) + ".*?$", RegexOptions.Multiline); m.Success; m = m.NextMatch())
                {
                    ICSharpCode.TextEditor.Document.TextMarker marker = new ICSharpCode.TextEditor.Document.TextMarker(m.Index, m.Length, ICSharpCode.TextEditor.Document.TextMarkerType.SolidBlock, System.Drawing.Color.Cyan);
                    DocumentParserClassDefinitions.Document.MarkerStrategy.AddMarker(marker);
                }
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private bool save()
        {
            List<Type> commonDocumentParserTypes = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(DocumentParserClassDefinitions.Text))
                {
                    DocumentParserClassDefinitions.Document.MarkerStrategy.RemoveAll(marker => true);
                    try
                    {
                        List<Template2T> template2s = templateListControl.GetTemplatesFromGui();
                        commonDocumentParserTypes = templateListControl.Compiler.CompileMultipleTypes(DocumentParserClassDefinitions.Text);
                        List<string> ns = template2s.Where(a => !string.IsNullOrWhiteSpace(a.DocumentParserClass) && !a.DocumentParserClass.StartsWith("#")).Select(a => a.DocumentParserClass).Distinct()
                            .Except(templateListControl.Compiler.HardcodedDocumentParserTypes.Select(a => a.Name))
                            .Except(commonDocumentParserTypes.Select(a => a.Name).ToList())
                            .Except(template2s.Where(a => a.DocumentParserClass?.StartsWith("#") == true).Select(a => a.DocumentParserClass.TrimStart('#')))
                            .ToList();
                        if (ns.Count > 0)
                            throw new Exception2("The following templates would link not defined parsers:\r\n" +
                                string.Join("\r\n", templateListControl.TemplateInfo.Template2s.Where(a => ns.Contains(a.DocumentParserClass)).Select(a => a.Name + " => " + a.DocumentParserClass))
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
                markUnusedClasses();

                templateListControl.TemplateInfo.DocumentParserClassNames = commonDocumentParserTypes.Select(a => a.Name).ToList();
                templateListControl.Compiler.CommonDocumentParserTypes = commonDocumentParserTypes;
                templateListControl.TemplateInfo.DocumentParserClassDefinitions = DocumentParserClassDefinitions.Text;
                templateListControl.TemplateInfo.Touch();
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
            if (!save())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
