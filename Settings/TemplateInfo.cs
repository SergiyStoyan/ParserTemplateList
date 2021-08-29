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

namespace Cliver.ParserTemplateList
{
    abstract public class TemplateInfoSettings<Template2T> : Cliver.UserSettings where Template2T : Template2
    {
        public List<Template2T> Template2s = new List<Template2T>();

        protected override void Saving()
        {
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
