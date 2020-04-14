using EmployeeHealthInfoRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MainForm()
        {
            InitializeComponent();

            GIN_NUMBER_TYPE_TIP = "? Number Only"; //"Not valid GinNumber type (Integer)."; //"Only integer is allowed for ginNumber.";
            GIN_NUMBER_NOT_FOUND_TIP = "X Not Found"; //"No such GinNumber found.";//"Record of same GinNumber Not found.";

            employeeRecords = new EmployeeRecords();

            FilterRecords();
            employeeDatabaseDataGridView.DataSource = employeeRecordBindingSource;

        }

        // Validate input with tipinfo

        public void AddTipInfoForInvalidInput(TextBox textbox, Label tipLabel, string tipInfo, DataValidator dataValidator)
        {
            if (!dataValidator(textbox.Text.Trim()))
            {
                //textbox.BackColor = Color.FromArgb(255, 186, 205);
                tipLabel.Text = tipInfo;
                tipLabel.ForeColor = Color.Red;
            }
        }

        public void AddTipInfoForInvalidInput(TextBox textbox, Label tipLabel, string tipInfo, DataValidatorWithDatabase dataValidator)
        {
            if (!dataValidator(textbox.Text.Trim(), employeeRecords))
            {
                //textbox.BackColor = Color.FromArgb(255, 186, 205);
                tipLabel.Text = tipInfo;
                tipLabel.ForeColor = Color.Red;
            }
        }

        public void ClearTipInfoWhenInputIsEmptyOrValid(TextBox textbox, Label tipLabel, DataValidator dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text.Trim()))
            {
                //textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

        public void ClearTipInfoWhenInputIsEmptyOrValid(TextBox textbox, Label tipLabel, DataValidatorWithDatabase dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text.Trim(), employeeRecords))
            {
                //textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

        public void ValidExistedGinNumberInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_NOT_FOUND_TIP, WFAPPInputValidator.IsValidExistedGinNumber);
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_TYPE_TIP, WFAPPInputValidator.IsValidGinNumberType);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidExistedGinNumber);
        }

        // Update autocomplete source for textbox
        public void UpdateAutoCompleteStringForFilterGinNumberTextBox()
        {
            AutoCompleteStringCollection existedGinNumber = new AutoCompleteStringCollection();
            existedGinNumber.AddRange(employeeRecords.RecordsDatabase.Keys.ToArray());
            filterGinNumberTextBox.AutoCompleteCustomSource = existedGinNumber;
        }

        // data file operation

        public void ImportDatabaseFromFile()
        {
            statusLabel.Text = "Loading...";

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

            statusLabel.Text = "Ready";
        }

        public void SaveDatabaseToFile()
        {
            statusLabel.Text = "Saving...";

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

            statusLabel.Text = "Ready";
        }

        private void EditCurrentRecord()
        {
            if (employeeDatabaseDataGridView.SelectedRows.Count != 0)
            {
                statusLabel.Text = "Editing...";
                //statusLabel.Image = Bitmap.FromFile("Icons/status/Edit_16x.png");

                string ginNumber = (string)employeeDatabaseDataGridView.SelectedRows[0].Cells[0].Value;
                string checkDate = ((DateTime)employeeDatabaseDataGridView.SelectedRows[0].Cells[2].Value).ToShortDateString();
                EmployeeRecord currentRecord = employeeRecords.GetEmployeeRecordGivenSpecificDate(ginNumber, checkDate);

                UpdateRecordForm editRecordForm = new UpdateRecordForm(employeeRecords, currentRecord, "Edit");
                editRecordForm.Text = "Edit Record";
                editRecordForm.updatedView += FilterRecords;
                editRecordForm.updatedView += UpdateAutoCompleteStringForFilterGinNumberTextBox;
                editRecordForm.ShowDialog();

                statusLabel.Text = "Ready";
            }
        }

        private void AddNewRecord()
        {
            statusLabel.Text = "Working...";
            //statusLabel.Image = Bitmap.FromFile("Icons/status/StatusUpdate_16x.png");

            UpdateRecordForm addNewRecordForm = new UpdateRecordForm(employeeRecords, null, "Add");
            addNewRecordForm.Text = "Add New Record";
            addNewRecordForm.updatedView += FilterRecords;
            addNewRecordForm.updatedView += UpdateAutoCompleteStringForFilterGinNumberTextBox;
            addNewRecordForm.ShowDialog();

            statusLabel.Text = "Ready";
        }

        private void DeleteCurrentRecord()
        {
            if (employeeDatabaseDataGridView.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("You are trying to delete this record, are you sure?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string ginNumber = (string)employeeDatabaseDataGridView.SelectedRows[0].Cells[0].Value;
                    DateTime checkDate = (DateTime)employeeDatabaseDataGridView.SelectedRows[0].Cells[2].Value;
                    employeeRecords.RemoveRecord(ginNumber, checkDate);

                    FilterRecords();
                    UpdateAutoCompleteStringForFilterGinNumberTextBox();
                }
            }
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

            List<EmployeeRecord> suspectRecords = filterBindingList.FindAll(x => !string.IsNullOrEmpty(x.GetAbnormalInfo()));
            recordsStatisticsStatusLabel.Text = filterBindingList.Count.ToString();
            suspectRecordsNumberStatusLabel.Text = suspectRecords.Count.ToString();

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

        private void FindRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
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

        private void ViewDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeDatabaseDataGridView.SelectedRows.Count != 0)
            {
                string ginNumber = (string)employeeDatabaseDataGridView.SelectedRows[0].Cells[0].Value;
                string checkDate = ((DateTime)employeeDatabaseDataGridView.SelectedRows[0].Cells[2].Value).ToShortDateString();
                EmployeeRecord currentRecord = employeeRecords.GetEmployeeRecordGivenSpecificDate(ginNumber, checkDate);
                RecordDetailForm recordDetailForm = new RecordDetailForm(currentRecord, employeeRecords);
                recordDetailForm.updatedRecords += FilterRecords;
                recordDetailForm.updatedRecords += UpdateAutoCompleteStringForFilterGinNumberTextBox;
                recordDetailForm.ShowDialog();
            }
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


        }

        private void SearchToolStripTextBox_Leave(object sender, EventArgs e)
        {
            SearchToolStripTextBox.ForeColor = Color.Gray;
            SearchToolStripTextBox.Text = "Search By GinNumber & CheckDate";
        }

    }
}
