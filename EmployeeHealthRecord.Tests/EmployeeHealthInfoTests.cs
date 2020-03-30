using System;
using Xunit;
using EmployeeHealthRecord;

namespace EmployeeHealthRecord.Tests
{
    public class EmployeeTests
    {
        private readonly Employee _employee;

        public EmployeeTests()
        {
            _employee = new Employee("1", "test", 36.5, false, false);
        }

        [Fact]
        public void FormatForSave_ReturnCorrectStringFormat()
        {
            string result = _employee.FormatForSave();

            Assert.Equal("1,test,36.5,False,False,0", result);
        }

        [Theory]
        [MemberData(nameof(EmployeeTestData.TestAbnormalData), MemberType = typeof(EmployeeTestData))]
        public void IsSuspected_ReturnTrue_ForSuspectEmployee(Employee employee)
        {
            bool result = employee.IsSuspected();

            Assert.True(result);
        }

        [Fact]
        public void IsSuspected_ReturnFalse_ForNormalEmployee()
        {
            bool result = _employee.IsSuspected();

            Assert.False(result);
        }


        [Fact]
        public void EditValue_WithGinNumberEdited()
        {
            _employee.EditValue("GinNumber", "0");

            string result = _employee.GinNumber;

            Assert.Equal("0", result);
        }

        [Fact]
        public void EditValue_WithNameEdited()
        {
            _employee.EditValue("Name", "Test");

            string result = _employee.Name;

            Assert.Equal("Test", result);
        }

        [Fact]
        public void EditValue_WithBodyTemperatureEdited()
        {
            _employee.EditValue("Body Temperature", "36.0");

            double result = _employee.BodyTemperature;

            Assert.Equal(36.0, result);
        }

        [Fact]
        public void EditValue_WithHasHubeiTravelHistoryEdited()
        {
            _employee.EditValue("Has Hubei Travel History", "y");

            bool result = _employee.HasHubeiTravelHistory;

            Assert.True(result);
        }

        [Fact]
        public void EditValue_WithHasSymptomsEdited()
        {
            _employee.EditValue("Has Symptoms", "y");

            bool result = _employee.HasSymptoms;

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(EmployeeTestData.TestAbnormalInfoData), MemberType = typeof(EmployeeTestData))]
        public void GetAbnormalInfo_ReturnCorrectAbnormalInfo_ForSuspectEmployee(Employee employee, string expected)
        {
            string result = employee.GetAbnormalInfo();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAbnormalInfo_ReturnEmptyString_For_NormalEmployee()
        {
            string result = _employee.GetAbnormalInfo();

            Assert.Equal("", result);
        }

        [Fact]
        public void CompareTo_ReturnZero_IfTwoEmployeesHaveSameGinNumber()
        {
            Employee anotherEmployee = new Employee("1", "test", 36.5, false, false);

            int result = _employee.CompareTo(anotherEmployee);

            Assert.Equal(0, result);
        }


        [Fact]
        public void CompareTo_ReturnOne_IfEmployeesHaveLargerGinNumber()
        {
            Employee anotherEmployee = new Employee("0", "test", 36.5, false, false);

            int result = _employee.CompareTo(anotherEmployee);

            Assert.Equal(1, result);
        }

        [Fact]
        public void CompareTo_ReturnMinusOne_IfTwoEmployeesHaveSmallerGinNumber()
        {
            Employee anotherEmployee = new Employee("2", "test", 36.5, false, false);

            int result = _employee.CompareTo(anotherEmployee);

            Assert.Equal(-1, result);
        }

    }
}
