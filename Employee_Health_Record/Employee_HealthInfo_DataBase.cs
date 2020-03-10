using System;
using System.IO;
using System.Linq;
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

        public bool HasEmployee(string ginNumber, out int indexOfEmployee)
        {
            indexOfEmployee = -1;

            foreach (var employee in EmployeeData)
            {
                if (employee.GinNumber == ginNumber)
                {
                    indexOfEmployee = EmployeeData.IndexOf(employee);
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

        public bool HasEmployee(string ginNumber, string name, out int indexOfEmployee)
        {
            indexOfEmployee = -1;

            foreach (var employee in EmployeeData)
            {
                if (employee.GinNumber == ginNumber && employee.Name == name)
                {
                    indexOfEmployee = EmployeeData.IndexOf(employee);
                    return true;
                }
            }

            return false;
        }

        public void EditEmployeeInfo(string ginNumber, string option, string editedValue)
        {
            int indexOfEmployee;

            if (HasEmployee(ginNumber, out indexOfEmployee))
            {
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
        }

        public void EditEmployeeInfo(string ginNumber, string name, string option, string editedValue)
        {
            int indexOfEmployee;

            if (HasEmployee(ginNumber, name, out indexOfEmployee))
            {
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
        }

        public void AddEmployee(string ginNumber, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms)
        {
            if (HasEmployee(ginNumber))
            {
                Console.WriteLine("GinNumber has been occupied! Choose another one.");
            }

            if (HasEmployee(ginNumber, name))
            {
                Console.WriteLine("Employee exists already! Try Edit function!");
            }

            Employee newEmployee = new Employee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);

            EmployeeData.Add(newEmployee);
            // Console.WriteLine("New Employee Added!");
        }
    }
}