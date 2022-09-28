namespace Cliver.ParserTemplateList
{
    partial class DocumentParserClassDefinitionsForm<Template2T, DocumentParserT>
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
            this.bCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bOK = new System.Windows.Forms.Button();
            this.bValidate = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.documentParserClasses = new System.Windows.Forms.ComboBox();
            this.SelectedDocumentParserClassIsDefault = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.templatesUsingSelectedDocumentParserClass = new System.Windows.Forms.ComboBox();
            this.bSelectedTemplateEdit = new System.Windows.Forms.Button();
            this.bSelectedTemplateEdit2 = new System.Windows.Forms.Button();
            this.DocumentParserClassDefinitions = new ICSharpCode.TextEditor.TextEditorControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCancel.Location = new System.Drawing.Point(193, 3);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 50;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.bCancel);
            this.flowLayoutPanel1.Controls.Add(this.bOK);
            this.flowLayoutPanel1.Controls.Add(this.bValidate);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(754, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(271, 31);
            this.flowLayoutPanel1.TabIndex = 51;
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bOK.Location = new System.Drawing.Point(112, 3);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 51;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bValidate
            // 
            this.bValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bValidate.Location = new System.Drawing.Point(31, 3);
            this.bValidate.Name = "bValidate";
            this.bValidate.Size = new System.Drawing.Size(75, 23);
            this.bValidate.TabIndex = 58;
            this.bValidate.Text = "Check";
            this.bValidate.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.documentParserClasses);
            this.flowLayoutPanel2.Controls.Add(this.SelectedDocumentParserClassIsDefault);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.templatesUsingSelectedDocumentParserClass);
            this.flowLayoutPanel2.Controls.Add(this.bSelectedTemplateEdit);
            this.flowLayoutPanel2.Controls.Add(this.bSelectedTemplateEdit2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 1);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(732, 27);
            this.flowLayoutPanel2.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Classes:";
            // 
            // documentParserClasses
            // 
            this.documentParserClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.documentParserClasses.FormattingEnabled = true;
            this.documentParserClasses.Location = new System.Drawing.Point(55, 3);
            this.documentParserClasses.Name = "documentParserClasses";
            this.documentParserClasses.Size = new System.Drawing.Size(145, 21);
            this.documentParserClasses.TabIndex = 0;
            // 
            // SelectedDocumentParserClassIsDefault
            // 
            this.SelectedDocumentParserClassIsDefault.Appearance = System.Windows.Forms.Appearance.Button;
            this.SelectedDocumentParserClassIsDefault.Location = new System.Drawing.Point(206, 3);
            this.SelectedDocumentParserClassIsDefault.Name = "SelectedDocumentParserClassIsDefault";
            this.SelectedDocumentParserClassIsDefault.Size = new System.Drawing.Size(75, 23);
            this.SelectedDocumentParserClassIsDefault.TabIndex = 53;
            this.SelectedDocumentParserClassIsDefault.Text = "Default";
            this.SelectedDocumentParserClassIsDefault.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SelectedDocumentParserClassIsDefault.UseVisualStyleBackColor = true;
            //this.SelectedDocumentParserClassIsDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Using Templates:";
            // 
            // templatesUsingSelectedDocumentParserClass
            // 
            this.templatesUsingSelectedDocumentParserClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templatesUsingSelectedDocumentParserClass.FormattingEnabled = true;
            this.templatesUsingSelectedDocumentParserClass.Location = new System.Drawing.Point(382, 3);
            this.templatesUsingSelectedDocumentParserClass.Name = "templatesUsingSelectedDocumentParserClass";
            this.templatesUsingSelectedDocumentParserClass.Size = new System.Drawing.Size(144, 21);
            this.templatesUsingSelectedDocumentParserClass.TabIndex = 54;
            // 
            // bSelectedTemplateEdit
            // 
            this.bSelectedTemplateEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSelectedTemplateEdit.Location = new System.Drawing.Point(532, 3);
            this.bSelectedTemplateEdit.Name = "bSelectedTemplateEdit";
            this.bSelectedTemplateEdit.Size = new System.Drawing.Size(75, 23);
            this.bSelectedTemplateEdit.TabIndex = 58;
            this.bSelectedTemplateEdit.Text = "Edit";
            this.bSelectedTemplateEdit.UseVisualStyleBackColor = true;
            // 
            // bSelectedTemplateEdit2
            // 
            this.bSelectedTemplateEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSelectedTemplateEdit2.Location = new System.Drawing.Point(613, 3);
            this.bSelectedTemplateEdit2.Name = "bSelectedTemplateEdit2";
            this.bSelectedTemplateEdit2.Size = new System.Drawing.Size(75, 23);
            this.bSelectedTemplateEdit2.TabIndex = 52;
            this.bSelectedTemplateEdit2.Text = "Edit2";
            this.bSelectedTemplateEdit2.UseVisualStyleBackColor = true;
            // 
            // DocumentParserClassDefinitions
            // 
            this.DocumentParserClassDefinitions.AutoHideScrollbars = false;
            this.DocumentParserClassDefinitions.AutoScroll = true;
            this.DocumentParserClassDefinitions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentParserClassDefinitions.Highlighting = null;
            this.DocumentParserClassDefinitions.Location = new System.Drawing.Point(0, 0);
            this.DocumentParserClassDefinitions.Margin = new System.Windows.Forms.Padding(1);
            this.DocumentParserClassDefinitions.Name = "DocumentParserClassDefinitions";
            this.DocumentParserClassDefinitions.ShowVRuler = false;
            this.DocumentParserClassDefinitions.Size = new System.Drawing.Size(1025, 401);
            this.DocumentParserClassDefinitions.TabIndex = 87;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 33);
            this.panel1.TabIndex = 88;
            // 
            // DocumentParserClassDefinitionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 434);
            this.Controls.Add(this.DocumentParserClassDefinitions);
            this.Controls.Add(this.panel1);
            this.Name = "DocumentParserClassDefinitionsForm";
            this.Text = "DocumentParserClassDefinitionsForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ICSharpCode.TextEditor.TextEditorControl DocumentParserClassDefinitions;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox documentParserClasses;
        private System.Windows.Forms.CheckBox SelectedDocumentParserClassIsDefault;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox templatesUsingSelectedDocumentParserClass;
        private System.Windows.Forms.Button bSelectedTemplateEdit2;
        private System.Windows.Forms.Button bValidate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bSelectedTemplateEdit;
    }
}