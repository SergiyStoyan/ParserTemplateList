//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Text.RegularExpressions;
using Cliver.PdfDocumentParser;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Cliver.PdfDocumentParserTemplateList
{
    public class Template2
    {
        [Newtonsoft.Json.JsonIgnore]
        internal DocumentParser DocumentParser
        {
            get
            {
                if (documentParser == null)
                {
                    if (!string.IsNullOrWhiteSpace(DocumentParserClass))
                    {
                        Type documentParserType = ADocumentParser.HardcodedDocumentParsers.FirstOrDefault(a => a.Name == DocumentParserClass);
                        if (documentParserType == null)
                            throw new Exception2("There is no hardcoded class '" + DocumentParserClass + "'");
                        documentParser = (DocumentParser)Activator.CreateInstance(documentParserType);
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(DocumentParserClassDefinition))
                            documentParser = ADocumentParser.CreateDocumentParser(this);
                        if (documentParser == null)//a non-empty definition can be a commented code string
                            documentParser = new DocumentParser();
                    }
                    documentParser.Template2 = this;
                }
                return documentParser;
            }
            set
            {
                if (value != null)
                    throw new Exception("Value can be only NULL");
                documentParser = value;
            }
        }
        DocumentParser documentParser = null;

        //public class ConditionNames
        //{
        //    public const string DocumentFirstPage = "FirstPageOfDocument";
        //    //public const string DocumentLastPage = "LastPageOfDocument";
        //    public const string QuotationDocument = "QuotationDocument";
        //    public const string NeedManualEntry = "NeedManualEntry";
        //}

        //public class FieldNames
        //{
        //    public const string TABLE = "TABLE";
        //    public const string ITEM = "ITEM";
        //    public const string ItemFirstLineValue = "ItemFirstLineValue";
        //}

        public Template2 Clone()
        {
            return Serialization.Json.Clone(this);
        }

        public Template Template;

        public bool Active = true;
        public string Group = "";
        public DateTime ModifiedTime;
        public string Comment = "";
        public float OrderWeight = 1f;
        public Regex FileFilterRegex = null;
        public string DocumentParserClass = "";
        public string DocumentParserClassDefinition = "";
        //public string Company;

        public string GetModifiedTimeAsString()
        {
            return ModifiedTime.ToString("yy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// !!!Company name is taken from the template name which must comply with the mnemonic rule: [name]([description])
        /// </summary>
        /// <returns></returns>
        public string Company()
        {
            return Regex.Replace(Template.Name, @"\(.*", "");
        }
    }
}