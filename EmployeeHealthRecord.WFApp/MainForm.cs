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
using System.Collections.Specialized;

namespace EmployeeHealthRecord.WFApp
{

    public delegate bool DataValidator(string input);
    public delegate bool DataValidatorWithDatabase(string input, ref EmployeeDatabase employeeDatabase);

    public partial class MainForm : Form
    {
        // HACK: one Tip class ?
        const string GIN_NUMBER_EXISTED_TIP = "Existed!"; //"Employee with same GinNumber existed, try new one!";
        const string GIN_NUMBER_VALUE_TIP = "Only integer is allowed for ginNumber.";
        const string GIN_NUMBER_NOT_FOUND_TIP = "Not found.";
        const string NAME_EXISTED_TIP = "Existed!"; //"Employee with same Name existed, try new one!";
        const string BODY_TEMPERATURE_VALUE_TIP = "Human Body Temperature should be 35 - 43.";
        const string BODY_TEMPERATURE_TYPE_TIP = "Only numerical value is allowed for Temperature.";
        const string HAS_HUBEI_TRAVEL_HISTORY_VALUE_TIP = "Only \"yes/y/no/n\" (case insensitive) is allowed.";
        const string HAS_SYMPTOMS_VALUE_TIP = "Only \"yes/y/no/n\" (case insensitive) is allowed.";
        const string CHECK_DATE_VALUE_TIP = "Check date can not be future date.";

        EmployeeDatabase employeeDatabase;
        BindingList<Employee> employeeToRemoveList;

        public MainForm()
        {
            InitializeComponent();

            employeeDatabase = new EmployeeDatabase();

            employeeBindingSource.DataSource = employeeDatabase.EmployeeList;
            employeeDatabaseDataGridView.DataSource = employeeBindingSource;

            suspectEmployeeBindingSource.DataSource = employeeDatabase.SuspectEmployeeList;
            suspectEmployeeDataGridView.DataSource = suspectEmployeeBindingSource;

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
            if (!dataValidator(textbox.Text, ref employeeDatabase))
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
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text, ref employeeDatabase))
            {
                textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

        private void RefreshEmployeeAndSuspectEmployeeDatabaseGridView()
        {
            employeeBindingSource.DataSource = employeeDatabase.EmployeeList;
            suspectEmployeeBindingSource.DataSource = employeeDatabase.SuspectEmployeeList;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            if ((GetEmptyInputItems().Count == 0) && IsAllItemsValid())
            {
                string ginNumber = ginNumberTextBox.Text.TrimStart(' ').TrimEnd(' ');
                string name = nameTextBox.Text.TrimStart(' ').TrimEnd(' ');
                double bodyTemperature = double.Parse(bodyTemperatureTextBox.Text);
                DateTime checkDate = checkDateTimePicker.Value.Date;
                bool hasHubeiTravelHistory = hubeiTravelHistoryCheckBox.Checked;
                bool hasSymptoms = symptomsCheckBox.Checked;
                string notes = notesRichTextBox.Text;

                employeeDatabase.AddEmployee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);

                RefreshEmployeeAndSuspectEmployeeDatabaseGridView();

                MessageBox.Show($"Record of Employee \"{name}\" with GinNumber \"{ginNumber}\" added to database.", "Add Employee", MessageBoxButtons.OK);

                ClearEmployeeDataInput();
            }
            else if (GetEmptyInputItems().Count != 0)
            {
                string errorMessage = GetErrorMessageWhenSubmit();
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Items invalid, check items labeled with correcting tip.", "Error", MessageBoxButtons.OK);
            }
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

        private void ginNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidNewGinNumberInputWithTipInfo(ginNumberTextBox, ginNumberTipLabel);
        }

