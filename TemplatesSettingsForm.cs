//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
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
    public partial class TemplatesSettingsForm<Template2T> : Form where Template2T : Template2
    {
        public TemplatesSettingsForm(TemplateInfoSettings<Template2T> templateInfo)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
            Text = Application.ProductName + ": Template Collection Settings";

            //important.Text = "Important! Letting folder '" + Config.StorageDir + "' be synchronized by a remote drive application may bring to malfunction.";
            this.templateInfo = templateInfo;
            load_settings();
        }
        TemplateInfoSettings<Template2T> templateInfo;

        void load_settings()
        {
            DeactivateTemplatesOlderThanDays.Value = templateInfo.DeactivateTemplatesOlderThanDays;
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

                templateInfo.DeactivateTemplatesOlderThanDays = (int)DeactivateTemplatesOlderThanDays.Value;
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
