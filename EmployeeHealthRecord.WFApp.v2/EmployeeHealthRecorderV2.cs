using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeHealthRecord;

namespace EmployeeHealthRecord.WFApp.v2
{
    public delegate bool DataValidator(string input);
    public delegate bool DataValidatorWithDatabase(string input, EmployeeDatabase employeeDatabase);

    public partial class EmployeeHealthRecorderV2 : Form
    {

        const string GIN_NUMBER_EXISTED_TIP = "Existed!"; //"Employee with same GinNumber existed, try new one!";
        const string GIN_NUMBER_VALUE_TIP = "Only integer is allowed for ginNumber.";
        const string GIN_NUMBER_NOT_FOUND_TIP = "Not found.";
        const string NAME_EXISTED_TIP = "Existed!"; //"Employee with same Name existed, try new one!";
        const string BODY_TEMPERATURE_VALUE_TIP = "Human Body Temperature should be 35 - 43.";
        const string BODY_TEMPERATURE_TYPE_TIP = "Only numerical value is allowed for Temperature.";
        const string HAS_HUBEI_TRAVEL_HISTORY_VALUE_TIP = "Only \"yes/y/no/n\" (case insensitive) is allowed.";
        const string HAS_SYMPTOMS_VALUE_TIP = "Only \"yes/y/no/n\" (case insensitive) is allowed.";
        const string CHECK_DATE_VALUE_TIP = "Check date can not be future date.";

        private EmployeeDatabase employeeDatabase;
        BindingList<Employee> employeeToRemoveList;

        public EmployeeHealthRecorderV2()
        {
            InitializeComponent();

            employeeDatabase = new EmployeeDatabase();

            employeeBindingSource.DataSource = employeeDatabase.EmployeeList;
            employeeDatabaseDataGridView.DataSource = employeeBindingSource;

            employeeToRemoveList = new BindingList<Employee>();
            employeeToRemoveBindingSource.DataSource = employeeToRemoveList;
            employeeToRemoveDataGridView.DataSource = employeeToRemoveBindingSource;

        }

        private void AddTipInfoForInvalidInput(TextBox textbox, Label tipLabel, string tipInfo, DataValidator dataValidator)
        {
            if (!dataValidator(textbox.Text))
            {
                textbox.BackColor = Color.Red;
                tipLabel.Text = tipInfo;
            }
        }

        private void AddTipInfoForInvalidInput(TextBox textbox, Label tipLabel, string tipInfo, DataValidatorWithDatabase dataValidator)
        {
            if (!dataValidator(textbox.Text, employeeDatabase))
            {
                textbox.BackColor = Color.Red;
                tipLabel.Text = tipInfo;
            }
        }

        private void ClearTipInfoWhenInputIsEmptyOrValid(TextBox textbox, Label tipLabel, DataValidator dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text))
            {
                textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

        private void ClearTipInfoWhenInputIsEmptyOrValid(TextBox textbox, Label tipLabel, DataValidatorWithDatabase dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text, employeeDatabase))
            {
                textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

        private void ginNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection existedGinNumber = new AutoCompleteStringCollection();
            existedGinNumber.AddRange(employeeDatabase.EmployeeData.Keys.ToArray());
            ginNumberTextBox.AutoCompleteCustomSource = existedGinNumber;

            AddTipInfoForInvalidInput(ginNumberTextBox, ginNumberTipLabel, GIN_NUMBER_VALUE_TIP, WFAPPInputValidator.IsValidGinNumberType);
            ClearTipInfoWhenInputIsEmptyOrValid(ginNumberTextBox, ginNumberTipLabel, WFAPPInputValidator.IsValidGinNumberType);

            ClearHealthInfoInput();

            if (WFAPPInputValidator.IsValidExistedGinNumber(ginNumberTextBox.Text, employeeDatabase))
            {
                ShowCurrentEmployeeHealthInfo();
            }
        }

        private void ShowCurrentEmployeeHealthInfo()
        {
            Employee employee = employeeDatabase.GetEmployee(ginNumberTextBox.Text);

            nameTextBox.Text = employee.Name.ToString();
            //checkDateTimePicker.Value = ;
            bodyTemperatureTextBox.Text = employee.BodyTemperature.ToString();
            hasHubeiTravelHistoryCheckBox.Checked = employee.HasHubeiTravelHistory;
            hasSymptomsCheckBox.Checked = employee.HasSymptoms;
            //notesRichTextBox.Text = ;
        }

