//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Cliver.PdfDocumentParser;
using System.Text.RegularExpressions;

namespace Cliver.PdfDocumentParserTemplateList
{
    public class DocumentParser : ADocumentParser
    {
        public virtual FieldValues GetFieldsFromDocument(PageCollection pages, int documentFirstPageI)
        {
            pages.ActiveTemplate = Template2.Template;
            //if (!pages[documentFirstPageI].IsCondition(Template2.ConditionNames.DocumentFirstPage))
            //    return null;

            //if (pages[documentFirstPageI].IsCondition(Template2.ConditionNames.NeedManualEntry))
            //    return new FieldValues { Template2 = Template2, NeedManualEntry = true, Records = null };

            //if (!pages[documentFirstPageI].IsCondition(Template2.ConditionNames.QuotationDocument))
            //    return new FieldValues { Template2 = Template2, QuotationDocument = false, Records = null };

            FieldValues fieldValues = new FieldValues { Template2 = Template2 };
            int i = documentFirstPageI;
            for (; i <= pages.TotalCount; i++)
            {
                Page p = pages[i];
                appendFields(p, fieldValues);
            }
            return fieldValues;
        }

        protected virtual void appendFields(Page page, FieldValues fieldValues)
        {
            //List<string> items = page.GetTextLines(Template2.FieldNames.ITEM);
            //if (items == null)
            //    return;
            //List<string> itemFirstLineValues = page.GetTextLines(Template2.FieldNames.ItemFirstLineValue);
            //List<string> items2 = new List<string>();

            //for (int i = 0; i < items.Count; i++)
            //{
            //    if (!string.IsNullOrWhiteSpace(itemFirstLineValues[i]))
            //        items2.Add(items[i]);
            //    else if (items2.Count > 0)
            //        items2[items2.Count - 1] += " " + items[i];
            //}

            //fieldValues.AppendPageRecords(page.Number, items2);
        }

        public virtual void PrepareRecords(FieldValues fieldValues)
        {
            for (int i = fieldValues.Records.Count - 1; i >= 0; i--)
            {
                Record r = fieldValues.Records[i];
                r.Item = clear(r.Item);
                if (string.IsNullOrWhiteSpace(r.Item))
                    fieldValues.Records.RemoveAt(i);
            }
        }
        protected virtual string clear(string s)
        {
            return s == null ? "" : Page.NormalizeText(Regex.Replace(s, @"[_\t\|]", ""));
        }
    }

    public class Record
    {
        public int PageI;
        public string Item;
    }

    public class FieldValues
    {
        public List<Record> Records = new List<Record>();
        public Template2 Template2;
        public bool QuotationDocument = true;
        public bool NeedManualEntry = false;

        public void AppendPageRecords(int pageI, List<string> items)
        {
            if (items == null)
                return;
            for (int i = 0; i < items.Count; i++)
                Records.Add(new Record { PageI = pageI, Item = items[i] });
        }
    }

    public abstract class ADocumentParser
    {
        internal protected Template2 Template2 { get; set; }

        public static Type CompileDocumentParserType(string documentParserClassDefinition)
        {
            Type[] ts = PdfDocumentParser.Compiler.Compile(documentParserClassDefinition);
            if (ts.Length < 1)//to allow commented code string
                return null;
            Type t = PdfDocumentParser.Compiler.FindSubTypes(typeof(DocumentParser), ts).FirstOrDefault();
            if (t == null)
                throw new Exception("No sub-type of '" + typeof(DocumentParser).Name + "' was found in the hot-compiled type definition.");
            return t;
        }

        public static DocumentParser CreateDocumentParser(Template2 template2)
        {
            Log.Inform("Compiling '" + template2.Template.Name + "' DocumentParser...");
            Type documentParserType = CompileDocumentParserType(template2.DocumentParserClassDefinition);
            if (documentParserType == null)//allow commented code string
                return null;
            return (DocumentParser)Activator.CreateInstance(documentParserType);
        }

        public static List<Type> HardcodedDocumentParsers
        {
            get
            {
                if (hardcodedDocumentParsers == null)
                    hardcodedDocumentParsers = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(DocumentParser)).ToList();
                return hardcodedDocumentParsers;
            }
        }
        static List<Type> hardcodedDocumentParsers = null;
    }
}