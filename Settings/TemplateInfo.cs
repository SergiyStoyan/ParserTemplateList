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
        [SettingsAttributes.Config(Optional = true)]
        public static TemplateInfoSettings TemplateInfo;
    }

    abstract public class TemplateInfoSettings : Cliver.UserSettings
    {
        public List<Template2> Template2s = new List<Template2>();

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
        }

        abstract public Template2 CreateInitialTemplate();
    }
}
