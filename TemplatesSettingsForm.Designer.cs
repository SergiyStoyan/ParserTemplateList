﻿namespace Cliver.ParserTemplateList
{
    partial class TemplatesSettingsForm<Template2T, DocumentParserT> 
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
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.OcrConfig = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeactivateTemplatesOlderThanDays = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DoCleaningEveryDays = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NextCleaningTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeactivateTemplatesOlderThanDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoCleaningEveryDays)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSave.Location = new System.Drawing.Point(225, 3);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 49;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCancel.Location = new System.Drawing.Point(306, 3);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 50;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.bCancel);
            this.flowLayoutPanel1.Controls.Add(this.bSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 393);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(384, 31);
            this.flowLayoutPanel1.TabIndex = 51;
            // 
            // OcrConfig
            // 
            this.OcrConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OcrConfig.Location = new System.Drawing.Point(27, 176);
            this.OcrConfig.Name = "OcrConfig";
            this.OcrConfig.Size = new System.Drawing.Size(330, 201);
            this.OcrConfig.TabIndex = 60;
            this.OcrConfig.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Deactivate Templates Older Than Days:";
            // 
            // DeactivateTemplatesOlderThanDays
            // 
            this.DeactivateTemplatesOlderThanDays.Location = new System.Drawing.Point(26, 94);
            this.DeactivateTemplatesOlderThanDays.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DeactivateTemplatesOlderThanDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.DeactivateTemplatesOlderThanDays.Name = "DeactivateTemplatesOlderThanDays";
            this.DeactivateTemplatesOlderThanDays.Size = new System.Drawing.Size(61, 20);
            this.DeactivateTemplatesOlderThanDays.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Tesseract Config:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "Clean Every Days:";
            // 
            // DoCleaningEveryDays
            // 
            this.DoCleaningEveryDays.Location = new System.Drawing.Point(26, 41);
            this.DoCleaningEveryDays.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DoCleaningEveryDays.Name = "DoCleaningEveryDays";
            this.DoCleaningEveryDays.Size = new System.Drawing.Size(61, 20);
            this.DoCleaningEveryDays.TabIndex = 73;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.NextCleaningTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DeactivateTemplatesOlderThanDays);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DoCleaningEveryDays);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 129);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cleaning";
            // 
            // NextCleaningTime
            // 
            this.NextCleaningTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.NextCleaningTime.Location = new System.Drawing.Point(167, 41);
            this.NextCleaningTime.Name = "NextCleaningTime";
            this.NextCleaningTime.Size = new System.Drawing.Size(81, 20);
            this.NextCleaningTime.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 75;
            this.label4.Text = "Next Time:";
            // 
            // TemplatesSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OcrConfig);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TemplatesSettingsForm";
            this.Text = "SettingsForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeactivateTemplatesOlderThanDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoCleaningEveryDays)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RichTextBox OcrConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown DeactivateTemplatesOlderThanDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown DoCleaningEveryDays;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker NextCleaningTime;
        private System.Windows.Forms.Label label4;
    }
}