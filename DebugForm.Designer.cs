﻿namespace Cliver.ParserTemplateList
{
    partial class DebugForm<Template2T, DocumentParserT>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Result = new System.Windows.Forms.RichTextBox();
            this.bTestFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TestFile = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bClose = new System.Windows.Forms.Button();
            this.bDebug = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bLog = new System.Windows.Forms.Button();
            this.WrapLines = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.bEdit2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Result
            // 
            this.Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Result.Location = new System.Drawing.Point(0, 0);
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Size = new System.Drawing.Size(574, 339);
            this.Result.TabIndex = 0;
            this.Result.Text = "";
            // 
            // bTestFile
            // 
            this.bTestFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bTestFile.Location = new System.Drawing.Point(536, 4);
            this.bTestFile.Name = "bTestFile";
            this.bTestFile.Size = new System.Drawing.Size(26, 23);
            this.bTestFile.TabIndex = 64;
            this.bTestFile.Text = "...";
            this.bTestFile.UseVisualStyleBackColor = true;
            this.bTestFile.Click += new System.EventHandler(this.bTestFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Test File:";
            // 
            // TestFile
            // 
            this.TestFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestFile.Location = new System.Drawing.Point(68, 6);
            this.TestFile.Name = "TestFile";
            this.TestFile.Size = new System.Drawing.Size(462, 20);
            this.TestFile.TabIndex = 62;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.bClose);
            this.flowLayoutPanel1.Controls.Add(this.bDebug);
            this.flowLayoutPanel1.Controls.Add(this.bEdit2);
            this.flowLayoutPanel1.Controls.Add(this.bEdit);
            this.flowLayoutPanel1.Controls.Add(this.bLog);
            this.flowLayoutPanel1.Controls.Add(this.WrapLines);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 419);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(574, 31);
            this.flowLayoutPanel1.TabIndex = 65;
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bClose.Location = new System.Drawing.Point(496, 3);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 50;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bDebug
            // 
            this.bDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDebug.Location = new System.Drawing.Point(415, 3);
            this.bDebug.Name = "bDebug";
            this.bDebug.Size = new System.Drawing.Size(75, 23);
            this.bDebug.TabIndex = 85;
            this.bDebug.Text = "Debug";
            this.bDebug.UseVisualStyleBackColor = true;
            this.bDebug.Click += new System.EventHandler(this.bDebug_Click);
            // 
            // bEdit
            // 
            this.bEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bEdit.Location = new System.Drawing.Point(253, 3);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(75, 23);
            this.bEdit.TabIndex = 86;
            this.bEdit.Text = "Edit";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bLog
            // 
            this.bLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bLog.Location = new System.Drawing.Point(172, 3);
            this.bLog.Name = "bLog";
            this.bLog.Size = new System.Drawing.Size(75, 23);
            this.bLog.TabIndex = 87;
            this.bLog.Text = "Log";
            this.bLog.UseVisualStyleBackColor = true;
            this.bLog.Click += new System.EventHandler(this.bLog_Click);
            // 
            // WrapLines
            // 
            this.WrapLines.AutoSize = true;
            this.WrapLines.Location = new System.Drawing.Point(86, 3);
            this.WrapLines.Name = "WrapLines";
            this.WrapLines.Size = new System.Drawing.Size(80, 17);
            this.WrapLines.TabIndex = 88;
            this.WrapLines.Text = "Wrap Lines";
            this.WrapLines.UseVisualStyleBackColor = true;
            this.WrapLines.CheckedChanged += new System.EventHandler(this.cWrapLines_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Result);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LogBox);
            this.splitContainer1.Size = new System.Drawing.Size(574, 384);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 66;
            // 
            // LogBox
            // 
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox.Location = new System.Drawing.Point(0, 0);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(574, 41);
            this.LogBox.TabIndex = 1;
            this.LogBox.Text = "";
            // 
            // bEdit2
            // 
            this.bEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bEdit2.Location = new System.Drawing.Point(334, 3);
            this.bEdit2.Name = "bEdit2";
            this.bEdit2.Size = new System.Drawing.Size(75, 23);
            this.bEdit2.TabIndex = 89;
            this.bEdit2.Text = "Edit2";
            this.bEdit2.UseVisualStyleBackColor = true;
            this.bEdit2.Click += new System.EventHandler(this.bEdit2_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.bTestFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TestFile);
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.RichTextBox Result;
        private System.Windows.Forms.Button bTestFile;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox TestFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bDebug;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Button bLog;
        protected System.Windows.Forms.CheckBox WrapLines;
        private System.Windows.Forms.Button bEdit2;
    }
}