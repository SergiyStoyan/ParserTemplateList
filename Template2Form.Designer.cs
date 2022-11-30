namespace Cliver.ParserTemplateList
{
    partial class Template2Form<Template2T, DocumentParserT>
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
            this.bOK = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bDebug = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bEdit2Custom = new System.Windows.Forms.Button();
            this.bJson = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Comment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Group = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Active = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.OrderWeight = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.DocumentParserClass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DocumentParserClassDefinition = new ICSharpCode.TextEditor.TextEditorControl();
            this.pMain = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderWeight)).BeginInit();
            this.pMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCancel.Location = new System.Drawing.Point(926, 3);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 50;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bOK.Location = new System.Drawing.Point(845, 3);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 49;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.bCancel);
            this.flowLayoutPanel1.Controls.Add(this.bOK);
            this.flowLayoutPanel1.Controls.Add(this.bDebug);
            this.flowLayoutPanel1.Controls.Add(this.bEdit);
            this.flowLayoutPanel1.Controls.Add(this.bEdit2Custom);
            this.flowLayoutPanel1.Controls.Add(this.bJson);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 399);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1004, 31);
            this.flowLayoutPanel1.TabIndex = 60;
            // 
            // bDebug
            // 
            this.bDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDebug.Location = new System.Drawing.Point(764, 3);
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
            this.bEdit.Location = new System.Drawing.Point(683, 3);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(75, 23);
            this.bEdit.TabIndex = 86;
            this.bEdit.Text = "Edit";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bEdit2Custom
            // 
            this.bEdit2Custom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bEdit2Custom.Location = new System.Drawing.Point(602, 3);
            this.bEdit2Custom.Name = "bEdit2Custom";
            this.bEdit2Custom.Size = new System.Drawing.Size(75, 23);
            this.bEdit2Custom.TabIndex = 87;
            this.bEdit2Custom.Text = "Edit2 (ext)";
            this.bEdit2Custom.UseVisualStyleBackColor = true;
            this.bEdit2Custom.Click += new System.EventHandler(this.bEdit2Custom_Click);
            // 
            // bJson
            // 
            this.bJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bJson.Location = new System.Drawing.Point(521, 3);
            this.bJson.Name = "bJson";
            this.bJson.Size = new System.Drawing.Size(75, 23);
            this.bJson.TabIndex = 88;
            this.bJson.Text = "Json";
            this.bJson.UseVisualStyleBackColor = true;
            this.bJson.Click += new System.EventHandler(this.bJson_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comment:";
            // 
            // Comment
            // 
            this.Comment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comment.Location = new System.Drawing.Point(412, 6);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(588, 20);
            this.Comment.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Group:";
            // 
            // Group
            // 
            this.Group.Location = new System.Drawing.Point(130, 6);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(82, 20);
            this.Group.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Active:";
            // 
            // Active
            // 
            this.Active.AutoSize = true;
            this.Active.Location = new System.Drawing.Point(57, 12);
            this.Active.Name = "Active";
            this.Active.Size = new System.Drawing.Size(15, 14);
            this.Active.TabIndex = 53;
            this.Active.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Order:";
            // 
            // OrderWeight
            // 
            this.OrderWeight.DecimalPlaces = 1;
            this.OrderWeight.Location = new System.Drawing.Point(268, 6);
            this.OrderWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.OrderWeight.Name = "OrderWeight";
            this.OrderWeight.Size = new System.Drawing.Size(63, 20);
            this.OrderWeight.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 13);
            this.label9.TabIndex = 77;
            this.label9.Text = "Document Parser Class Definition:";
            // 
            // DocumentParserClass
            // 
            this.DocumentParserClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DocumentParserClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DocumentParserClass.FormattingEnabled = true;
            this.DocumentParserClass.Location = new System.Drawing.Point(823, 33);
            this.DocumentParserClass.Name = "DocumentParserClass";
            this.DocumentParserClass.Size = new System.Drawing.Size(177, 21);
            this.DocumentParserClass.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(697, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Document Parser Class:";
            // 
            // DocumentParserClassDefinition
            // 
            this.DocumentParserClassDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DocumentParserClassDefinition.AutoHideScrollbars = false;
            this.DocumentParserClassDefinition.AutoScroll = true;
            this.DocumentParserClassDefinition.Highlighting = null;
            this.DocumentParserClassDefinition.Location = new System.Drawing.Point(6, 60);
            this.DocumentParserClassDefinition.Margin = new System.Windows.Forms.Padding(1);
            this.DocumentParserClassDefinition.Name = "DocumentParserClassDefinition";
            this.DocumentParserClassDefinition.ShowVRuler = false;
            this.DocumentParserClassDefinition.Size = new System.Drawing.Size(994, 335);
            this.DocumentParserClassDefinition.TabIndex = 85;
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.DocumentParserClassDefinition);
            this.pMain.Controls.Add(this.label1);
            this.pMain.Controls.Add(this.label5);
            this.pMain.Controls.Add(this.Comment);
            this.pMain.Controls.Add(this.DocumentParserClass);
            this.pMain.Controls.Add(this.label3);
            this.pMain.Controls.Add(this.label9);
            this.pMain.Controls.Add(this.Group);
            this.pMain.Controls.Add(this.OrderWeight);
            this.pMain.Controls.Add(this.label2);
            this.pMain.Controls.Add(this.label7);
            this.pMain.Controls.Add(this.Active);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1004, 399);
            this.pMain.TabIndex = 86;
            // 
            // Template2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 430);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Template2Form";
            this.Text = "Template2Form";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrderWeight)).EndInit();
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button bDebug;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bEdit2Custom;
        private System.Windows.Forms.Button bJson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Comment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Group;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Active;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown OrderWeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox DocumentParserClass;
        private System.Windows.Forms.Label label5;
        private ICSharpCode.TextEditor.TextEditorControl DocumentParserClassDefinition;
        private System.Windows.Forms.Panel pMain;
    }
}