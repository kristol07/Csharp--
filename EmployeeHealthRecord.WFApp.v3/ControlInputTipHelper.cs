using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeHealthInfoRecord;

namespace EmployeeHealthRecord.WFApp.v3
{
    public static class ControlInputTipHelper
    {
        public static void AddTipInfoForInvalidInput(Control control, Label tipLabel, string tipInfo, DataValidator dataValidator)
        {
            if (!dataValidator(control.Text.Trim()))
            {
                //textbox.BackColor = Color.FromArgb(255, 186, 205);
                tipLabel.Text = tipInfo;
                tipLabel.ForeColor = Color.Red;
            }
        }

        public static void AddTipInfoForInvalidInput(Control control, Label tipLabel, string tipInfo, EmployeeRecords employeeRecords, DataValidatorWithDatabase dataValidator)
        {
            if (!dataValidator(control.Text.Trim(), employeeRecords))
            {
                //textbox.BackColor = Color.FromArgb(255, 186, 205);
                tipLabel.Text = tipInfo;
                tipLabel.ForeColor = Color.Red;
            }
        }

        public static void ClearTipInfoWhenInputIsEmptyOrValid(Control control, Label tipLabel, DataValidator dataValidator)
        {
            if (string.IsNullOrWhiteSpace(control.Text) || dataValidator(control.Text.Trim()))
            {
                //textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }

        public static void ClearTipInfoWhenInputIsEmptyOrValid(Control control, Label tipLabel, EmployeeRecords employeeRecords, DataValidatorWithDatabase dataValidator)
        {
            if (string.IsNullOrWhiteSpace(control.Text) || dataValidator(control.Text.Trim(), employeeRecords))
            {
                //textbox.BackColor = Color.White;
                tipLabel.Text = "";
            }
        }
    }
}
