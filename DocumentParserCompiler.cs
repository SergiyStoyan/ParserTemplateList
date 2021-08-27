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

namespace Cliver.ParserTemplateList
{
    public class DocumentParserCompiler<DocumentParserT> where DocumentParserT : class
    {
        public Type Compile(string documentParserClassDefinition)
        {
            Type[] ts = PdfDocumentParser.Compiler.Compile(documentParserClassDefinition);
            if (ts.Length < 1)//to allow commented code string
                return null;
            Type t = PdfDocumentParser.Compiler.FindSubTypes(typeof(DocumentParserT), ts).FirstOrDefault();
            if (t == null)
                throw new Exception("No sub-type of '" + typeof(DocumentParserT).Name + "' was found in the hot-compiled type definition.");
            return t;
        }

        public DocumentParserT Create(Template2 template2)
        {
            Log.Inform("Compiling '" + template2.Template.Name + "' DocumentParser...");
            Type documentParserType = Compile(template2.DocumentParserClassDefinition);
            if (documentParserType == null)//allow commented code string
                return null;
            return (DocumentParserT)Activator.CreateInstance(documentParserType);
        }

        public List<Type> HardcodedDocumentParsers
        {
            get
            {
                if (hardcodedDocumentParsers == null)
                    hardcodedDocumentParsers = Assembly.GetCallingAssembly().GetTypes().Where(t => t.BaseType == typeof(DocumentParserT)).ToList();
                return hardcodedDocumentParsers;
            }
        }
        List<Type> hardcodedDocumentParsers = null;
    }
}