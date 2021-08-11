namespace Cliver.PdfDocumentParserTemplateList
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lProgress = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.lProgressTask = new System.Windows.Forms.Label();
            this.lProgressCurrentBlock = new System.Windows.Forms.Label();
            this.saveTemplates = new System.Windows.Forms.Button();
            this.template2s = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.orderWeightChange = new System.Windows.Forms.NumericUpDown();
            this.applyOrderWeightChange = new System.Windows.Forms.Button();
            this.applyActiveChange = new System.Windows.Forms.Button();
            this.applyGroupChange = new System.Windows.Forms.Button();
            this.activeChange = new System.Windows.Forms.CheckBox();
            this.groupChange = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lRefreshSelectedCounter = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.selectedTemplatesCount = new System.Windows.Forms.Label();
            this.orderWeightPattern2 = new System.Windows.Forms.NumericUpDown();
            this.orderWeightPattern1 = new System.Windows.Forms.NumericUpDown();
            this.commentPattern = new System.Windows.Forms.TextBox();
            this.useOrderWeightPattern = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.useCommentPattern = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sortSelectedUp = new System.Windows.Forms.CheckBox();
            this.useNamePattern = new System.Windows.Forms.CheckBox();
            this.useGroupPattern = new System.Windows.Forms.CheckBox();
            this.useActivePattern = new System.Windows.Forms.CheckBox();
            this.selectByFilter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.activePattern = new System.Windows.Forms.CheckBox();
            this.selectInvertion = new System.Windows.Forms.Button();
            this.selectNothing = new System.Windows.Forms.Button();
            this.selectAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupPattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.namePattern = new System.Windows.Forms.TextBox();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Copy = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Debug = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Name_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentParserClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.template2s)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderWeightChange)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderWeightPattern2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderWeightPattern1)).BeginInit();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(10, 478);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(1110, 12);
            this.progress.TabIndex = 7;
            // 
            // lProgress
            // 
            this.lProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lProgress.AutoSize = true;
            this.lProgress.Location = new System.Drawing.Point(31, 0);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(22, 13);
            this.lProgress.TabIndex = 15;
            this.lProgress.Text = "     ";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.Controls.Add(this.lProgressTask);
            this.flowLayoutPanel4.Controls.Add(this.lProgress);
            this.flowLayoutPanel4.Controls.Add(this.lProgressCurrentBlock);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(10, 455);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1110, 17);
            this.flowLayoutPanel4.TabIndex = 38;
            // 
            // lProgressTask
            // 
            this.lProgressTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lProgressTask.AutoSize = true;
            this.lProgressTask.Location = new System.Drawing.Point(3, 0);
            this.lProgressTask.Name = "lProgressTask";
            this.lProgressTask.Size = new System.Drawing.Size(22, 13);
            this.lProgressTask.TabIndex = 16;
            this.lProgressTask.Text = "     ";
            // 
            // lProgressCurrentBlock
            // 
            this.lProgressCurrentBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lProgressCurrentBlock.AutoSize = true;
            this.lProgressCurrentBlock.Location = new System.Drawing.Point(59, 0);
            this.lProgressCurrentBlock.Name = "lProgressCurrentBlock";
            this.lProgressCurrentBlock.Size = new System.Drawing.Size(22, 13);
            this.lProgressCurrentBlock.TabIndex = 17;
            this.lProgressCurrentBlock.Text = "     ";
            // 
            // saveTemplates
            // 
            this.saveTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTemplates.Location = new System.Drawing.Point(1045, 424);
            this.saveTemplates.Name = "saveTemplates";
            this.saveTemplates.Size = new System.Drawing.Size(75, 23);
            this.saveTemplates.TabIndex = 42;
            this.saveTemplates.Text = "Save";
            this.saveTemplates.UseVisualStyleBackColor = true;
            // 
            // template2s
            // 
            this.template2s.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.template2s.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.template2s.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.Edit,
            this.Copy,
            this.Edit2,
            this.Debug,
            this.Active,
            this.Name_,
            this.Group,
            this.OrderWeight,
            this.UsedTime,
            this.Comment,
            this.ModifiedTime,
            this.DocumentParserClass});
            this.template2s.Location = new System.Drawing.Point(12, 12);
            this.template2s.MultiSelect = false;
            this.template2s.Name = "template2s";
            this.template2s.RowHeadersWidth = 102;
            this.template2s.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.template2s.Size = new System.Drawing.Size(860, 435);
            this.template2s.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.orderWeightChange);
            this.groupBox2.Controls.Add(this.applyOrderWeightChange);
            this.groupBox2.Controls.Add(this.applyActiveChange);
            this.groupBox2.Controls.Add(this.applyGroupChange);
            this.groupBox2.Controls.Add(this.activeChange);
            this.groupBox2.Controls.Add(this.groupChange);
            this.groupBox2.Location = new System.Drawing.Point(878, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 124);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Selected";
            // 
            // orderWeightChange
            // 
            this.orderWeightChange.DecimalPlaces = 1;
            this.orderWeightChange.Location = new System.Drawing.Point(81, 92);
            this.orderWeightChange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.orderWeightChange.Name = "orderWeightChange";
            this.orderWeightChange.Size = new System.Drawing.Size(61, 20);
            this.orderWeightChange.TabIndex = 33;
            // 
            // applyOrderWeightChange
            // 
            this.applyOrderWeightChange.Location = new System.Drawing.Point(14, 92);
            this.applyOrderWeightChange.Name = "applyOrderWeightChange";
            this.applyOrderWeightChange.Size = new System.Drawing.Size(60, 23);
            this.applyOrderWeightChange.TabIndex = 31;
            this.applyOrderWeightChange.Text = "Order =";
            this.applyOrderWeightChange.UseVisualStyleBackColor = true;
            // 
            // applyActiveChange
            // 
            this.applyActiveChange.Location = new System.Drawing.Point(14, 22);
            this.applyActiveChange.Name = "applyActiveChange";
            this.applyActiveChange.Size = new System.Drawing.Size(60, 23);
            this.applyActiveChange.TabIndex = 30;
            this.applyActiveChange.Text = "Active =";
            this.applyActiveChange.UseVisualStyleBackColor = true;
            // 
            // applyGroupChange
            // 
            this.applyGroupChange.Location = new System.Drawing.Point(14, 57);
            this.applyGroupChange.Name = "applyGroupChange";
            this.applyGroupChange.Size = new System.Drawing.Size(60, 23);
            this.applyGroupChange.TabIndex = 29;
            this.applyGroupChange.Text = "Group =";
            this.applyGroupChange.UseVisualStyleBackColor = true;
            // 
            // activeChange
            // 
            this.activeChange.AutoSize = true;
            this.activeChange.Checked = true;
            this.activeChange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeChange.Location = new System.Drawing.Point(81, 27);
            this.activeChange.Name = "activeChange";
            this.activeChange.Size = new System.Drawing.Size(15, 14);
            this.activeChange.TabIndex = 25;
            this.activeChange.UseVisualStyleBackColor = true;
            // 
            // groupChange
            // 
            this.groupChange.Location = new System.Drawing.Point(81, 59);
            this.groupChange.Name = "groupChange";
            this.groupChange.Size = new System.Drawing.Size(145, 20);
            this.groupChange.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lRefreshSelectedCounter);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.selectedTemplatesCount);
            this.groupBox1.Controls.Add(this.orderWeightPattern2);
            this.groupBox1.Controls.Add(this.orderWeightPattern1);
            this.groupBox1.Controls.Add(this.commentPattern);
            this.groupBox1.Controls.Add(this.useOrderWeightPattern);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.useCommentPattern);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.sortSelectedUp);
            this.groupBox1.Controls.Add(this.useNamePattern);
            this.groupBox1.Controls.Add(this.useGroupPattern);
            this.groupBox1.Controls.Add(this.useActivePattern);
            this.groupBox1.Controls.Add(this.selectByFilter);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.activePattern);
            this.groupBox1.Controls.Add(this.selectInvertion);
            this.groupBox1.Controls.Add(this.selectNothing);
            this.groupBox1.Controls.Add(this.selectAll);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupPattern);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.namePattern);
            this.groupBox1.Location = new System.Drawing.Point(878, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 267);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select";
            // 
            // lRefreshSelectedCounter
            // 
            this.lRefreshSelectedCounter.AutoSize = true;
            this.lRefreshSelectedCounter.Location = new System.Drawing.Point(190, 241);
            this.lRefreshSelectedCounter.Name = "lRefreshSelectedCounter";
            this.lRefreshSelectedCounter.Size = new System.Drawing.Size(44, 13);
            this.lRefreshSelectedCounter.TabIndex = 51;
            this.lRefreshSelectedCounter.TabStop = true;
            this.lRefreshSelectedCounter.Text = "Refresh";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "-";
            // 
            // selectedTemplatesCount
            // 
            this.selectedTemplatesCount.AutoSize = true;
            this.selectedTemplatesCount.Location = new System.Drawing.Point(14, 241);
            this.selectedTemplatesCount.Name = "selectedTemplatesCount";
            this.selectedTemplatesCount.Size = new System.Drawing.Size(16, 13);
            this.selectedTemplatesCount.TabIndex = 49;
            this.selectedTemplatesCount.Text = "...";
            // 
            // orderWeightPattern2
            // 
            this.orderWeightPattern2.DecimalPlaces = 1;
            this.orderWeightPattern2.Location = new System.Drawing.Point(171, 132);
            this.orderWeightPattern2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.orderWeightPattern2.Name = "orderWeightPattern2";
            this.orderWeightPattern2.Size = new System.Drawing.Size(63, 20);
            this.orderWeightPattern2.TabIndex = 48;
            // 
            // orderWeightPattern1
            // 
            this.orderWeightPattern1.DecimalPlaces = 1;
            this.orderWeightPattern1.Location = new System.Drawing.Point(89, 132);
            this.orderWeightPattern1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.orderWeightPattern1.Name = "orderWeightPattern1";
            this.orderWeightPattern1.Size = new System.Drawing.Size(63, 20);
            this.orderWeightPattern1.TabIndex = 47;
            // 
            // commentPattern
            // 
            this.commentPattern.Location = new System.Drawing.Point(89, 102);
            this.commentPattern.Name = "commentPattern";
            this.commentPattern.Size = new System.Drawing.Size(145, 20);
            this.commentPattern.TabIndex = 41;
            // 
            // useOrderWeightPattern
            // 
            this.useOrderWeightPattern.AutoSize = true;
            this.useOrderWeightPattern.Checked = true;
            this.useOrderWeightPattern.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useOrderWeightPattern.Location = new System.Drawing.Point(14, 133);
            this.useOrderWeightPattern.Name = "useOrderWeightPattern";
            this.useOrderWeightPattern.Size = new System.Drawing.Size(15, 14);
            this.useOrderWeightPattern.TabIndex = 46;
            this.useOrderWeightPattern.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Order:";
            // 
            // useCommentPattern
            // 
            this.useCommentPattern.AutoSize = true;
            this.useCommentPattern.Checked = true;
            this.useCommentPattern.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useCommentPattern.Location = new System.Drawing.Point(14, 105);
            this.useCommentPattern.Name = "useCommentPattern";
            this.useCommentPattern.Size = new System.Drawing.Size(15, 14);
            this.useCommentPattern.TabIndex = 43;
            this.useCommentPattern.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Comment:";
            // 
            // sortSelectedUp
            // 
            this.sortSelectedUp.AutoSize = true;
            this.sortSelectedUp.Location = new System.Drawing.Point(14, 162);
            this.sortSelectedUp.Name = "sortSelectedUp";
            this.sortSelectedUp.Size = new System.Drawing.Size(107, 17);
            this.sortSelectedUp.TabIndex = 40;
            this.sortSelectedUp.Text = "Sort Selected Up";
            this.sortSelectedUp.UseVisualStyleBackColor = true;
            // 
            // useNamePattern
            // 
            this.useNamePattern.AutoSize = true;
            this.useNamePattern.Checked = true;
            this.useNamePattern.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useNamePattern.Location = new System.Drawing.Point(14, 49);
            this.useNamePattern.Name = "useNamePattern";
            this.useNamePattern.Size = new System.Drawing.Size(15, 14);
            this.useNamePattern.TabIndex = 38;
            this.useNamePattern.UseVisualStyleBackColor = true;
            // 
            // useGroupPattern
            // 
            this.useGroupPattern.AutoSize = true;
            this.useGroupPattern.Checked = true;
            this.useGroupPattern.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useGroupPattern.Location = new System.Drawing.Point(14, 77);
            this.useGroupPattern.Name = "useGroupPattern";
            this.useGroupPattern.Size = new System.Drawing.Size(15, 14);
            this.useGroupPattern.TabIndex = 37;
            this.useGroupPattern.UseVisualStyleBackColor = true;
            // 
            // useActivePattern
            // 
            this.useActivePattern.AutoSize = true;
            this.useActivePattern.Checked = true;
            this.useActivePattern.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useActivePattern.Location = new System.Drawing.Point(14, 22);
            this.useActivePattern.Name = "useActivePattern";
            this.useActivePattern.Size = new System.Drawing.Size(15, 14);
            this.useActivePattern.TabIndex = 35;
            this.useActivePattern.UseVisualStyleBackColor = true;
            // 
            // selectByFilter
            // 
            this.selectByFilter.Location = new System.Drawing.Point(174, 173);
            this.selectByFilter.Name = "selectByFilter";
            this.selectByFilter.Size = new System.Drawing.Size(60, 23);
            this.selectByFilter.TabIndex = 34;
            this.selectByFilter.Text = "Apply";
            this.selectByFilter.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Active:";
            // 
            // activePattern
            // 
            this.activePattern.AutoSize = true;
            this.activePattern.Location = new System.Drawing.Point(89, 22);
            this.activePattern.Name = "activePattern";
            this.activePattern.Size = new System.Drawing.Size(15, 14);
            this.activePattern.TabIndex = 32;
            this.activePattern.UseVisualStyleBackColor = true;
            // 
            // selectInvertion
            // 
            this.selectInvertion.Location = new System.Drawing.Point(174, 206);
            this.selectInvertion.Name = "selectInvertion";
            this.selectInvertion.Size = new System.Drawing.Size(60, 23);
            this.selectInvertion.TabIndex = 28;
            this.selectInvertion.Text = "Invert";
            this.selectInvertion.UseVisualStyleBackColor = true;
            // 
            // selectNothing
            // 
            this.selectNothing.Location = new System.Drawing.Point(93, 206);
            this.selectNothing.Name = "selectNothing";
            this.selectNothing.Size = new System.Drawing.Size(60, 23);
            this.selectNothing.TabIndex = 27;
            this.selectNothing.Text = "Nothing";
            this.selectNothing.UseVisualStyleBackColor = true;
            // 
            // selectAll
            // 
            this.selectAll.Location = new System.Drawing.Point(17, 206);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(60, 23);
            this.selectAll.TabIndex = 26;
            this.selectAll.Text = "All";
            this.selectAll.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Group:";
            // 
            // groupPattern
            // 
            this.groupPattern.Location = new System.Drawing.Point(89, 72);
            this.groupPattern.Name = "groupPattern";
            this.groupPattern.Size = new System.Drawing.Size(145, 20);
            this.groupPattern.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Name:";
            // 
            // namePattern
            // 
            this.namePattern.Location = new System.Drawing.Point(89, 43);
            this.namePattern.Name = "namePattern";
            this.namePattern.Size = new System.Drawing.Size(145, 20);
            this.namePattern.TabIndex = 19;
            // 
            // Selected
            // 
            this.Selected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Selected.HeaderText = "";
            this.Selected.MinimumWidth = 12;
            this.Selected.Name = "Selected";
            this.Selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Selected.Width = 21;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit.HeaderText = "";
            this.Edit.MinimumWidth = 12;
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 21;
            // 
            // Copy
            // 
            this.Copy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Copy.HeaderText = "";
            this.Copy.MinimumWidth = 12;
            this.Copy.Name = "Copy";
            this.Copy.Text = "Copy";
            this.Copy.UseColumnTextForButtonValue = true;
            this.Copy.Width = 21;
            // 
            // Edit2
            // 
            this.Edit2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit2.HeaderText = "";
            this.Edit2.MinimumWidth = 12;
            this.Edit2.Name = "Edit2";
            this.Edit2.Text = "Edit2";
            this.Edit2.UseColumnTextForButtonValue = true;
            this.Edit2.Width = 21;
            // 
            // Debug
            // 
            this.Debug.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Debug.HeaderText = "";
            this.Debug.MinimumWidth = 12;
            this.Debug.Name = "Debug";
            this.Debug.Text = "Debug";
            this.Debug.UseColumnTextForButtonValue = true;
            this.Debug.Width = 21;
            // 
            // Active
            // 
            this.Active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Active.HeaderText = "Active";
            this.Active.MinimumWidth = 12;
            this.Active.Name = "Active";
            this.Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Active.Width = 62;
            // 
            // Name_
            // 
            this.Name_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Name_.DefaultCellStyle = dataGridViewCellStyle1;
            this.Name_.HeaderText = "Name";
            this.Name_.MinimumWidth = 12;
            this.Name_.Name = "Name_";
            this.Name_.Width = 60;
            // 
            // Group
            // 
            this.Group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Group.HeaderText = "Group";
            this.Group.MinimumWidth = 12;
            this.Group.Name = "Group";
            this.Group.Width = 61;
            // 
            // OrderWeight
            // 
            this.OrderWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OrderWeight.HeaderText = "Order";
            this.OrderWeight.MaxInputLength = 10;
            this.OrderWeight.MinimumWidth = 12;
            this.OrderWeight.Name = "OrderWeight";
            this.OrderWeight.Width = 58;
            // 
            // UsedTime
            // 
            this.UsedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UsedTime.HeaderText = "Used";
            this.UsedTime.MinimumWidth = 12;
            this.UsedTime.Name = "UsedTime";
            this.UsedTime.ReadOnly = true;
            this.UsedTime.Width = 57;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.MinimumWidth = 12;
            this.Comment.Name = "Comment";
            this.Comment.Width = 250;
            // 
            // ModifiedTime
            // 
            this.ModifiedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ModifiedTime.HeaderText = "Modified";
            this.ModifiedTime.MinimumWidth = 12;
            this.ModifiedTime.Name = "ModifiedTime";
            this.ModifiedTime.ReadOnly = true;
            this.ModifiedTime.Width = 72;
            // 
            // DocumentParserClass
            // 
            this.DocumentParserClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DocumentParserClass.HeaderText = "DocumentParserClass";
            this.DocumentParserClass.MinimumWidth = 12;
            this.DocumentParserClass.Name = "DocumentParserClass";
            this.DocumentParserClass.Width = 136;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 500);
            this.Controls.Add(this.saveTemplates);
            this.Controls.Add(this.template2s);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.progress);
            this.MinimumSize = new System.Drawing.Size(502, 286);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.template2s)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderWeightChange)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderWeightPattern2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderWeightPattern1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lProgress;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label lProgressTask;
        private System.Windows.Forms.Label lProgressCurrentBlock;
        private System.Windows.Forms.Button saveTemplates;
        private System.Windows.Forms.DataGridView template2s;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown orderWeightChange;
        private System.Windows.Forms.Button applyOrderWeightChange;
        private System.Windows.Forms.Button applyActiveChange;
        private System.Windows.Forms.Button applyGroupChange;
        private System.Windows.Forms.CheckBox activeChange;
        private System.Windows.Forms.TextBox groupChange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lRefreshSelectedCounter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label selectedTemplatesCount;
        private System.Windows.Forms.NumericUpDown orderWeightPattern2;
        private System.Windows.Forms.NumericUpDown orderWeightPattern1;
        private System.Windows.Forms.TextBox commentPattern;
        private System.Windows.Forms.CheckBox useOrderWeightPattern;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox useCommentPattern;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox sortSelectedUp;
        private System.Windows.Forms.CheckBox useNamePattern;
        private System.Windows.Forms.CheckBox useGroupPattern;
        private System.Windows.Forms.CheckBox useActivePattern;
        private System.Windows.Forms.Button selectByFilter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox activePattern;
        private System.Windows.Forms.Button selectInvertion;
        private System.Windows.Forms.Button selectNothing;
        private System.Windows.Forms.Button selectAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox groupPattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox namePattern;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Copy;
        private System.Windows.Forms.DataGridViewButtonColumn Edit2;
        private System.Windows.Forms.DataGridViewButtonColumn Debug;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentParserClass;
    }
}