//********************************************************************************************
//Author: Sergiy Stoyan
//        systoyan@gmail.com
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
            DoTemplateDeactivationEveryDays.Value = localInfo.DoTemplateDeactivationEveryDays;
            NextTemplateDeactivationTime.Value = localInfo.NextTemplateDeactivationTime < NextTemplateDeactivationTime.MinDate ? NextTemplateDeactivationTime.MinDate : localInfo.NextTemplateDeactivationTime;

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
                localInfo.DoTemplateDeactivationEveryDays = (int)DoTemplateDeactivationEveryDays.Value;
                localInfo.NextTemplateDeactivationTime = NextTemplateDeactivationTime.Value;
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