        private void ClearHealthInfoInput()
        {
            nameTextBox.Text = "";
            checkDateTimePicker.Value = DateTime.Today;
            bodyTemperatureTextBox.Text = "";
            hasHubeiTravelHistoryCheckBox.Checked = false;
            hasSymptomsCheckBox.Checked = false;
            notesRichTextBox.Text = "";
        }


        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!WFAPPInputValidator.IsValidCheckDate(checkDateTimePicker.Value))
            {
                checkDateTipLabel.Text = CHECK_DATE_VALUE_TIP;
            }
            else
            {
                checkDateTipLabel.Text = "";
            }
        }

        private void bodyTemperatureTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidBodyTemperatureInputWithTipInfo(bodyTemperatureTextBox, bodyTemperatureTipLabel);
        }

        private void ValidBodyTemperatureInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_VALUE_TIP, WFAPPInputValidator.IsValidBodyTemperatureValue);
            AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_TYPE_TIP, WFAPPInputValidator.IsValidBodyTemperatureType);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidBodyTemperature);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            if ((GetEmptyInputItems().Count == 0) && IsAllItemsValid())
            {
                string ginNumber = ginNumberTextBox.Text.Trim(' ');
                string name = nameTextBox.Text.Trim(' ');
                double bodyTemperature = double.Parse(bodyTemperatureTextBox.Text);
                DateTime checkDate = checkDateTimePicker.Value.Date;
                bool hasHubeiTravelHistory = hasHubeiTravelHistoryCheckBox.Checked;
                bool hasSymptoms = hasSymptomsCheckBox.Checked;
                string notes = notesRichTextBox.Text;

                employeeDatabase.RemoveEmployee(ginNumber);
                employeeDatabase.AddEmployee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);

                RefreshEmployeeAndSuspectEmployeeDatabaseGridView();

                MessageBox.Show($"Record of Employee \"{name}\" with GinNumber \"{ginNumber}\" updated.", "Update Employee", MessageBoxButtons.OK);

                ginNumberTextBox.Text = "";
                ClearHealthInfoInput();
            }
            else if (GetEmptyInputItems().Count != 0)
            {
                string errorMessage = GetErrorMessageWhenUpdate();
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Items invalid, check items labeled with correcting tip.", "Error", MessageBoxButtons.OK);
            }
        }

        private bool IsAllItemsValid()
        {
            string tipLabel = "";
            tipLabel += ginNumberTipLabel.Text;
            tipLabel += nameTipLabel.Text;
            tipLabel += bodyTemperatureTipLabel.Text;
            tipLabel += checkDateTipLabel.Text;

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

        private void employeeToRemoveTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidExistedGinNumberInputWithTipInfo(employeeToRemoveTextBox, employeeToRemoveTipLabel);

            AutoCompleteStringCollection existedGinNumber = new AutoCompleteStringCollection();
            existedGinNumber.AddRange(employeeDatabase.EmployeeData.Keys.ToArray());
            employeeToRemoveTextBox.AutoCompleteCustomSource = existedGinNumber;
        }

        private void ValidExistedGinNumberInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_NOT_FOUND_TIP, WFAPPInputValidator.IsValidExistedGinNumber);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidExistedGinNumber);
        }

        private void addEmployeeToRemoveButton_Click(object sender, EventArgs e)
        {
            //if(!string.IsNullOrWhiteSpace(employeeToRemoveTextBox.Text) && WFAPPInputValidator.IsValidExistedGinNumber(employeeToRemoveTextBox.Text, ref employeeDatabase))
            if (!string.IsNullOrWhiteSpace(employeeToRemoveTextBox.Text)
                && employeeToRemoveTipLabel.Text == ""
                && !employeeToRemoveList.Contains(employeeDatabase.GetEmployee(employeeToRemoveTextBox.Text)))
            {
                employeeToRemoveList.Add(employeeDatabase.GetEmployee(employeeToRemoveTextBox.Text));
                employeeToRemoveBindingSource.DataSource = employeeToRemoveList;
                employeeToRemoveTextBox.Text = "";
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (employeeToRemoveList.Count != 0)
            {
                if (MessageBox.Show("Confirm removing all these employees?", "Remove Employee", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (employeeToRemoveList.Contains(employeeDatabase.GetEmployee(ginNumberTextBox.Text)))
                    {
                        ClearHealthInfoInput();
                    }

                    foreach (var employee in employeeToRemoveList)
                    {
                        employeeDatabase.RemoveEmployee(employee.GinNumber);
                    }

                    employeeToRemoveTextBox.Text = "";

                    employeeToRemoveList.Clear();
                    employeeToRemoveBindingSource.DataSource = employeeToRemoveList;

                    RefreshEmployeeAndSuspectEmployeeDatabaseGridView();
                }
            }
        }

        private void RefreshEmployeeAndSuspectEmployeeDatabaseGridView()
        {
            if(viewOnlySuspectCheckBox.Checked)
            {
                employeeBindingSource.DataSource = employeeDatabase.SuspectEmployeeList;
            }
            else
            {
                employeeBindingSource.DataSource = employeeDatabase.EmployeeList;
            }
        }

        private void viewOnlySuspectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshEmployeeAndSuspectEmployeeDatabaseGridView();
        }

        private void loadDatabaseButton_Click(object sender, EventArgs e)
        {
            if (loadDatabaseOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = loadDatabaseOpenFileDialog.FileName;
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

        private void saveDatabaseButton_Click(object sender, EventArgs e)
        {
            if (saveDatabaseSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveDatabaseSaveFileDialog.FileName;
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
