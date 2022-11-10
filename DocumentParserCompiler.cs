//********************************************************************************************
//Author: Sergiy Stoyan
//        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
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
    public class DocumentParserCompiler<DocumentParserT> where DocumentParserT : class
    {
        public DocumentParserCompiler(Assembly hardcodedDocumentParsersAssembly, string documentCommonParserClassDefinitions, string defaultCommonDocumentParserName)
        {
            this.hardcodedDocumentParsersAssembly = hardcodedDocumentParsersAssembly;
            this.documentCommonParserClassDefinitions = documentCommonParserClassDefinitions;
            DefaultCommonDocumentParserName = defaultCommonDocumentParserName;
        }
        string documentCommonParserClassDefinitions;
        Assembly hardcodedDocumentParsersAssembly;

        public List<Type> CompileMultipleTypes(string documentParserClassDefinitions)
        {
            System.Windows.Forms.Cursor cursor0 = System.Windows.Forms.Cursor.Current;
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                Type[] ts = Compiler.Compile(documentParserClassDefinitions, Assembly.GetEntryAssembly());
                Type t = Compiler.FindSubTypes(typeof(DocumentParserT), ts).FirstOrDefault();
                if (ts.Any() && t == null)
                    throw new Exception("No sub-type of '" + typeof(DocumentParserT).Name + "' was found in the hot-compiled type definition.");
                return ts.ToList();
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = cursor0;
            }
        }

        public Type CompileSingleType(string documentParserClassDefinition)
        {
            System.Windows.Forms.Cursor cursor0 = System.Windows.Forms.Cursor.Current;
            try
            {
                if (!compilerIsLoaded)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    compilerIsLoaded = true;
                }
                Type[] ts = Compiler.Compile(documentParserClassDefinition, Assembly.GetEntryAssembly());
                if (ts.Length < 1)//to allow commented code string
                    return null;
                Type t = Compiler.FindSubTypes(typeof(DocumentParserT), ts).FirstOrDefault();
                if (t == null)
                    throw new Exception("No sub-type of '" + typeof(DocumentParserT).Name + "' was found in the hot-compiled type definition.");
                return t;
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = cursor0;
            }
        }
        bool compilerIsLoaded = false;

        //public DocumentParserT CreateSingleParser(Template2 template2)
        //{
        //    Log.Inform("Compiling '" + template2.Template.Name + "' DocumentParser...");
        //    Type documentParserType = CompileSingleType(template2.DocumentParserClassDefinition);
        //    if (documentParserType == null)//allow commented code string
        //        return null;
        //    return (DocumentParserT)Activator.CreateInstance(documentParserType);
        //}

        public List<Type> HardcodedDocumentParserTypes
        {
            get
            {
                if (hardcodedDocumentParserTypes == null)
                    hardcodedDocumentParserTypes = hardcodedDocumentParsersAssembly.GetTypes().Where(t => t.BaseType == typeof(DocumentParserT)).ToList();
                return hardcodedDocumentParserTypes;
            }
        }
        List<Type> hardcodedDocumentParserTypes = null;

        public List<string> HardcodedDocumentParserNames
        {
            get
            {
                return HardcodedDocumentParserTypes.Select(a => a.Name).ToList();
            }
        }

        public List<Type> CommonDocumentParserTypes
        {
            get
            {
                if (commonDocumentParserTypes == null)
                    commonDocumentParserTypes = CompileMultipleTypes(documentCommonParserClassDefinitions);
                return commonDocumentParserTypes;
            }
            internal set
            {
                commonDocumentParserTypes = value;
            }
        }
        List<Type> commonDocumentParserTypes = null;

        public List<string> CommonDocumentParserNames
        {
            get
            {
                return CommonDocumentParserTypes.Select(a => a.Name).ToList();
            }
        }

        public Type DefaultDocumentParserType
        {
            get
            {
                if (defaultDocumentParserType == null)
                    defaultDocumentParserType = DefaultCommonDocumentParserName != null ? CommonDocumentParserTypes.Find(a => a.Name == DefaultCommonDocumentParserName) : typeof(DocumentParserT);
                return defaultDocumentParserType;
            }
        }
        Type defaultDocumentParserType;

        internal string DefaultCommonDocumentParserName
        {
            get
            {
                return _defaultCommonDocumentParserName;
            }
            set
            {
                _defaultCommonDocumentParserName = value;
                defaultDocumentParserType = null;
            }
        }
        string _defaultCommonDocumentParserName;

        //public Type GetDocumentParserType(string templateName)
        //{

        //}
        //Dictionary<string,Type> templateNames2documentParserType = new Dictionary<string, Type>();
    }
}