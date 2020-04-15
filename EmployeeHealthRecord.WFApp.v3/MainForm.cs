using EmployeeHealthInfoRecord;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeHealthRecord.WFApp.v3
{
    public delegate bool DataValidator(string input);
    public delegate bool DataValidatorWithDatabase(string input, EmployeeRecords recordsDatabase);
    public delegate void UpdateView();

    public partial class MainForm : Form
    {
        readonly string GIN_NUMBER_TYPE_TIP;
        readonly string GIN_NUMBER_NOT_FOUND_TIP;

        private EmployeeRecords employeeRecords;

        Dictionary<string, string> statusIconsInfo;

        public MainForm()
        {
            InitializeComponent();

            GIN_NUMBER_TYPE_TIP = "? Number Only"; //"Not valid GinNumber type (Integer)."; //"Only integer is allowed for ginNumber.";
            GIN_NUMBER_NOT_FOUND_TIP = "X Not Found"; //"No such GinNumber found.";//"Record of same GinNumber Not found.";

            statusIconsInfo = new Dictionary<string, string>();
            statusIconsInfo.Add("Ready", "/Icons/status/StatusOK_blue_16x.png");
            statusIconsInfo.Add("Working...", "/Icons/status/StatusUpdate_16x.png");
            statusIconsInfo.Add("Editing...", "/Icons/status/Edit_16x.png");
            statusIconsInfo.Add("Deleting...", "/Icons/status/DeleteClause_16x.png");
            statusIconsInfo.Add("Loading...", "/Icons/status/Download_16x.png");
            statusIconsInfo.Add("Saving...", "/Icons/status/SaveStatusBar8_16x.png");
            statusIconsInfo.Add("Searching...", "/Icons/status/CloudSearch_16x.png");

            employeeRecords = new EmployeeRecords();

            FilterRecords();
            employeeDatabaseDataGridView.DataSource = employeeRecordBindingSource;

        }

        // Validate input with tipinfo

        public void ValidExistedGinNumberInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            ControlInputTipHelper.AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_NOT_FOUND_TIP, employeeRecords, WFAPPInputValidator.IsValidExistedGinNumber);
            ControlInputTipHelper.AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_TYPE_TIP, WFAPPInputValidator.IsValidGinNumberType);
            ControlInputTipHelper.ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, employeeRecords, WFAPPInputValidator.IsValidExistedGinNumber);
        }

        // Update autocomplete source for textbox
        private void UpdateAutoCompleteStringForFilterGinNumberTextBox()
        {
            AutoCompleteStringCollection existedGinNumber = new AutoCompleteStringCollection();
            existedGinNumber.AddRange(employeeRecords.RecordsDatabase.Keys.ToArray());
            filterGinNumberTextBox.AutoCompleteCustomSource = existedGinNumber;
        }

        // data file operation

        private void ImportDatabaseFromFile()
        {
            ChangeStatusInfo("Loading...");

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string loadResult = EmployeeRecordsFileOperation.ReadDatabaseFromCSVFile(filePath, ref employeeRecords);

                switch (loadResult)
                {
                    case "success":
                        FilterRecords();
                        MessageBox.Show($"Database loading from {filePath} succeed.", "Loading Database", MessageBoxButtons.OK);
                        break;
                    case "formatError":
                        MessageBox.Show($"Format error in Database from {filePath}.", "Loading Database", MessageBoxButtons.OK);
                        break;
                    case "loadError":
                        MessageBox.Show($"Can not load file at {filePath}.", "Loading Database", MessageBoxButtons.OK);
                        break;
                    case "error":
                        MessageBox.Show($"Database loading from {filePath} operation failed.", "Loading Database", MessageBoxButtons.OK);
                        break;
                }
            }

            ChangeStatusInfo("Ready");
        }

        private void SaveDatabaseToFile()
        {
            ChangeStatusInfo("Saving...");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string saveResult = EmployeeRecordsFileOperation.SaveDatabaseToCSVFile(filePath, employeeRecords);

                switch (saveResult)
                {
                    case "done":
                        MessageBox.Show($"Database saving to {filePath} succeed", "Saving Database", MessageBoxButtons.OK);
                        break;
                    case "error":
                        MessageBox.Show($"Database saving to {filePath} failed, can not open file.", "Saving Database", MessageBoxButtons.OK);
                        break;
                    default:
                        MessageBox.Show($"Database saving to {filePath} operation failed.", "Saving Database", MessageBoxButtons.OK);
                        break;
                }
            }

            ChangeStatusInfo("Ready");
        }

        private void EditCurrentRecord()
        {
            if (employeeDatabaseDataGridView.SelectedRows.Count != 0)
            {

                ChangeStatusInfo("Editing...");

                string ginNumber = (string)employeeDatabaseDataGridView.SelectedRows[0].Cells[0].Value;
                string checkDate = ((DateTime)employeeDatabaseDataGridView.SelectedRows[0].Cells[2].Value).ToShortDateString();
                EmployeeRecord currentRecord = employeeRecords.GetEmployeeRecordGivenSpecificDate(ginNumber, checkDate);

                UpdateRecordForm editRecordForm = new UpdateRecordForm(employeeRecords, currentRecord, "Edit");
                editRecordForm.Text = "Edit Record";
                editRecordForm.updatedView += FilterRecords;
                editRecordForm.updatedView += UpdateAutoCompleteStringForFilterGinNumberTextBox;
                editRecordForm.ShowDialog();

                ChangeStatusInfo("Ready");
            }
        }

        private void AddNewRecord()
        {
            ChangeStatusInfo("Working...");

            UpdateRecordForm addNewRecordForm = new UpdateRecordForm(employeeRecords, null, "Add");
            addNewRecordForm.Text = "Add New Record";
            addNewRecordForm.updatedView += FilterRecords;
            addNewRecordForm.updatedView += UpdateAutoCompleteStringForFilterGinNumberTextBox;
            addNewRecordForm.ShowDialog();

            ChangeStatusInfo("Ready");
        }

        private void DeleteCurrentRecord()
        {
            if (employeeDatabaseDataGridView.SelectedRows.Count != 0)
            {
                ChangeStatusInfo("Deleting...");

                if (MessageBox.Show("You are trying to delete this record, are you sure?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string ginNumber = (string)employeeDatabaseDataGridView.SelectedRows[0].Cells[0].Value;
                    DateTime checkDate = (DateTime)employeeDatabaseDataGridView.SelectedRows[0].Cells[2].Value;
                    employeeRecords.RemoveRecord(ginNumber, checkDate.ToShortDateString());

                    FilterRecords();
                    UpdateAutoCompleteStringForFilterGinNumberTextBox();
                }

                ChangeStatusInfo("Ready");
            }
        }

        // status update
        private void ChangeStatusInfo(string message)
        {
            statusLabel.Text = message;

            string iconPath = statusIconsInfo[message];
            statusLabel.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + iconPath);
        }

        /////////////// Filter Control Events /////////////////

        private void FilterGinNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAutoCompleteStringForFilterGinNumberTextBox();

            ValidExistedGinNumberInputWithTipInfo(filterGinNumberTextBox, filterGinNumberTipLabel);

            //ClearHealthInfoInput();

            FilterRecords();
        }

        private void FilterDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FilterRecords();
        }

        private void ViewOnlySuspectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FilterRecords();
        }

        private void FilterCheckDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FilterRecords();
        }

        private void FilterCheckDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FilterRecords();
        }

        private void FilterRecords()
        {
            List<EmployeeRecord> filterBindingList = employeeRecords.GetAllRecords();
            if (filterCheckDateCheckBox.Checked)
            {
                filterBindingList = filterBindingList.FindAll(x => x.CheckDate.ToShortDateString() == filterCheckDateTimePicker.Value.ToShortDateString());
            }

            if (viewOnlySuspectCheckBox.Checked)
            {
                filterBindingList = filterBindingList.FindAll(x => !string.IsNullOrEmpty(x.GetAbnormalInfo()));
            }

            string ginNumber = filterGinNumberTextBox.Text.Trim();
            if (WFAPPInputValidator.IsValidExistedGinNumber(ginNumber, employeeRecords))
            {
                filterBindingList = filterBindingList.FindAll(x => x.GinNumber == ginNumber);
            }

            // status bar: records statistics
            List<EmployeeRecord> suspectRecords = filterBindingList.FindAll(x => !string.IsNullOrEmpty(x.GetAbnormalInfo()));
            recordsStatisticsStatusLabel.Text = filterBindingList.Count.ToString();
            suspectRecordsNumberStatusLabel.Text = suspectRecords.Count.ToString();

            // update datagrid view/source
            employeeRecordBindingSource.DataSource = EmployeeRecords.TransformRecordListToBindingSource(filterBindingList.ToArray());
        }

        ///////////////// Menu Strips ///////////////////

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabaseFromFile();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDatabaseToFile();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        private void EditRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCurrentRecord();
        }

        private void DeleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCurrentRecord();
        }

        private void ViewCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // HACK
            System.Diagnostics.Process.Start("https://github.com/kristol07/Csharp--/tree/master/EmployeeHealthRecord.WFApp.v3");
        }

        private void AboutHealthRecorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
            //MessageBox.Show("This is an application for helping recording and management of employee health info during the outbreak of COVID-19.", "About Employee Health Recorder");
        }

        ///////////////// ContextMenu Strips ////////////////

        private void ViewOnlySuspectEployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewOnlySuspectCheckBox.Checked = true;
            FilterRecords();
        }

        private void ViewAllEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewOnlySuspectCheckBox.Checked = false;
            FilterRecords();
        }

        private void ImportFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabaseFromFile();
        }

        private void SaveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveDatabaseToFile();
        }

        private void AddNewRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        private void DeleteCurrentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCurrentRecord();
        }

        private void EditCurrentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCurrentRecord();
        }

        //////////////// Tool Strips /////////////////////

        private void ImportRecordsToolStripButton_Click(object sender, EventArgs e)
        {
            ImportDatabaseFromFile();
        }

        private void SaveRecordsToolStripButton_Click(object sender, EventArgs e)
        {
            SaveDatabaseToFile();
        }

        private void AddRecordToolStripButton_Click(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        private void EditRecordToolStripButton_Click(object sender, EventArgs e)
        {
            EditCurrentRecord();
        }

        private void DeleteRecordToolStripButton_Click(object sender, EventArgs e)
        {
            DeleteCurrentRecord();
        }

        private void SearchToolStripTextBox_Click(object sender, EventArgs e)
        {
            SearchToolStripTextBox.ForeColor = Color.Black;
            SearchToolStripTextBox.Text = "";
        }

        private void SearchToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            // UNDONE
        }

        private void SearchToolStripTextBox_Leave(object sender, EventArgs e)
        {
            SearchToolStripTextBox.ForeColor = Color.Gray;
            SearchToolStripTextBox.Text = "Search By GinNumber & CheckDate";
        }

        ///////////////// status strip //////////////////////

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeStatusLabel.Text = DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        }

    }
}
