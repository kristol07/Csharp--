﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        string operation;

        public UpdateRecordForm(EmployeeRecords employeeRecords, EmployeeRecord currentRecord, string operation)
        {
            this.employeeRecords = employeeRecords;
            this.currentRecord = currentRecord;
            this.operation = operation;

            GIN_NUMBER_TYPE_TIP = "? Number Only"; //"Not valid GinNumber type (Integer)."; //"Only integer is allowed for ginNumber.";
            CHECKDATE_VALUE_TIP = "Check date can not be future date.";
            BODY_TEMPERATURE_VALUE_TIP = "Human Body Temperature should be 35-43.";
            BODY_TEMPERATURE_TYPE_TIP = "Not valid Temperature type (Numbers)."; //"Only numerical value is allowed for Temperature.";

            InitializeComponent();

            if (currentRecord != null)
            {
                ginNumberTextBox.Text = currentRecord.GinNumber;
                nameTextBox.Text = currentRecord.Name;
                checkdateTimePicker.Value = currentRecord.CheckDate;
                bodyTemperatureTextBox.Text = currentRecord.BodyTemperature.ToString();
                hasHubeiTravelHistoryCheckBox.Checked = currentRecord.HasHubeiTravelHistory;
                hasSymptomsCheckBox.Checked = currentRecord.HasSymptoms;
                notesRichTextBox.Text = currentRecord.Notes;
            }
        }

        // others

        private void UpdateCurrentRecord()
        {
            if(currentRecord != null)
            {
                currentRecord.GinNumber = ginNumberTextBox.Text;
                currentRecord.Name = nameTextBox.Text;
                currentRecord.CheckDate = checkdateTimePicker.Value;
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

        public void ValidBodyTemperatureInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_VALUE_TIP, WFAPPInputValidator.IsValidBodyTemperatureValue);
            AddTipInfoForInvalidInput(textbox, tipLabel, BODY_TEMPERATURE_TYPE_TIP, WFAPPInputValidator.IsValidBodyTemperatureType);
            ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, WFAPPInputValidator.IsValidBodyTemperature);
        }

        // control event

        private void GinNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            AddTipInfoForInvalidInput(ginNumberTextBox, ginNumberTipLabel, GIN_NUMBER_TYPE_TIP, WFAPPInputValidator.IsValidGinNumberType);
            ClearTipInfoWhenInputIsEmptyOrValid(ginNumberTextBox, ginNumberTipLabel, WFAPPInputValidator.IsValidGinNumberType);
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!WFAPPInputValidator.IsValidCheckDateValue(checkdateTimePicker.Value.ToShortDateString()))
            {
                checkdateTipLabel.Text = CHECKDATE_VALUE_TIP;
                checkdateTipLabel.ForeColor = Color.Red;
            }
            else
            {
                checkdateTipLabel.Text = "";
                checkdateTipLabel.ForeColor = Color.White;
            }
        }

        private void BodyTemperatureTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidBodyTemperatureInputWithTipInfo(bodyTemperatureTextBox, bodyTemperatureTipLabel);
        }

        private void HasHubeiTravelHistoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HasSymptomsCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NotesRichTextBox_TextChanged(object sender, EventArgs e)
        {

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

                if (currentRecord != null)
                {
                    employeeRecords.RemoveRecord(currentRecord.GinNumber, currentRecord.CheckDate);
                }

                employeeRecords.AddRecord(ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
                UpdateCurrentRecord();

                MessageBox.Show($"Record of Employee \"{name}\" with GinNumber \"{ginNumber}\" in \"{checkDate}\" updated.", "Update Employee Records", MessageBoxButtons.OK);

                if (updatedView != null)
                {
                    updatedView();
                }

                this.Close();
            }
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

            string ginNumber = ginNumberTextBox.Text.Trim();
            string checkdate = checkdateTimePicker.Value.ToShortDateString();
            if (operation == "Add")
            {
                if (WFAPPInputValidator.IsValidNewRecord(ginNumber, checkdate, employeeRecords))
                {
                    string confirmMessage = "You are trying to add new record, are you sure?";
                    TrySaveWithConfirmMessage(confirmMessage);
                }
                else
                {
                    MessageBox.Show($"Record existed for GinNumber {ginNumber} in check date {checkdate}. Try edit function.");
                }
            }
            if (operation == "Edit")
            {
                if (ginNumber == currentRecord.GinNumber && checkdate == currentRecord.CheckDate.ToShortDateString())
                {
                    string confirmMessage = "You are trying to update record, are you sure?";
                    TrySaveWithConfirmMessage(confirmMessage);
                }
                else if (WFAPPInputValidator.IsValidExistedRecord(ginNumber, checkdate, employeeRecords))
                {
                    string confirmMessage = "You are trying to override existed record, current record will be also deleted, are you sure?";
                    TrySaveWithConfirmMessage(confirmMessage);
                }
                else if (WFAPPInputValidator.IsValidNewRecord(ginNumber, checkdate, employeeRecords))
                {
                    string confirmMessage = "You are trying to add new record, current record will be also deleted, are you sure?";
                    TrySaveWithConfirmMessage(confirmMessage);
                }
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}