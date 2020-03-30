using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeHealthRecord
{
    public class EmployeeDatabase
    {
        public Dictionary<string, Employee> EmployeeData
        {
            get; set;
        }

        public EmployeeDatabase()
        {
            EmployeeData = new Dictionary<string, Employee>();
        }

        public bool HasEmployee(string ginNumber)
        {
            return EmployeeData.ContainsKey(ginNumber);
        }
        public Employee GetEmployee(string ginNumber)
        {
            if (HasEmployee(ginNumber))
            {
                return EmployeeData[ginNumber];
            }
            else
            {
                return null;
            }
        }

        public List<Employee> GetAllEmployee()
        {
            return EmployeeData.Values.ToList();
        }

        public List<Employee> GetAllSuspectEmployee()
        {
            List<Employee> listOfSuspectEmployee = new List<Employee>();

            foreach (var Employee in EmployeeData.Values)
            {
                if (!string.IsNullOrEmpty(Employee.GetAbnormalInfo()))
                {
                    listOfSuspectEmployee.Add(Employee);
                }
            }

            return listOfSuspectEmployee;
        }

        public void EditEmployeeInfo(string ginNumber, string option, string editedValue)
        {
            if (HasEmployee(ginNumber))
            {
                EmployeeData[ginNumber].EditValue(option, editedValue);
            }
        }

        public void AddEmployee(string ginNumber, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms)
        {
            Employee newEmployee = new Employee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);

            EmployeeData.Add(ginNumber, newEmployee);
        }

        public void RemoveEmployee(string ginNumber)
        {
            if (HasEmployee(ginNumber))
            {
                EmployeeData.Remove(ginNumber);
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