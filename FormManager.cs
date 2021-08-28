//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        sergey.stoyan@hotmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;

namespace Cliver.ParserTemplateList
{
    public class FormManager
    {
        static Dictionary<Type, Dictionary<DataGridViewRow, Form>> formTypes2rows2form = new Dictionary<Type, Dictionary<DataGridViewRow, Form>>();

        static public T Get<T>(DataGridViewRow row) where T : Form
        {
            Dictionary<DataGridViewRow, Form> rows2form = getRows2form(typeof(T));
            rows2form.TryGetValue(row, out Form form);
            if (form?.IsDisposed == true)
            {
                rows2form.Remove(row);
                form = null;
            }
            return (T)form;
        }

        static Dictionary<DataGridViewRow, Form> getRows2form(Type formType)
        {
            if (!formTypes2rows2form.TryGetValue(formType, out Dictionary<DataGridViewRow, Form> rows2form))
            {
                rows2form = new Dictionary<DataGridViewRow, Form>();
                formTypes2rows2form[formType] = rows2form;
            }
            return rows2form;
        }

        static public void Set(DataGridViewRow row, Form form)
        {
            Dictionary<DataGridViewRow, Form> rows2form = getRows2form(form.GetType());
            form.FormClosed += delegate
            {
                rows2form.Remove(row);
            };
            rows2form[row] = form;
        }
    }
}