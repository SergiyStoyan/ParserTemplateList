//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        sergey.stoyan@hotmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Text.RegularExpressions;
using Cliver.PdfDocumentParser;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Cliver.ParserTemplateList
{
    /// <summary>
    /// Template container
    /// </summary>
    abstract public class Template2<DocumentParserT> where DocumentParserT : class
    {
        public Template2T Clone<Template2T>() where Template2T : Template2<DocumentParserT>
        {
            return (Template2T)Serialization.Json.Clone(typeof(Template2T), this);
        }

        [Newtonsoft.Json.JsonIgnore]
        public string Name { get { return Template.Name; } set { Template.Name = value; } }

        public virtual Template Template { get; set; }

        public bool Active = true;
        public string Group = "";
        public DateTime ModifiedTime;
        public string Comment = "";
        public float OrderWeight = 1f;
        public Regex FileFilterRegex = null;
        /// <summary>
        /// (!)If the string starts with # then it is the name of the own class defined in DocumentParserClassDefinition
        /// </summary>
        public string DocumentParserClass = "";
        public string DocumentParserClassDefinition = "";
        public bool WrapLinesInDebugger = true;


        [Newtonsoft.Json.JsonIgnore]
        virtual public Type DocumentParserType
        {
            get
            {
                if (documentParserType == null)
                {
                    if (!string.IsNullOrWhiteSpace(DocumentParserClass))
                    {
                        if (DocumentParserClass.StartsWith("#"))//own definition
                        {
                            documentParserType = Compiler.CompileSingleType(DocumentParserClassDefinition);
                            if (documentParserType == null)//a non-empty definition can be a commented code string
                                throw new Exception2("There is no class '" + DocumentParserClass + "' defined in DocumentParserClassDefinition");
                        }
                        else
                        {
                            documentParserType = Compiler.HardcodedDocumentParserTypes.FirstOrDefault(a => a.Name == DocumentParserClass);
                            if (documentParserType == null)
                            {
                                Template2<DocumentParserT> t = GetTemplate2s().Find(a => a.DocumentParserClass == "#" + DocumentParserClass);
                                if (t != null)
                                    documentParserType = t.DocumentParserType;
                                else
                                {
                                    documentParserType = Compiler.CommonDocumentParserTypes.FirstOrDefault(a => a.Name == DocumentParserClass);
                                    if (documentParserType == null)
                                        throw new Exception2("There is no hardcoded nor hot-compiled class '" + DocumentParserClass + "'");
                                }
                            }
                        }
                    }
                    else
                        documentParserType = Compiler.DefaultDocumentParserType;
                }
                return documentParserType;
            }
            set
            {
                if (DocumentParserClass?.StartsWith("#") == true)
                {
                    var ts = GetTemplate2s().Where(a => a.DocumentParserClass == DocumentParserClass.TrimStart('#'));
                    foreach (Template2<DocumentParserT> t in ts)
                        t.DocumentParserType = null;
                }
                documentParserType = value;
                documentParser = null;
            }
        }
        protected Type documentParserType = null;

        [Newtonsoft.Json.JsonIgnore]
        virtual public DocumentParserT DocumentParser
        {
            get
            {
                if (documentParser == null)
                {
                    documentParser = (DocumentParserT)Activator.CreateInstance(DocumentParserType);
                    //documentParser.Template2 = this;
                }
                return documentParser;
            }
        }
        protected DocumentParserT documentParser = null;

        abstract public DocumentParserCompiler<DocumentParserT> Compiler { get; }

        abstract public List<Template2<DocumentParserT>> GetTemplate2s();

        public string GetModifiedTimeAsString()
        {
            return ModifiedTime.ToString("yy-MM-dd HH:mm:ss");
        }

        public virtual void Rectify(Template2<DocumentParserT> t0)
        {
            //for (int i = t.Template.Conditions.Count - 1; i >= 0; i--)
            //    if (t0.Template.Conditions.Find(a => a.Name == t.Template.Conditions[i].Name) == null)
            //        t.Template.Conditions.RemoveAt(i);
            for (int i = 0; i < t0.Template.Conditions.Count; i++)
                if (Template.Conditions.Find(a => a.Name == t0.Template.Conditions[i].Name) == null)
                    Template.Conditions.Insert(i, t0.Template.Conditions[i]);
            for (int i = 0; i < t0.Template.Conditions.Count; i++)//ordering
                while (Template.Conditions[i].Name != t0.Template.Conditions[i].Name)
                {
                    Template.Conditions.Add(Template.Conditions[i]);
                    Template.Conditions.RemoveAt(i);
                }

            //for (int i = t.Template.Fields.Count - 1; i >= 0; i--)
            //    if (t0.Template.Fields.Find(a => a.Name == t.Template.Fields[i].Name) == null)
            //        t.Template.Fields.RemoveAt(i);
            for (int i = 0; i < t0.Template.Fields.Count; i++)
                if (Template.Fields.Find(a => a.Name == t0.Template.Fields[i].Name) == null)
                    Template.Fields.Add(t0.Template.Fields[i]);
            int j = 0;
            for (int i = 0; i < t0.Template.Fields.Count; i++)//ordering
            {
                while (Template.Fields[j].Name != t0.Template.Fields[i].Name)
                {
                    Template.Fields.Add(Template.Fields[j]);
                    Template.Fields.RemoveAt(j);
                }
                j++;
                while (j < Template.Fields.Count && Template.Fields[j].Name == t0.Template.Fields[i].Name)//there may be multiple field defintions
                    j++;
            }
        }
    }
}