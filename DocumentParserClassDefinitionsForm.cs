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
                    if (documentParserClasses.SelectedItem == null)
                        return;
                    DocumentParserClassItem documentParserClassItem = (DocumentParserClassItem)documentParserClasses.SelectedItem;
                    SelectedDocumentParserClassIsDefault.Checked = documentParserClassItem.Class == defaultDocumentParserClass;
                    List<Template2T> template2s = templateListControl.GetTemplatesFromGui();
                    templatesUsingSelectedDocumentParserClass.DataSource = documentParserClassItem.Class != defaultDocumentParserClass ?
                        template2s.Where(a => a.DocumentParserClass == documentParserClassItem.Class).Select(a => a.Name).ToList() :
                        template2s.Where(a => string.IsNullOrWhiteSpace(a.DocumentParserClass) || a.DocumentParserClass == documentParserClassItem.Class).Select(a => a.Name).ToList();
                    Match m = Regex.Match(DocumentParserClassDefinitions.Text, @"^.*?\s?class\s+" + Regex.Escape(documentParserClassItem.Class) + @"(\s.*)?$", RegexOptions.Multiline);
                    if (!m.Success)
                        throw new Exception2("There is no class '" + documentParserClassItem.Class + "'.");
                    var p = DocumentParserClassDefinitions.Document.OffsetToPosition(m.Index);
                    DocumentParserClassDefinitions.ActiveTextAreaControl.ScrollTo(p.Line, p.Column);
                }
                catch (Exception e)
                {
                    Message.Error(e);
                }
            };

            bSelectedTemplateEdit.Click += delegate
            {
                if (templatesUsingSelectedDocumentParserClass.SelectedValue == null)
                    return;
                templateListControl.EditTemplate((string)templatesUsingSelectedDocumentParserClass.SelectedValue);
            };

            bSelectedTemplateEdit2.Click += delegate
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
                if (documentParserClasses.SelectedItem == null)
                {
                    SelectedDocumentParserClassIsDefault.Checked = false;
                    return;
                }
                defaultDocumentParserClass = SelectedDocumentParserClassIsDefault.Checked ? ((DocumentParserClassItem)documentParserClasses.SelectedItem).Class : null;
            };

            //documentParserClasses.DrawMode = DrawMode.OwnerDrawFixed;//!!!turn this on to paint items with colors
            //documentParserClasses.BackColor = SystemColors.ControlLight;
            documentParserClasses.DrawItem += delegate (object sender, DrawItemEventArgs e)//!!!could not paint the edit box area properly
            {
                if (e.Index < 0)
                    return;
                //e.DrawBackground();
                DocumentParserClassItem item = (DocumentParserClassItem)documentParserClasses.Items[e.Index];
                Color c;
                if (e.State.HasFlag(DrawItemState.ComboBoxEdit)/*|| e.State.HasFlag(DrawItemState.NoFocusRect)*/)
                {
                    c = documentParserClasses.BackColor; 
                    //e.DrawBackground();
                    //using (var brush = new SolidBrush(item.FontColor))
                    //{
                    //    e.Graphics.DrawString(item.Class, e.Font, brush, e.Bounds);
                    //}
                    //e.DrawFocusRectangle();
                    //return;
                }
                else if (e.State.HasFlag(DrawItemState.Focus) || e.State.HasFlag(DrawItemState.HotLight) || e.State.HasFlag(DrawItemState.Selected))
                    c = e.BackColor;
                else
                    c = item.Color;
                //using (var pen = new Pen(c))
                //{
                //    e.Graphics.DrawRectangle(pen, e.Bounds);
                //}
                using (var brush = new SolidBrush(c))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
                using (var brush = new SolidBrush(item.FontColor))
                {
                    e.Graphics.DrawString(item.Class, e.Font, brush, e.Bounds);
                }
                e.DrawFocusRectangle();
            };
        }
        TemplateListControl<Template2T, DocumentParserT> templateListControl;

        void load_settings()
        {
            DocumentParserClassDefinitions.Text = templateListControl.TemplateInfo.DocumentParserClassDefinitions;
            DocumentParserClassDefinitions.SetHighlighting("C#");

            defaultDocumentParserClass = templateListControl.TemplateInfo.DefaultDocumentParserClass;

            validate();
            if (documentParserClasses.SelectedIndex < 0 && documentParserClasses.Items.Count > 0)
                documentParserClasses.SelectedIndex = 0;
        }

        void markClasses(out Dictionary<string, DocumentParserClassItem> documentParserClassNames2Item)
        {
            documentParserClassNames2Item = new Dictionary<string, DocumentParserClassItem>();
            DocumentParserClassDefinitions.Document.MarkerStrategy.RemoveAll(a => true);
            List<string> templateDocumentParserClassNames = templateListControl.GetTemplatesFromGui().Where(a => a.DocumentParserClass != templateListControl.TemplateInfo.DefaultDocumentParserClass).Select(a => a.DocumentParserClass).ToList();
            for (Match m = Regex.Match(DocumentParserClassDefinitions.Text, @"^.*?\s?class\s+(?'Class'\w+).*?$", RegexOptions.Multiline); m.Success; m = m.NextMatch())
            {
                Color c;
                string documentParserClass = m.Groups["Class"].Value;
                if (documentParserClass == templateListControl.TemplateInfo.DefaultDocumentParserClass)
                    c = defaultClassColor;
                else if (templateDocumentParserClassNames.Contains(documentParserClass))
                    c = usedClassColor;
                else
                    c = notUsedClassColor;
                ICSharpCode.TextEditor.Document.TextMarker marker = new ICSharpCode.TextEditor.Document.TextMarker(m.Index, m.Length, ICSharpCode.TextEditor.Document.TextMarkerType.SolidBlock, c);
                DocumentParserClassDefinitions.Document.MarkerStrategy.AddMarker(marker);
                documentParserClassNames2Item[documentParserClass] = new DocumentParserClassItem { Class = documentParserClass, Color = c };
            }
            DocumentParserClassDefinitions.Refresh();
        }

        readonly Color defaultClassColor = Color.Gold;
        readonly Color usedClassColor = Color.Cyan;
        readonly Color notUsedClassColor = Color.Gray;

        string defaultDocumentParserClass;
        List<Type> documentParserTypes = new List<Type>();

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

                markClasses(out Dictionary<string, DocumentParserClassItem> documentParserClassNames2Item);

                string selectedClass0 = ((DocumentParserClassItem)documentParserClasses.SelectedItem)?.Class;
                documentParserClasses.DisplayMember = "Class";
                documentParserClasses.ValueMember = "Color";
                documentParserClasses.DataSource = documentParserTypes.Select(a => documentParserClassNames2Item[a.Name]).ToList();
                if (selectedClass0 != null && documentParserClassNames2Item.TryGetValue(selectedClass0, out DocumentParserClassItem selectedDocumentParserClassItem))
                    documentParserClasses.SelectedItem = selectedDocumentParserClassItem;

                if (!documentParserTypes.Exists(a => a.Name == defaultDocumentParserClass))
                    defaultDocumentParserClass = null;
                else
                {
                    if (documentParserClasses.SelectedValue != null)
                        SelectedDocumentParserClassIsDefault.Checked = defaultDocumentParserClass == ((DocumentParserClassItem)documentParserClasses.SelectedItem).Class;
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

        //public class ComboBoxE : System.Windows.Forms.ComboBox
        //{
        //    public ComboBoxE()
        //    {
        //        DropDownStyle = ComboBoxStyle.DropDownList;
        //        //DrawMode = DrawMode.OwnerDrawFixed;//!!!turn this on to paint items with colors
        //        BackColor = SystemColors.Control;//!!!not the right color
        //    }

        //    protected override void OnDrawItem(DrawItemEventArgs e)
        //    {
        //        //e.DrawBackground();
        //        DocumentParserClassItem item = (DocumentParserClassItem)Items[e.Index];
        //        Color c;
        //        if (e.State.HasFlag(DrawItemState.ComboBoxEdit)/*|| e.State.HasFlag(DrawItemState.NoFocusRect)*/)
        //            c = BackColor;
        //        else if (e.State.HasFlag(DrawItemState.Focus) || e.State.HasFlag(DrawItemState.HotLight) || e.State.HasFlag(DrawItemState.Selected))
        //            c = e.BackColor;
        //        else
        //            c = item.Color;
        //        using (var brush = new SolidBrush(c))
        //        {
        //            e.Graphics.FillRectangle(brush, e.Bounds);
        //        }
        //        using (var brush = new SolidBrush(item.FontColor))
        //        {
        //            e.Graphics.DrawString(item.Class, e.Font, brush, e.Bounds);
        //        }
        //        e.DrawFocusRectangle();
        //        //base.OnDrawItem(e);
        //    }
        //}

        public class DocumentParserClassItem
        {
            public string Class { get; set; }
            //public DocumentParserClassItemValue Value;
            public Color Color { get; set; }
            public Color FontColor { get; set; } = SystemColors.ControlText;
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
