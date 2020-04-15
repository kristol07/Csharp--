using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHealthRecord.WFApp.v3
{
    public class IconsImageResource
    {

        public Dictionary<string, string> IconImagePath
        {
            get; set;
        }

        public IconsImageResource()
        {
            IconImagePath = new Dictionary<string, string>();
            IconImagePath.Add("Ready", "/Icons/status/StatusOK_blue_16x.png");
            IconImagePath.Add("Working...", "/Icons/status/StatusUpdate_16x.png");
            IconImagePath.Add("Editing...", "/Icons/status/Edit_16x.png");
            IconImagePath.Add("Deleting...", "/Icons/status/DeleteClause_16x.png");
            IconImagePath.Add("Loading...", "/Icons/status/Download_16x.png");
            IconImagePath.Add("Saving...", "/Icons/status/SaveStatusBar8_16x.png");
            IconImagePath.Add("Searching...", "/Icons/status/CloudSearch_16x.png");
        }
    }
}