        private void ValidNewGinNumberInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_EXISTED_TIP, WFAPPInputValidator.IsValidNotExistedGinNumber);
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_VALUE_TIP, WFAPPInputValidator.IsValidGinNumberType);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidNewGinNumber);
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

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidNewNameInputWithTipInfo(nameTextBox, nameTipLabel);
        }

        private void ValidNewNameInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, NAME_EXISTED_TIP, WFAPPInputValidator.IsValidNewName);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidNewName);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearEmployeeDataInput();
        }

        private void addEmployeeToRemoveButton_Click(object sender, EventArgs e)
        {
            //if(!string.IsNullOrWhiteSpace(employeeToRemoveTextBox.Text) && WFAPPInputValidator.IsValidExistedGinNumber(employeeToRemoveTextBox.Text, ref employeeDatabase))
            if (!string.IsNullOrWhiteSpace(employeeToRemoveTextBox.Text)
                && removeGinNumberTipLabel.Text == ""
                && !employeeToRemoveList.Contains(employeeDatabase.GetEmployee(employeeToRemoveTextBox.Text)))
            {
                employeeToRemoveList.Add(employeeDatabase.GetEmployee(employeeToRemoveTextBox.Text));
                employeeToRemoveBindingSource.DataSource = employeeToRemoveList;
                employeeToRemoveTextBox.Text = "";
            }
        }

        private void employeeToRemoveTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidExistedGinNumberInputWithTipInfo(employeeToRemoveTextBox, removeGinNumberTipLabel);

            AutoCompleteStringCollection existedGinNumber = new AutoCompleteStringCollection();
            existedGinNumber.AddRange(employeeDatabase.EmployeeData.Keys.ToArray());
            employeeToRemoveTextBox.AutoCompleteCustomSource = existedGinNumber;
        }

        private void ValidExistedGinNumberInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_NOT_FOUND_TIP, WFAPPInputValidator.IsValidExistedGinNumber);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidExistedGinNumber);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (employeeToRemoveList.Count != 0)
            {
                if (MessageBox.Show("Confirm removing all these employees?", "Remove Employee", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (employeeToRemoveList.Contains(employeeDatabase.GetEmployee(employeeToEditTextBox.Text)))
                    {
                        employeeToEditTextBox.Text = "";
                        itemToEditComboBox.SelectedIndex = -1;
                        valueToEditTextBox.Text = "";
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

        private void employeeToEditTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidExistedGinNumberInputWithTipInfo(employeeToEditTextBox, editGinNumberTipLabel);

            AutoCompleteStringCollection existedGinNumber = new AutoCompleteStringCollection();
            existedGinNumber.AddRange(employeeDatabase.EmployeeData.Keys.ToArray());
            employeeToEditTextBox.AutoCompleteCustomSource = existedGinNumber;

            if(employeeToEditInfoListView.Items.Count != 0 )
            {
                employeeToEditInfoListView.Items.Clear();
            }
            
            if (WFAPPInputValidator.IsValidExistedGinNumber(employeeToEditTextBox.Text, ref employeeDatabase))
            {
                Employee employeeToEdit = employeeDatabase.GetEmployee(employeeToEditTextBox.Text);
                GenerateEmployeeListView(employeeToEdit, employeeToEditInfoListView);
            }
        }

        private void GenerateEmployeeListView(Employee employee, ListView listView)
        {
            listView.Items.Add(GenerateListViewItem("GinNumber", employee.GinNumber));
            listView.Items.Add(GenerateListViewItem("Name", employee.Name));
            listView.Items.Add(GenerateListViewItem("BodyTemperature", employee.BodyTemperature.ToString()));
            listView.Items.Add(GenerateListViewItem("HasHubeiTravelHistory", employee.HasHubeiTravelHistory.ToString()));
            listView.Items.Add(GenerateListViewItem("HasSymptoms", employee.HasSymptoms.ToString()));
        }

        private ListViewItem GenerateListViewItem(string item, string value)
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.SubItems.Add(item);
            listViewItem.SubItems.Add(value);
            return listViewItem;
        }

        private void itemToEditComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueToEditTextBox.Text = "";
        }

        private void valueToEditTextBox_TextChanged(object sender, EventArgs e)
        {
            switch (itemToEditComboBox.Text)
            {
                case "GinNumber":
                    ValidNewGinNumberInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel);
                    break;
                case "Name":
                    ValidNewNameInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel);
                    break;
                case "Body Temperature":
                    ValidBodyTemperatureInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel);
                    break;
                case "Has Hubei Travel History":
                    ValidHasHubeiTravelHistoryInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel);
                    break;
                case "Has Symptoms":
                    ValidHasSymptomsInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel);
                    break;
            }
        }

        private void ValidHasHubeiTravelHistoryInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, HAS_HUBEI_TRAVEL_HISTORY_VALUE_TIP, WFAPPInputValidator.IsValidHasHubeiTravelHistoryChoice);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidHasHubeiTravelHistoryChoice);
        }

        private void ValidHasSymptomsInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, HAS_SYMPTOMS_VALUE_TIP, WFAPPInputValidator.IsValidHasSymptomsChoice);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidHasSymptomsChoice);
        }

        private void confirmEditButton_Click(object sender, EventArgs e)
        {
            // TODO: More clear and simple way ?
            if (!string.IsNullOrWhiteSpace(employeeToEditTextBox.Text)
                && string.IsNullOrWhiteSpace(editGinNumberTipLabel.Text)
                && itemToEditComboBox.SelectedItem != null
                && !string.IsNullOrWhiteSpace(valueToEditTextBox.Text)
                && string.IsNullOrWhiteSpace(valueToEditTipLabel.Text))
            {
                employeeDatabase.EditEmployeeInfo(employeeToEditTextBox.Text, itemToEditComboBox.Text, valueToEditTextBox.Text);

                RefreshEmployeeAndSuspectEmployeeDatabaseGridView();

                string originalEmployeeToEdit = employeeToEditTextBox.Text;
                employeeToEditTextBox.Text = "";
                employeeToEditTextBox.Text = originalEmployeeToEdit;
                //employeeToEditInfoListView.Items.Clear();
                itemToEditComboBox.SelectedIndex = -1;
                valueToEditTextBox.Text = "";

                employeeToRemoveList.Clear();
                employeeToRemoveBindingSource.DataSource = employeeToRemoveList;
            }
        }

        private string GetErrorMessageWhenSubmit()
        {
            string errorMessage = "";

            List<string> emptyItems = GetEmptyInputItems();
            if (emptyItems.Count != 0)
            {
                errorMessage += string.Join(", ", emptyItems) + " to input!";
            }

            return errorMessage;
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

        private void ClearEmployeeDataInput()
        {
            ginNumberTextBox.Clear();
            nameTextBox.Clear();
            bodyTemperatureTextBox.Clear();
            checkDateTimePicker.Value = DateTime.Today;
            hubeiTravelHistoryCheckBox.Checked = false;
            symptomsCheckBox.Checked = false;
            notesRichTextBox.Clear();
        }

        // UNDONE: clear all the input on the form
        private void ClearAllInput()
        {

        }

    }
}
