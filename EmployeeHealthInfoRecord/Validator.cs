using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EmployeeHealthInfoRecord
{
    public static class WFAPPInputValidator
    {
        public static string GetSearchTextType(string searchText)
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

        public static bool IsValidNewGinNumber(string ginNumber, EmployeeRecords recordsDatabase)
        {
            return IsValidNotExistedGinNumber(ginNumber, recordsDatabase) && IsValidGinNumberType(ginNumber);
        }

        public static bool IsValidNotExistedGinNumber(string ginNumber, EmployeeRecords recordsDatabase)
        {
            return !recordsDatabase.HasEmployeeRecord(ginNumber);
        }

        public static bool IsValidExistedGinNumber(string ginNumber, EmployeeRecords recordsDatabase)
        {
            return recordsDatabase.HasEmployeeRecord(ginNumber);
        }

        public static bool IsValidGinNumberType(string ginNumber)
        {
            return Int32.TryParse(ginNumber, out _);
        }

        public static bool IsValidNewRecord(string ginNumber, string date, EmployeeRecords recordsDatabase)
        {
            if (recordsDatabase.HasEmployeeRecordGivenSpecificDate(ginNumber, date))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidExistedRecord(string ginNumber, string date, EmployeeRecords recordsDatabase)
        {
            if (recordsDatabase.HasEmployeeRecordGivenSpecificDate(ginNumber, date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidNewName(string name, EmployeeRecords recordsDatabase)
        {
            return true;
        }

        public static bool IsValidExistedName(string name, EmployeeRecords recordsDatabase)
        {
            return true;
        }

        public static bool IsValidBodyTemperatureType(string bodyTemperature)
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

        public static bool IsValidBodyTemperatureValue(string bodyTemperature)
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

        public static bool IsValidBodyTemperature(string bodyTemperature)
        {
            return IsValidBodyTemperatureType(bodyTemperature) && IsValidBodyTemperatureValue(bodyTemperature);
        }

        public static bool IsValidCheckDateValue(string checkDate)
        {
            DateTime result;
            DateTime.TryParse(checkDate, out result);
            return (result.Date <= DateTime.Today);
        }

        public static bool IsValidCheckDateType(string checkDate)
        {
            return DateTime.TryParse(checkDate, out _);
        }

        public static bool IsValidExistedCheckDate(string checkDate, EmployeeRecords recordsDatabase)
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

        //public static bool IsValidComboBoxInput(string input)
        //{

        //    string[] options = { "yes", "y", "Y", "no", "n", "N" };

        //    return options.Contains(input.ToLower());
        //}

        public static bool IsValidHasHubeiTravelHistoryChoice(string hasHubeiTravelHistoryChoice)
        {
            string[] options = { "yes", "y", "Y", "no", "n", "N" };

            return options.Contains(hasHubeiTravelHistoryChoice.ToLower());
        }

        public static bool IsValidHasSymptomsChoice(string hasSymptomsChoice)
        {
            string[] options = { "yes", "y", "Y", "no", "n", "N" };

            return options.Contains(hasSymptomsChoice.ToLower());
        }
    }
}