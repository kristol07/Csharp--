using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace EmployeeHealthInfoRecord
{
    public class EmployeeRecords
    {
        public int TotalRecords
        {
            get
            {
                int totalRecords = 0;
                foreach (var ginNumber in RecordsDatabase.Keys)
                {
                    totalRecords += RecordsDatabase[ginNumber].Count;
                }
                return totalRecords;
            }
        }

        public int TotalSuspectRecords
        {
            get
            {
                int totalSuspectRecords = 0;
                foreach (var ginNumber in RecordsDatabase.Keys)
                {
                    foreach (var record in RecordsDatabase[ginNumber].Values)
                    {
                        if (!string.IsNullOrEmpty(record.GetAbnormalInfo()))
                        {
                            totalSuspectRecords += 1;
                        }
                    }
                }
                return totalSuspectRecords;
            }
        }

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

        public static BindingList<EmployeeRecord> TransformRecordListToBindingSource(params EmployeeRecord[] arrayOfRecords)
        {
            BindingList<EmployeeRecord> recordList = new BindingList<EmployeeRecord>();

            foreach (var record in arrayOfRecords)
            {
                recordList.Add(record);
            }

            return recordList;
        }

        public bool HasEmployeeRecordGivenGinNumber(string ginNumber)
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
            if(HasEmployeeRecordGivenGinNumber(ginNumber))
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

        public void EditRecord(string oldGinNumber, DateTime oldCheckDate, string ginNumber, DateTime checkDate, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms, string notes)
        {
            if (!HasEmployeeRecordGivenGinNumberAndCheckDate(oldGinNumber, oldCheckDate.ToShortDateString()))
            {
                return;
            }

            if (HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString()))
            {
                return;
            }

            EmployeeRecord oldRecord = GetEmployeeRecordGivenGinNumberAndCheckDate(oldGinNumber, oldCheckDate.ToShortDateString());

            RemoveRecord(oldGinNumber, oldCheckDate.ToShortDateString());

            if(!HasEmployeeRecordGivenGinNumber(ginNumber))
            {
                Employee newEmployee = new Employee(ginNumber, name);
                EmployeeDatabase.Add(ginNumber, newEmployee);
                RecordsDatabase.Add(ginNumber, new Dictionary<string, EmployeeRecord>());
            }

            EmployeeDatabase[ginNumber].Name = name;

            oldRecord.Edit(EmployeeDatabase[ginNumber], checkDate, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
            RecordsDatabase[ginNumber].Add(checkDate.ToShortDateString(), oldRecord);
        }

        public void AddRecord(string ginNumber, DateTime checkDate, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms, string notes)
        {
            // HACK: use notes to save edit history

            if (!HasEmployeeRecordGivenGinNumber(ginNumber))
            {
                Employee newEmployee = new Employee(ginNumber, name);
                EmployeeDatabase.Add(ginNumber, newEmployee);
                RecordsDatabase.Add(ginNumber, new Dictionary<string, EmployeeRecord>());
            }

            // TODO: reconsider this step
            if (HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString()))
            {
                return;
            }

            EmployeeDatabase[ginNumber].Name = name;

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
            }
        }

    }
}