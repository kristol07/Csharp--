﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EmployeeHealthInfoRecord;

namespace EmployeeHealthRecord.WFApp.v3
{
    public partial class UpdateRecordForm : Form
    {
        private EmployeeRecords employeeRecords;
        public event UpdateView updatedView;

        readonly string GIN_NUMBER_TYPE_TIP;
        readonly string CHECKDATE_VALUE_TIP;
        readonly string BODY_TEMPERATURE_VALUE_TIP;
        readonly string BODY_TEMPERATURE_TYPE_TIP;

        EmployeeRecord currentRecord;
        string operation;  // edit or add

        ControlInputTipHelper tipHelper;
        WinFormAppInputValidator inputValidator;

        public UpdateRecordForm(EmployeeRecords employeeRecords, EmployeeRecord currentRecord, string operation)
        {
            this.employeeRecords = employeeRecords;
            this.currentRecord = currentRecord;
            this.operation = operation;

            GIN_NUMBER_TYPE_TIP = "?: Number Only"; //"Not valid GinNumber type (Integer)."; //"Only integer is allowed for ginNumber.";
            CHECKDATE_VALUE_TIP = @"X: Future Date"; // "Check date can not be future date.";
            BODY_TEMPERATURE_VALUE_TIP = "X: Meaningful = 35~43"; // "Human Body Temperature should be 35-43.";
            BODY_TEMPERATURE_TYPE_TIP = "?: Number Only"; // "Not valid Temperature type (Numbers)."; //"Only numerical value is allowed for Temperature.";

            InitializeComponent();

            tipHelper = new ControlInputTipHelper();
            inputValidator = new WinFormAppInputValidator();

            if (currentRecord != null)
            {
                ginNumberTextBox.Text = currentRecord.GinNumber;
                // ginNumberTextBox.ReadOnly = true; // GinNumber can not be changed.
                nameTextBox.Text = currentRecord.Name;
                checkDateTimePicker.Value = currentRecord.CheckDate;
                bodyTemperatureTextBox.Text = currentRecord.BodyTemperature.ToString();
                hasHubeiTravelHistoryCheckBox.Checked = currentRecord.HasHubeiTravelHistory;
                hasSymptomsCheckBox.Checked = currentRecord.HasSymptoms;
                notesRichTextBox.Text = currentRecord.Notes;
            }
        }

        /////////// Validate input with tip reminder  //////////////

