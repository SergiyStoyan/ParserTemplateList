//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;

namespace Cliver.PdfDocumentParserTemplateList
{
    public partial class Settings
    {
        [SettingsAttributes.Config(Optional = true)]
        public static GeneralSettings General { get; set; }
    }

    abstract public class GeneralSettings : Cliver.UserSettings
    {
        public bool UseActiveSelectPattern = false;
        public bool UseNameSelectPattern = true;
        public bool UseGroupSelectPattern = false;
        public bool UseCommentSelectPattern = false;
        public bool UseOrderWeightPattern = false;
        public bool SortSelectedUp = true;
        public int DeactivateTemplatesOlderThanDays = 200;

        public string LogFolder;

        protected override void Loaded()
        {
        }

        protected override void Saving()
        {
        }
    }
}
