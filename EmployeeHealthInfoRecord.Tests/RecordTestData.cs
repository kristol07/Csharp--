using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeHealthInfoRecord.Tests
{
    public class RecordTestData
    {
        public static IEnumerable<object[]> TestAbnormalData
        {
            get
            {
                Employee employee = new Employee("1", "John");
                DateTime checkDate = DateTime.Parse("2020/01/01");

                yield return new object[] { new EmployeeRecord(employee, checkDate, 38, false, false) };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 37, true, false) };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 37, false, true) };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 38, true, false) };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 38, false, true) };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 37, true, true) };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 38, true, true) };
            }
        }

        public static IEnumerable<object[]> TestAbnormalInfoData
        {
            get
            {
                Employee employee = new Employee("1", "John");
                DateTime checkDate = DateTime.Parse("2020/01/01");

                yield return new object[] { new EmployeeRecord(employee, checkDate, 38, false, false), "1-John-2020/1/1||BodyTemperature: 38" };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 37, true, false), "1-John-2020/1/1||Has been to Hubei" };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 37, false, true), "1-John-2020/1/1||Has symptoms" };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 38, true, false), "1-John-2020/1/1||BodyTemperature: 38||Has been to Hubei" };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 38, false, true), "1-John-2020/1/1||BodyTemperature: 38||Has symptoms" };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 37, true, true), "1-John-2020/1/1||Has been to Hubei||Has symptoms" };
                yield return new object[] { new EmployeeRecord(employee, checkDate, 38, true, true), "1-John-2020/1/1||BodyTemperature: 38||Has been to Hubei||Has symptoms" };
            }
        }


    }
}
