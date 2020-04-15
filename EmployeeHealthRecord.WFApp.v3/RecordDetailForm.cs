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
    public partial class RecordDetailForm : Form
    {

        EmployeeRecord currentRecord;
        EmployeeRecords employeeRecords;

        public event UpdateView updatedRecords;

        public RecordDetailForm(EmployeeRecord currentRecord, EmployeeRecords employeeRecords)
        {
            InitializeComponent();
            this.currentRecord = currentRecord;
            this.employeeRecords = employeeRecords;

            ShowCurrentRecordInfo();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            UpdateRecordForm editRecordForm = new UpdateRecordForm(employeeRecords, currentRecord, "Edit");
            editRecordForm.Text = "Edit Record";
            editRecordForm.updatedView += ShowCurrentRecordInfo;
            editRecordForm.ShowDialog();

            if (updatedRecords != null)
            {
                updatedRecords();
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are trying to delete this record, are you sure?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                employeeRecords.RemoveRecord(currentRecord.GinNumber, currentRecord.CheckDate.ToShortDateString());

                if (updatedRecords != null)
                {
                    updatedRecords();
                }

                this.Close();
            }
        }

        private void ShowCurrentRecordInfo()
        {
            if (currentRecord != null)
            {
                ginNumberValue.Text = currentRecord.GinNumber;
                nameValue.Text = currentRecord.Name;
                checkDateValue.Text = currentRecord.CheckDate.ToShortDateString();
                temperatureValue.Text = currentRecord.BodyTemperature.ToString();
                if(!WFAPPInputValidator.IsNormalBodyTemperature(currentRecord.BodyTemperature))
                {
                    temperatureValue.ForeColor = Color.Red;
                }
                else
                {
                    temperatureValue.ForeColor = Color.Black;
                }
                hasHubeiTravelHistoryValue.Text = currentRecord.HasHubeiTravelHistory.ToString();
                if(!WFAPPInputValidator.IsNormalHubeiTravelHistoryChoice(currentRecord.HasHubeiTravelHistory))
                {
                    hasHubeiTravelHistoryValue.ForeColor = Color.Red;
                }
                else
                {
                    hasHubeiTravelHistoryValue.ForeColor = Color.Black;
                }
                hasSymptomsValue.Text = currentRecord.HasSymptoms.ToString();
                if(!WFAPPInputValidator.IsNormalSymtomsChoice(currentRecord.HasSymptoms))
                {
                    hasSymptomsValue.ForeColor = Color.Red;
                }
                else
                {
                    hasSymptomsValue.ForeColor = Color.Black;
                }
                notesValue.Text = currentRecord.Notes;
            }
        }
    }
}
