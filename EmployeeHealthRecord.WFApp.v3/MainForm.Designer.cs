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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHealthRecorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterCheckDateCheckBox = new System.Windows.Forms.CheckBox();
            this.filterCheckDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.filterGinNumberLabel = new System.Windows.Forms.Label();
            this.filterGinNumberTextBox = new System.Windows.Forms.TextBox();
            this.filterGinNumberTipLabel = new System.Windows.Forms.Label();
            this.viewOnlySuspectCheckBox = new System.Windows.Forms.CheckBox();
            this.employeeDatabaseDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewRecordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCurrentRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlySuspectEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnlySuspectEployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.SearchToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.suspectRecordsNumberStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordsStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordsStatisticsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordsStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDatabaseDataGridView)).BeginInit();
            this.databaseContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRecordBindingSource)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.recordToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(3, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1008, 27);
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
            this.openFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileToolStripMenuItem.Image")));
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openFileToolStripMenuItem.Text = "&Open File...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.saveAsToolStripMenuItem.Text = "&Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewRecordToolStripMenuItem,
            this.saveRecordToolStripMenuItem,
            this.deleteRecordToolStripMenuItem,
            this.findRecordToolStripMenuItem});
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.recordToolStripMenuItem.Text = "&Record";
            // 
            // addNewRecordToolStripMenuItem
            // 
            this.addNewRecordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewRecordToolStripMenuItem.Image")));
            this.addNewRecordToolStripMenuItem.Name = "addNewRecordToolStripMenuItem";
            this.addNewRecordToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addNewRecordToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addNewRecordToolStripMenuItem.Text = "&Add";
            this.addNewRecordToolStripMenuItem.Click += new System.EventHandler(this.AddNewRecordToolStripMenuItem_Click);
            // 
            // saveRecordToolStripMenuItem
            // 
            this.saveRecordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveRecordToolStripMenuItem.Image")));
            this.saveRecordToolStripMenuItem.Name = "saveRecordToolStripMenuItem";
            this.saveRecordToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.saveRecordToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveRecordToolStripMenuItem.Text = "&Edit";
            this.saveRecordToolStripMenuItem.Click += new System.EventHandler(this.EditRecordToolStripMenuItem_Click);
            // 
            // deleteRecordToolStripMenuItem
            // 
            this.deleteRecordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteRecordToolStripMenuItem.Image")));
            this.deleteRecordToolStripMenuItem.Name = "deleteRecordToolStripMenuItem";
            this.deleteRecordToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteRecordToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.deleteRecordToolStripMenuItem.Text = "&Delete";
            this.deleteRecordToolStripMenuItem.Click += new System.EventHandler(this.DeleteRecordToolStripMenuItem_Click);
            // 
            // findRecordToolStripMenuItem
            // 
            this.findRecordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("findRecordToolStripMenuItem.Image")));
            this.findRecordToolStripMenuItem.Name = "findRecordToolStripMenuItem";
            this.findRecordToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findRecordToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.findRecordToolStripMenuItem.Text = "&Find";
            this.findRecordToolStripMenuItem.Click += new System.EventHandler(this.FindRecordToolStripMenuItem_Click);
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
            this.viewCodeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewCodeToolStripMenuItem.Image")));
            this.viewCodeToolStripMenuItem.Name = "viewCodeToolStripMenuItem";
            this.viewCodeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
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
            this.panel1.Controls.Add(this.filterLabel);
            this.panel1.Controls.Add(this.filterCheckDateCheckBox);
            this.panel1.Controls.Add(this.filterCheckDateTimePicker);
            this.panel1.Controls.Add(this.filterGinNumberLabel);
            this.panel1.Controls.Add(this.filterGinNumberTextBox);
            this.panel1.Controls.Add(this.filterGinNumberTipLabel);
            this.panel1.Controls.Add(this.viewOnlySuspectCheckBox);
            this.panel1.Controls.Add(this.employeeDatabaseDataGridView);
            this.panel1.Location = new System.Drawing.Point(5, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel1.Size = new System.Drawing.Size(1003, 549);
            this.panel1.TabIndex = 2;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(6, 11);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(49, 17);
            this.filterLabel.TabIndex = 6;
            this.filterLabel.Text = "Filters :";
            // 
            // filterCheckDateCheckBox
            // 
            this.filterCheckDateCheckBox.AutoSize = true;
            this.filterCheckDateCheckBox.Location = new System.Drawing.Point(112, 10);
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
            this.filterCheckDateTimePicker.Location = new System.Drawing.Point(206, 9);
            this.filterCheckDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filterCheckDateTimePicker.Name = "filterCheckDateTimePicker";
            this.filterCheckDateTimePicker.Size = new System.Drawing.Size(88, 23);
            this.filterCheckDateTimePicker.TabIndex = 1;
            this.filterCheckDateTimePicker.ValueChanged += new System.EventHandler(this.FilterCheckDateTimePicker_ValueChanged);
            // 
            // filterGinNumberLabel
            // 
            this.filterGinNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterGinNumberLabel.AutoSize = true;
            this.filterGinNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.filterGinNumberLabel.Location = new System.Drawing.Point(673, 12);
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
            this.filterGinNumberTextBox.Location = new System.Drawing.Point(753, 9);
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
            this.filterGinNumberTipLabel.Location = new System.Drawing.Point(880, 12);
            this.filterGinNumberTipLabel.Name = "filterGinNumberTipLabel";
            this.filterGinNumberTipLabel.Size = new System.Drawing.Size(0, 17);
            this.filterGinNumberTipLabel.TabIndex = 3;
            // 
            // viewOnlySuspectCheckBox
            // 
            this.viewOnlySuspectCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.viewOnlySuspectCheckBox.AutoSize = true;
            this.viewOnlySuspectCheckBox.Location = new System.Drawing.Point(386, 11);
            this.viewOnlySuspectCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewOnlySuspectCheckBox.Name = "viewOnlySuspectCheckBox";
            this.viewOnlySuspectCheckBox.Size = new System.Drawing.Size(200, 21);
            this.viewOnlySuspectCheckBox.TabIndex = 2;
            this.viewOnlySuspectCheckBox.Text = "View Only Suspect Employees";
            this.viewOnlySuspectCheckBox.UseVisualStyleBackColor = true;
            this.viewOnlySuspectCheckBox.CheckedChanged += new System.EventHandler(this.ViewOnlySuspectCheckBox_CheckedChanged);
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
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.checkDateDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.notesDataGridViewTextBoxColumn});
            this.employeeDatabaseDataGridView.ContextMenuStrip = this.databaseContextMenuStrip;
            this.employeeDatabaseDataGridView.DataSource = this.employeeRecordBindingSource;
            this.employeeDatabaseDataGridView.Location = new System.Drawing.Point(0, 41);
            this.employeeDatabaseDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.employeeDatabaseDataGridView.MultiSelect = false;
            this.employeeDatabaseDataGridView.Name = "employeeDatabaseDataGridView";
            this.employeeDatabaseDataGridView.ReadOnly = true;
            this.employeeDatabaseDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.employeeDatabaseDataGridView.RowTemplate.Height = 23;
            this.employeeDatabaseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeeDatabaseDataGridView.Size = new System.Drawing.Size(1003, 508);
            this.employeeDatabaseDataGridView.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "GinNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "GinNumber";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 68;
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BodyTemperature";
            this.dataGridViewTextBoxColumn3.HeaderText = "BodyTemperature";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 138;
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
            this.importFromFileToolStripMenuItem,
            this.addNewRecordToolStripMenuItem1,
            this.viewDetailToolStripMenuItem,
            this.editCurrentRecordToolStripMenuItem,
            this.deleteCurrentRecordToolStripMenuItem,
            this.viewOnlySuspectEmployeeToolStripMenuItem,
            this.saveAsToolStripMenuItem1});
            this.databaseContextMenuStrip.Name = "databaseContextMenuStrip";
            this.databaseContextMenuStrip.Size = new System.Drawing.Size(250, 158);
            // 
            // importFromFileToolStripMenuItem
            // 
            this.importFromFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importFromFileToolStripMenuItem.Image")));
            this.importFromFileToolStripMenuItem.Name = "importFromFileToolStripMenuItem";
            this.importFromFileToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.importFromFileToolStripMenuItem.Text = "Import From...";
            this.importFromFileToolStripMenuItem.Click += new System.EventHandler(this.ImportFromFileToolStripMenuItem_Click);
            // 
            // addNewRecordToolStripMenuItem1
            // 
            this.addNewRecordToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("addNewRecordToolStripMenuItem1.Image")));
            this.addNewRecordToolStripMenuItem1.Name = "addNewRecordToolStripMenuItem1";
            this.addNewRecordToolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.addNewRecordToolStripMenuItem1.Text = "Add New Record";
            this.addNewRecordToolStripMenuItem1.Click += new System.EventHandler(this.AddNewRecordToolStripMenuItem1_Click);
            // 
            // viewDetailToolStripMenuItem
            // 
            this.viewDetailToolStripMenuItem.Name = "viewDetailToolStripMenuItem";
            this.viewDetailToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.viewDetailToolStripMenuItem.Text = "View Detail of Current Record";
            this.viewDetailToolStripMenuItem.Click += new System.EventHandler(this.ViewDetailToolStripMenuItem_Click);
            // 
            // editCurrentRecordToolStripMenuItem
            // 
            this.editCurrentRecordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editCurrentRecordToolStripMenuItem.Image")));
            this.editCurrentRecordToolStripMenuItem.Name = "editCurrentRecordToolStripMenuItem";
            this.editCurrentRecordToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.editCurrentRecordToolStripMenuItem.Text = "Edit Current Record";
            this.editCurrentRecordToolStripMenuItem.Click += new System.EventHandler(this.EditCurrentRecordToolStripMenuItem_Click);
            // 
            // deleteCurrentRecordToolStripMenuItem
            // 
            this.deleteCurrentRecordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteCurrentRecordToolStripMenuItem.Image")));
            this.deleteCurrentRecordToolStripMenuItem.Name = "deleteCurrentRecordToolStripMenuItem";
            this.deleteCurrentRecordToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.deleteCurrentRecordToolStripMenuItem.Text = "Delete Current Record";
            this.deleteCurrentRecordToolStripMenuItem.Click += new System.EventHandler(this.DeleteCurrentRecordToolStripMenuItem_Click);
            // 
            // viewOnlySuspectEmployeeToolStripMenuItem
            // 
            this.viewOnlySuspectEmployeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewOnlySuspectEployeeToolStripMenuItem,
            this.viewAllEmployeesToolStripMenuItem});
            this.viewOnlySuspectEmployeeToolStripMenuItem.Name = "viewOnlySuspectEmployeeToolStripMenuItem";
            this.viewOnlySuspectEmployeeToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.viewOnlySuspectEmployeeToolStripMenuItem.Text = "Filter...";
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
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem1.Image")));
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.saveAsToolStripMenuItem1.Text = "Save As...";
            this.saveAsToolStripMenuItem1.Click += new System.EventHandler(this.SaveAsToolStripMenuItem1_Click);
            // 
            // employeeRecordBindingSource
            // 
            this.employeeRecordBindingSource.DataSource = typeof(EmployeeHealthInfoRecord.EmployeeRecord);
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
            this.DeleteRecordToolStripButton.Click += new System.EventHandler(this.DeleteRecordToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.recordsStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(742, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(269, 22);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 631);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1030, 670);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Text = "Employee Health Recorder v3";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDatabaseDataGridView)).EndInit();
            this.databaseContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeRecordBindingSource)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHealthRecorderToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox filterGinNumberTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label filterGinNumberTipLabel;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn symptomsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource employeeRecordBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.CheckBox filterCheckDateCheckBox;
        private System.Windows.Forms.DateTimePicker filterCheckDateTimePicker;
        private System.Windows.Forms.ToolStripButton SaveRecordsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label filterGinNumberLabel;
        private System.Windows.Forms.ToolStripButton AddRecordToolStripButton;
        private System.Windows.Forms.ToolStripButton EditRecordToolStripButton;
        private System.Windows.Forms.ToolStripButton DeleteRecordToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem saveRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton ImportRecordsToolStripButton;
        private System.Windows.Forms.ToolStripTextBox SearchToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem editCurrentRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDetailToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel suspectRecordsNumberStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel recordsStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel recordsStatisticsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel recordsStatusLabel2;
    }
}

