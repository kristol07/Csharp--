using System;
using System.Collections.Generic;

namespace EmployeeHealthRecord
{
    [Flags]
    public enum Symptoms : uint
    {
        DryCough = 0x01,
        ChestStuffiness = 0x02,
        Fever = 0x04,
    }


    public class Employee : IComparable
    {
        public string GinNumber
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public bool HasHubeiTravelHistory
        {
            get; set;
        }

        public bool HasSymptoms
        {
            get; set;
        }

        public Symptoms Symptoms
        {
            get; set;
        }

        public double BodyTemperature
        {
            get; set;
        }

        public Employee(string ginNumber, string name, double bodyTemperature, bool hasHubeiTravelHistory = false, bool hasSymptoms = false)
        {
            GinNumber = ginNumber;
            Name = name;
            BodyTemperature = bodyTemperature;
            HasHubeiTravelHistory = hasHubeiTravelHistory;
            HasSymptoms = hasSymptoms;
        }

        public override string ToString()
        {
            if (HasSymptoms)
            {
                return GinNumber + "-" + Name
                        + ": Body Temperature->" + BodyTemperature.ToString()
                        + ", Hubei Travel History->" + HasHubeiTravelHistory.ToString()
                        + ", Symptoms->" + Symptoms.ToString("f");
            }
            else
            {
                return GinNumber + "-" + Name
                        + ": Body Temperature->" + BodyTemperature.ToString()
                        + ", Hubei Travel History->" + HasHubeiTravelHistory.ToString()
                        + ", Has Symptoms->" + HasSymptoms.ToString();
            }
        }

        public string FormatForSave()
        {
            List<string> allInfo = new List<string>();

            allInfo.Add(GinNumber);
            allInfo.Add(Name);
            allInfo.Add(BodyTemperature.ToString());
            allInfo.Add(HasHubeiTravelHistory.ToString());
            allInfo.Add(HasSymptoms.ToString());
            allInfo.Add(Symptoms.ToString("d"));

            string seperator = ",";

            return string.Join(seperator, allInfo);
            // return GinNumber + "," + Name 
            //         + "," + BodyTemperature.ToString()
            //         + "," + HasSymptoms.ToString() + "," + Symptoms.ToString("d")
            //         +"," + HasHubeiTravelHistory.ToString();
        }

        // public bool IsSuspected(out List<string> abnormalInfo)
        // {
        //     abnormalInfo = new List<string>();
        //     abnormalInfo.Add(GinNumber + "-" + Name);

        //     bool isSuspected = false;

        //     if (BodyTemperature > 37.3 || BodyTemperature < 36.0)
        //     {
        //         abnormalInfo.Add("BodyTempeature: " + BodyTemperature.ToString());
        //         isSuspected = true;
        //     }

        //     if (HasSymptoms)
        //     {
        //         abnormalInfo.Add("Has symptoms");
        //         isSuspected = true;
        //     }

        //     if (HasHubeiTravelHistory)
        //     {
        //         abnormalInfo.Add("Has been to Hubei");
        //         isSuspected = true;
        //     }

        //     return isSuspected;
        // }

        public bool IsSuspected()
        {
            bool isSuspected = false;

            if (BodyTemperature > 37.3 || BodyTemperature < 36.0)
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
                abnormalInfo.Add(GinNumber + "-" + Name);

                if (BodyTemperature > 37.3 || BodyTemperature < 36.0)
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

        public int CompareTo(object obj)
        {
            Employee anotherEmployee = (Employee)obj;
            if (Int32.Parse(this.GinNumber) < Int32.Parse(anotherEmployee.GinNumber))
            {
                return -1;
            }
            else if (Int32.Parse(this.GinNumber) > Int32.Parse(anotherEmployee.GinNumber))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}