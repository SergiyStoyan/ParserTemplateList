//********************************************************************************************
//Author: Sergiy Stoyan
//        systoyan@gmail.com
//        sergiy.stoyan@outlook.com
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
    public interface IEditor
    {
        bool IsDisposed { get; }
        event EventHandler Disposed;
        void Show();
        void Activate();
    }

    public class EditorManager
    {
        static Dictionary<Type, Dictionary<int, IEditor>> formTypes2hashes2form = new Dictionary<Type, Dictionary<int, IEditor>>();

        static public T Get<T>(int hash) where T : IEditor
        {
            Dictionary<int, IEditor> hashes2form = getHashes2form(typeof(T));
            hashes2form.TryGetValue(hash, out IEditor form);
            if (form?.IsDisposed == true)
            {
                hashes2form.Remove(hash);
                form = null;
            }
            return (T)form;
        }

        static Dictionary<int, IEditor> getHashes2form(Type formType)
        {
            if (!formTypes2hashes2form.TryGetValue(formType, out Dictionary<int, IEditor> hashes2form))
            {
                hashes2form = new Dictionary<int, IEditor>();
                formTypes2hashes2form[formType] = hashes2form;
            }
            return hashes2form;
        }

        static public void Set(int hash, IEditor form)
        {
            Dictionary<int, IEditor> hashes2form = getHashes2form(form.GetType());
            form.Disposed += delegate (object sender, EventArgs e)
            {
                hashes2form.Remove(hash);
            };
            hashes2form[hash] = form;
        }

        static internal T Get<T>(DataGridViewRow row) where T : IEditor
        {
            return Get<T>(row.GetHashCode());
        }

        static internal void Set(DataGridViewRow row, IEditor form)
        {
            Set(row.GetHashCode(), form);
        }
    }

    public class FormManager
    {
        static Dictionary<Type, Dictionary<DataGridViewRow, Form>> formTypes2rows2form = new Dictionary<Type, Dictionary<DataGridViewRow, Form>>();
        static object lockObject = new object();

        static public T Get<T>(DataGridViewRow row) where T : Form
        {
            lock (lockObject)
            {
                Dictionary<DataGridViewRow, Form> rows2form = getRows2form(typeof(T));
                rows2form.TryGetValue(row, out Form form);
                if (form?.IsDisposed == true)
                {
                    rows2form.TryGetValue(row, out Form f);
                    if (f == form)
                        rows2form.Remove(row);
                    form = null;
                }
                return (T)form;
            }
        }

        static Dictionary<DataGridViewRow, Form> getRows2form(Type formType)
        {
            lock (lockObject)
            {
                if (!formTypes2rows2form.TryGetValue(formType, out Dictionary<DataGridViewRow, Form> rows2form))
                {
                    rows2form = new Dictionary<DataGridViewRow, Form>();
                    formTypes2rows2form[formType] = rows2form;
                }
                return rows2form;
            }
        }

        static public void Set<T>(DataGridViewRow row, Form form) where T : Form
        {
            lock (lockObject)
            {
                Dictionary<DataGridViewRow, Form> rows2form = getRows2form(typeof(T));
                form.FormClosed += delegate
                {
                    lock (lockObject)
                    {
                        rows2form.TryGetValue(row, out Form f);
                        if (f == form)
                            rows2form.Remove(row);
                    }
                };
                rows2form[row] = form;
            }
        }
    }
}