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
    }
}