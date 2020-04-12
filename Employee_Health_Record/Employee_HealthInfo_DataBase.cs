using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace EmployeeHealthRecord
{
    public class EmployeeDatabase
    {

        public BindingList<Employee> EmployeeList
        {
            get
            {
                BindingList<Employee> employeeList = new BindingList<Employee>();
                foreach (var emplyee in GetAllEmployee())
                {
                    employeeList.Add(emplyee);
                }
                return employeeList;
            }
            //set
            //{
            //    Dictionary<string, Employee> newEmployeeData = new Dictionary<string, Employee>();
            //    foreach(var employee in value)
            //    {
            //        newEmployeeData.Add(employee.GinNumber, employee);
            //    }
            //    EmployeeData = newEmployeeData;
            //}
        }

        public BindingList<Employee> SuspectEmployeeList
        {
            get
            {
                BindingList<Employee> suspectEmployeeList = new BindingList<Employee>();
                foreach (var emplyee in GetAllSuspectEmployee())
                {
                    suspectEmployeeList.Add(emplyee);
                }
                return suspectEmployeeList;
            }
        }

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

            foreach (var employee in EmployeeData.Values)
            {
                if (!string.IsNullOrEmpty(employee.GetAbnormalInfo()))
                {
                    listOfSuspectEmployee.Add(employee);
                }
            }

            return listOfSuspectEmployee;
        }

        public void EditEmployeeInfo(string ginNumber, string option, string editedValue)
        {
            if (HasEmployee(ginNumber))
            {
                EmployeeData[ginNumber].EditValue(option, editedValue);

                if(option == "GinNumber" || option == "1")
                {
                    EmployeeData.Add(editedValue, EmployeeData[ginNumber]);
                    EmployeeData.Remove(ginNumber);
                }
            }
        }

        public void AddEmployee(string ginNumber, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms)
        {
            Employee newEmployee = new Employee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);

            EmployeeData.Add(ginNumber, newEmployee);
        }

        //public void RemoveEmployee(string ginNumber)
        //{
        //    if (HasEmployee(ginNumber))
        //    {
        //        EmployeeData.Remove(ginNumber);
        //    }
        //}

        public void RemoveEmployee(params string[] ginNumbers)
        {
            foreach (var ginNumber in ginNumbers)
            {
                if (!HasEmployee(ginNumber))
                {
                    return;
                }
            }

            foreach (var ginNumber in ginNumbers)
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