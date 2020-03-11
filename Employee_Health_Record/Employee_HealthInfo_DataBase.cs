using System;
using System.Collections.Generic;


namespace CsharpTest
{
    public class EmployeeDatabase
    {
        // private List<Employee> employeeData;

        public List<Employee> EmployeeData
        {
            get; set;
        }

        public EmployeeDatabase()
        {
            EmployeeData = new List<Employee>();
        }

        public bool HasEmployee(string ginNumber)
        {
            foreach (var employee in EmployeeData)
            {
                if (employee.GinNumber == ginNumber)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasEmployee(string ginNumber, string name)
        {
            foreach (var employee in EmployeeData)
            {
                if (employee.GinNumber == ginNumber && employee.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int FindEmployee(string ginNumber)
        {
            int indexOfEmployee = -1;

            foreach (var employee in EmployeeData)
            {
                if (employee.GinNumber == ginNumber)
                {
                    indexOfEmployee = EmployeeData.IndexOf(employee);
                }
            }

            return indexOfEmployee;
        }

        public int FindEmployee(string ginNumber, string name)
        {
            int indexOfEmployee = -1;

            foreach (var employee in EmployeeData)
            {
                if (employee.GinNumber == ginNumber && employee.Name == name)
                {
                    indexOfEmployee = EmployeeData.IndexOf(employee);
                }
            }

            return indexOfEmployee;
        }

        public List<Employee> GetListOfSuspectEmployee()
        {
            List<Employee> listOfSuspectEmployee = new List<Employee>();

            foreach (var Employee in EmployeeData)
            {
                if (!string.IsNullOrEmpty(Employee.FormatForAbnormalInfoPrinting()))
                {
                    listOfSuspectEmployee.Add(Employee);
                }
            }

            return listOfSuspectEmployee;
        }

        public void EditEmployeeInfo(string ginNumber, string option, string editedValue)
        {
            int indexOfEmployee = FindEmployee(ginNumber);

            switch (option)
            {
                case "1":
                case "GinNumber":
                    EmployeeData[indexOfEmployee].GinNumber = editedValue;
                    break;
                case "2":
                case "Name":
                    EmployeeData[indexOfEmployee].Name = editedValue;
                    break;
                case "3":
                case "Body Temperature":
                    EmployeeData[indexOfEmployee].BodyTemperature = double.Parse(editedValue);
                    break;
                case "4":
                case "Has Hubei Travel History":
                    if (editedValue == "no" || editedValue == "n")
                    {
                        EmployeeData[indexOfEmployee].HasHubeiTravelHistory = false;
                    }
                    else
                    {
                        EmployeeData[indexOfEmployee].HasHubeiTravelHistory = true;
                    }
                    break;
                case "5":
                case "Has Symptoms":
                    if (editedValue == "no" || editedValue == "n")
                    {
                        EmployeeData[indexOfEmployee].HasSymptoms = false;
                    }
                    else
                    {
                        EmployeeData[indexOfEmployee].HasSymptoms = true;
                    }
                    break;
            }
        }

        public void EditEmployeeInfo(string ginNumber, string name, string option, string editedValue)
        {
            int indexOfEmployee = FindEmployee(ginNumber, name);

            switch (option)
            {
                case "GinNumber":
                    EmployeeData[indexOfEmployee].GinNumber = editedValue;
                    break;
                case "Name":
                    EmployeeData[indexOfEmployee].Name = editedValue;
                    break;
                case "Body Temperature":
                    EmployeeData[indexOfEmployee].BodyTemperature = double.Parse(editedValue);
                    break;
                case "Has Hubei Travel History":
                    if (editedValue == "no" || editedValue == "n")
                    {
                        EmployeeData[indexOfEmployee].HasHubeiTravelHistory = false;
                    }
                    else
                    {
                        EmployeeData[indexOfEmployee].HasHubeiTravelHistory = true;
                    }
                    break;
                case "Has Symptoms":
                    if (editedValue == "no" || editedValue == "n")
                    {
                        EmployeeData[indexOfEmployee].HasSymptoms = false;
                    }
                    else
                    {
                        EmployeeData[indexOfEmployee].HasSymptoms = true;
                    }
                    break;
            }
        }

        public void AddEmployee(string ginNumber, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms)
        {
            Employee newEmployee = new Employee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);

            EmployeeData.Add(newEmployee);
        }

        public void RemoveEmployee(string ginNumber)
        {
            int indexOfEmployee = FindEmployee(ginNumber);

            if (indexOfEmployee != -1)
            {
                EmployeeData.RemoveAt(indexOfEmployee);
            }
        }

        public bool IsEmpty()
        {
            if (EmployeeData.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}