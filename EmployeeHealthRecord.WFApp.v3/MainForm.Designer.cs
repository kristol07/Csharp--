namespace EmployeeHealthRecord.WFApp.v3
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHealthRecorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.databaseContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlySuspectEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlySuspectEployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewRecordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchTipLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ginNumberGroupBox = new System.Windows.Forms.GroupBox();
            this.ginNumberTipLabel = new System.Windows.Forms.Label();
            this.ginNumberTextBox = new System.Windows.Forms.TextBox();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.nameTipLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.checkdateGroupBox = new System.Windows.Forms.GroupBox();
            this.checkdateTipLabel = new System.Windows.Forms.Label();
            this.checkdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.bodyTemperatureGroupBox = new System.Windows.Forms.GroupBox();
            this.bodyTemperatureTipLabel = new System.Windows.Forms.Label();
            this.bodyTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.hasHubeiTravelHistoryCheckBox = new System.Windows.Forms.CheckBox();
            this.hasSymptomsCheckBox = new System.Windows.Forms.CheckBox();
            this.notesGroupBox = new System.Windows.Forms.GroupBox();
            this.notesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDatabaseDataGridView = new System.Windows.Forms.DataGridView();
            this.viewOnlySuspectCheckBox = new System.Windows.Forms.CheckBox();
            this.ginNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bodyTemperatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasHubeiTravelHistoryDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hasSymptomsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.symptomsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.databaseContextMenuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.ginNumberGroupBox.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            this.checkdateGroupBox.SuspendLayout();
            this.bodyTemperatureGroupBox.SuspendLayout();
            this.notesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDatabaseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(3, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1020, 25);
            this.menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openFileToolStripMenuItem.Text = "&Open File...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveAsToolStripMenuItem.Text = "&Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewRecordToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.databaseToolStripMenuItem.Text = "&Database";
            // 
            // addNewRecordToolStripMenuItem
            // 
            this.addNewRecordToolStripMenuItem.Name = "addNewRecordToolStripMenuItem";
            this.addNewRecordToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.addNewRecordToolStripMenuItem.Text = "&Add New Record...";
            this.addNewRecordToolStripMenuItem.Click += new System.EventHandler(this.addNewRecordToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCodeToolStripMenuItem,
            this.aboutHealthRecorderToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // viewCodeToolStripMenuItem
            // 
            this.viewCodeToolStripMenuItem.Name = "viewCodeToolStripMenuItem";
            this.viewCodeToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.viewCodeToolStripMenuItem.Text = "&View Code";
            this.viewCodeToolStripMenuItem.Click += new System.EventHandler(this.ViewCodeToolStripMenuItem_Click);
            // 
            // aboutHealthRecorderToolStripMenuItem
            // 
            this.aboutHealthRecorderToolStripMenuItem.Name = "aboutHealthRecorderToolStripMenuItem";
            this.aboutHealthRecorderToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.aboutHealthRecorderToolStripMenuItem.Text = "&About Employee Health Recorder";
            this.aboutHealthRecorderToolStripMenuItem.Click += new System.EventHandler(this.AboutHealthRecorderToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel1.Size = new System.Drawing.Size(1017, 565);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1011, 565);
            this.splitContainer1.SplitterDistance = 746;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.employeeDatabaseDataGridView);
            this.groupBox1.Controls.Add(this.searchLabel);
            this.groupBox1.Controls.Add(this.searchTextBox);
            this.groupBox1.Controls.Add(this.searchTipLabel);
            this.groupBox1.Controls.Add(this.viewOnlySuspectCheckBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 565);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Records";
            // 
            // databaseContextMenuStrip
            // 
            this.databaseContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromFileToolStripMenuItem,
            this.saveAsToolStripMenuItem1,
            this.viewOnlySuspectEmployeeToolStripMenuItem,
            this.addNewRecordToolStripMenuItem1,
            this.deleteCurrentRecordToolStripMenuItem});
            this.databaseContextMenuStrip.Name = "databaseContextMenuStrip";
            this.databaseContextMenuStrip.Size = new System.Drawing.Size(207, 114);
            // 
            // importFromFileToolStripMenuItem
            // 
            this.importFromFileToolStripMenuItem.Name = "importFromFileToolStripMenuItem";
            this.importFromFileToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.importFromFileToolStripMenuItem.Text = "Import From...";
            this.importFromFileToolStripMenuItem.Click += new System.EventHandler(this.ImportFromFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
            this.saveAsToolStripMenuItem1.Text = "Save As...";
            this.saveAsToolStripMenuItem1.Click += new System.EventHandler(this.SaveAsToolStripMenuItem1_Click);
            // 
            // viewOnlySuspectEmployeeToolStripMenuItem
            // 
            this.viewOnlySuspectEmployeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewOnlySuspectEployeeToolStripMenuItem,
            this.viewAllEmployeesToolStripMenuItem});
            this.viewOnlySuspectEmployeeToolStripMenuItem.Name = "viewOnlySuspectEmployeeToolStripMenuItem";
            this.viewOnlySuspectEmployeeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.viewOnlySuspectEmployeeToolStripMenuItem.Text = "Choose View...";
            // 
            // viewOnlySuspectEployeeToolStripMenuItem
            // 
            this.viewOnlySuspectEployeeToolStripMenuItem.Name = "viewOnlySuspectEployeeToolStripMenuItem";
            this.viewOnlySuspectEployeeToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.viewOnlySuspectEployeeToolStripMenuItem.Text = "View Only Suspect Employees";
            this.viewOnlySuspectEployeeToolStripMenuItem.Click += new System.EventHandler(this.ViewOnlySuspectEployeeToolStripMenuItem_Click);
            // 
            // viewAllEmployeesToolStripMenuItem
            // 
            this.viewAllEmployeesToolStripMenuItem.Name = "viewAllEmployeesToolStripMenuItem";
            this.viewAllEmployeesToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.viewAllEmployeesToolStripMenuItem.Text = "View All Employees";
            this.viewAllEmployeesToolStripMenuItem.Click += new System.EventHandler(this.ViewAllEmployeesToolStripMenuItem_Click);
            // 
            // addNewRecordToolStripMenuItem1
            // 
            this.addNewRecordToolStripMenuItem1.Name = "addNewRecordToolStripMenuItem1";
            this.addNewRecordToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
            this.addNewRecordToolStripMenuItem1.Text = "Add New Record";
            // 
            // deleteCurrentRecordToolStripMenuItem
            // 
            this.deleteCurrentRecordToolStripMenuItem.Name = "deleteCurrentRecordToolStripMenuItem";
            this.deleteCurrentRecordToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.deleteCurrentRecordToolStripMenuItem.Text = "Delete Current Record";
            // 
            // searchLabel
            // 
            this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchLabel.Location = new System.Drawing.Point(6, 22);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(136, 17);
            this.searchLabel.TabIndex = 2;
            this.searchLabel.Text = "Search by GinNumber";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.searchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchTextBox.Location = new System.Drawing.Point(148, 19);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(115, 23);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // searchTipLabel
            // 
            this.searchTipLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTipLabel.AutoSize = true;
            this.searchTipLabel.Location = new System.Drawing.Point(269, 22);
            this.searchTipLabel.Name = "searchTipLabel";
            this.searchTipLabel.Size = new System.Drawing.Size(0, 17);
            this.searchTipLabel.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 565);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update Record";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.ginNumberGroupBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.nameGroupBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkdateGroupBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.bodyTemperatureGroupBox, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.hasHubeiTravelHistoryCheckBox, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.notesGroupBox, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.saveButton, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.deleteButton, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.clearButton, 2, 7);
            this.tableLayoutPanel3.Controls.Add(this.hasSymptomsCheckBox, 0, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.07513F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.07513F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.07513F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.07513F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.261194F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.261194F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.13953F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.037565F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(255, 543);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // ginNumberGroupBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.ginNumberGroupBox, 3);
            this.ginNumberGroupBox.Controls.Add(this.ginNumberTipLabel);
            this.ginNumberGroupBox.Controls.Add(this.ginNumberTextBox);
            this.ginNumberGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ginNumberGroupBox.Location = new System.Drawing.Point(6, 3);
            this.ginNumberGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.ginNumberGroupBox.Name = "ginNumberGroupBox";
            this.ginNumberGroupBox.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.ginNumberGroupBox.Size = new System.Drawing.Size(243, 70);
            this.ginNumberGroupBox.TabIndex = 0;
            this.ginNumberGroupBox.TabStop = false;
            this.ginNumberGroupBox.Text = "GinNumber";
            // 
            // ginNumberTipLabel
            // 
            this.ginNumberTipLabel.AutoSize = true;
            this.ginNumberTipLabel.Location = new System.Drawing.Point(10, 45);
            this.ginNumberTipLabel.Name = "ginNumberTipLabel";
            this.ginNumberTipLabel.Size = new System.Drawing.Size(0, 17);
            this.ginNumberTipLabel.TabIndex = 1;
            // 
            // ginNumberTextBox
            // 
            this.ginNumberTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ginNumberTextBox.Location = new System.Drawing.Point(6, 19);
            this.ginNumberTextBox.Name = "ginNumberTextBox";
            this.ginNumberTextBox.Size = new System.Drawing.Size(231, 23);
            this.ginNumberTextBox.TabIndex = 0;
            this.ginNumberTextBox.TextChanged += new System.EventHandler(this.GinNumberTextBox_TextChanged);
            // 
            // nameGroupBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.nameGroupBox, 3);
            this.nameGroupBox.Controls.Add(this.nameTipLabel);
            this.nameGroupBox.Controls.Add(this.nameTextBox);
            this.nameGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameGroupBox.Location = new System.Drawing.Point(6, 79);
            this.nameGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.nameGroupBox.Size = new System.Drawing.Size(243, 70);
            this.nameGroupBox.TabIndex = 1;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // nameTipLabel
            // 
            this.nameTipLabel.AutoSize = true;
            this.nameTipLabel.Location = new System.Drawing.Point(9, 45);
            this.nameTipLabel.Name = "nameTipLabel";
            this.nameTipLabel.Size = new System.Drawing.Size(0, 17);
            this.nameTipLabel.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameTextBox.Location = new System.Drawing.Point(6, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(231, 23);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // checkdateGroupBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.checkdateGroupBox, 3);
            this.checkdateGroupBox.Controls.Add(this.checkdateTipLabel);
            this.checkdateGroupBox.Controls.Add(this.checkdateTimePicker);
            this.checkdateGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkdateGroupBox.Location = new System.Drawing.Point(6, 155);
            this.checkdateGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.checkdateGroupBox.Name = "checkdateGroupBox";
            this.checkdateGroupBox.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.checkdateGroupBox.Size = new System.Drawing.Size(243, 70);
            this.checkdateGroupBox.TabIndex = 2;
            this.checkdateGroupBox.TabStop = false;
            this.checkdateGroupBox.Text = "Check Date";
            // 
            // checkdateTipLabel
            // 
            this.checkdateTipLabel.AutoSize = true;
            this.checkdateTipLabel.Location = new System.Drawing.Point(10, 45);
            this.checkdateTipLabel.Name = "checkdateTipLabel";
            this.checkdateTipLabel.Size = new System.Drawing.Size(0, 17);
            this.checkdateTipLabel.TabIndex = 1;
            // 
            // checkdateTimePicker
            // 
            this.checkdateTimePicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkdateTimePicker.Location = new System.Drawing.Point(6, 19);
            this.checkdateTimePicker.Name = "checkdateTimePicker";
            this.checkdateTimePicker.Size = new System.Drawing.Size(231, 23);
            this.checkdateTimePicker.TabIndex = 0;
            this.checkdateTimePicker.ValueChanged += new System.EventHandler(this.CheckdateTimePicker_ValueChanged);
            // 
            // bodyTemperatureGroupBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.bodyTemperatureGroupBox, 3);
            this.bodyTemperatureGroupBox.Controls.Add(this.bodyTemperatureTipLabel);
            this.bodyTemperatureGroupBox.Controls.Add(this.bodyTemperatureTextBox);
            this.bodyTemperatureGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTemperatureGroupBox.Location = new System.Drawing.Point(6, 231);
            this.bodyTemperatureGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.bodyTemperatureGroupBox.Name = "bodyTemperatureGroupBox";
            this.bodyTemperatureGroupBox.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.bodyTemperatureGroupBox.Size = new System.Drawing.Size(243, 70);
            this.bodyTemperatureGroupBox.TabIndex = 3;
            this.bodyTemperatureGroupBox.TabStop = false;
            this.bodyTemperatureGroupBox.Text = "Body Temperature";
            // 
            // bodyTemperatureTipLabel
            // 
            this.bodyTemperatureTipLabel.AutoSize = true;
            this.bodyTemperatureTipLabel.Location = new System.Drawing.Point(10, 45);
            this.bodyTemperatureTipLabel.Name = "bodyTemperatureTipLabel";
            this.bodyTemperatureTipLabel.Size = new System.Drawing.Size(0, 17);
            this.bodyTemperatureTipLabel.TabIndex = 1;
            // 
            // bodyTemperatureTextBox
            // 
            this.bodyTemperatureTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.bodyTemperatureTextBox.Location = new System.Drawing.Point(6, 19);
            this.bodyTemperatureTextBox.Name = "bodyTemperatureTextBox";
            this.bodyTemperatureTextBox.Size = new System.Drawing.Size(231, 23);
            this.bodyTemperatureTextBox.TabIndex = 0;
            this.bodyTemperatureTextBox.TextChanged += new System.EventHandler(this.BodyTemperatureTextBox_TextChanged);
            // 
            // hasHubeiTravelHistoryCheckBox
            // 
            this.hasHubeiTravelHistoryCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hasHubeiTravelHistoryCheckBox.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.hasHubeiTravelHistoryCheckBox, 3);
            this.hasHubeiTravelHistoryCheckBox.Location = new System.Drawing.Point(6, 307);
            this.hasHubeiTravelHistoryCheckBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.hasHubeiTravelHistoryCheckBox.Name = "hasHubeiTravelHistoryCheckBox";
            this.hasHubeiTravelHistoryCheckBox.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.hasHubeiTravelHistoryCheckBox.Size = new System.Drawing.Size(177, 21);
            this.hasHubeiTravelHistoryCheckBox.TabIndex = 4;
            this.hasHubeiTravelHistoryCheckBox.Text = "Has Hubei Travel History";
            this.hasHubeiTravelHistoryCheckBox.UseVisualStyleBackColor = true;
            this.hasHubeiTravelHistoryCheckBox.CheckedChanged += new System.EventHandler(this.HasHubeiTravelHistoryCheckBox_CheckedChanged);
            // 
            // hasSymptomsCheckBox
            // 
            this.hasSymptomsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hasSymptomsCheckBox.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.hasSymptomsCheckBox, 3);
            this.hasSymptomsCheckBox.Location = new System.Drawing.Point(6, 335);
            this.hasSymptomsCheckBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.hasSymptomsCheckBox.Name = "hasSymptomsCheckBox";
            this.hasSymptomsCheckBox.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.hasSymptomsCheckBox.Size = new System.Drawing.Size(145, 21);
            this.hasSymptomsCheckBox.TabIndex = 5;
            this.hasSymptomsCheckBox.Text = "Has Any Symptoms";
            this.hasSymptomsCheckBox.UseVisualStyleBackColor = true;
            this.hasSymptomsCheckBox.CheckedChanged += new System.EventHandler(this.HasSymptomsCheckBox_CheckedChanged);
            // 
            // notesGroupBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.notesGroupBox, 3);
            this.notesGroupBox.Controls.Add(this.notesRichTextBox);
            this.notesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesGroupBox.Location = new System.Drawing.Point(6, 363);
            this.notesGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.notesGroupBox.Name = "notesGroupBox";
            this.notesGroupBox.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.notesGroupBox.Size = new System.Drawing.Size(243, 135);
            this.notesGroupBox.TabIndex = 6;
            this.notesGroupBox.TabStop = false;
            this.notesGroupBox.Text = "Notes";
            // 
            // notesRichTextBox
            // 
            this.notesRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.notesRichTextBox.Name = "notesRichTextBox";
            this.notesRichTextBox.Size = new System.Drawing.Size(231, 110);
            this.notesRichTextBox.TabIndex = 0;
            this.notesRichTextBox.Text = "";
            this.notesRichTextBox.TextChanged += new System.EventHandler(this.NotesRichTextBox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveButton.Location = new System.Drawing.Point(11, 509);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(62, 26);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButtonToolTip.SetToolTip(this.saveButton, "Save current changes. If GinNumber is new, Add new record to database.");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteButton.Location = new System.Drawing.Point(95, 509);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(62, 26);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clearButton.Location = new System.Drawing.Point(180, 509);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(62, 26);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "CSV Files|*.csv|TXT Files|*.txt";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "CSV Files|*.csv|TXT Files|*.txt";
            // 
            // Notes
            // 
            this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            // 
            // employeeDatabaseDataGridView
            // 
            this.employeeDatabaseDataGridView.AllowUserToAddRows = false;
            this.employeeDatabaseDataGridView.AllowUserToDeleteRows = false;
            this.employeeDatabaseDataGridView.AllowUserToResizeRows = false;
            this.employeeDatabaseDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeDatabaseDataGridView.AutoGenerateColumns = false;
            this.employeeDatabaseDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.employeeDatabaseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDatabaseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ginNumberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.bodyTemperatureDataGridViewTextBoxColumn,
            this.hasHubeiTravelHistoryDataGridViewCheckBoxColumn,
            this.hasSymptomsDataGridViewCheckBoxColumn,
            this.Notes,
            this.symptomsDataGridViewTextBoxColumn});
            this.employeeDatabaseDataGridView.ContextMenuStrip = this.databaseContextMenuStrip;
            this.employeeDatabaseDataGridView.DataSource = this.employeeBindingSource;
            this.employeeDatabaseDataGridView.Location = new System.Drawing.Point(9, 50);
            this.employeeDatabaseDataGridView.Name = "employeeDatabaseDataGridView";
            this.employeeDatabaseDataGridView.ReadOnly = true;
            this.employeeDatabaseDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.employeeDatabaseDataGridView.RowTemplate.Height = 23;
            this.employeeDatabaseDataGridView.Size = new System.Drawing.Size(728, 505);
            this.employeeDatabaseDataGridView.TabIndex = 4;
            // 
            // viewOnlySuspectCheckBox
            // 
            this.viewOnlySuspectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewOnlySuspectCheckBox.AutoSize = true;
            this.viewOnlySuspectCheckBox.Location = new System.Drawing.Point(534, 21);
            this.viewOnlySuspectCheckBox.Name = "viewOnlySuspectCheckBox";
            this.viewOnlySuspectCheckBox.Size = new System.Drawing.Size(200, 21);
            this.viewOnlySuspectCheckBox.TabIndex = 1;
            this.viewOnlySuspectCheckBox.Text = "View Only Suspect Employees";
            this.viewOnlySuspectCheckBox.UseVisualStyleBackColor = true;
            this.viewOnlySuspectCheckBox.CheckedChanged += new System.EventHandler(this.ViewOnlySuspectCheckBox_CheckedChanged);
            // 
            // ginNumberDataGridViewTextBoxColumn
            // 
            this.ginNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ginNumberDataGridViewTextBoxColumn.DataPropertyName = "GinNumber";
            this.ginNumberDataGridViewTextBoxColumn.HeaderText = "GinNumber";
            this.ginNumberDataGridViewTextBoxColumn.Name = "ginNumberDataGridViewTextBoxColumn";
            this.ginNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 68;
            // 
            // bodyTemperatureDataGridViewTextBoxColumn
            // 
            this.bodyTemperatureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.bodyTemperatureDataGridViewTextBoxColumn.DataPropertyName = "BodyTemperature";
            this.bodyTemperatureDataGridViewTextBoxColumn.HeaderText = "BodyTemperature";
            this.bodyTemperatureDataGridViewTextBoxColumn.Name = "bodyTemperatureDataGridViewTextBoxColumn";
            this.bodyTemperatureDataGridViewTextBoxColumn.ReadOnly = true;
            this.bodyTemperatureDataGridViewTextBoxColumn.Width = 138;
            // 
            // hasHubeiTravelHistoryDataGridViewCheckBoxColumn
            // 
            this.hasHubeiTravelHistoryDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.hasHubeiTravelHistoryDataGridViewCheckBoxColumn.DataPropertyName = "HasHubeiTravelHistory";
            this.hasHubeiTravelHistoryDataGridViewCheckBoxColumn.HeaderText = "HasHubeiTravelHistory";
            this.hasHubeiTravelHistoryDataGridViewCheckBoxColumn.Name = "hasHubeiTravelHistoryDataGridViewCheckBoxColumn";
            this.hasHubeiTravelHistoryDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasHubeiTravelHistoryDataGridViewCheckBoxColumn.Width = 146;
            // 
            // hasSymptomsDataGridViewCheckBoxColumn
            // 
            this.hasSymptomsDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.hasSymptomsDataGridViewCheckBoxColumn.DataPropertyName = "HasSymptoms";
            this.hasSymptomsDataGridViewCheckBoxColumn.HeaderText = "HasSymptoms";
            this.hasSymptomsDataGridViewCheckBoxColumn.Name = "hasSymptomsDataGridViewCheckBoxColumn";
            this.hasSymptomsDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasSymptomsDataGridViewCheckBoxColumn.Width = 97;
            // 
            // symptomsDataGridViewTextBoxColumn
            // 
            this.symptomsDataGridViewTextBoxColumn.DataPropertyName = "Symptoms";
            this.symptomsDataGridViewTextBoxColumn.HeaderText = "Symptoms";
            this.symptomsDataGridViewTextBoxColumn.Name = "symptomsDataGridViewTextBoxColumn";
            this.symptomsDataGridViewTextBoxColumn.ReadOnly = true;
            this.symptomsDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(EmployeeHealthRecord.Employee);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1026, 601);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Text = "Employee Health Recorder v3";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.databaseContextMenuStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ginNumberGroupBox.ResumeLayout(false);
            this.ginNumberGroupBox.PerformLayout();
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.checkdateGroupBox.ResumeLayout(false);
            this.checkdateGroupBox.PerformLayout();
            this.bodyTemperatureGroupBox.ResumeLayout(false);
            this.bodyTemperatureGroupBox.PerformLayout();
            this.notesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeDatabaseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHealthRecorderToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox ginNumberGroupBox;
        private System.Windows.Forms.TextBox ginNumberTextBox;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.GroupBox checkdateGroupBox;
        private System.Windows.Forms.GroupBox bodyTemperatureGroupBox;
        private System.Windows.Forms.CheckBox hasHubeiTravelHistoryCheckBox;
        private System.Windows.Forms.CheckBox hasSymptomsCheckBox;
        private System.Windows.Forms.GroupBox notesGroupBox;
        private System.Windows.Forms.Label ginNumberTipLabel;
        private System.Windows.Forms.Label nameTipLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label checkdateTipLabel;
        private System.Windows.Forms.DateTimePicker checkdateTimePicker;
        private System.Windows.Forms.Label bodyTemperatureTipLabel;
        private System.Windows.Forms.TextBox bodyTemperatureTextBox;
        private System.Windows.Forms.RichTextBox notesRichTextBox;
        private System.Windows.Forms.Label searchTipLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ContextMenuStrip databaseContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNewRecordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOnlySuspectEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewOnlySuspectEployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolTip saveButtonToolTip;
        private System.Windows.Forms.CheckBox viewOnlySuspectCheckBox;
        private System.Windows.Forms.DataGridView employeeDatabaseDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ginNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bodyTemperatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasHubeiTravelHistoryDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasSymptomsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn symptomsDataGridViewTextBoxColumn;
    }
}

