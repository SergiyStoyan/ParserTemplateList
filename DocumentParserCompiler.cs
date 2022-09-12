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
using System.Text.RegularExpressions;
using Cliver.PdfDocumentParser;

namespace Cliver.ParserTemplateList
{
    public class DocumentParserCompiler<Template2T, DocumentParserT> where Template2T : Template2 where DocumentParserT : class
    {
        public DocumentParserCompiler(Assembly hardcodedDocumentParsersAssembly, TemplateListControl<Template2T, DocumentParserT> templateListControl)
        {
            this.hardcodedDocumentParsersAssembly = hardcodedDocumentParsersAssembly;
            this.templateListControl = templateListControl;
        }
        TemplateListControl<Template2T, DocumentParserT> templateListControl;
        Assembly hardcodedDocumentParsersAssembly;

        public List<Type> CompileMultipleTypes(string documentParserClassDefinitions)
        {
            Type[] ts = Compiler.Compile(documentParserClassDefinitions, Assembly.GetEntryAssembly());
            Type t = Compiler.FindSubTypes(typeof(DocumentParserT), ts).FirstOrDefault();
            if (t == null)
                throw new Exception("No sub-type of '" + typeof(DocumentParserT).Name + "' was found in the hot-compiled type definition.");
            return ts.ToList();
        }

        public Type CompileSingleType(string documentParserClassDefinition)
        {
            Type[] ts = Compiler.Compile(documentParserClassDefinition, Assembly.GetEntryAssembly());
            if (ts.Length < 1)//to allow commented code string
                return null;
            Type t = Compiler.FindSubTypes(typeof(DocumentParserT), ts).FirstOrDefault();
            if (t == null)
                throw new Exception("No sub-type of '" + typeof(DocumentParserT).Name + "' was found in the hot-compiled type definition.");
            return t;
        }

        public DocumentParserT CreateSingleParser(Template2 template2)
        {
            Log.Inform("Compiling '" + template2.Template.Name + "' DocumentParser...");
            Type documentParserType = CompileSingleType(template2.DocumentParserClassDefinition);
            if (documentParserType == null)//allow commented code string
                return null;
            return (DocumentParserT)Activator.CreateInstance(documentParserType);
        }

        public List<Type> HardcodedDocumentParsers
        {
            get
            {
                if (hardcodedDocumentParsers == null)
                    hardcodedDocumentParsers = hardcodedDocumentParsersAssembly.GetTypes().Where(t => t.BaseType == typeof(DocumentParserT)).ToList();
                return hardcodedDocumentParsers;
            }
        }
        List<Type> hardcodedDocumentParsers = null;

        public List<Type> CommonDocumentParsers
        {
            get
            {
                if (commonDocumentParsers == null)
                    commonDocumentParsers = CompileMultipleTypes(templateListControl.TemplateInfo.DocumentParserClassDefinitions);
                return commonDocumentParsers;
            }
            set
            {
                commonDocumentParsers = value;
            }
        }
        List<Type> commonDocumentParsers = null;
    }
}