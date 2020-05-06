using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EmployeeHealthInfoRecord.IntegrationTests
{
    public class AddNewRecord
    {
        private readonly EmployeeRecords _records;

        public AddNewRecord()
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

        [Fact]
        public void AddRecord_WithNoRecordAdded_IfRecordWithSameGinNumberAndCheckDateExisted()
        {
            string ginNumber = "0";
            DateTime checkDate = DateTime.Parse("2020/01/01");
            string name = "Tesla";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";

            EmployeeRecord expected = _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString());

            _records.AddRecord(ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString());

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void AddRecord_WithNoRecordAdded_IfNewNameIsDifferentForExistedGinNumber()
        {
            string ginNumber = "0";
            DateTime checkDate = DateTime.Parse("2020/01/04");
            string name = "Tesla";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";

            _records.AddRecord(ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString());

            result.Should().BeNull();
        }

        [Fact]
        public void AddRecord_WithNewRecordAdded_IfRecordWithSameGinNumberDoesNotExist()
        {
            string ginNumber = "3";
            DateTime checkDate = DateTime.Parse("2020/01/01");
            string name = "Adam";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";

            _records.AddRecord(ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString());

            EmployeeRecord expected = new EmployeeRecord(_records.EmployeeDatabase[ginNumber], checkDate, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void AddRecord_WithNewRecordAdded_IfRecordWithSameGinNumberAndCheckDateDoesNotExist()
        {
            string ginNumber = "0";
            DateTime checkDate = DateTime.Parse("2020/01/04");
            string name = "Adam";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";

            _records.AddRecord(ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString());

            EmployeeRecord expected = new EmployeeRecord(_records.EmployeeDatabase[ginNumber], checkDate, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            result.Should().BeEquivalentTo(expected);
        }

    }
}
