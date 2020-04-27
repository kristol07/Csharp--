using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace EmployeeHealthInfoRecord
{
    public class EmployeeRecords
    {
        //public int TotalRecords
        //{
        //    get
        //    {
        //        int totalRecords = 0;
        //        foreach (var ginNumber in RecordsDatabase.Keys)
        //        {
        //            totalRecords += RecordsDatabase[ginNumber].Count;
        //        }
        //        return totalRecords;
        //    }
        //}

        //public int TotalSuspectRecords
        //{
        //    get
        //    {
        //        int totalSuspectRecords = 0;
        //        foreach (var ginNumber in RecordsDatabase.Keys)
        //        {
        //            foreach (var record in RecordsDatabase[ginNumber].Values)
        //            {
        //                if (!string.IsNullOrEmpty(record.GetAbnormalInfo()))
        //                {
        //                    totalSuspectRecords += 1;
        //                }
        //            }
        //        }
        //        return totalSuspectRecords;
        //    }
        //}

        public Dictionary<string, Employee> EmployeeDatabase { get; set; }

        public Dictionary<string, Dictionary<string, EmployeeRecord>> RecordsDatabase
        {
            get; set;
        }

        public EmployeeRecords()
        {
            EmployeeDatabase = new Dictionary<string, Employee>();
            RecordsDatabase = new Dictionary<string, Dictionary<string, EmployeeRecord>>();
        }

        public bool HasEmployeeGivenGinNumber(string ginNumber)
        {
            return EmployeeDatabase.ContainsKey(ginNumber);
        }

        public bool HasEmployeeRecordGivenGinNumberAndCheckDate(string ginNumber, string checkDate)
        {
            if (EmployeeDatabase.ContainsKey(ginNumber))
            {
                return RecordsDatabase[ginNumber].ContainsKey(checkDate);
            }
            else
            {
                return false;
            }
        }

        public Employee GetEmployeeGivenGinNumber(string ginNumber)
        {
            if (HasEmployeeGivenGinNumber(ginNumber))
            {
                return EmployeeDatabase[ginNumber];
            }
            else
            {
                return null;
            }
        }

        public EmployeeRecord GetEmployeeRecordGivenGinNumberAndCheckDate(string ginNumber, string checkDate)
        {
            if (HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate))
            {
                return RecordsDatabase[ginNumber][checkDate];
            }

            return null;
        }

        public List<EmployeeRecord> GetAllRecords()
        {
            List<EmployeeRecord> allRecords = new List<EmployeeRecord>();
            foreach (var recordsOfSpecificEmployee in RecordsDatabase.Values)
            {
                allRecords.AddRange(recordsOfSpecificEmployee.Values);
            }
            return allRecords;
        }

        public List<Employee> GetAllEmployees()
        {
            return EmployeeDatabase.Values.ToList();
        }

        public void EditRecord(string oldGinNumber, DateTime oldCheckDate, string ginNumber, DateTime checkDate, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms, string notes)
        {
            // can not edit non-existed record
            if (!HasEmployeeRecordGivenGinNumberAndCheckDate(oldGinNumber, oldCheckDate.ToShortDateString()))
            {
                return;
            }

            // can not override existed record when not editing self
            if (!((oldGinNumber == ginNumber) && (oldCheckDate == checkDate)) && HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString()))
            {
                return;
            }

            // save as new record when not editing self and no conflict with other existed records
            if (!((oldGinNumber == ginNumber) && (oldCheckDate == checkDate)))
            {
                // can not change name of existed ginNumber when not edit self
                if (HasEmployeeGivenGinNumber(ginNumber) && EmployeeDatabase[ginNumber].Name != name)
                {
                    return;
                }

                EmployeeRecord oldRecord = GetEmployeeRecordGivenGinNumberAndCheckDate(oldGinNumber, oldCheckDate.ToShortDateString());

                RemoveRecord(oldGinNumber, oldCheckDate.ToShortDateString());

                if (!HasEmployeeGivenGinNumber(ginNumber))
                {
                    Employee newEmployee = new Employee(ginNumber, name);
                    EmployeeDatabase.Add(ginNumber, newEmployee);
                    RecordsDatabase.Add(ginNumber, new Dictionary<string, EmployeeRecord>());
                }

                //EmployeeDatabase[ginNumber].Name = name;

                oldRecord.Edit(EmployeeDatabase[ginNumber], checkDate, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
                RecordsDatabase[ginNumber].Add(checkDate.ToShortDateString(), oldRecord);
            }
            // edit self
            else
            {
                EmployeeDatabase[ginNumber].Name = name;
                RecordsDatabase[ginNumber][checkDate.ToShortDateString()].Edit(EmployeeDatabase[ginNumber], checkDate, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
            }
        }

        public void AddRecord(string ginNumber, DateTime checkDate, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms, string notes)
        {
            // only possible to edit existed record
            if (HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString()))
            {
                return;
            }

            // can not change existed Employee name. Use edit function.
            if (HasEmployeeGivenGinNumber(ginNumber) && EmployeeDatabase[ginNumber].Name != name)
            {
                return;
            }

            if (!HasEmployeeGivenGinNumber(ginNumber))
            {
                Employee newEmployee = new Employee(ginNumber, name);
                EmployeeDatabase.Add(ginNumber, newEmployee);
                RecordsDatabase.Add(ginNumber, new Dictionary<string, EmployeeRecord>());
            }

            //EmployeeDatabase[ginNumber].Name = name; // the second return has done things for this step

            EmployeeRecord newRecord = new EmployeeRecord(EmployeeDatabase[ginNumber], checkDate, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            RecordsDatabase[ginNumber].Add(checkDate.ToShortDateString(), newRecord);
        }

        public void RemoveRecord(string ginNumber, params string[] checkDates)
        {
            foreach (var checkDate in checkDates)
            {
                if (!HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate))
                {
                    return;
                }
            }

            foreach (var checkDate in checkDates)
            {
                RecordsDatabase[ginNumber].Remove(checkDate);
            }

            if (RecordsDatabase[ginNumber].Values.Count == 0)
            {
                RecordsDatabase.Remove(ginNumber);
                EmployeeDatabase.Remove(ginNumber);
            }
        }

    }
}