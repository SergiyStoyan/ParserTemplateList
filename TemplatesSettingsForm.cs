//********************************************************************************************
//Author: Sergiy Stoyan
//        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Cliver.ParserTemplateList
{
    public partial class TemplatesSettingsForm<Template2T, DocumentParserT> : Form where Template2T : Template2<DocumentParserT> where DocumentParserT : class
    {
        public TemplatesSettingsForm(TemplateInfoSettings<Template2T, DocumentParserT> templateInfo, LocalInfoSettings<Template2T, DocumentParserT> localInfo)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
            Text = Application.ProductName + ": Template Collection Settings";

            //important.Text = "Important! Letting folder '" + Config.StorageDir + "' be synchronized by a remote drive application may bring to malfunction.";
            this.templateInfo = templateInfo;
            this.localInfo = localInfo;
            load_settings();
        }
        TemplateInfoSettings<Template2T, DocumentParserT> templateInfo;
        LocalInfoSettings<Template2T, DocumentParserT> localInfo;

        void load_settings()
        {
            DeactivateTemplatesOlderThanDays.Value = localInfo.DeactivateTemplatesOlderThanDays;
            DoCleaningEveryDays.Value = localInfo.DoCleaningEveryDays;
            NextCleaningTime.Value = localInfo.NextCleaningTime < NextCleaningTime.MinDate ? NextCleaningTime.MinDate : localInfo.NextCleaningTime;

            OcrConfig.Text = templateInfo.OcrConfig.ToStringByJson();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(OcrConfig.Text))
                    throw new Exception("OcrConfig is empty.");

                localInfo.DeactivateTemplatesOlderThanDays = (int)DeactivateTemplatesOlderThanDays.Value;
                localInfo.DoCleaningEveryDays = (int)DoCleaningEveryDays.Value;
                localInfo.NextCleaningTime = NextCleaningTime.Value;
                localInfo.Save();

                templateInfo.OcrConfig = Serialization.Json.Deserialize<PdfDocumentParser.Ocr.Config>(OcrConfig.Text);

                templateInfo.Touch();

                Close();
            }
            catch (Exception ex)
            {
                Message.Error2(ex, this);
            }
        }
    }
}
