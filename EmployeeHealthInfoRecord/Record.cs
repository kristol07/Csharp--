using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EmployeeHealthInfoRecord
{
    public class EmployeeRecord
    {
        Employee relatedEmployee { get; set; }

        public string GinNumber
        {
            get
            {
                return relatedEmployee.GinNumber;
            }
            set
            {
                relatedEmployee.GinNumber = value;
            }
        }

        public string Name
        {
            get
            {
                return relatedEmployee.Name;
            }
            set
            {
                relatedEmployee.Name = value;
            }
        }

        public DateTime CheckDate { get; set; }

        public double BodyTemperature { get; set; }

        public bool HasHubeiTravelHistory { get; set; }

        public bool HasSymptoms { get; set; }

        public string Notes { get; set; }

        public readonly DateTime createTime;

        public List<DateTime> EditTimeHistory { get; set; }

        public EmployeeRecord(Employee employee, DateTime checkDate, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms, string notes = "")
        {
            relatedEmployee = employee;
            CheckDate = checkDate;
            BodyTemperature = bodyTemperature;
            HasHubeiTravelHistory = hasHubeiTravelHistory;
            HasSymptoms = hasSymptoms;
            Notes = notes;

            //createTime = DateTime.Now;
            //Notes = notes + "||" + createTime.ToString();  // HACK: use notes to save create time
            //EditTimeHistory = new List<DateTime>();
            //EditTimeHistory.Add(createTime);
        }

        public void Edit(Employee employee, DateTime checkDate, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms, string notes)
        {
            relatedEmployee = employee;
            CheckDate = checkDate;
            BodyTemperature = bodyTemperature;
            HasHubeiTravelHistory = hasHubeiTravelHistory;
            HasSymptoms = hasSymptoms;
            Notes = notes;
            //EditTimeHistory.Add(DateTime.Now);
        }

        public string FormatForSave()
        {
            string[] allInfo = {
                relatedEmployee.GinNumber,
                CheckDate.ToString("d"),
                relatedEmployee.Name,
                BodyTemperature.ToString(),
                HasHubeiTravelHistory.ToString(),
                HasSymptoms.ToString(),
                Notes,
                //string.Join("|", EditTimeHistory)
            };
            string seperator = ",";

            return string.Join(seperator, allInfo);
        }

        public bool IsSuspected()
        {
            bool isSuspected = false;

            if (BodyTemperature > 37.3)
            {
                isSuspected = true;
            }

            if (HasSymptoms)
            {
                isSuspected = true;
            }

            if (HasHubeiTravelHistory)
            {
                isSuspected = true;
            }

            return isSuspected;
        }

        public string GetAbnormalInfo()
        {
            if (IsSuspected())
            {
                List<string> abnormalInfo = new List<string>();
                abnormalInfo.Add(relatedEmployee.GinNumber + "-" + relatedEmployee.Name + "-" + CheckDate.ToShortTimeString());

                if (BodyTemperature > 37.3)
                {
                    abnormalInfo.Add("BodyTemperature: " + BodyTemperature.ToString());
                }

                if (HasHubeiTravelHistory)
                {
                    abnormalInfo.Add("Has been to Hubei");
                }

                if (HasSymptoms)
                {
                    abnormalInfo.Add("Has symptoms");
                }

                return string.Join("||", abnormalInfo);
            }
            else
            {
                return "";
            }
        }
    }
}