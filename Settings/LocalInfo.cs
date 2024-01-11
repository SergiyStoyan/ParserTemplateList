//********************************************************************************************
//Author: Sergiy Stoyan
//        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cliver.ParserTemplateList
{
    abstract public class LocalInfoSettings<Template2T, DocumentParserT> : Cliver.UserSettings where Template2T : Template2<DocumentParserT> where DocumentParserT : class
    {
        public Dictionary<string, TemplateInfo> TemplateNames2TemplateInfo = new Dictionary<string, TemplateInfo>();
        public int DeactivateTemplatesOlderThanDays = 390;
        public DateTime NextCleaningTime = DateTime.MinValue;
        public int DoCleaningEveryDays = 30;

        public class TemplateInfo
        {
            public string LastTestFile;
            public DateTime UsedTime;

            public string GetUsedTimeAsString()
            {
                return UsedTime.ToString("yy-MM-dd HH:mm:ss");
            }
        }

        public void SetLastTestFile(Template2T template2, string lastTestFile)
        {
            GetInfo(template2).LastTestFile = lastTestFile;
        }

        public void SetUsedTime(Template2T template2)
        {
            GetInfo(template2).UsedTime = DateTime.Now;
        }

        public TemplateInfo GetInfo(Template2T template2)
        {
            if (!TemplateNames2TemplateInfo.TryGetValue(template2.Name, out TemplateInfo i))
            {
                i = new TemplateInfo();
                TemplateNames2TemplateInfo[template2.Name] = i;
            }
            return i;
        }

        /// <summary>
        /// It must called before loading templates to the table. Otherwise the changes might be rewritten.
        /// </summary>
        /// <param name="templateListControl"></param>
        /// <returns></returns>
        internal bool CleanObsoleteData(TemplateListControl<Template2T, DocumentParserT> templateListControl)
        {
            if (NextCleaningTime <= DateTime.Now)
            {
                if (!System.Threading.Monitor.TryEnter(this, 1000))//lock to avoid overrriding when updating by Synchronization.onNewerSettingsFile()
                {
                    Log.Warning2("Could not lock " + this.GetType().Name);
                    return false;
                }
                try
                {
                    NextCleaningTime = DateTime.Now.AddDays(DoCleaningEveryDays);
                    deactivateObsoleteTemplates(templateListControl);
                    removeObsoleteData(templateListControl);
                    Save();
                    return true;
                }
                finally
                {
                    System.Threading.Monitor.Exit(this);
                }
            }
            return false;
        }

        bool deactivateObsoleteTemplates(TemplateListControl<Template2T, DocumentParserT> templateListControl)
        {
            if (DeactivateTemplatesOlderThanDays < 1)
                return false;
            Log.Inform("Deactivating obsolete templates...");
            DateTime obsoleteTime = DateTime.Now.AddDays(-DeactivateTemplatesOlderThanDays);
            bool deactivated = false;
            foreach (Template2T t2 in templateListControl.TemplateInfo.Template2s.Where(a => a.Active))
                if (t2.ModifiedTime < obsoleteTime && GetInfo(t2)?.UsedTime < obsoleteTime)
                {
                    deactivated = true;
                    t2.Active = false;
                    t2.Group = "obsolete";// since " + DateTime.Now.ToString("yyyy-MM-dd");
                    Log.Warning2("Template '" + t2.Template.Name + "' has been deactivated as obsolete.");
                }
            if (deactivated)
            {
                templateListControl.TemplateInfo.Save();
                Message.Inform("Some templates were deactivated as obsolete.\r\nSee the log for details.");
            }
            return deactivated;
        }

        void removeObsoleteData(TemplateListControl<Template2T, DocumentParserT> templateListControl)
        {
            Log.Inform("Removing obsolete data from LocalInfo...");
            var deletedTNs = TemplateNames2TemplateInfo.Keys.Where(n => templateListControl.TemplateInfo.Template2s.Where(a => a.Name == n).FirstOrDefault() == null).ToList();
            foreach (string n in deletedTNs)
                TemplateNames2TemplateInfo.Remove(n);
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