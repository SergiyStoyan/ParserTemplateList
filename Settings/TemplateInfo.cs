//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using Cliver.PdfDocumentParser;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Cliver.PdfDocumentParserTemplateList
{
    public partial class Settings
    {
        [SettingsAttributes.Indented(false)]
        public static readonly TemplateInfoSettings TemplateInfo;
    }

    [SettingsAttributes.TypeVersion(210601)]
    public class TemplateInfoSettings : Cliver.UserSettings
    {
        public List<Template2> Template2s = new List<Template2>();
        public List<string> OrderedOutputFieldNames = new List<string>();

        override protected UnsupportedTypeVersionHandlerCommand UnsupportedTypeVersionHandler()
        {
            throw new Exception("Unsupported version of " + GetType().FullName + ": " + __TypeVersion);
        }

        protected override void Loaded()
        {
            //IsTypeVersionSupported(210601, 210601);
        }

        protected void setDocumentParserClasses(Type documentParserBaseType)
        {
            Dictionary<string, Type> documentParserClasses2documentParserType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == documentParserBaseType).ToDictionary(t => t.Name, t => t);
        }

        protected override void Saving()
        {
            Template2s.RemoveAll(x => string.IsNullOrWhiteSpace(x.Template.Name));
        }

        //public void SaveIfTouched()
        //{
        //    if (!touched)
        //        return;
        //    Save();
        //}

        public void Touch()
        {
            if (touched)
                return;
            touched = true;
            TouchedChanged?.BeginInvoke(null, null);
        }
        bool touched = false;
        public bool IsTouched()
        {
            return touched;
        }
        public delegate void OnTouchedChanged();
        static public event OnTouchedChanged TouchedChanged;

        protected override void Saved()
        {
            if (!touched)
                return;
            touched = false;
            TouchedChanged?.BeginInvoke(null, null);

            ClearParsers();
        }

        public void ClearParsers()
        {
            Template2s.ForEach(a => a.DocumentParser = null);
        }

        public Template2 CreateInitialTemplate()
        {
            return new Template2
            {
                FileFilterRegex = new Regex(@"\.pdf$", RegexOptions.IgnoreCase),
                Template = new Template
                {
                    Name = "",
                    PageRotation = PdfDocumentParser.Template.PageRotations.NONE,
                    Deskew = null,
                    Anchors = new List<Template.Anchor>(),
                    Conditions = new List<Template.Condition>
                    {
                        new Template.Condition { Name = Template2.ConditionNames.DocumentFirstPage },
                        new Template.Condition { Name = Template2.ConditionNames.QuotationDocument, Value="T" },
                        new Template.Condition { Name = Template2.ConditionNames.NeedManualEntry, Value="F" }
                    },
                    Fields = new List<Template.Field>
                    {
                        new Template.Field { DefaultValueType = Template.Field.ValueTypes.PdfText, Name = Template2.FieldNames.TABLE, Rectangle=new Template.RectangleF(0,0,10,10) },
                        new Template.Field { DefaultValueType = Template.Field.ValueTypes.PdfTextLines, Name = Template2.FieldNames.ITEM, ColumnOfTable = Template2.FieldNames.TABLE, Rectangle=new Template.RectangleF(0,0,10,10) },
                        new Template.Field { DefaultValueType = Template.Field.ValueTypes.PdfTextLines, Name = Template2.FieldNames.ItemFirstLineValue, ColumnOfTable = Template2.FieldNames.TABLE, Rectangle=new Template.RectangleF(0,0,10,10) },
                    },
                    Editor = new Template.EditorSettings
                    {
                        TestPictureScale = 1.2m,
                        TestFile = "",
                        CheckConditionsAutomaticallyWhenPageChanged = true,
                        ExtractFieldsAutomaticallyWhenPageChanged = true,
                    },
                },
            };
        }
    }
}