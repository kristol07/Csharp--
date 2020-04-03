﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeHealthRecord;

namespace EmployeeHealthRecord.WFApp
{

    public delegate bool DataValidator(string input);
    public delegate bool DataValidatorWithDatabase(string input, ref EmployeeDatabase employeeDatabase);

    public partial class MainForm : Form
    {
        const string GIN_NUMBER_EXISTED_TIP = "Employee with same GinNumber existed, try new one!";
        const string NAME_EXISTED_TIP = "Employee with same Name existed, try new one!";
        const string BODY_TEMPERATURE_VALUE_TIP = "Only positive numerical value is allowed for Temperature.";
        const string HAS_HUBEI_TRAVEL_HISTORY_VALUE_TIP = "Only \"yes/y/no/n\" (case insensitive) is allowed.";
        const string HAS_SYMPTOMS_VALUE_TIP = "Only \"yes/y/no/n\" (case insensitive) is allowed.";
        const string EMPLOYEE_NOT_FOUND_TIP = "Not found.";

        EmployeeDatabase employeeDatabase;
        List<string> employeeListToRemove;

        public MainForm()
        {
            InitializeComponent();

            employeeDatabase = new EmployeeDatabase();
            
            employeeListToRemove = new List<string>();
        }

        private void ValidInputWithTipInfo(TextBox textbox, Label tipLabel, string tipInfo, DataValidator dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text))
            {
                textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
            else
            {
                textbox.BackColor = Color.Red;
                tipLabel.Text = tipInfo;
            }
        }

        private void ValidInputWithTipInfo(TextBox textbox, Label tipLabel, string tipInfo, DataValidatorWithDatabase dataValidator)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text) || dataValidator(textbox.Text, ref employeeDatabase))
            {
                textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
            else
            {
                textbox.BackColor = Color.Red;
                tipLabel.Text = tipInfo;
            }
        }

        private void UpdateDatabaseGridView()
        {
            employeeBindingSource = new BindingSource();
            foreach (var employee in employeeDatabase.EmployeeData.Values)
            {
                employeeBindingSource.Add(employee);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            if ((GetEmptyInputItems().Count == 0) && IsAllItemsValid())
            {
                string ginNumber = ginNumberTextBox.Text;
                string name = nameTextBox.Text;
                double bodyTemperature = double.Parse(bodyTemperatureTextBox.Text);
                DateTime checkDate = checkDateTimePicker.Value.Date;
                bool hasHubeiTravelHistory = hubeiTravelHistoryCheckBox.Checked;
                bool hasSymptoms = symptomsCheckBox.Checked;
                string notes = notesRichTextBox.Text;

                employeeDatabase.AddEmployee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);

                UpdateDatabaseGridView();

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
                        MessageBox.Show($"Database loading from {filePath} succeed.", "Loading Database", MessageBoxButtons.OK);
                        UpdateDatabaseGridView();
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
            ValidInputWithTipInfo(bodyTemperatureTextBox, bodyTemperatureTipLabel, BODY_TEMPERATURE_VALUE_TIP, WFAPPInputValidator.IsValidBodyTemperature);
        }

        private void ginNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidInputWithTipInfo(ginNumberTextBox, ginNumberTipLabel, GIN_NUMBER_EXISTED_TIP, WFAPPInputValidator.IsValidNewGinNumber);
        }

        private void checkDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!WFAPPInputValidator.IsValidCheckDate(checkDateTimePicker.Value))
            {
                string checkDateWarningTip = "Check date can not be future date.\n";
                checkDateTipLabel.Text = checkDateWarningTip;
            }
            else
            {
                checkDateTipLabel.Text = "";
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            string nameExistedTip = $"Employee with same Name existed, try new one!\n";
            ValidInputWithTipInfo(nameTextBox, nameTipLabel, nameExistedTip, WFAPPInputValidator.IsValidNewName);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearEmployeeDataInput();
        }

        private void addItemToRemoveButton_Click(object sender, EventArgs e)
        {
            //if(!string.IsNullOrWhiteSpace(employeeToRemoveTextBox.Text) && WFAPPInputValidator.IsValidExistedGinNumber(employeeToRemoveTextBox.Text, ref employeeDatabase))
            if (!string.IsNullOrWhiteSpace(employeeToRemoveTextBox.Text) && removeGinNumberTipLabel.Text == "")
            {
                employeeListToRemove.Add(employeeToRemoveTextBox.Text);
            }
        }

        private void employeeToRemoveTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidInputWithTipInfo(employeeToRemoveTextBox, removeGinNumberTipLabel, EMPLOYEE_NOT_FOUND_TIP, WFAPPInputValidator.IsValidExistedGinNumber);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            employeeDatabase.RemoveEmployee(employeeListToRemove.ToArray());
        }

        private void employeeToEditTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidInputWithTipInfo(employeeToEditTextBox, editGinNumberTipLabel, EMPLOYEE_NOT_FOUND_TIP, WFAPPInputValidator.IsValidExistedGinNumber);
        }

        private void valueToEditTextBox_TextChanged(object sender, EventArgs e)
        {
            switch (itemToEditComboBox.Text)
            {
                case "GinNumber":
                    ValidInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel, GIN_NUMBER_EXISTED_TIP, WFAPPInputValidator.IsValidExistedGinNumber);
                    break;
                case "Name":
                    ValidInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel, NAME_EXISTED_TIP, WFAPPInputValidator.IsValidExistedName);
                    break;
                case "Body Temperature":
                    ValidInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel, BODY_TEMPERATURE_VALUE_TIP, WFAPPInputValidator.IsValidBodyTemperature);
                    break;
                case "Has Hubei Travel History":
                    ValidInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel, HAS_HUBEI_TRAVEL_HISTORY_VALUE_TIP, WFAPPInputValidator.IsValidHasHubeiTravelHistoryChoice);
                    break;
                case "Has Symptoms":
                    ValidInputWithTipInfo(valueToEditTextBox, valueToEditTipLabel, HAS_SYMPTOMS_VALUE_TIP, WFAPPInputValidator.IsValidHasSymptomsChoice);
                    break;
            }
        }

        private void confirmEditButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(editGinNumberTipLabel.Text)
                && itemToEditComboBox.SelectedItem != null
                && !string.IsNullOrWhiteSpace(valueToEditTextBox.Text)
                && string.IsNullOrWhiteSpace(valueToEditTipLabel.Text))
            {
                employeeDatabase.EditEmployeeInfo(employeeToEditTextBox.Text, itemToEditComboBox.Text, valueToEditTextBox.Text);
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

        // to do
        private void ClearAllInput()
        {

        }

    }
}
