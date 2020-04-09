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
    public delegate bool DataValidatorWithDatabase(string input, EmployeeDatabase employeeDatabase);

    public partial class MainForm : Form
    {
        const string GIN_NUMBER_EXISTED_TIP = "Existed!"; //"Employee with same GinNumber existed, try new one!";
        const string GIN_NUMBER_VALUE_TIP = "Not valid GinNumber type (Integer)."; //"Only integer is allowed for ginNumber.";
        const string GIN_NUMBER_NOT_FOUND_TIP = "Not found.";
        const string NAME_EXISTED_TIP = "Existed!"; //"Employee with same Name existed, try new one!";
        const string BODY_TEMPERATURE_VALUE_TIP = "Human Body Temperature should be 35 - 43.";
        const string BODY_TEMPERATURE_TYPE_TIP = "Only numerical value is allowed for Temperature.";
        const string HAS_HUBEI_TRAVEL_HISTORY_VALUE_TIP = "Only \"yes/y/no/n\" (case insensitive) is allowed.";
        const string HAS_SYMPTOMS_VALUE_TIP = "Only \"yes/y/no/n\" (case insensitive) is allowed.";
        const string CHECK_DATE_VALUE_TIP = "Check date can not be future date.";

        private EmployeeDatabase employeeDatabase;
        private bool recordUnchanged;

        public MainForm()
        {
            InitializeComponent();

            employeeDatabase = new EmployeeDatabase();

            employeeBindingSource.DataSource = employeeDatabase.EmployeeList;
            employeeDatabaseDataGridView.DataSource = employeeBindingSource;

            recordUnchanged = false;
        }

        private void AddTipInfoForInvalidInput(TextBox textbox, Label tipLabel, string tipInfo, DataValidator dataValidator)
        {
            if (!dataValidator(textbox.Text.Trim()))
            {
                textbox.BackColor = Color.FromArgb(255, 186, 205);
                tipLabel.Text = tipInfo;
            }
        }

        private void AddTipInfoForInvalidInput(TextBox textbox, Label tipLabel, string tipInfo, DataValidatorWithDatabase dataValidator)
        {
            if (!dataValidator(textbox.Text.Trim(), employeeDatabase))
            {
                textbox.BackColor = Color.FromArgb(255, 186, 205);
                tipLabel.Text = tipInfo;
            }
        }

        private void ClearTipInfoWhenInputIsEmptyOrValid(TextBox textbox, Label tipLabel, DataValidator dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text.Trim()))
            {
                textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

        private void ClearTipInfoWhenInputIsEmptyOrValid(TextBox textbox, Label tipLabel, DataValidatorWithDatabase dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text.Trim(), employeeDatabase))
            {
                textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

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

        private void RefreshEmployeeAndSuspectEmployeeDatabaseGridView()
        {
            if (viewOnlySuspectCheckBox.Checked)
            {
                employeeBindingSource.DataSource = employeeDatabase.SuspectEmployeeList;
            }
            else
            {
                employeeBindingSource.DataSource = employeeDatabase.EmployeeList;
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidExistedGinNumberInputWithTipInfo(searchTextBox, searchTipLabel);

            AutoCompleteStringCollection existedGinNumber = new AutoCompleteStringCollection();
            existedGinNumber.AddRange(employeeDatabase.EmployeeData.Keys.ToArray());
            searchTextBox.AutoCompleteCustomSource = existedGinNumber;

            ClearHealthInfoInput();

            if (WFAPPInputValidator.IsValidExistedGinNumber(searchTextBox.Text.Trim(), employeeDatabase))
            {
                ShowCurrentEmployeeHealthInfo();
                recordUnchanged = true;
            }
        }

        private void ShowCurrentEmployeeHealthInfo()
        {
            Employee employee = employeeDatabase.GetEmployee(searchTextBox.Text.Trim());

            ginNumberTextBox.Text = employee.GinNumber;
            nameTextBox.Text = employee.Name;
            //checkDateTimePicker.Value = ;
            bodyTemperatureTextBox.Text = employee.BodyTemperature.ToString();
            hasHubeiTravelHistoryCheckBox.Checked = employee.HasHubeiTravelHistory;
            hasSymptomsCheckBox.Checked = employee.HasSymptoms;
            //notesRichTextBox.Text = ;
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

        private void ValidExistedGinNumberInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_NOT_FOUND_TIP, WFAPPInputValidator.IsValidExistedGinNumber);
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_VALUE_TIP, WFAPPInputValidator.IsValidGinNumberType);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidExistedGinNumber);
        }

        private void viewOnlySuspectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshEmployeeAndSuspectEmployeeDatabaseGridView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabaseFromFile();
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDatabaseToFile();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            System.Diagnostics.Process.Start("https://github.com/kristol07/Csharp--/tree/master/EmployeeHealthRecord.WFApp.v3");
        }

        private void aboutHealthRecorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is an application for helping recording and management of employee health info during the outbreak of COVID-19.", "About Employee Health Recorder");
        }

        private void ginNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            AddTipInfoForInvalidInput(ginNumberTextBox, ginNumberTipLabel, GIN_NUMBER_VALUE_TIP, WFAPPInputValidator.IsValidGinNumberType);
            ClearTipInfoWhenInputIsEmptyOrValid(ginNumberTextBox, ginNumberTipLabel, WFAPPInputValidator.IsValidGinNumberType);

            recordUnchanged = false;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            recordUnchanged = false;
        }

        private void checkdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!WFAPPInputValidator.IsValidCheckDate(checkdateTimePicker.Value))
            {
                checkdateTipLabel.Text = CHECK_DATE_VALUE_TIP;
            }
            else
            {
                checkdateTipLabel.Text = "";
            }

            //recordUnchanged = false;
        }

        private void bodyTemperatureTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidBodyTemperatureInputWithTipInfo(bodyTemperatureTextBox, bodyTemperatureTipLabel);

            recordUnchanged = false;
        }

        private void ValidBodyTemperatureInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_VALUE_TIP, WFAPPInputValidator.IsValidBodyTemperatureValue);
            AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_TYPE_TIP, WFAPPInputValidator.IsValidBodyTemperatureType);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidBodyTemperature);
        }


        private void hasHubeiTravelHistoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            recordUnchanged = false;
        }

        private void hasSymptomsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            recordUnchanged = false;
        }


        private void notesRichTextBox_TextChanged(object sender, EventArgs e)
        {
            //recordUnchanged = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
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

            if (WFAPPInputValidator.IsValidExistedGinNumber(ginNumberTextBox.Text.Trim(), employeeDatabase))
            {
                string confirmMessage = "You are trying to update existed record, are you sure?";
                TrySaveWithConfirmMessage(confirmMessage);
            }
            else if (WFAPPInputValidator.IsValidNewGinNumber(ginNumberTextBox.Text.Trim(), employeeDatabase))
            {
                string confirmMessage = "You are trying to add new record, are you sure?";
                TrySaveWithConfirmMessage(confirmMessage);
            }
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

                employeeDatabase.RemoveEmployee(ginNumber);
                employeeDatabase.AddEmployee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);

                RefreshEmployeeAndSuspectEmployeeDatabaseGridView();

                MessageBox.Show($"Record of Employee \"{name}\" with GinNumber \"{ginNumber}\" updated.", "Update Employee", MessageBoxButtons.OK);

                //ClearHealthInfoInput();
                string memoryGinNumber = searchTextBox.Text;
                searchTextBox.Text = "";
                searchTextBox.Text = memoryGinNumber;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (recordUnchanged == true)
            {
                if(MessageBox.Show("You are trying to delete one record, are you sure?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    employeeDatabase.RemoveEmployee(ginNumberTextBox.Text);

                    RefreshEmployeeAndSuspectEmployeeDatabaseGridView();

                    //ClearHealthInfoInput();
                    string memoryGinNumber = searchTextBox.Text;
                    searchTextBox.Text = "";
                    searchTextBox.Text = memoryGinNumber;
                }
            }
            else
            {
                MessageBox.Show("You have changes unsaved, try save them first!", "Error", MessageBoxButtons.OK);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //ClearHealthInfoInput();
            searchTextBox.Text = "";
            
        }

        private void viewOnlySuspectEployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = employeeDatabase.SuspectEmployeeList;
        }

        private void viewAllEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = employeeDatabase.EmployeeList;
        }

        private void importFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabaseFromFile();
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveDatabaseToFile();
        }

        private void ImportDatabaseFromFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string loadResult = EmployeeDataFileOperation.ReadDatabaseFromCSVFile(filePath, ref employeeDatabase);

                switch (loadResult)
                {
                    case "success":
                        RefreshEmployeeAndSuspectEmployeeDatabaseGridView();
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
                string saveResult = EmployeeDataFileOperation.SaveDatabaseToCSVFile(filePath, employeeDatabase);

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

    }
}
