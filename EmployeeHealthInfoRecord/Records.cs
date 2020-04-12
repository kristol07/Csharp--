using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace EmployeeHealthInfoRecord
{
    public class EmployeeRecords
    {

        public BindingList<EmployeeRecord> RecordList
        {
            get
            {
                return TransformRecordListToBindingSource(GetAllRecords().ToArray());
            }
        }

        public BindingList<EmployeeRecord> SuspectRecordList
        {
            get
            {
                return TransformRecordListToBindingSource(GetAllSuspectRecords().ToArray());
            }
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

        public Dictionary<string, Dictionary<string, EmployeeRecord>> RecordsDatabase
        {
            get; set;
        }

        public EmployeeRecords()
        {
            RecordsDatabase = new Dictionary<string, Dictionary<string, EmployeeRecord>>();
        }

        public bool HasEmployeeRecord(string ginNumber)
        {
            return RecordsDatabase.ContainsKey(ginNumber);
        }

        public bool HasEmployeeRecordGivenSpecificDate(string ginNumber, string checkDate)
        {
            if (RecordsDatabase.ContainsKey(ginNumber))
            {
                return RecordsDatabase[ginNumber].ContainsKey(checkDate);
            }
            else
            {
                return false;
            }
        }

        public EmployeeRecord GetEmployeeRecordGivenSpecificDate(string ginNumber, string checkDate)
        {
            if (HasEmployeeRecordGivenSpecificDate(ginNumber, checkDate))
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

        public List<EmployeeRecord> GetAllSuspectRecords()
        {
            List<EmployeeRecord> allSuspectRecords = new List<EmployeeRecord>();

            foreach (var recordsOfSpecificEmployee in RecordsDatabase.Values)
            {
                foreach (var employeeRecord in recordsOfSpecificEmployee.Values)
                {
                    if (!string.IsNullOrEmpty(employeeRecord.GetAbnormalInfo()))
                    {
                        allSuspectRecords.Add(employeeRecord);
                    }
                }
            }

            return allSuspectRecords;
        }

        public List<EmployeeRecord> GetAllRecordsOfSpecificEmployee(string ginNumber)
        {
            List<EmployeeRecord> allRecordsOfSpecificEmployee = new List<EmployeeRecord>();

            if (HasEmployeeRecord(ginNumber))
            {
                allRecordsOfSpecificEmployee.AddRange(RecordsDatabase[ginNumber].Values);
            }

            return allRecordsOfSpecificEmployee;
        }

        public List<EmployeeRecord> GetAllRecordsOfSpecificCheckDate(string checkDate)
        {
            List<EmployeeRecord> allRecordsOfSpecificCheckDate = new List<EmployeeRecord>();

            foreach (var recordsOfEmployee in RecordsDatabase.Values)
            {
                if (recordsOfEmployee.ContainsKey(checkDate))
                {
                    allRecordsOfSpecificCheckDate.Add(recordsOfEmployee[checkDate]);
                }
            }

            return allRecordsOfSpecificCheckDate;
        }

        public void EditRecord(string ginNumber, DateTime checkDate, string option, string editedValue)
        {
            // UNDONE
        }

        public void AddRecord(string ginNumber, DateTime checkDate, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms, string notes)
        {
            // HACK: use notes to show date key string
            EmployeeRecord newRecord = new EmployeeRecord(ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, checkDate.ToShortDateString());

            if (!HasEmployeeRecord(ginNumber))
            {
                RecordsDatabase.Add(ginNumber, new Dictionary<string, EmployeeRecord>());
            }

            RecordsDatabase[ginNumber].Add(checkDate.ToShortDateString(), newRecord);
        }

        public void RemoveRecord(string ginNumber, params DateTime[] checkDates)
        {
            foreach (var checkDate in checkDates)
            {
                if (!HasEmployeeRecordGivenSpecificDate(ginNumber, checkDate.ToShortDateString()))
                {
                    return;
                }
            }

            foreach (var checkDate in checkDates)
            {
                RecordsDatabase[ginNumber].Remove(checkDate.ToShortDateString());
            }

            if (RecordsDatabase[ginNumber].Values.Count == 0)
            {
                RecordsDatabase.Remove(ginNumber);
            }
        }

    }
}