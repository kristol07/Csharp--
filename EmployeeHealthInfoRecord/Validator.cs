using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EmployeeHealthInfoRecord
{
    public class WinFormAppInputValidator
    {
        public string GetSearchTextType(string searchText)
        {
            if(string.IsNullOrWhiteSpace(searchText))
            {
                return "Empty";
            }

            if (int.TryParse(searchText, out _))
            {
                return "Number";
            }

            if (DateTime.TryParse(searchText, out _))
            {
                return "Time";
            }

            char seperator = '&';
            if(searchText.Contains(seperator) && searchText.Split(seperator).Length == 2)
            {
                string ginNumber = searchText.Split(seperator)[0];
                string checkDate = searchText.Split(seperator)[1];
                if(int.TryParse(ginNumber, out _) && DateTime.TryParse(checkDate, out _));
                {
                    return "Record";
                }
            }

            return "Invalid";
        }

        public bool IsValidNewGinNumber(string ginNumber, EmployeeRecords recordsDatabase)
        {
            return IsValidNotExistedGinNumber(ginNumber, recordsDatabase) && IsValidGinNumberType(ginNumber);
        }

        public bool IsValidNotExistedGinNumber(string ginNumber, EmployeeRecords recordsDatabase)
        {
            return !recordsDatabase.HasEmployeeRecordGivenGinNumber(ginNumber);
        }

        public bool IsValidExistedGinNumber(string ginNumber, EmployeeRecords recordsDatabase)
        {
            return recordsDatabase.HasEmployeeRecordGivenGinNumber(ginNumber);
        }

        public bool IsValidGinNumberType(string ginNumber)
        {
            return Int32.TryParse(ginNumber, out _);
        }

        public bool IsValidNewRecord(string ginNumber, string checkdate, EmployeeRecords recordsDatabase)
        {
            if (recordsDatabase.HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkdate))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsValidExistedRecord(string ginNumber, string checkdate, EmployeeRecords recordsDatabase)
        {
            if (recordsDatabase.HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkdate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidNewName(string name, EmployeeRecords recordsDatabase)
        {
            return true;
        }

        public bool IsValidExistedName(string name, EmployeeRecords recordsDatabase)
        {
            return recordsDatabase.EmployeeDatabase.Values.ToList().Select(x=>x.Name).Contains(name);
        }

        public bool IsValidSameNameForExistedGinNumber(string ginNumber, string name, EmployeeRecords recordsDatabse)
        {
            return recordsDatabse.EmployeeDatabase[ginNumber].Name == name;
        }

        public bool IsValidBodyTemperatureType(string bodyTemperature)
        {
            double result;
            if (double.TryParse(bodyTemperature, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidBodyTemperatureValue(string bodyTemperature)
        {
            double result;
            double.TryParse(bodyTemperature, out result);
            if (result >= 35 && result <= 43)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidBodyTemperature(string bodyTemperature)
        {
            return IsValidBodyTemperatureType(bodyTemperature) && IsValidBodyTemperatureValue(bodyTemperature);
        }

        public bool IsNormalBodyTemperature(double bodyTemperature)
        {
            return bodyTemperature <= 37.3;
        }

        public bool IsValidCheckDateValue(string checkDate)
        {
            DateTime result;
            DateTime.TryParse(checkDate, out result);
            return (result.Date <= DateTime.Today);
        }

        public bool IsValidCheckDateType(string checkDate)
        {
            return DateTime.TryParse(checkDate, out _);
        }

        public bool IsValidExistedCheckDate(string checkDate, EmployeeRecords recordsDatabase)
        {
            if(IsValidCheckDateType(checkDate))
            {
                foreach (var records in recordsDatabase.RecordsDatabase.Values)
                {
                    if (records.ContainsKey(checkDate))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //public bool IsValidComboBoxInput(string input)
        //{

        //    string[] options = { "yes", "y", "Y", "no", "n", "N" };

        //    return options.Contains(input.ToLower());
        //}

        public bool IsValidHasHubeiTravelHistoryChoice(string hasHubeiTravelHistoryChoice)
        {
            string[] options = { "yes", "y", "Y", "no", "n", "N" };

            return options.Contains(hasHubeiTravelHistoryChoice.ToLower());
        }

        public bool IsNormalHubeiTravelHistoryChoice(bool hasHubeiTravelHistoryChoice)
        {
            return hasHubeiTravelHistoryChoice == false;
        }

        public bool IsValidHasSymptomsChoice(string hasSymptomsChoice)
        {
            string[] options = { "yes", "y", "Y", "no", "n", "N" };

            return options.Contains(hasSymptomsChoice.ToLower());
        }

        public bool IsNormalSymtomsChoice(bool hasSymptomsChoice)
        {
            return hasSymptomsChoice == false;
        }
    }
}