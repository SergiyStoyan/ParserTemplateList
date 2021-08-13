//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cliver.ParserTemplateList
{
    abstract public class LocalInfoSettings<T2> : Cliver.UserSettings where T2 : Template2
    {
        public Dictionary<string, TemplateInfo> TemplateNames2TemplateInfo;

        public class TemplateInfo
        {
            public string LastTestFile;
            public DateTime UsedTime;

            public string GetUsedTimeAsString()
            {
                return UsedTime.ToString("yy-MM-dd HH:mm:ss");
            }
        }

        public void SetLastTestFile(T2 template2, string lastTestFile)
        {
            GetInfo(template2).LastTestFile = lastTestFile;
        }

        public void SetUsedTime(T2 template2)
        {
            GetInfo(template2).UsedTime = DateTime.Now;
        }

        public TemplateInfo GetInfo(T2 template2)
        {
            if (!TemplateNames2TemplateInfo.TryGetValue(template2.Template.Name, out TemplateInfo i))
            {
                i = new TemplateInfo();
                TemplateNames2TemplateInfo[template2.Template.Name] = i;
            }
            return i;
        }

        public void ClearAndSave(TemplateInfoSettings<T2> templateInfo)
        {
            var deletedTNs = TemplateNames2TemplateInfo.Keys.Where(n => templateInfo.Template2s.Where(a => a.Template.Name == n).FirstOrDefault() == null).ToList();
            foreach (string n in deletedTNs)
                TemplateNames2TemplateInfo.Remove(n);
            Save();
        }

        protected override void Loaded()
        {
            if (TemplateNames2TemplateInfo == null)
                TemplateNames2TemplateInfo = new Dictionary<string, TemplateInfo>();
        }

        protected override void Saving()
        {
        }
    }
}