        public void ValidBodyTemperatureInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            tipHelper.AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_VALUE_TIP, inputValidator.IsValidBodyTemperatureValue);
            tipHelper.AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_TYPE_TIP, inputValidator.IsValidBodyTemperatureType);
            tipHelper.ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, inputValidator.IsValidBodyTemperature);
        }

        // others

        private void UpdateCurrentRecord()
        {
            if (currentRecord != null)
            {
                Employee employee = employeeRecords.GetEmployeeGivenGinNumber(ginNumberTextBox.Text);
                //currentRecord.GinNumber = ginNumberTextBox.Text;
                //currentRecord.Name = nameTextBox.Text;
                currentRecord.CheckDate = checkDateTimePicker.Value;
                currentRecord.BodyTemperature = double.Parse(bodyTemperatureTextBox.Text);
                currentRecord.HasHubeiTravelHistory = hasHubeiTravelHistoryCheckBox.Checked;
                currentRecord.HasSymptoms = hasSymptomsCheckBox.Checked;
                currentRecord.Notes = notesRichTextBox.Text;
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

        //

        private void TrySaveWithConfirmMessage(string confirmMessage)
        {
            if (MessageBox.Show(confirmMessage, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string ginNumber = ginNumberTextBox.Text.Trim();
                string name = nameTextBox.Text.Trim();
                double bodyTemperature = double.Parse(bodyTemperatureTextBox.Text);
                DateTime checkDate = checkDateTimePicker.Value.Date;
                bool hasHubeiTravelHistory = hasHubeiTravelHistoryCheckBox.Checked;
                bool hasSymptoms = hasSymptomsCheckBox.Checked;
                string notes = notesRichTextBox.Text;

                if (currentRecord != null)
                {
                    employeeRecords.EditRecord(currentRecord.GinNumber, currentRecord.CheckDate, ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
                }
                else
                {
                    employeeRecords.AddRecord(ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
                }

                // UpdateCurrentRecord();

                MessageBox.Show($"Record of Employee \"{name}\" with GinNumber \"{ginNumber}\" in \"{checkDate}\" updated.", "Update Employee Records", MessageBoxButtons.OK);

                if (updatedView != null)
                {
                    updatedView();
                }

                this.Close();
            }
        }

        private void TryEditCurrentRecord()
        {
            string ginNumber = ginNumberTextBox.Text.Trim();
            string checkdate = checkDateTimePicker.Value.ToShortDateString();
            string name = nameTextBox.Text.Trim();

            if (ginNumber == currentRecord.GinNumber && checkdate == currentRecord.CheckDate.ToShortDateString())
            {
                string confirmMessage = "You are trying to update record, are you sure?";
                TrySaveWithConfirmMessage(confirmMessage);
            }
            else if (inputValidator.IsValidExistedRecord(ginNumber, checkdate, employeeRecords))
            {
                MessageBox.Show("You are trying to override existed record. Try edit directly that one.");
            }
            else if (inputValidator.IsValidNewRecord(ginNumber, checkdate, employeeRecords))
            {
                if (inputValidator.IsValidExistedGinNumber(ginNumber, employeeRecords) && !inputValidator.IsValidSameNameForExistedGinNumber(ginNumber, name, employeeRecords))
                {
                    MessageBox.Show("You are trying to edit name for existed GinNumber, this is not allowed.\nTry first edit name directly for one record without changing GinNumber and CheckDate");
                }
                else
                {
                    string confirmMessage = "You are trying to add new record, current record will be also deleted, are you sure?";
                    TrySaveWithConfirmMessage(confirmMessage);
                }
            }
        }

        private void TryAddNewRecord()
        {
            string ginNumber = ginNumberTextBox.Text.Trim();
            string checkdate = checkDateTimePicker.Value.ToShortDateString();
            string name = nameTextBox.Text.Trim();

            if (inputValidator.IsValidNewRecord(ginNumber, checkdate, employeeRecords) && inputValidator.IsValidSameNameForExistedGinNumber(ginNumber, name, employeeRecords))
            {
                string confirmMessage = "You are trying to add new record, are you sure?";
                TrySaveWithConfirmMessage(confirmMessage);
            }
            else if (inputValidator.IsValidNewRecord(ginNumber, checkdate, employeeRecords) && !inputValidator.IsValidSameNameForExistedGinNumber(ginNumber, name, employeeRecords))
            {
                MessageBox.Show($"You can not change Name for existed GinNumber. Try edit function.");
            }
            else
            {
                MessageBox.Show($"Record existed for GinNumber {ginNumber} in check date {checkdate}. Try edit function.");
            }
        }

        // control event

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

            if (operation == "Add")
            {
                TryAddNewRecord();
            }
            else if (operation == "Edit")
            {
                TryEditCurrentRecord();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GinNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            tipHelper.AddTipInfoForInvalidInput(ginNumberTextBox, ginNumberTipLabel, GIN_NUMBER_TYPE_TIP, inputValidator.IsValidGinNumberType);
            tipHelper.ClearTipInfoWhenInputIsEmptyOrValid(ginNumberTextBox, ginNumberTipLabel, inputValidator.IsValidGinNumberType);
        }

        private void BodyTemperatureTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidBodyTemperatureInputWithTipInfo(bodyTemperatureTextBox, bodyTemperatureTipLabel);
        }

        private void CheckdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            tipHelper.AddTipInfoForInvalidInput(checkDateTimePicker, checkDateTipLabel, CHECKDATE_VALUE_TIP, inputValidator.IsValidCheckDateValue);
            tipHelper.ClearTipInfoWhenInputIsEmptyOrValid(checkDateTimePicker, checkDateTipLabel, inputValidator.IsValidCheckDateValue);
        }

    }
}
