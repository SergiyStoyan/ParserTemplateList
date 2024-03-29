//********************************************************************************************
//Author: Sergiy Stoyan
//        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;

namespace Cliver.ParserTemplateList
{
    public partial class Settings
    {
        public static GeneralSettings General { get; set; }
    }

    public class GeneralSettings : Cliver.UserSettings
    {
        public bool UseActiveSelectPattern = false;
        public bool UseNameSelectPattern = true;
        public bool UseGroupSelectPattern = false;
        public bool UseCommentSelectPattern = false;
        public bool UseOrderWeightPattern = false;
        public bool SortSelectedUp = true;
    }
}
