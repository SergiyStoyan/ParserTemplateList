//********************************************************************************************
//Author: Sergiy Stoyan
//        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
//        http://www.cliversoft.com
//********************************************************************************************
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Cliver.PdfDocumentParser;

namespace Cliver.ParserTemplateList
{
    abstract public class TemplateInfoSettings<Template2T, DocumentParserT> : Cliver.UserSettings where Template2T : Template2<DocumentParserT> where DocumentParserT:class
    {
        public List<Template2T> Template2s = new List<Template2T>();
        public string DocumentParserClassDefinitions;
        //public List<string> DocumentParserClassNames = new List<string>();
        public string DefaultDocumentParserClass;

        public Ocr.Config OcrConfig;
        public string PdfDocumentParserVersion;

        protected override void Loaded()
        {
            if (OcrConfig == null)
                OcrConfig = new Ocr.Config
                {
                    Language = "eng",
                    EngineMode = Tesseract.EngineMode.Default,
                    VariableNames2value = new Dictionary<string, object>
                        {
                            { "load_system_dawg", false },//don't load dictionary
                            { "load_freq_dawg", false },//don't load dictionary
                            //(name: "tessedit_char_whitelist", "0123456789.,"),
                        }
                };
        }

        protected override void Saving()
        {
            PdfDocumentParserVersion = PdfDocumentParser.Program.Version.ToString();
            Template2s.RemoveAll(x => string.IsNullOrWhiteSpace(x.Name));
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
            TouchedChanged?.BeginInvoke();
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
            TouchedChanged?.BeginInvoke();
        }

        abstract public Template2T CreateInitialTemplate();
    }
}
