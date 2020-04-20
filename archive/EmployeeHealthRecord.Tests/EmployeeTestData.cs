using System;
using System.Collections.Generic;
using EmployeeHealthRecord;

namespace EmployeeHealthRecord.Tests
{
    public class EmployeeTestData
    {
        public static IEnumerable<object[]> TestAbnormalData
        {
            get
            {
                // single 
                // yield return new object[] { new Employee("0", "Test", 0, false, false) };
                yield return new object[] { new Employee("0", "Test", 40, false, false) };
                yield return new object[] { new Employee("0", "Test", 36.5, true, false) };
                yield return new object[] { new Employee("0", "Test", 36.5, false, true) };

                // double
                // yield return new object[] { new Employee("0", "Test", 0, true, false) };
                yield return new object[] { new Employee("0", "Test", 40, false, true) };
                // yield return new object[] { new Employee("0", "Test", 0, false, true) };
                yield return new object[] { new Employee("0", "Test", 36.5, true, true) };
                yield return new object[] { new Employee("0", "Test", 40, true, false) };

                // treble
                // yield return new object[] { new Employee("0", "Test", 0, true, true) };
                yield return new object[] { new Employee("0", "Test", 40, true, true) };
            }
        }

        public static IEnumerable<Object[]> TestAbnormalInfoData
        {
            get
            {
                // single 
                // yield return new object[] { new Employee("0", "Test", 0, false, false), "0-Test||BodyTemperature: 0" };
                yield return new object[] { new Employee("0", "Test", 40, false, false), "0-Test||BodyTemperature: 40" };
                yield return new object[] { new Employee("0", "Test", 36.5, true, false), "0-Test||Has been to Hubei" };
                yield return new object[] { new Employee("0", "Test", 36.5, false, true), "0-Test||Has symptoms" };

                // double
                // yield return new object[] { new Employee("0", "Test", 0, true, false), "0-Test||BodyTemperature: 0||Has been to Hubei" };
                // yield return new object[] { new Employee("0", "Test", 0, false, true), "0-Test||BodyTemperature: 0||Has symptoms" };
                yield return new object[] { new Employee("0", "Test", 36.5, true, true), "0-Test||Has been to Hubei||Has symptoms" };
                yield return new object[] { new Employee("0", "Test", 40, false, true), "0-Test||BodyTemperature: 40||Has symptoms" };
                yield return new object[] { new Employee("0", "Test", 40, true, false), "0-Test||BodyTemperature: 40||Has been to Hubei" };

                //trible
                // yield return new object[] { new Employee("0", "Test", 0, true, true), "0-Test||BodyTemperature: 0||Has been to Hubei||Has symptoms" };
                yield return new object[] { new Employee("0", "Test", 40, true, true), "0-Test||BodyTemperature: 40||Has been to Hubei||Has symptoms" };
            }
        }

        public static IEnumerable<object[]> TestEditFunctionData
        {
            get
            {
                yield return new object[] { "0", "GinNumber", "5", new Employee("5", "test", 36.5, false, false) };
                yield return new object[] { "0", "Name", "Test", new Employee("0", "Test", 36.5, false, false) };
                yield return new object[] { "0", "Body Temperature", "36", new Employee("0", "test", 36, false, false) };
                yield return new object[] { "0", "Has Hubei Travel History", "y", new Employee("0", "test", 36.5, true, false) };
                yield return new object[] { "0", "Has Symptoms", "y", new Employee("0", "test", 36.5, false, true) };

                yield return new object[] { "2", "Has Hubei Travel History", "n", new Employee("2", "test", 40, false, false) };
                yield return new object[] { "3", "Has Symptoms", "n", new Employee("3", "test", 36, false, false) };

                yield return new object[] { "0", "1", "5", new Employee("5", "test", 36.5, false, false) };
                yield return new object[] { "0", "2", "Test", new Employee("0", "Test", 36.5, false, false) };
                yield return new object[] { "0", "3", "36", new Employee("0", "test", 36, false, false) };
                yield return new object[] { "0", "4", "y", new Employee("0", "test", 36.5, true, false) };
                yield return new object[] { "0", "5", "y", new Employee("0", "test", 36.5, false, true) };

                yield return new object[] {"4", "1", "4", null};
            }
        }
    }
}