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

namespace Cliver.ParserTemplateList
{
    abstract public class TemplateInfoSettings<T2> : Cliver.UserSettings where T2 : Template2
    {
        public List<T2> Template2s = new List<T2>();

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

        abstract public T2 CreateInitialTemplate();
    }
}
