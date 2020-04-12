using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EmployeeHealthInfoRecord
{
    public class EmployeeRecord
    {
        public string GinNumber { get; set; }

        public DateTime CheckDate { get; set; }

        public string Name { get; set; }

        public double BodyTemperature { get; set; }

        public bool HasHubeiTravelHistory { get; set; }

        public bool HasSymptoms { get; set; }

        public string Notes { get; set; }

        public EmployeeRecord(string ginNumber, DateTime date, string name, double bodyTemperature, bool hasHubeiTravelHistory = false, bool hasSymptoms = false, string notes = "")
        {
            this.GinNumber = ginNumber;
            this.CheckDate = date;
            this.Name = name;
            this.BodyTemperature = bodyTemperature;
            this.HasHubeiTravelHistory = hasHubeiTravelHistory;
            this.HasSymptoms = hasSymptoms;
            this.Notes = notes;
        }

        public string FormatForSave()
        {
            string[] allInfo = {
                GinNumber,
                CheckDate.ToString("d"),
                Name,
                BodyTemperature.ToString(),
                HasHubeiTravelHistory.ToString(),
                HasSymptoms.ToString(),
                Notes
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
                abnormalInfo.Add(GinNumber + "-" + Name + "-" + CheckDate.ToShortTimeString());

                if (BodyTemperature > 37.3)
                {
                    abnormalInfo.Add("BodyTempeature: " + BodyTemperature.ToString());
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