namespace EmployeeHealthRecord.WFApp
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.employeeDataPanel = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.ginNumberLabel = new System.Windows.Forms.Label();
            this.notesLabel = new System.Windows.Forms.Label();
            this.hubeiTravelHistoryCheckBox = new System.Windows.Forms.CheckBox();
            this.symptomsCheckBox = new System.Windows.Forms.CheckBox();
            this.bodyTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.checkDateLabel = new System.Windows.Forms.Label();
            this.bodyTemperatureLabel = new System.Windows.Forms.Label();
            this.ginNumberTextBox = new System.Windows.Forms.TextBox();
            this.checkDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.notesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.employeeDatabaseSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.loadDatabaseButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addItemToRemoveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listAllSuspectsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.loadDatabaseOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDatabaseSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.employeeDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDatabaseSplitContainer)).BeginInit();
            this.employeeDatabaseSplitContainer.Panel1.SuspendLayout();
            this.employeeDatabaseSplitContainer.Panel2.SuspendLayout();
            this.employeeDatabaseSplitContainer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.employeeDataPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.employeeDatabaseSplitContainer);
            this.splitContainer1.Size = new System.Drawing.Size(1166, 579);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 1;
            // 
            // employeeDataPanel
            // 
            this.employeeDataPanel.ColumnCount = 4;
            this.employeeDataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.employeeDataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.employeeDataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.employeeDataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.employeeDataPanel.Controls.Add(this.nameLabel, 2, 0);
            this.employeeDataPanel.Controls.Add(this.ginNumberLabel, 0, 0);
            this.employeeDataPanel.Controls.Add(this.notesLabel, 0, 5);
            this.employeeDataPanel.Controls.Add(this.hubeiTravelHistoryCheckBox, 0, 4);
            this.employeeDataPanel.Controls.Add(this.symptomsCheckBox, 2, 4);
            this.employeeDataPanel.Controls.Add(this.bodyTemperatureTextBox, 0, 3);
            this.employeeDataPanel.Controls.Add(this.checkDateLabel, 2, 2);
            this.employeeDataPanel.Controls.Add(this.bodyTemperatureLabel, 0, 2);
            this.employeeDataPanel.Controls.Add(this.ginNumberTextBox, 0, 1);
            this.employeeDataPanel.Controls.Add(this.checkDateTimePicker, 2, 3);
            this.employeeDataPanel.Controls.Add(this.nameTextBox, 2, 1);
            this.employeeDataPanel.Controls.Add(this.notesRichTextBox, 0, 6);
            this.employeeDataPanel.Controls.Add(this.submitButton, 0, 7);
            this.employeeDataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDataPanel.Location = new System.Drawing.Point(0, 0);
            this.employeeDataPanel.Name = "employeeDataPanel";
            this.employeeDataPanel.RowCount = 8;
            this.employeeDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.496504F));
            this.employeeDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.993007F));
            this.employeeDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.496504F));
            this.employeeDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.993007F));
            this.employeeDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.48951F));
            this.employeeDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.496504F));
            this.employeeDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.94406F));
            this.employeeDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.employeeDataPanel.Size = new System.Drawing.Size(388, 575);
            this.employeeDataPanel.TabIndex = 2;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nameLabel.AutoSize = true;
            this.employeeDataPanel.SetColumnSpan(this.nameLabel, 2);
            this.nameLabel.Location = new System.Drawing.Point(196, 8);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 12);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // ginNumberLabel
            // 
            this.ginNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ginNumberLabel.AutoSize = true;
            this.employeeDataPanel.SetColumnSpan(this.ginNumberLabel, 2);
            this.ginNumberLabel.Location = new System.Drawing.Point(3, 8);
            this.ginNumberLabel.Name = "ginNumberLabel";
            this.ginNumberLabel.Size = new System.Drawing.Size(59, 12);
            this.ginNumberLabel.TabIndex = 0;
            this.ginNumberLabel.Text = "GinNumber";
            // 
            // notesLabel
            // 
            this.notesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.notesLabel.AutoSize = true;
            this.notesLabel.Location = new System.Drawing.Point(3, 188);
            this.notesLabel.Name = "notesLabel";
            this.notesLabel.Size = new System.Drawing.Size(35, 12);
            this.notesLabel.TabIndex = 12;
            this.notesLabel.Text = "Notes";
            // 
            // hubeiTravelHistoryCheckBox
            // 
            this.hubeiTravelHistoryCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hubeiTravelHistoryCheckBox.AutoSize = true;
            this.employeeDataPanel.SetColumnSpan(this.hubeiTravelHistoryCheckBox, 2);
            this.hubeiTravelHistoryCheckBox.Location = new System.Drawing.Point(3, 142);
            this.hubeiTravelHistoryCheckBox.Name = "hubeiTravelHistoryCheckBox";
            this.hubeiTravelHistoryCheckBox.Size = new System.Drawing.Size(168, 16);
            this.hubeiTravelHistoryCheckBox.TabIndex = 14;
            this.hubeiTravelHistoryCheckBox.Text = "Has Hubei Travel History";
            this.hubeiTravelHistoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // symptomsCheckBox
            // 
            this.symptomsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.symptomsCheckBox.AutoSize = true;
            this.employeeDataPanel.SetColumnSpan(this.symptomsCheckBox, 2);
            this.symptomsCheckBox.Location = new System.Drawing.Point(196, 142);
            this.symptomsCheckBox.Name = "symptomsCheckBox";
            this.symptomsCheckBox.Size = new System.Drawing.Size(96, 16);
            this.symptomsCheckBox.TabIndex = 15;
            this.symptomsCheckBox.Text = "Has Symptoms";
            this.symptomsCheckBox.UseVisualStyleBackColor = true;
            // 
            // bodyTemperatureTextBox
            // 
            this.bodyTemperatureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeDataPanel.SetColumnSpan(this.bodyTemperatureTextBox, 2);
            this.bodyTemperatureTextBox.Location = new System.Drawing.Point(3, 83);
            this.bodyTemperatureTextBox.Name = "bodyTemperatureTextBox";
            this.bodyTemperatureTextBox.Size = new System.Drawing.Size(187, 21);
            this.bodyTemperatureTextBox.TabIndex = 5;
            this.bodyTemperatureTextBox.TextChanged += new System.EventHandler(this.bodyTemperatureTextBox_TextChanged);
            // 
            // checkDateLabel
            // 
            this.checkDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkDateLabel.AutoSize = true;
            this.employeeDataPanel.SetColumnSpan(this.checkDateLabel, 2);
            this.checkDateLabel.Location = new System.Drawing.Point(196, 68);
            this.checkDateLabel.Name = "checkDateLabel";
            this.checkDateLabel.Size = new System.Drawing.Size(65, 12);
            this.checkDateLabel.TabIndex = 6;
            this.checkDateLabel.Text = "Check Date";
            // 
            // bodyTemperatureLabel
            // 
            this.bodyTemperatureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bodyTemperatureLabel.AutoSize = true;
            this.employeeDataPanel.SetColumnSpan(this.bodyTemperatureLabel, 2);
            this.bodyTemperatureLabel.Location = new System.Drawing.Point(3, 68);
            this.bodyTemperatureLabel.Name = "bodyTemperatureLabel";
            this.bodyTemperatureLabel.Size = new System.Drawing.Size(101, 12);
            this.bodyTemperatureLabel.TabIndex = 4;
            this.bodyTemperatureLabel.Text = "Body Temperature";
            // 
            // ginNumberTextBox
            // 
            this.ginNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeDataPanel.SetColumnSpan(this.ginNumberTextBox, 2);
            this.ginNumberTextBox.Location = new System.Drawing.Point(3, 23);
            this.ginNumberTextBox.Name = "ginNumberTextBox";
            this.ginNumberTextBox.Size = new System.Drawing.Size(187, 21);
            this.ginNumberTextBox.TabIndex = 1;
            // 
            // checkDateTimePicker
            // 
            this.checkDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeDataPanel.SetColumnSpan(this.checkDateTimePicker, 2);
            this.checkDateTimePicker.Location = new System.Drawing.Point(196, 83);
            this.checkDateTimePicker.Name = "checkDateTimePicker";
            this.checkDateTimePicker.Size = new System.Drawing.Size(189, 21);
            this.checkDateTimePicker.TabIndex = 7;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeDataPanel.SetColumnSpan(this.nameTextBox, 2);
            this.nameTextBox.Location = new System.Drawing.Point(196, 23);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(189, 21);
            this.nameTextBox.TabIndex = 3;
            // 
            // notesRichTextBox
            // 
            this.employeeDataPanel.SetColumnSpan(this.notesRichTextBox, 4);
            this.notesRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesRichTextBox.Location = new System.Drawing.Point(3, 203);
            this.notesRichTextBox.Name = "notesRichTextBox";
            this.notesRichTextBox.Size = new System.Drawing.Size(382, 315);
            this.notesRichTextBox.TabIndex = 16;
            this.notesRichTextBox.Text = "";
            // 
            // submitButton
            // 
            this.submitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.employeeDataPanel.SetColumnSpan(this.submitButton, 4);
            this.submitButton.Location = new System.Drawing.Point(149, 535);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(90, 25);
            this.submitButton.TabIndex = 17;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // employeeDatabaseSplitContainer
            // 
            this.employeeDatabaseSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDatabaseSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.employeeDatabaseSplitContainer.Name = "employeeDatabaseSplitContainer";
            this.employeeDatabaseSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // employeeDatabaseSplitContainer.Panel1
            // 
            this.employeeDatabaseSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // employeeDatabaseSplitContainer.Panel2
            // 
            this.employeeDatabaseSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.employeeDatabaseSplitContainer.Size = new System.Drawing.Size(760, 575);
            this.employeeDatabaseSplitContainer.SplitterDistance = 200;
            this.employeeDatabaseSplitContainer.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.loadDatabaseButton, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.button5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.76237F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.23762F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(760, 200);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // loadDatabaseButton
            // 
            this.loadDatabaseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadDatabaseButton.Location = new System.Drawing.Point(490, 161);
            this.loadDatabaseButton.Name = "loadDatabaseButton";
            this.loadDatabaseButton.Size = new System.Drawing.Size(160, 25);
            this.loadDatabaseButton.TabIndex = 9;
            this.loadDatabaseButton.Text = "Load database from file";
            this.loadDatabaseButton.UseVisualStyleBackColor = true;
            this.loadDatabaseButton.Click += new System.EventHandler(this.loadDatabaseButton_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.Location = new System.Drawing.Point(110, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 25);
            this.button5.TabIndex = 8;
            this.button5.Text = "Save database to file";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.tableLayoutPanel3.SetColumnSpan(this.listView1, 2);
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(754, 141);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "GinNumber";
            this.columnHeader1.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 52;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Body Temperature";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Has Hubei Travel History";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 169;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Has Symptoms";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 96;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Notes";
            this.columnHeader6.Width = 253;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.710491F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.684211F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.31579F));
            this.tableLayoutPanel2.Controls.Add(this.listView2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.addItemToRemoveButton, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.listView3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.listAllSuspectsLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.listView4, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.button1, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.removeButton, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.333652F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.778202F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.53486F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.847776F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.752754F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.752754F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(760, 371);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(3, 30);
            this.listView2.Name = "listView2";
            this.tableLayoutPanel2.SetRowSpan(this.listView2, 5);
            this.listView2.Size = new System.Drawing.Size(295, 338);
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "GinNumber";
            this.columnHeader7.Width = 61;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Name";
            this.columnHeader8.Width = 48;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "SuspectInfo";
            this.columnHeader9.Width = 155;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(316, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(82, 21);
            this.textBox1.TabIndex = 10;
            // 
            // addItemToRemoveButton
            // 
            this.addItemToRemoveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addItemToRemoveButton.Location = new System.Drawing.Point(425, 32);
            this.addItemToRemoveButton.Name = "addItemToRemoveButton";
            this.addItemToRemoveButton.Size = new System.Drawing.Size(90, 25);
            this.addItemToRemoveButton.TabIndex = 11;
            this.addItemToRemoveButton.Text = "Add";
            this.addItemToRemoveButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(345, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "Add Employee to remove";
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11});
            this.tableLayoutPanel2.SetColumnSpan(this.listView3, 2);
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(304, 66);
            this.listView3.Name = "listView3";
            this.tableLayoutPanel2.SetRowSpan(this.listView3, 3);
            this.listView3.Size = new System.Drawing.Size(220, 271);
            this.listView3.TabIndex = 13;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "GinNumber";
            this.columnHeader10.Width = 118;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Name";
            this.columnHeader11.Width = 111;
            // 
            // listAllSuspectsLabel
            // 
            this.listAllSuspectsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listAllSuspectsLabel.AutoSize = true;
            this.listAllSuspectsLabel.Location = new System.Drawing.Point(97, 7);
            this.listAllSuspectsLabel.Name = "listAllSuspectsLabel";
            this.listAllSuspectsLabel.Size = new System.Drawing.Size(107, 12);
            this.listAllSuspectsLabel.TabIndex = 14;
            this.listAllSuspectsLabel.Text = "List all Suspects";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 3);
            this.label2.Location = new System.Drawing.Point(587, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Edit Employee Info";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.Location = new System.Drawing.Point(638, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(93, 21);
            this.textBox2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(573, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "GinNumber";
            // 
            // listView4
            // 
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13});
            this.tableLayoutPanel2.SetColumnSpan(this.listView4, 3);
            this.listView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(530, 66);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(227, 214);
            this.listView4.TabIndex = 18;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Item";
            this.columnHeader12.Width = 120;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Value";
            this.columnHeader13.Width = 119;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "Item";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "Value";
            // 
            // textBox3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox3, 2);
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(573, 315);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(184, 21);
            this.textBox3.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.button1, 3);
            this.button1.Location = new System.Drawing.Point(598, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 23;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.removeButton, 2);
            this.removeButton.Location = new System.Drawing.Point(369, 343);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(90, 25);
            this.removeButton.TabIndex = 0;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.comboBox1, 2);
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "GinNumber",
            "Name",
            "Body Temperature",
            "Has Hubei Travel History",
            "Has Symptoms"});
            this.comboBox1.Location = new System.Drawing.Point(573, 286);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 20);
            this.comboBox1.TabIndex = 24;
            // 
            // loadDatabaseOpenFileDialog
            // 
            this.loadDatabaseOpenFileDialog.FileName = "myEmployeeDatabase";
            this.loadDatabaseOpenFileDialog.Filter = "TXT Files|*.txt|CSV Files|*.csv";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 579);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Employee Health Recorder";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.employeeDataPanel.ResumeLayout(false);
            this.employeeDataPanel.PerformLayout();
            this.employeeDatabaseSplitContainer.Panel1.ResumeLayout(false);
            this.employeeDatabaseSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeDatabaseSplitContainer)).EndInit();
            this.employeeDatabaseSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer employeeDatabaseSplitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button loadDatabaseButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TableLayoutPanel employeeDataPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label ginNumberLabel;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.CheckBox hubeiTravelHistoryCheckBox;
        private System.Windows.Forms.CheckBox symptomsCheckBox;
        private System.Windows.Forms.TextBox bodyTemperatureTextBox;
        private System.Windows.Forms.Label checkDateLabel;
        private System.Windows.Forms.Label bodyTemperatureLabel;
        private System.Windows.Forms.TextBox ginNumberTextBox;
        private System.Windows.Forms.DateTimePicker checkDateTimePicker;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.RichTextBox notesRichTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.OpenFileDialog loadDatabaseOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog saveDatabaseSaveFileDialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addItemToRemoveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Label listAllSuspectsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

