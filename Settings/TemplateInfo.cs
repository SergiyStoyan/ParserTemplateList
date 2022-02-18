//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        sergey.stoyan@hotmail.com
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
    abstract public class TemplateInfoSettings<Template2T> : Cliver.UserSettings where Template2T : Template2
    {
        public List<Template2T> Template2s = new List<Template2T>();

        public Ocr.Config OcrConfig;
        public string PdfDocumentParserVersion;
        public int DeactivateTemplatesOlderThanDays = 390;

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

        virtual public bool DeactivateObsoleteTemplates(LocalInfoSettings<Template2T> localInfo)
        {
            if (DeactivateTemplatesOlderThanDays < 1)
                return false;
            DateTime obsoleteTime = DateTime.Now.AddDays(-DeactivateTemplatesOlderThanDays);
            bool deactivated = false;
            foreach (Template2T t2 in Template2s.Where(a => a.Active))
                if (t2.ModifiedTime < obsoleteTime && localInfo.GetInfo(t2)?.UsedTime < obsoleteTime)
                {
                    deactivated = true;
                    t2.Active = false;
                    t2.Group = "obsolete";// since " + DateTime.Now.ToString("yyyy-MM-dd");
                    Log.Warning2("Template '" + t2.Template.Name + "' has been disactivated as obsolete.");
                }
            if (deactivated)
            {
                Save();
                Message.Inform("Some templates were deactivated as obsolete.\r\nSee the log for details.");
            }
            return deactivated;
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
