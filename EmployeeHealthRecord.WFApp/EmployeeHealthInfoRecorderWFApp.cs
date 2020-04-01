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
    public partial class EmployeeHealthInfoRecorderWFApp : Form
    {

        EmployeeDatabase employeeDatabase;

        public EmployeeHealthInfoRecorderWFApp()
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
            string ginNumber = ginNumberTextBox.Text;
            string name = nameTextBox.Text;
            double bodyTemperature = double.Parse(bodyTemperatureTextBox.Text);
            bool hasHubeiTravelHistory = hubeiTravelHistoryCheckBox.Checked;
            bool hasSymptoms = symptomsCheckBox.Checked;

            employeeDatabase.AddEmployee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);
        }
    }
}
