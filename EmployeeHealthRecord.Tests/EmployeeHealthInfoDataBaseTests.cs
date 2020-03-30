using System;
using System.Collections.Generic;
using Xunit;
using EmployeeHealthRecord;
using FluentAssertions;

namespace EmployeeHealthRecord.Tests
{
    public class EmployeeDataBaseTests
    {
        private readonly EmployeeDatabase _employeeDatabase;

        public EmployeeDataBaseTests()
        {
            _employeeDatabase = new EmployeeDatabase();
            _employeeDatabase.EmployeeData.Add("0", new Employee("0", "test", 36.5, false, false));
            _employeeDatabase.EmployeeData.Add("1", new Employee("1", "test", 36, false, false));
            _employeeDatabase.EmployeeData.Add("2", new Employee("2", "test", 40, true, false));
            _employeeDatabase.EmployeeData.Add("3", new Employee("3", "test", 36, false, true));
        }

        [Fact]
        public void HasEmployee_ReturnTrue_IfEmployeeInDatabaseHasSameGinNumber()
        {
            bool result = _employeeDatabase.HasEmployee("0");
            Assert.True(result);
        }

        [Fact]
        public void HasEmployee_ReturnFalse_IfEmployeeInDatabaseHasNoSameGinNumber()
        {
            bool result = _employeeDatabase.HasEmployee("4");
            Assert.False(result);
        }

        [Fact]
        public void GetEmployee_ReturnNull_IfNoEmployeeWithSameGinNumberFound()
        {
            Employee result = _employeeDatabase.GetEmployee("4");

            result.Should().BeNull();
        }

        [Fact]
        public void GetEmployee_ReturnEmployee_IfEmployeeWithSameGinNumberFound()
        {
            Employee result = _employeeDatabase.GetEmployee("0");

            result.Should().BeEquivalentTo(new Employee("0", "test", 36.5, false, false));
        }

        [Fact]
        public void GetAllEmployee_ReturnListOfAllEmployeeInDatabase()
        {
            List<Employee> expected = new List<Employee> {  new Employee("0", "test", 36.5, false, false),
                                                            new Employee("1", "test", 36, false, false),
                                                            new Employee("2", "test", 40, true, false),
                                                            new Employee("3", "test", 36, false, true)};

            List<Employee> result = _employeeDatabase.GetAllEmployee();

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllSuspectEmployee_ReturnListOfAllSuspectEmployeeInDatabase()
        {
            List<Employee> expected = new List<Employee> {  new Employee("2", "test", 40, true, false),
                                                            new Employee("3", "test", 36, false, true)};

            List<Employee> result = _employeeDatabase.GetAllSuspectEmployee();

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(EmployeeTestData.TestEditFunctionData), MemberType = typeof(EmployeeTestData))]
        public void EditEmployeeInfo_WithEmployeeInfoEditedInDatabase(string ginNumber, string option, string editedValue, Employee expected)
        {
            _employeeDatabase.EditEmployeeInfo(ginNumber, option, editedValue);
            Employee result = _employeeDatabase.GetEmployee(ginNumber);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void AddEmployee_WithNewEmployeeAddedInDatabase()
        {
            Employee expected = new Employee("5", "test", 37, false, false);

            _employeeDatabase.AddEmployee("5", "test", 37, false, false);
            Employee result = _employeeDatabase.GetEmployee("5");

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void RemoveEmployee_WithEmployeeRemovedInDatabase_IfEmployeeWithSameGinNumberExisted()
        {
            _employeeDatabase.RemoveEmployee("0");
            Employee result = _employeeDatabase.GetEmployee("0");

            result.Should().BeNull();
        }


        [Fact]
        public void IsEmpty_ReturnTrue_IfDatabaseIsEmpty()
        {
            _employeeDatabase.RemoveEmployee("0");
            _employeeDatabase.RemoveEmployee("1");
            _employeeDatabase.RemoveEmployee("2");
            _employeeDatabase.RemoveEmployee("3");
            Assert.True(_employeeDatabase.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ReturnFalse_IfDatabaseIsNotEmpty()
        {
            Assert.False(_employeeDatabase.IsEmpty());
        }
    }
}