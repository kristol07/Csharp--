﻿namespace EmployeeHealthRecord.WFApp.v3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("All Records");
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameBasedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDateBasedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewStatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlySuspectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewRecordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRecordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRecordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHealthRecorderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterCheckDateCheckBox = new System.Windows.Forms.CheckBox();
            this.filterCheckDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.viewOnlySuspectCheckBox = new System.Windows.Forms.CheckBox();
            this.filterGinNumberLabel = new System.Windows.Forms.Label();
            this.filterGinNumberTextBox = new System.Windows.Forms.TextBox();
            this.filterGinNumberTipLabel = new System.Windows.Forms.Label();
            this.employeeDatabaseDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importFromFileContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSidebarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewRecordContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCurrentRecordCntextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentRecordContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlySuspectEployeeContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllEmployeesContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recordsTreeView = new System.Windows.Forms.TreeView();
            this.treeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nameBasedContextMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDateBasedContextMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteNodeContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.ImportRecordsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveRecordsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddRecordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditRecordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteRecordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tressViewToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.nameBasedTreeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDateBasedTreeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCloseTreeviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSelectedNodeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.suspectRecordsNumberStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordsStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordsStatisticsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordsStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.navigationBarPanel = new System.Windows.Forms.Panel();
            this.treeviewLabel = new System.Windows.Forms.Label();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.menuStrip.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDatabaseDataGridView)).BeginInit();
            this.databaseContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRecordBindingSource)).BeginInit();
            this.treeViewContextMenuStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.navigationBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.viewMenuItem,
            this.recordMenuItem,
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(3, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1008, 27);
            this.menuStrip.TabIndex = 0;
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.saveAsMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileMenuItem.Text = "&File";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileMenuItem.Image")));
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openFileMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openFileMenuItem.Text = "&Open File...";
            this.openFileMenuItem.Click += new System.EventHandler(this.OpenFileMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsMenuItem.Image")));
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMenuItem.Size = new System.Drawing.Size(221, 22);
            this.saveAsMenuItem.Text = "&Save As...";
            this.saveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitMenuItem.Size = new System.Drawing.Size(221, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeViewMenuItem,
            this.filterMenuItem});
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewMenuItem.Text = "&View";
            // 
            // treeViewMenuItem
            // 
            this.treeViewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameBasedMenuItem,
            this.checkDateBasedMenuItem,
            this.deleteSelectedNodeMenuItem,
            this.treeViewStatusMenuItem});
            this.treeViewMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("treeViewMenuItem.Image")));
            this.treeViewMenuItem.Name = "treeViewMenuItem";
            this.treeViewMenuItem.Size = new System.Drawing.Size(180, 22);
            this.treeViewMenuItem.Text = "&TreeView";
            // 
            // nameBasedMenuItem
            // 
            this.nameBasedMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nameBasedMenuItem.Image")));
            this.nameBasedMenuItem.Name = "nameBasedMenuItem";
            this.nameBasedMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.N)));
            this.nameBasedMenuItem.Size = new System.Drawing.Size(249, 22);
            this.nameBasedMenuItem.Text = "&Name-Based";
            this.nameBasedMenuItem.Click += new System.EventHandler(this.NameBasedMenuItem_Click);
            // 
            // checkDateBasedMenuItem
            // 
            this.checkDateBasedMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkDateBasedMenuItem.Image")));
            this.checkDateBasedMenuItem.Name = "checkDateBasedMenuItem";
            this.checkDateBasedMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.checkDateBasedMenuItem.Size = new System.Drawing.Size(249, 22);
            this.checkDateBasedMenuItem.Text = "Check&Date-Based";
            this.checkDateBasedMenuItem.Click += new System.EventHandler(this.CheckDateBasedMenuItem_Click);
            // 
            // deleteSelectedNodeMenuItem
            // 
            this.deleteSelectedNodeMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteSelectedNodeMenuItem.Image")));
            this.deleteSelectedNodeMenuItem.Name = "deleteSelectedNodeMenuItem";
            this.deleteSelectedNodeMenuItem.Size = new System.Drawing.Size(249, 22);
            this.deleteSelectedNodeMenuItem.Text = "Delete Selected Node";
            this.deleteSelectedNodeMenuItem.Click += new System.EventHandler(this.DeleteSelectedNodeMenuItem_Click);
            // 
            // treeViewStatusMenuItem
            // 
            this.treeViewStatusMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("treeViewStatusMenuItem.Image")));
            this.treeViewStatusMenuItem.Name = "treeViewStatusMenuItem";
            this.treeViewStatusMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Space)));
            this.treeViewStatusMenuItem.Size = new System.Drawing.Size(249, 22);
            this.treeViewStatusMenuItem.Text = "&Open/Close";
            this.treeViewStatusMenuItem.Click += new System.EventHandler(this.TreeViewStatusMenuItem_Click);
            // 
            // filterMenuItem
            // 
            this.filterMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewOnlySuspectsToolStripMenuItem});
            this.filterMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filterMenuItem.Image")));
            this.filterMenuItem.Name = "filterMenuItem";
            this.filterMenuItem.Size = new System.Drawing.Size(180, 22);
            this.filterMenuItem.Text = "&Filter";
            // 
            // viewOnlySuspectsToolStripMenuItem
            // 
            this.viewOnlySuspectsToolStripMenuItem.Name = "viewOnlySuspectsToolStripMenuItem";
            this.viewOnlySuspectsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.viewOnlySuspectsToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.viewOnlySuspectsToolStripMenuItem.Text = "View Only &Suspects";
            this.viewOnlySuspectsToolStripMenuItem.Click += new System.EventHandler(this.ViewOnlySuspectsMenuItem_Click);
            // 
            // recordMenuItem
            // 
            this.recordMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewRecordMenuItem,
            this.saveRecordMenuItem,
            this.deleteRecordMenuItem});
            this.recordMenuItem.Name = "recordMenuItem";
            this.recordMenuItem.Size = new System.Drawing.Size(62, 21);
            this.recordMenuItem.Text = "&Record";
            // 
            // addNewRecordMenuItem
            // 
            this.addNewRecordMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewRecordMenuItem.Image")));
            this.addNewRecordMenuItem.Name = "addNewRecordMenuItem";
            this.addNewRecordMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addNewRecordMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addNewRecordMenuItem.Text = "&Add";
            this.addNewRecordMenuItem.Click += new System.EventHandler(this.AddNewRecordMenuItem_Click);
            // 
            // saveRecordMenuItem
            // 
            this.saveRecordMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveRecordMenuItem.Image")));
            this.saveRecordMenuItem.Name = "saveRecordMenuItem";
            this.saveRecordMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.saveRecordMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveRecordMenuItem.Text = "&Edit";
            this.saveRecordMenuItem.Click += new System.EventHandler(this.EditRecordMenuItem_Click);
            // 
            // deleteRecordMenuItem
            // 
            this.deleteRecordMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteRecordMenuItem.Image")));
            this.deleteRecordMenuItem.Name = "deleteRecordMenuItem";
            this.deleteRecordMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteRecordMenuItem.Size = new System.Drawing.Size(159, 22);
            this.deleteRecordMenuItem.Text = "&Delete";
            this.deleteRecordMenuItem.Click += new System.EventHandler(this.DeleteRecordMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCodeMenuItem,
            this.aboutHealthRecorderMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpMenuItem.Text = "&Help";
            // 
            // viewCodeMenuItem
            // 
            this.viewCodeMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewCodeMenuItem.Image")));
            this.viewCodeMenuItem.Name = "viewCodeMenuItem";
            this.viewCodeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.viewCodeMenuItem.Size = new System.Drawing.Size(271, 22);
            this.viewCodeMenuItem.Text = "&View Code";
            this.viewCodeMenuItem.Click += new System.EventHandler(this.ViewCodeMenuItem_Click);
            // 
            // aboutHealthRecorderMenuItem
            // 
            this.aboutHealthRecorderMenuItem.Name = "aboutHealthRecorderMenuItem";
            this.aboutHealthRecorderMenuItem.Size = new System.Drawing.Size(271, 22);
            this.aboutHealthRecorderMenuItem.Text = "&About Employee Health Recorder";
            this.aboutHealthRecorderMenuItem.Click += new System.EventHandler(this.AboutHealthRecorderMenuItem_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.filterLabel);
            this.contentPanel.Controls.Add(this.filterCheckDateCheckBox);
            this.contentPanel.Controls.Add(this.filterCheckDateTimePicker);
            this.contentPanel.Controls.Add(this.viewOnlySuspectCheckBox);
            this.contentPanel.Controls.Add(this.filterGinNumberLabel);
            this.contentPanel.Controls.Add(this.filterGinNumberTextBox);
            this.contentPanel.Controls.Add(this.filterGinNumberTipLabel);
            this.contentPanel.Controls.Add(this.employeeDatabaseDataGridView);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.contentPanel.Size = new System.Drawing.Size(849, 551);
            this.contentPanel.TabIndex = 2;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(22, 12);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(49, 17);
            this.filterLabel.TabIndex = 11;
            this.filterLabel.Text = "Filters :";
            // 
            // filterCheckDateCheckBox
            // 
            this.filterCheckDateCheckBox.AutoSize = true;
            this.filterCheckDateCheckBox.Location = new System.Drawing.Point(109, 11);
            this.filterCheckDateCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filterCheckDateCheckBox.Name = "filterCheckDateCheckBox";
            this.filterCheckDateCheckBox.Size = new System.Drawing.Size(89, 21);
            this.filterCheckDateCheckBox.TabIndex = 0;
            this.filterCheckDateCheckBox.Text = "CheckDate";
            this.filterCheckDateCheckBox.UseVisualStyleBackColor = true;
            this.filterCheckDateCheckBox.CheckedChanged += new System.EventHandler(this.FilterCheckDateCheckBox_CheckedChanged);
            // 
            // filterCheckDateTimePicker
            // 
            this.filterCheckDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.filterCheckDateTimePicker.Location = new System.Drawing.Point(201, 9);
            this.filterCheckDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filterCheckDateTimePicker.Name = "filterCheckDateTimePicker";
            this.filterCheckDateTimePicker.Size = new System.Drawing.Size(88, 23);
            this.filterCheckDateTimePicker.TabIndex = 1;
            this.filterCheckDateTimePicker.ValueChanged += new System.EventHandler(this.FilterCheckDateTimePicker_ValueChanged);
            // 
            // viewOnlySuspectCheckBox
            // 
            this.viewOnlySuspectCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.viewOnlySuspectCheckBox.AutoSize = true;
            this.viewOnlySuspectCheckBox.Location = new System.Drawing.Point(326, 11);
            this.viewOnlySuspectCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewOnlySuspectCheckBox.Name = "viewOnlySuspectCheckBox";
            this.viewOnlySuspectCheckBox.Size = new System.Drawing.Size(200, 21);
            this.viewOnlySuspectCheckBox.TabIndex = 2;
            this.viewOnlySuspectCheckBox.Text = "View Only Suspect Employees";
            this.viewOnlySuspectCheckBox.UseVisualStyleBackColor = true;
            this.viewOnlySuspectCheckBox.CheckedChanged += new System.EventHandler(this.ViewOnlySuspectCheckBox_CheckedChanged);
            // 
            // filterGinNumberLabel
            // 
            this.filterGinNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterGinNumberLabel.AutoSize = true;
            this.filterGinNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.filterGinNumberLabel.Location = new System.Drawing.Point(557, 14);
            this.filterGinNumberLabel.Name = "filterGinNumberLabel";
            this.filterGinNumberLabel.Size = new System.Drawing.Size(75, 17);
            this.filterGinNumberLabel.TabIndex = 9;
            this.filterGinNumberLabel.Text = "GinNumber";
            // 
            // filterGinNumberTextBox
            // 
            this.filterGinNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterGinNumberTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.filterGinNumberTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.filterGinNumberTextBox.Location = new System.Drawing.Point(636, 11);
            this.filterGinNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filterGinNumberTextBox.Name = "filterGinNumberTextBox";
            this.filterGinNumberTextBox.Size = new System.Drawing.Size(123, 23);
            this.filterGinNumberTextBox.TabIndex = 3;
            this.filterGinNumberTextBox.TextChanged += new System.EventHandler(this.FilterGinNumberTextBox_TextChanged);
            // 
            // filterGinNumberTipLabel
            // 
            this.filterGinNumberTipLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterGinNumberTipLabel.AutoSize = true;
            this.filterGinNumberTipLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filterGinNumberTipLabel.ForeColor = System.Drawing.Color.Red;
            this.filterGinNumberTipLabel.Location = new System.Drawing.Point(764, 14);
            this.filterGinNumberTipLabel.Name = "filterGinNumberTipLabel";
            this.filterGinNumberTipLabel.Size = new System.Drawing.Size(0, 17);
            this.filterGinNumberTipLabel.TabIndex = 3;
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
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.checkDateDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.notesDataGridViewTextBoxColumn});
            this.employeeDatabaseDataGridView.ContextMenuStrip = this.databaseContextMenuStrip;
            this.employeeDatabaseDataGridView.DataSource = this.employeeRecordBindingSource;
            this.employeeDatabaseDataGridView.Location = new System.Drawing.Point(0, 39);
            this.employeeDatabaseDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.employeeDatabaseDataGridView.MultiSelect = false;
            this.employeeDatabaseDataGridView.Name = "employeeDatabaseDataGridView";
            this.employeeDatabaseDataGridView.ReadOnly = true;
            this.employeeDatabaseDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.employeeDatabaseDataGridView.RowTemplate.Height = 23;
            this.employeeDatabaseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeeDatabaseDataGridView.Size = new System.Drawing.Size(849, 511);
            this.employeeDatabaseDataGridView.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "GinNumber";
            this.dataGridViewTextBoxColumn3.HeaderText = "GinNumber";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 68;
            // 
            // checkDateDataGridViewTextBoxColumn
            // 
            this.checkDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.checkDateDataGridViewTextBoxColumn.DataPropertyName = "CheckDate";
            this.checkDateDataGridViewTextBoxColumn.HeaderText = "CheckDate";
            this.checkDateDataGridViewTextBoxColumn.Name = "checkDateDataGridViewTextBoxColumn";
            this.checkDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkDateDataGridViewTextBoxColumn.Width = 95;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "BodyTemperature";
            this.dataGridViewTextBoxColumn5.HeaderText = "BodyTemperature";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 138;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "HasHubeiTravelHistory";
            this.dataGridViewCheckBoxColumn1.HeaderText = "HasHubeiTravelHistory";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 146;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "HasSymptoms";
            this.dataGridViewCheckBoxColumn2.HeaderText = "HasSymptoms";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Width = 97;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // databaseContextMenuStrip
            // 
            this.databaseContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromFileContextMenuItem,
            this.openSidebarToolStripMenuItem,
            this.addNewRecordContextMenuItem,
            this.editCurrentRecordCntextMenuItem,
            this.deleteCurrentRecordContextMenuItem,
            this.filterContextMenuItem,
            this.saveAsContextMenuItem});
            this.databaseContextMenuStrip.Name = "databaseContextMenuStrip";
            this.databaseContextMenuStrip.Size = new System.Drawing.Size(262, 158);
            // 
            // importFromFileContextMenuItem
            // 
            this.importFromFileContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importFromFileContextMenuItem.Image")));
            this.importFromFileContextMenuItem.Name = "importFromFileContextMenuItem";
            this.importFromFileContextMenuItem.Size = new System.Drawing.Size(261, 22);
            this.importFromFileContextMenuItem.Text = "Import From...";
            this.importFromFileContextMenuItem.Click += new System.EventHandler(this.ImportFromFileContextpMenuItem_Click);
            // 
            // openSidebarToolStripMenuItem
            // 
            this.openSidebarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openSidebarToolStripMenuItem.Image")));
            this.openSidebarToolStripMenuItem.Name = "openSidebarToolStripMenuItem";
            this.openSidebarToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.openSidebarToolStripMenuItem.Text = "Open/Close Navigation Sidebar";
            this.openSidebarToolStripMenuItem.Click += new System.EventHandler(this.OpenSidebarToolStripMenuItem_Click);
            // 
            // addNewRecordContextMenuItem
            // 
            this.addNewRecordContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewRecordContextMenuItem.Image")));
            this.addNewRecordContextMenuItem.Name = "addNewRecordContextMenuItem";
            this.addNewRecordContextMenuItem.Size = new System.Drawing.Size(261, 22);
            this.addNewRecordContextMenuItem.Text = "Add New Record";
            this.addNewRecordContextMenuItem.Click += new System.EventHandler(this.AddNewRecordContextMenuItem_Click);
            // 
            // editCurrentRecordCntextMenuItem
            // 
            this.editCurrentRecordCntextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editCurrentRecordCntextMenuItem.Image")));
            this.editCurrentRecordCntextMenuItem.Name = "editCurrentRecordCntextMenuItem";
            this.editCurrentRecordCntextMenuItem.Size = new System.Drawing.Size(261, 22);
            this.editCurrentRecordCntextMenuItem.Text = "View/Edit Current Record";
            this.editCurrentRecordCntextMenuItem.Click += new System.EventHandler(this.EditCurrentRecordContextMenuItem_Click);
            // 
            // deleteCurrentRecordContextMenuItem
            // 
            this.deleteCurrentRecordContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteCurrentRecordContextMenuItem.Image")));
            this.deleteCurrentRecordContextMenuItem.Name = "deleteCurrentRecordContextMenuItem";
            this.deleteCurrentRecordContextMenuItem.Size = new System.Drawing.Size(261, 22);
            this.deleteCurrentRecordContextMenuItem.Text = "Delete Current Record";
            this.deleteCurrentRecordContextMenuItem.Click += new System.EventHandler(this.DeleteCurrentRecordContextMenuItem_Click);
            // 
            // filterContextMenuItem
            // 
            this.filterContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewOnlySuspectEployeeContextMenuItem,
            this.viewAllEmployeesContextMenuItem});
            this.filterContextMenuItem.Name = "filterContextMenuItem";
            this.filterContextMenuItem.Size = new System.Drawing.Size(261, 22);
            this.filterContextMenuItem.Text = "Filter...";
            // 
            // viewOnlySuspectEployeeContextMenuItem
            // 
            this.viewOnlySuspectEployeeContextMenuItem.Name = "viewOnlySuspectEployeeContextMenuItem";
            this.viewOnlySuspectEployeeContextMenuItem.Size = new System.Drawing.Size(249, 22);
            this.viewOnlySuspectEployeeContextMenuItem.Text = "View Only Suspect Employees";
            this.viewOnlySuspectEployeeContextMenuItem.Click += new System.EventHandler(this.ViewOnlySuspectEployeeContextMenuItem_Click);
            // 
            // viewAllEmployeesContextMenuItem
            // 
            this.viewAllEmployeesContextMenuItem.Name = "viewAllEmployeesContextMenuItem";
            this.viewAllEmployeesContextMenuItem.Size = new System.Drawing.Size(249, 22);
            this.viewAllEmployeesContextMenuItem.Text = "View All Employees";
            this.viewAllEmployeesContextMenuItem.Click += new System.EventHandler(this.ViewAllEmployeesContextMenuItem_Click);
            // 
            // saveAsContextMenuItem
            // 
            this.saveAsContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsContextMenuItem.Image")));
            this.saveAsContextMenuItem.Name = "saveAsContextMenuItem";
            this.saveAsContextMenuItem.Size = new System.Drawing.Size(261, 22);
            this.saveAsContextMenuItem.Text = "Save As...";
            this.saveAsContextMenuItem.Click += new System.EventHandler(this.SaveAsContextMenuItem_Click);
            // 
            // employeeRecordBindingSource
            // 
            this.employeeRecordBindingSource.DataSource = typeof(EmployeeHealthInfoRecord.EmployeeRecord);
            // 
            // recordsTreeView
            // 
            this.recordsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordsTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recordsTreeView.ContextMenuStrip = this.treeViewContextMenuStrip;
            this.recordsTreeView.Indent = 10;
            this.recordsTreeView.Location = new System.Drawing.Point(0, 39);
            this.recordsTreeView.Name = "recordsTreeView";
            treeNode1.Name = "All Records";
            treeNode1.Text = "All Records";
            this.recordsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.recordsTreeView.Size = new System.Drawing.Size(150, 511);
            this.recordsTreeView.TabIndex = 10;
            this.recordsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RecordsTreeView_AfterSelect);
            // 
            // treeViewContextMenuStrip
            // 
            this.treeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameBasedContextMenuItem1,
            this.checkDateBasedContextMenuItem1,
            this.deleteNodeContextMenuItem,
            this.openCloseToolStripMenuItem});
            this.treeViewContextMenuStrip.Name = "treeViewContextMenuStrip";
            this.treeViewContextMenuStrip.Size = new System.Drawing.Size(180, 92);
            // 
            // nameBasedContextMenuItem1
            // 
            this.nameBasedContextMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("nameBasedContextMenuItem1.Image")));
            this.nameBasedContextMenuItem1.Name = "nameBasedContextMenuItem1";
            this.nameBasedContextMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.nameBasedContextMenuItem1.Text = "Name-Based";
            this.nameBasedContextMenuItem1.Click += new System.EventHandler(this.NameBasedContextMenuItem_Click);
            // 
            // checkDateBasedContextMenuItem1
            // 
            this.checkDateBasedContextMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("checkDateBasedContextMenuItem1.Image")));
            this.checkDateBasedContextMenuItem1.Name = "checkDateBasedContextMenuItem1";
            this.checkDateBasedContextMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.checkDateBasedContextMenuItem1.Text = "CheckDate-Based";
            this.checkDateBasedContextMenuItem1.Click += new System.EventHandler(this.CheckDateBasedContextMenuItem_Click);
            // 
            // deleteNodeContextMenuItem
            // 
            this.deleteNodeContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteNodeContextMenuItem.Image")));
            this.deleteNodeContextMenuItem.Name = "deleteNodeContextMenuItem";
            this.deleteNodeContextMenuItem.Size = new System.Drawing.Size(179, 22);
            this.deleteNodeContextMenuItem.Text = "Delete Node";
            this.deleteNodeContextMenuItem.Click += new System.EventHandler(this.DeleteNodeContextMenuItem_Click);
            // 
            // openCloseToolStripMenuItem
            // 
            this.openCloseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openCloseToolStripMenuItem.Image")));
            this.openCloseToolStripMenuItem.Name = "openCloseToolStripMenuItem";
            this.openCloseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.openCloseToolStripMenuItem.Text = "Close Sidebar";
            this.openCloseToolStripMenuItem.Click += new System.EventHandler(this.OpenCloseToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "CSV Files|*.csv|TXT Files|*.txt";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "CSV Files|*.csv|TXT Files|*.txt";
            // 
            // ToolStrip
            // 
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportRecordsToolStripButton,
            this.SaveRecordsToolStripButton,
            this.toolStripSeparator1,
            this.AddRecordToolStripButton,
            this.EditRecordToolStripButton,
            this.DeleteRecordToolStripButton,
            this.toolStripSeparator2,
            this.tressViewToolStripDropDownButton,
            this.DeleteSelectedNodeToolStripButton,
            this.toolStripSeparator3,
            this.SearchToolStripTextBox});
            this.ToolStrip.Location = new System.Drawing.Point(3, 27);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(1008, 25);
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // ImportRecordsToolStripButton
            // 
            this.ImportRecordsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ImportRecordsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ImportRecordsToolStripButton.Image")));
            this.ImportRecordsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportRecordsToolStripButton.Name = "ImportRecordsToolStripButton";
            this.ImportRecordsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ImportRecordsToolStripButton.Text = "Import From File";
            this.ImportRecordsToolStripButton.Click += new System.EventHandler(this.ImportRecordsToolStripButton_Click);
            // 
            // SaveRecordsToolStripButton
            // 
            this.SaveRecordsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveRecordsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveRecordsToolStripButton.Image")));
            this.SaveRecordsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveRecordsToolStripButton.Name = "SaveRecordsToolStripButton";
            this.SaveRecordsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveRecordsToolStripButton.Text = "Save To File";
            this.SaveRecordsToolStripButton.Click += new System.EventHandler(this.SaveRecordsToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // AddRecordToolStripButton
            // 
            this.AddRecordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddRecordToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddRecordToolStripButton.Image")));
            this.AddRecordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddRecordToolStripButton.Name = "AddRecordToolStripButton";
            this.AddRecordToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.AddRecordToolStripButton.Text = "Add New Record";
            this.AddRecordToolStripButton.Click += new System.EventHandler(this.AddRecordToolStripButton_Click);
            // 
            // EditRecordToolStripButton
            // 
            this.EditRecordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditRecordToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditRecordToolStripButton.Image")));
            this.EditRecordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditRecordToolStripButton.Name = "EditRecordToolStripButton";
            this.EditRecordToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.EditRecordToolStripButton.Text = "Edit Record";
            this.EditRecordToolStripButton.ToolTipText = "Edit Current Selected Record in Table";
            this.EditRecordToolStripButton.Click += new System.EventHandler(this.EditRecordToolStripButton_Click);
            // 
            // DeleteRecordToolStripButton
            // 
            this.DeleteRecordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteRecordToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteRecordToolStripButton.Image")));
            this.DeleteRecordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteRecordToolStripButton.Name = "DeleteRecordToolStripButton";
            this.DeleteRecordToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteRecordToolStripButton.Text = "Delete Record";
            this.DeleteRecordToolStripButton.ToolTipText = "Delete Current Selected Record in Table";
            this.DeleteRecordToolStripButton.Click += new System.EventHandler(this.DeleteRecordToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tressViewToolStripDropDownButton
            // 
            this.tressViewToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tressViewToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameBasedTreeViewToolStripMenuItem,
            this.checkDateBasedTreeViewToolStripMenuItem,
            this.openCloseTreeviewToolStripMenuItem});
            this.tressViewToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("tressViewToolStripDropDownButton.Image")));
            this.tressViewToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tressViewToolStripDropDownButton.Name = "tressViewToolStripDropDownButton";
            this.tressViewToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.tressViewToolStripDropDownButton.Text = "toolStripDropDownButton1";
            this.tressViewToolStripDropDownButton.ToolTipText = "Choose different tree views";
            // 
            // nameBasedTreeViewToolStripMenuItem
            // 
            this.nameBasedTreeViewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nameBasedTreeViewToolStripMenuItem.Image")));
            this.nameBasedTreeViewToolStripMenuItem.Name = "nameBasedTreeViewToolStripMenuItem";
            this.nameBasedTreeViewToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.nameBasedTreeViewToolStripMenuItem.Text = "Name Based TreeView";
            this.nameBasedTreeViewToolStripMenuItem.Click += new System.EventHandler(this.NameBasedTreeViewToolStripMenuItem_Click);
            // 
            // checkDateBasedTreeViewToolStripMenuItem
            // 
            this.checkDateBasedTreeViewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkDateBasedTreeViewToolStripMenuItem.Image")));
            this.checkDateBasedTreeViewToolStripMenuItem.Name = "checkDateBasedTreeViewToolStripMenuItem";
            this.checkDateBasedTreeViewToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.checkDateBasedTreeViewToolStripMenuItem.Text = "CheckDate Based TreeView";
            this.checkDateBasedTreeViewToolStripMenuItem.Click += new System.EventHandler(this.CheckDateBasedTreeViewToolStripMenuItem_Click);
            // 
            // openCloseTreeviewToolStripMenuItem
            // 
            this.openCloseTreeviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openCloseTreeviewToolStripMenuItem.Image")));
            this.openCloseTreeviewToolStripMenuItem.Name = "openCloseTreeviewToolStripMenuItem";
            this.openCloseTreeviewToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.openCloseTreeviewToolStripMenuItem.Text = "Open/Close";
            this.openCloseTreeviewToolStripMenuItem.Click += new System.EventHandler(this.SwitchTreeviewToolStripMenuItem_Click);
            // 
            // DeleteSelectedNodeToolStripButton
            // 
            this.DeleteSelectedNodeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteSelectedNodeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteSelectedNodeToolStripButton.Image")));
            this.DeleteSelectedNodeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteSelectedNodeToolStripButton.Name = "DeleteSelectedNodeToolStripButton";
            this.DeleteSelectedNodeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteSelectedNodeToolStripButton.Text = "toolStripButton1";
            this.DeleteSelectedNodeToolStripButton.ToolTipText = "Delete All Records under Current Selected Node in TreeView";
            this.DeleteSelectedNodeToolStripButton.Click += new System.EventHandler(this.DeleteSelectedNodeToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // SearchToolStripTextBox
            // 
            this.SearchToolStripTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.SearchToolStripTextBox.ForeColor = System.Drawing.Color.Gray;
            this.SearchToolStripTextBox.Name = "SearchToolStripTextBox";
            this.SearchToolStripTextBox.Size = new System.Drawing.Size(250, 25);
            this.SearchToolStripTextBox.Text = "Search By GinNumber or CheckDate";
            this.SearchToolStripTextBox.Leave += new System.EventHandler(this.SearchToolStripTextBox_Leave);
            this.SearchToolStripTextBox.Click += new System.EventHandler(this.SearchToolStripTextBox_Click);
            this.SearchToolStripTextBox.TextChanged += new System.EventHandler(this.SearchToolStripTextBox_TextChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(3, 609);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.statusLabel.Image = ((System.Drawing.Image)(resources.GetObject("statusLabel.Image")));
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(60, 17);
            this.statusLabel.Text = "Ready";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suspectRecordsNumberStatusLabel,
            this.recordsStatusLabel1,
            this.recordsStatisticsStatusLabel,
            this.recordsStatusLabel2,
            this.timeStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(773, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(238, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // suspectRecordsNumberStatusLabel
            // 
            this.suspectRecordsNumberStatusLabel.ForeColor = System.Drawing.Color.HotPink;
            this.suspectRecordsNumberStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.suspectRecordsNumberStatusLabel.Name = "suspectRecordsNumberStatusLabel";
            this.suspectRecordsNumberStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // recordsStatusLabel1
            // 
            this.recordsStatusLabel1.Name = "recordsStatusLabel1";
            this.recordsStatusLabel1.Size = new System.Drawing.Size(114, 17);
            this.recordsStatusLabel1.Text = "Suspect Records /";
            // 
            // recordsStatisticsStatusLabel
            // 
            this.recordsStatisticsStatusLabel.ForeColor = System.Drawing.Color.Orange;
            this.recordsStatisticsStatusLabel.Name = "recordsStatisticsStatusLabel";
            this.recordsStatisticsStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // recordsStatusLabel2
            // 
            this.recordsStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recordsStatusLabel2.Name = "recordsStatusLabel2";
            this.recordsStatusLabel2.Size = new System.Drawing.Size(107, 17);
            this.recordsStatusLabel2.Text = "Records In Total.";
            // 
            // timeStatusLabel
            // 
            this.timeStatusLabel.Name = "timeStatusLabel";
            this.timeStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // navigationBarPanel
            // 
            this.navigationBarPanel.Controls.Add(this.treeviewLabel);
            this.navigationBarPanel.Controls.Add(this.recordsTreeView);
            this.navigationBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationBarPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationBarPanel.Name = "navigationBarPanel";
            this.navigationBarPanel.Size = new System.Drawing.Size(150, 551);
            this.navigationBarPanel.TabIndex = 13;
            // 
            // treeviewLabel
            // 
            this.treeviewLabel.AutoSize = true;
            this.treeviewLabel.Location = new System.Drawing.Point(3, 12);
            this.treeviewLabel.Name = "treeviewLabel";
            this.treeviewLabel.Size = new System.Drawing.Size(95, 17);
            this.treeviewLabel.TabIndex = 12;
            this.treeviewLabel.Text = "Navigation Bar";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSplitContainer.Location = new System.Drawing.Point(6, 55);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.navigationBarPanel);
            this.mainSplitContainer.Panel1MinSize = 0;
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.contentPanel);
            this.mainSplitContainer.Size = new System.Drawing.Size(1003, 551);
            this.mainSplitContainer.SplitterDistance = 150;
            this.mainSplitContainer.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 631);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1030, 670);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Text = "Employee Health Recorder v3";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDatabaseDataGridView)).EndInit();
            this.databaseContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeRecordBindingSource)).EndInit();
            this.treeViewContextMenuStrip.ResumeLayout(false);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.navigationBarPanel.ResumeLayout(false);
            this.navigationBarPanel.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewRecordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHealthRecorderMenuItem;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label filterGinNumberTipLabel;
        private System.Windows.Forms.ContextMenuStrip databaseContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNewRecordContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentRecordContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromFileContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOnlySuspectEployeeContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllEmployeesContextMenuItem;
        private System.Windows.Forms.ToolTip saveButtonToolTip;
        private System.Windows.Forms.DataGridView employeeDatabaseDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ginNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bodyTemperatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasHubeiTravelHistoryDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasSymptomsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn symptomsDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton SaveRecordsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton AddRecordToolStripButton;
        private System.Windows.Forms.ToolStripButton EditRecordToolStripButton;
        private System.Windows.Forms.ToolStripButton DeleteRecordToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem saveRecordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRecordMenuItem;
        private System.Windows.Forms.ToolStripButton ImportRecordsToolStripButton;
        private System.Windows.Forms.ToolStripTextBox SearchToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem editCurrentRecordCntextMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel suspectRecordsNumberStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel recordsStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel recordsStatisticsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel recordsStatusLabel2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel timeStatusLabel;
        private System.Windows.Forms.BindingSource employeeRecordBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TreeView recordsTreeView;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameBasedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkDateBasedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOnlySuspectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tressViewToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem nameBasedTreeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkDateBasedTreeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip treeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem nameBasedContextMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkDateBasedContextMenuItem1;
        private System.Windows.Forms.CheckBox filterCheckDateCheckBox;
        private System.Windows.Forms.DateTimePicker filterCheckDateTimePicker;
        private System.Windows.Forms.Label filterGinNumberLabel;
        private System.Windows.Forms.TextBox filterGinNumberTextBox;
        private System.Windows.Forms.CheckBox viewOnlySuspectCheckBox;
        private System.Windows.Forms.ToolStripMenuItem treeViewStatusMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCloseTreeviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSidebarToolStripMenuItem;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Panel navigationBarPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem deleteNodeContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedNodeMenuItem;
        private System.Windows.Forms.ToolStripButton DeleteSelectedNodeToolStripButton;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Label treeviewLabel;
    }
}

