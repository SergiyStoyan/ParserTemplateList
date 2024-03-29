﻿//********************************************************************************************
//Author: Sergiy Stoyan
//        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
//        http://www.cliversoft.com
//********************************************************************************************
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Cliver.ParserTemplateList
{
    public partial class FileFilterForm : Form
    {
        public FileFilterForm(string folder, Regex r)
        {
            InitializeComponent();

            this.Icon = Win.AssemblyRoutines.GetAppIcon();
            Text = "Filtered Files";
            files.ReadOnly = true;

            Load += delegate
            {
                foreach(string f in FileSystemRoutines.GetFiles(folder))
                {
                    int i = files.Items.Add(f);
                    if (r.IsMatch(f))
                        files.SelectedIndex = i;
                }
            };

        }
    }

    public class ReadOnlyListBox : ListBox
    {
        public bool ReadOnly = false;

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            // If ReadOnly is set to true, then block any messages 
            // to the selection area from the mouse or keyboard. 
            // Let all other messages pass through to the 
            // Windows default implementation of DefWndProc.
            if (!ReadOnly || ((m.Msg <= 0x0200 || m.Msg >= 0x020E)
            && (m.Msg <= 0x0100 || m.Msg >= 0x0109)
            && m.Msg != 0x2111
            && m.Msg != 0x87))
            {
                base.DefWndProc(ref m);
            }
        }
    }
}
