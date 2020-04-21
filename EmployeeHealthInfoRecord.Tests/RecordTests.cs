using System;
using Xunit;

namespace EmployeeHealthInfoRecord.Tests
{
    public class RecordTests
    {
        private readonly EmployeeRecord _record;

        public RecordTests()
        {
            Employee _employee = new Employee("1", "John");
            DateTime checkDate = DateTime.Parse("2020/01/01");
            _record = new EmployeeRecord(_employee, checkDate, 37, false, false);
        }

        [Fact]
        public void FormatForSave_ReturnCorrectFormat()
        {
            string result = _record.FormatForSave();
            Assert.Equal("1,2020/1/1,John,37,False,False,", result);
        }

        [Theory]
        [MemberData(nameof(RecordTestData.TestAbnormalData), MemberType = typeof(RecordTestData))]
        public void IsSuspected_ReturnTrue_ForSuspectRecord(EmployeeRecord record)
        {
            bool result = record.IsSuspected();

            Assert.True(result);
        }
        


        [Fact]
        public void IsSuspected_ReturnFalse_ForNormalRecord()
        {
            bool result = _record.IsSuspected();

            Assert.False(result);
        }

        [Fact]
        public void Edit_WithCorrectItemEdited()
        {
            Employee newEmployee = new Employee("0", "Test");
            DateTime newCheckDate = DateTime.Parse("2021/01/01");
            _record.Edit(newEmployee, newCheckDate, 36, true, true, "testNotes");

            Assert.Equal("0", _record.GinNumber);
            Assert.Equal("Test", _record.Name);
            Assert.Equal(DateTime.Parse("2021/01/01"), _record.CheckDate);
            Assert.Equal(36, _record.BodyTemperature);
            Assert.True(_record.HasHubeiTravelHistory);
            Assert.True(_record.HasSymptoms);
            Assert.Equal("testNotes", _record.Notes);
        }

        [Theory]
        [MemberData(nameof(RecordTestData.TestAbnormalInfoData), MemberType = typeof(RecordTestData))]
        public void GetAbnormalInfo_ReturnCorrectAbnormalInfo_ForSuspectRecord(EmployeeRecord record, string expected)
        {
            string result = record.GetAbnormalInfo();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAbnormalInfo_ReturnEmptyString_For_NormalRecord()
        {
            string result = _record.GetAbnormalInfo();
            Assert.Equal("", result);
        }

        [Fact]
        public void CompareTo_ReturnZero_IfTwoRecordsHaveSameGinNumber()
        {
            Employee anotherEmployee = new Employee("1", "Test");
            DateTime checkDate = DateTime.Parse("2020/01/01");
            EmployeeRecord anotherRecord = new EmployeeRecord(anotherEmployee, checkDate, 36.5, false, false);

            int result = _record.CompareTo(anotherRecord);

            Assert.Equal(0, result);
        }


        [Fact]
        public void CompareTo_ReturnOne_IfRecordHasLargerGinNumber()
        {
            Employee anotherEmployee = new Employee("0", "Test");
            DateTime checkDate = DateTime.Parse("2020/01/01");
            EmployeeRecord anotherRecord = new EmployeeRecord(anotherEmployee, checkDate, 36.5, false, false);

            int result = _record.CompareTo(anotherRecord);

            Assert.Equal(1, result);
        }

        [Fact]
        public void CompareTo_ReturnMinusOne_IfRecordHasSmallerGinNumber()
        {
            Employee anotherEmployee = new Employee("2", "Test");
            DateTime checkDate = DateTime.Parse("2020/01/01");
            EmployeeRecord anotherRecord = new EmployeeRecord(anotherEmployee, checkDate, 36.5, false, false);

            int result = _record.CompareTo(anotherRecord);

            Assert.Equal(-1, result);
        }
    }
}
