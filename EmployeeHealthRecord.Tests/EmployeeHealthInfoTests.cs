using System;
using Xunit;
using EmployeeHealthRecord;

namespace EmployeeHealthRecord.Tests
{
    public class EmployeeTests
    {

        [Fact]
        public void FormatForSave_ReturnCorrectStringFormat()
        {
            Employee employee = new Employee("0", "Test", 0, false, false);

            string result = employee.FormatForSave();

            Assert.Equal("0,Test,0,False,False,0", result);
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
            Employee employee = new Employee("0", "Test", 36.5, false, false);

            bool result = employee.IsSuspected();

            Assert.False(result);
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
            Employee employee = new Employee("0", "test", 36.5, false, false);

            string result = employee.GetAbnormalInfo();

            Assert.Equal("", result);
        }

        [Fact]
        public void CompareTo_ReturnZero_IfTwoEmployeesHaveSameGinNumber()
        {
            Employee employee1 = new Employee("0", "test", 36.5, false, false);
            Employee employee2 = new Employee("0", "test", 36.5, false, false);

            int result = employee1.CompareTo(employee2);

            Assert.Equal(0, result);
        }


        [Fact]
        public void CompareTo_ReturnOne_IfEmployeesHaveLargerGinNumber()
        {
            Employee employee1 = new Employee("1", "test", 36.5, false, false);
            Employee employee2 = new Employee("0", "test", 36.5, false, false);

            int result = employee1.CompareTo(employee2);

            Assert.Equal(1, result);
        }

        [Fact]
        public void CompareTo_ReturnMinusOne_IfTwoEmployeesHaveSmallerGinNumber()
        {
            Employee employee1 = new Employee("0", "test", 36.5, false, false);
            Employee employee2 = new Employee("1", "test", 36.5, false, false);

            int result = employee1.CompareTo(employee2);

            Assert.Equal(-1, result);
        }

    }
}
