using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EmployeeHealthInfoRecord.Tests
{
    public class RecordsTests
    {
        private readonly EmployeeRecords _records;

        public RecordsTests()
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
        public void HasEmployeeRecordGivenGinNumber_ReturnTrue_IfDatabaseHasEmployeeWithSameGinNumber()
        {
            bool result = _records.HasEmployeeRecordGivenGinNumber("0");
            Assert.True(result);
        }

        [Fact]
        public void HasEmployeeRecordGivenGinNumber_ReturnFalse_IfDatabaseHasNoEmployeeWithSameGinNumber()
        {
            bool result = _records.HasEmployeeRecordGivenGinNumber("3");
            Assert.False(result);
        }

        [Theory]
        [InlineData("0", "2020/1/1")]
        public void HasEmployeeRecordGivenGinNumberAndCheckDate_ReturnTrue_IfDatabaseHasRecordWithSameGinNumberAndCheckDate(string ginNumber, string checkDate)
        {
            bool result = _records.HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate);
            Assert.True(result);
        }

        [Theory]
        [InlineData("3", "2020/1/1")]
        [InlineData("0", "2020/1/5")]
        [InlineData("3", "2020/1/5")]
        public void HasEmployeeRecordGivenGinNumberAndCheckDate_ReturnFalse_IfDatabaseHasNoRecordWithSameGinNumberAndCheckDate(string ginNumber, string checkDate)
        {
            bool result = _records.HasEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate);
            Assert.False(result);
        }

        [Fact]
        public void GetEmployeeGivenGinNumber_ReturnExactEmployee_IfDatabaseHasEmployeeWithSameGinNumber()
        {
            Employee result = _records.GetEmployeeGivenGinNumber("0");
            result.Should().BeEquivalentTo(new Employee("0", "Adam"));
        }

        [Fact]
        public void GetEmployeeGivenGinNumber_ReturnNull_IfDatabaseHasNoEmployeeWithSameGinNumber()
        {
            Employee result = _records.GetEmployeeGivenGinNumber("4");
            result.Should().BeNull();
        }

        [Fact]
        public void GetEmployeeRecordGivenGinNumberAndCheckDate_ReturnExactRecord_IfDatabaseHasRecordWithSameGinNumberAndCheckDate()
        {
            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("0", "2020/1/1");
            result.Should().BeEquivalentTo(new EmployeeRecord(new Employee("0", "Adam"), DateTime.Parse("2020/01/01"), 37, false, false));
        }

        [Theory]
        [InlineData("3", "2020/1/1")]
        [InlineData("0", "2020/1/5")]
        [InlineData("3", "2020/1/5")]
        public void GetEmployeeRecordGivenGinNumberAndCheckDate_ReturnNull_IfDatabaseHasNoRecordWithSameGinNumberAndCheckDate(string ginNumber, string checkDate)
        {
            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate);
            result.Should().BeNull();
        }

        [Fact]
        public void GetAllRecords_ReturnAllRecords()
        {
            List<EmployeeRecord> result = _records.GetAllRecords();

            Employee employee1 = new Employee("0", "Adam");
            Employee employee2 = new Employee("1", "Hugo");
            Employee employee3 = new Employee("2", "Zero");

            DateTime day1 = DateTime.Parse("2020/01/01");
            DateTime day2 = DateTime.Parse("2020/01/02");
            DateTime day3 = DateTime.Parse("2020/01/03");

            List<EmployeeRecord> expected = new List<EmployeeRecord>();

            expected.Add(new EmployeeRecord(employee1, day1, 37, false, false));
            expected.Add(new EmployeeRecord(employee1, day2, 37, true, false));
            expected.Add(new EmployeeRecord(employee1, day3, 37, false, true));
            expected.Add(new EmployeeRecord(employee2, day1, 38, true, false));
            expected.Add(new EmployeeRecord(employee2, day2, 38, false, true));
            expected.Add(new EmployeeRecord(employee2, day3, 37, true, false));
            expected.Add(new EmployeeRecord(employee3, day1, 38, false, true));
            expected.Add(new EmployeeRecord(employee3, day2, 37, false, true));
            expected.Add(new EmployeeRecord(employee3, day3, 38, true, true));

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("3", "2020/1/1")]
        [InlineData("0", "2020/1/5")]
        [InlineData("3", "2020/1/5")]
        public void EditRecord_WithNothingEdited_IfDatabaseHasNoRecordWithSameOldGinNumberAndOldCheckDate(string oldGinNumber, string oldCheckDate)
        {
            DateTime oldCheckdate = DateTime.Parse(oldCheckDate);

            string ginNumber = "5";
            DateTime checkDate = DateTime.Parse("2020/01/05");
            string name = "Tesla";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";
            _records.EditRecord(oldGinNumber, oldCheckdate, ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate.ToShortDateString());
            result.Should().BeNull();
        }

        [Fact]
        public void EditRecord_WithNothingEdited_IfDatabaseHasRecordWithSameNewGinNumberAndNewCheckDate_InCaseOfNotSelf()
        {
            string ginNumber = "0";
            DateTime checkDate = DateTime.Parse("2020/01/02");
            string name = "Tesla";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";

            EmployeeRecord expected = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("0", "2020/1/1");

            _records.EditRecord("0", DateTime.Parse("2020/01/01"), ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("0", "2020/1/1");
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void EditRecord_WithInfoEdited_AndOldRecordRemoved_IfNewGinNumberDoesNotExistBefore()
        {
            string ginNumber = "3";
            DateTime checkDate = DateTime.Parse("2020/01/01");
            string name = "Tesla";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";

            Employee newEmployee = new Employee("3", "Tesla");
            EmployeeRecord newRecord = new EmployeeRecord(newEmployee, checkDate, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            _records.EditRecord("0", DateTime.Parse("2020/01/01"), ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("3", "2020/1/1");
            result.Should().BeEquivalentTo(newRecord);

            EmployeeRecord oldRecord = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("0", "2020/1/1");
            oldRecord.Should().BeNull();
        }

        [Fact]
        public void EditRecord_WithInfoEdited_AndOldRecordRemoved_IfRecordWithSameNewGinNumberAndNewCheckDateDoesNotExistBefore()
        {
            string ginNumber = "3";
            DateTime checkDate = DateTime.Parse("2020/01/01");
            string name = "Tesla";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";

            Employee newEmployee = new Employee("3", "Tesla");
            EmployeeRecord newRecord = new EmployeeRecord(newEmployee, checkDate, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            _records.EditRecord("0", DateTime.Parse("2020/01/01"), ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("3", "2020/1/1");
            result.Should().BeEquivalentTo(newRecord);

            EmployeeRecord oldRecord = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("0", "2020/1/1");
            oldRecord.Should().BeNull();
        }

        [Fact]
        public void EditRecord_WithInfoEdited_AndOldRecordRemained_IfIsEditingSelf()
        {
            string ginNumber = "0";
            DateTime checkDate = DateTime.Parse("2020/01/01");
            string name = "Tesla";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";

            EmployeeRecord expected = new EmployeeRecord(_records.EmployeeDatabase[ginNumber], checkDate, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            _records.EditRecord("0", DateTime.Parse("2020/01/01"), ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            EmployeeRecord result = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("0", "2020/1/1");
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void EditRecord_WithNameConsistentInAllOtherRecordsWithSameGinNumber_IfNameIsEditedForOneGinNumber()
        {
            string ginNumber = "0";
            DateTime checkDate = DateTime.Parse("2020/01/01");
            string name = "Tesla";
            double bodyTemperature = 37.5;
            bool hasHubeiTravelHistory = true;
            bool hasSymptoms = true;
            string notes = "new Notes";

            _records.EditRecord("0", DateTime.Parse("2020/01/01"), ginNumber, checkDate, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);

            EmployeeRecord record1 = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("0", "2020/1/1");
            EmployeeRecord record2 = _records.GetEmployeeRecordGivenGinNumberAndCheckDate("0", "2020/1/2");

            Assert.Equal("Tesla", record1.Name);
            Assert.Equal("Tesla", record2.Name);
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

        [Theory]
        [InlineData("0", new string[] { "2020/1/1", "2020/1/2"})]
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
