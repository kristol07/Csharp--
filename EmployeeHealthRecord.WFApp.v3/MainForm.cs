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

    public partial class MainForm : Form
    {
        readonly string GIN_NUMBER_EXISTED_TIP;
        readonly string GIN_NUMBER_TYPE_TIP;
        readonly string GIN_NUMBER_NOT_FOUND_TIP;
        readonly string CHECKDATE_VALUE_TIP;
        readonly string CHECKDATE_NOT_FOUND_TIP;
        readonly string RECORD_NOT_FOUND_TIP;
        readonly string NAME_EXISTED_TIP;
        readonly string BODY_TEMPERATURE_VALUE_TIP;
        readonly string BODY_TEMPERATURE_TYPE_TIP;


        private EmployeeRecords employeeRecords;
        private bool recordUnchanged;

        public MainForm()
        {
            InitializeComponent();

            GIN_NUMBER_EXISTED_TIP = "Existed!"; //"Employee with same GinNumber existed, try new one!";
            GIN_NUMBER_TYPE_TIP = "? Number Only";//"Not valid GinNumber type (Integer)."; //"Only integer is allowed for ginNumber.";
            GIN_NUMBER_NOT_FOUND_TIP = "X Not Found";//"No such GinNumber found.";//"Record of same GinNumber Not found.";
            CHECKDATE_VALUE_TIP = "Check date can not be future date.";
            CHECKDATE_NOT_FOUND_TIP = "Record of same Date Not found.";
            RECORD_NOT_FOUND_TIP = "Record Not found.";
            NAME_EXISTED_TIP = "Existed!"; //"Employee with same Name existed, try new one!";
            BODY_TEMPERATURE_VALUE_TIP = "Human Body Temperature should be 35 - 43.";
            BODY_TEMPERATURE_TYPE_TIP = "Not valid Temperature type (Numbers)."; //"Only numerical value is allowed for Temperature.";

            employeeRecords = new EmployeeRecords();

            FilterRecords();
            employeeDatabaseDataGridView.DataSource = employeeRecordBindingSource;

            recordUnchanged = false;
        }

        // Validate input with tipinfo

        private void AddTipInfoForInvalidInput(TextBox textbox, Label tipLabel, string tipInfo, DataValidator dataValidator)
        {
            if (!dataValidator(textbox.Text.Trim()))
            {
                //textbox.BackColor = Color.FromArgb(255, 186, 205);
                tipLabel.Text = tipInfo;
                tipLabel.ForeColor = Color.Red;
            }
        }

        private void AddTipInfoForInvalidInput(TextBox textbox, Label tipLabel, string tipInfo, DataValidatorWithDatabase dataValidator)
        {
            if (!dataValidator(textbox.Text.Trim(), employeeRecords))
            {
                //textbox.BackColor = Color.FromArgb(255, 186, 205);
                tipLabel.Text = tipInfo;
                tipLabel.ForeColor = Color.Red;
            }
        }

        private void ClearTipInfoWhenInputIsEmptyOrValid(TextBox textbox, Label tipLabel, DataValidator dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text.Trim()))
            {
                //textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

        private void ClearTipInfoWhenInputIsEmptyOrValid(TextBox textbox, Label tipLabel, DataValidatorWithDatabase dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text.Trim(), employeeRecords))
            {
                //textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

        private void ValidExistedGinNumberInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_NOT_FOUND_TIP, WFAPPInputValidator.IsValidExistedGinNumber);
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_TYPE_TIP, WFAPPInputValidator.IsValidGinNumberType);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidExistedGinNumber);
        }

        private void ValidBodyTemperatureInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_VALUE_TIP, WFAPPInputValidator.IsValidBodyTemperatureValue);
            AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_TYPE_TIP, WFAPPInputValidator.IsValidBodyTemperatureType);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidBodyTemperature);
        }

        // 

        private bool IsAllItemsValid()
        {
            string tipLabel = "";
            tipLabel += ginNumberTipLabel.Text;
            tipLabel += nameTipLabel.Text;
            tipLabel += bodyTemperatureTipLabel.Text;
            tipLabel += checkdateTipLabel.Text;

            return string.IsNullOrWhiteSpace(tipLabel);
        }

        private string GetErrorMessageWhenUpdate()
        {
            string errorMessage = "";

            List<string> emptyItems = GetEmptyInputItems();
            if (emptyItems.Count != 0)
            {
                errorMessage += string.Join(", ", emptyItems) + " to input!";
            }

            return errorMessage;
        }

        private List<string> GetEmptyInputItems()
        {
            List<string> emptyItems = new List<string>();
            if (string.IsNullOrWhiteSpace(ginNumberTextBox.Text))
            {
                emptyItems.Add("GinNumber");
            }
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                emptyItems.Add("Name");
            }
            if (string.IsNullOrWhiteSpace(bodyTemperatureTextBox.Text))
            {
                emptyItems.Add("Body Temperature");
            }

            return emptyItems;
        }

        private void ShowCurrentEmployeeHealthInfo(string ginNumber, string checkDate)
        {
            EmployeeRecord employeeRecord = employeeRecords.GetEmployeeRecordGivenSpecificDate(ginNumber, checkDate);

            if (employeeRecord != null)
            {
                ginNumberTextBox.Text = employeeRecord.GinNumber;
                nameTextBox.Text = employeeRecord.Name;
                checkdateTimePicker.Value = employeeRecord.CheckDate;
                bodyTemperatureTextBox.Text = employeeRecord.BodyTemperature.ToString();
                hasHubeiTravelHistoryCheckBox.Checked = employeeRecord.HasHubeiTravelHistory;
                hasSymptomsCheckBox.Checked = employeeRecord.HasSymptoms;
                notesRichTextBox.Text = employeeRecord.Notes;
            }
        }

        private void ClearHealthInfoInput()
        {
            ginNumberTextBox.Text = "";
            nameTextBox.Text = "";
            checkdateTimePicker.Value = DateTime.Today;
            bodyTemperatureTextBox.Text = "";
            hasHubeiTravelHistoryCheckBox.Checked = false;
            hasSymptomsCheckBox.Checked = false;
            notesRichTextBox.Text = "";
        }

        private void TrySaveWithConfirmMessage(string confirmMessage)
        {
            if (MessageBox.Show(confirmMessage, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string ginNumber = ginNumberTextBox.Text.Trim();
                string name = nameTextBox.Text.Trim();
                double bodyTemperature = double.Parse(bodyTemperatureTextBox.Text);
                DateTime checkDate = checkdateTimePicker.Value.Date;
                bool hasHubeiTravelHistory = hasHubeiTravelHistoryCheckBox.Checked;
                bool hasSymptoms = hasSymptomsCheckBox.Checked;
                string notes = notesRichTextBox.Text;

                employeeRecords.RemoveRecord(ginNumber, checkDate);
                employeeRecords.AddRecord(ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

                FilterRecords();
                UpdateAutoCompleteStringForFilterGinNumberTextBox();

                MessageBox.Show($"Record of Employee \"{name}\" with GinNumber \"{ginNumber}\" in \"{checkDate}\" updated.", "Update Employee", MessageBoxButtons.OK);

                //ClearHealthInfoInput();
                string memorySearchText = filterGinNumberTextBox.Text;
                filterGinNumberTextBox.Text = "";
                filterGinNumberTextBox.Text = memorySearchText;
            }
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
        }

        private void SaveDatabaseToFile()
        {
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

            employeeRecordBindingSource.DataSource = EmployeeRecords.TransformRecordListToBindingSource(filterBindingList.ToArray());

            if(employeeDatabaseDataGridView.SelectedRows.Count > 0)
            {
                EmployeeRecord currentRecord = employeeDatabaseDataGridView.SelectedRows[0].DataBoundItem as EmployeeRecord;
                ShowCurrentEmployeeHealthInfo(currentRecord.GinNumber, currentRecord.CheckDate.ToShortDateString());
            }
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
            // UNDONE
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

        //////////////// Update Control Events //////////////

        private void GinNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            AddTipInfoForInvalidInput(ginNumberTextBox, ginNumberTipLabel, GIN_NUMBER_TYPE_TIP, WFAPPInputValidator.IsValidGinNumberType);
            ClearTipInfoWhenInputIsEmptyOrValid(ginNumberTextBox, ginNumberTipLabel, WFAPPInputValidator.IsValidGinNumberType);

            recordUnchanged = false;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            recordUnchanged = false;
        }

        private void CheckdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!WFAPPInputValidator.IsValidCheckDateValue(checkdateTimePicker.Value.ToShortDateString()))
            {
                checkdateTipLabel.Text = CHECKDATE_VALUE_TIP;
            }
            else
            {
                checkdateTipLabel.Text = "";
            }

            recordUnchanged = false;
        }

        private void BodyTemperatureTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidBodyTemperatureInputWithTipInfo(bodyTemperatureTextBox, bodyTemperatureTipLabel);

            recordUnchanged = false;
        }

        private void HasHubeiTravelHistoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            recordUnchanged = false;
        }

        private void HasSymptomsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            recordUnchanged = false;
        }

        private void NotesRichTextBox_TextChanged(object sender, EventArgs e)
        {
            recordUnchanged = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (GetEmptyInputItems().Count != 0)
            {
                string errorMessage = GetErrorMessageWhenUpdate();
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
                return;
            }

            if (!IsAllItemsValid())
            {
                MessageBox.Show("Items invalid, check items labeled with correcting tip.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (WFAPPInputValidator.IsValidExistedRecord(ginNumberTextBox.Text.Trim(), checkdateTimePicker.Value.ToShortDateString(), employeeRecords))
            {
                string confirmMessage = "You are trying to update existed record, are you sure?";
                TrySaveWithConfirmMessage(confirmMessage);
            }
            else if (WFAPPInputValidator.IsValidNewRecord(ginNumberTextBox.Text.Trim(), checkdateTimePicker.Value.ToShortDateString(), employeeRecords))
            {
                string confirmMessage = "You are trying to add new record, are you sure?";
                TrySaveWithConfirmMessage(confirmMessage);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (recordUnchanged == true)
            {
                if (MessageBox.Show("You are trying to delete one record, are you sure?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    employeeRecords.RemoveRecord(ginNumberTextBox.Text, checkdateTimePicker.Value);

                    FilterRecords();
                    UpdateAutoCompleteStringForFilterGinNumberTextBox();

                    //ClearHealthInfoInput();
                    string memorySearchText = filterGinNumberTextBox.Text;
                    filterGinNumberTextBox.Text = "";
                    filterGinNumberTextBox.Text = memorySearchText;
                }
            }
            else
            {
                MessageBox.Show("You have changes unsaved, try save them first!", "Error", MessageBoxButtons.OK);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearHealthInfoInput();
            filterGinNumberTextBox.Text = "";
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
            // UNDONE
        }

        private void DeleteCurrentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // UNDONE
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
            // UNDONE
        }

        private void SaveRecordToolStripButton_Click(object sender, EventArgs e)
        {
            // UNDONE
        }

        private void DeleteRecordToolStripButton_Click(object sender, EventArgs e)
        {
            // UNDONE
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
