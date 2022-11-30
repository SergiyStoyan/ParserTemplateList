//********************************************************************************************
//Author: Sergiy Stoyan
//        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cliver.ParserTemplateList
{
    public partial class Template2JsonForm<Template2T, DocumentParserT> : Form where Template2T : Template2<DocumentParserT> where DocumentParserT : class
    {
        public Template2JsonForm(Template2T template2)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
            Text = Application.ProductName + ": raw JSON of '" + template2.Name + "'";

            this.template2 = template2;

            FormClosed += delegate
            {
            };

            Load += delegate
            {
                JsonBox.Text = Serialization.Json.Serialize(template2);
            };
        }
        Template2T template2;

        protected bool setTemplate2()
        {
            try
            {
                template2 = Serialization.Json.Deserialize<Template2T>(JsonBox.Text);
                return true;
            }
            catch (Exception ex)
            {
                Message.Error2(ex, this);
                return false;
            }
        }

        protected void bOK_Click(object sender, EventArgs e)
        {
            if (!setTemplate2())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        protected void bCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}

