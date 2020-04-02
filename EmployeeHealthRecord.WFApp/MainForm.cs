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

namespace EmployeeHealthRecord.WFApp
{
    public partial class MainForm : Form
    {

        EmployeeDatabase employeeDatabase;

        public MainForm()
        {
            InitializeComponent();

            employeeDatabase = new EmployeeDatabase();

        }

        private void bodyTemperatureTextBox_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(bodyTemperatureTextBox.Text))
            {
                bodyTemperatureTextBox.BackColor = Color.White;
                return;
            }

            if(!double.TryParse(bodyTemperatureTextBox.Text, out _))
            {
                bodyTemperatureTextBox.BackColor = Color.Red;
            }
            else
            {
                bodyTemperatureTextBox.BackColor = Color.White;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string errorMessage;
            if(IsValidNewEmployeeInput(out errorMessage))
            {
                string ginNumber = ginNumberTextBox.Text;
                string name = nameTextBox.Text;
                double bodyTemperature = double.Parse(bodyTemperatureTextBox.Text);
                DateTime checkDate = checkDateTimePicker.Value.Date;
                bool hasHubeiTravelHistory = hubeiTravelHistoryCheckBox.Checked;
                bool hasSymptoms = symptomsCheckBox.Checked;

                employeeDatabase.AddEmployee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);
                
                MessageBox.Show($"Record of Employee \"{name}\" with GinNumber \"{ginNumber}\" added to database", "Add Employee", MessageBoxButtons.OK);
                
                ClearEmployeeDataInput();
            }
            else
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
            }
        }

        private void loadDatabaseButton_Click(object sender, EventArgs e)
        {
            if(loadDatabaseOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = loadDatabaseOpenFileDialog.FileName;
                EmployeeDataFileOperation.ReadDatabaseFromCSVFile(filePath, ref employeeDatabase);
                MessageBox.Show($"{filePath}" , "Database load from CSV file:", MessageBoxButtons.OK);
            }
        }


        private bool IsValidNewEmployeeInput(out string errorMessage)
        {
            errorMessage = "";

            List<string> emptyItems = GetEmptyInputItems();
            if(emptyItems.Count != 0)
            {
                errorMessage += string.Join(", ", emptyItems) + " to input!\n";
                return false;
            }

            if (!WFAPPInputValidator.IsValidNewGinNumber(ginNumberTextBox.Text, ref employeeDatabase))
            {
                errorMessage += $"Employee with same GinNumber {ginNumberTextBox.Text} existed already!\n";
            }

            //if (!WFAPPInputValidator.IsValidNewName(nameTextBox.Text))
            //{
            //    errorMessage += "Employee with Name ${nameTextBox.Text} existed already!\n";
            //}

            if (!WFAPPInputValidator.IsValidBodyTemperature(bodyTemperatureTextBox.Text))
            {
                errorMessage += "For Body Temperature, only numeric value is allowed.\n";
            }

            if (checkDateTimePicker.Value.Date > DateTime.Today)
            {
                errorMessage += "Check date can not be future date.\n";
            }

            return string.IsNullOrEmpty(errorMessage);

        }

        private List<string> GetEmptyInputItems()
        {
            List<string> emptyItems = new List<string>();
            if(string.IsNullOrWhiteSpace(ginNumberTextBox.Text))
            {
                emptyItems.Add("GinNumber");
            }
            if(string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                emptyItems.Add("Name");
            }
            if(string.IsNullOrWhiteSpace(bodyTemperatureTextBox.Text))
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
            hubeiTravelHistoryCheckBox.Checked = false;
            symptomsCheckBox.Checked = false;
            notesRichTextBox.Clear();
        }

    }
}
