using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EmployeeHealthInfoRecord.IntegrationTests
{
    public class DeleteCurrentRecord
    {
        private readonly EmployeeRecords _records;

        public DeleteCurrentRecord()
        {
            _records = new EmployeeRecords();
            Init();
        }

        public void Init()
        {
            Employee employee1 = new Employee("0", "Adam");
            Employee employee2 = new Employee("1", "Hugo");
            Employee employee3 = new Employee("2", "Zero");
            _records.EmployeeDatabase.Add("0", employee1);
            _records.EmployeeDatabase.Add("1", employee2);
            _records.EmployeeDatabase.Add("2", employee3);

            DateTime day1 = DateTime.Parse("2020/01/01");
            DateTime day2 = DateTime.Parse("2020/01/02");
            DateTime day3 = DateTime.Parse("2020/01/03");

            Dictionary<string, EmployeeRecord> employee1Records = new Dictionary<string, EmployeeRecord>();
            Dictionary<string, EmployeeRecord> employee2Records = new Dictionary<string, EmployeeRecord>();
            Dictionary<string, EmployeeRecord> employee3Records = new Dictionary<string, EmployeeRecord>();

            employee1Records.Add(day1.ToShortDateString(), new EmployeeRecord(employee1, day1, 37, false, false));
            employee1Records.Add(day2.ToShortDateString(), new EmployeeRecord(employee1, day2, 37, true, false));
            employee1Records.Add(day3.ToShortDateString(), new EmployeeRecord(employee1, day3, 37, false, true));
            employee2Records.Add(day1.ToShortDateString(), new EmployeeRecord(employee2, day1, 38, true, false));
            employee2Records.Add(day2.ToShortDateString(), new EmployeeRecord(employee2, day2, 38, false, true));
            employee2Records.Add(day3.ToShortDateString(), new EmployeeRecord(employee2, day3, 37, true, false));
            employee3Records.Add(day1.ToShortDateString(), new EmployeeRecord(employee3, day1, 38, false, true));
            employee3Records.Add(day2.ToShortDateString(), new EmployeeRecord(employee3, day2, 37, false, true));
            employee3Records.Add(day3.ToShortDateString(), new EmployeeRecord(employee3, day3, 38, true, true));

            _records.RecordsDatabase.Add("0", employee1Records);
            _records.RecordsDatabase.Add("1", employee2Records);
            _records.RecordsDatabase.Add("2", employee3Records);

        }

        [Theory]
        [InlineData("0", new string[] { "2020/1/1", "2020/1/2" })]
        public void RemoveRecord_WithRecordsAllRemoved_IfAllRecordsToRemoveExistInDatabase(string ginNumber, string[] checkDates)
        {
            _records.RemoveRecord(ginNumber, checkDates);
            _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDates[0]).Should().BeNull();
            _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDates[1]).Should().BeNull();
        }

        [Theory]
        [InlineData("0", new string[] { "2020/1/1", "2020/1/2", "2020/1/3" })]
        public void RemoveRecord_WithKeyRemovedInRecordsDatabase_IfAllRecordsOfGinNumberAreRemoved(string ginNumber, string[] checkDates)
        {
            _records.RemoveRecord(ginNumber, checkDates);
            _records.RecordsDatabase.Keys.Contains(ginNumber).Should().BeFalse();
        }

        [Theory]
        [InlineData("0", new string[] { "2020/1/1", "2020/1/4" })]
        public void RemoveRecord_WithNoRecordsRemoved_IfAtLeastOneRecordToRemoveDoesNotExistInDatabase(string ginNumber, string[] checkDates)
        {
            _records.RemoveRecord(ginNumber, checkDates);
            _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDates[0]).Should().NotBeNull();
        }

    }
}
