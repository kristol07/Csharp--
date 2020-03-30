using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeHealthRecord
{
    public class EmployeeDatabase
    {
        // private List<Employee> employeeData;

        // public List<Employee> EmployeeData
        // {
        //     get; set;
        // }

        public Dictionary<string, Employee> EmployeeData
        {
            get; set;
        }

        public EmployeeDatabase()
        {
            // EmployeeData = new List<Employee>();
            EmployeeData = new Dictionary<string, Employee>();
        }

        public bool HasEmployee(string ginNumber)
        {
            // foreach (var employee in EmployeeData)
            // {
            //     if (employee.GinNumber == ginNumber)
            //     {
            //         return true;
            //     }
            // }

            // return false;

            return EmployeeData.ContainsKey(ginNumber);
        }

        // public bool HasEmployee(string ginNumber, string name)
        // {
        //     foreach (var employee in EmployeeData)
        //     {
        //         if (employee.GinNumber == ginNumber && employee.Name == name)
        //         {
        //             return true;
        //         }
        //     }

        //     return false;
        // }

        // public int FindEmployee(string ginNumber)
        // {
        //     int indexOfEmployee = -1;

        //     foreach (var employee in EmployeeData)
        //     {
        //         if (employee.GinNumber == ginNumber)
        //         {
        //             indexOfEmployee = EmployeeData.IndexOf(employee);
        //         }
        //     }

        //     return indexOfEmployee;
        // }

        // public int FindEmployee(string ginNumber, string name)
        // {
        //     int indexOfEmployee = -1;

        //     foreach (var employee in EmployeeData)
        //     {
        //         if (employee.GinNumber == ginNumber && employee.Name == name)
        //         {
        //             indexOfEmployee = EmployeeData.IndexOf(employee);
        //         }
        //     }

        //     return indexOfEmployee;
        // }

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

        // public List<Employee> GetListOfSuspectEmployee()
        // {
        //     List<Employee> listOfSuspectEmployee = new List<Employee>();

        //     foreach (var Employee in EmployeeData)
        //     {
        //         if (!string.IsNullOrEmpty(Employee.FormatForAbnormalInfoPrinting()))
        //         {
        //             listOfSuspectEmployee.Add(Employee);
        //         }
        //     }

        //     return listOfSuspectEmployee;
        // }

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


        // public void EditEmployeeInfo(string ginNumber, string option, string editedValue)
        // {
        //     int indexOfEmployee = FindEmployee(ginNumber);

        //     switch (option)
        //     {
        //         case "1":
        //         case "GinNumber":
        //             EmployeeData[indexOfEmployee].GinNumber = editedValue;
        //             break;
        //         case "2":
        //         case "Name":
        //             EmployeeData[indexOfEmployee].Name = editedValue;
        //             break;
        //         case "3":
        //         case "Body Temperature":
        //             EmployeeData[indexOfEmployee].BodyTemperature = double.Parse(editedValue);
        //             break;
        //         case "4":
        //         case "Has Hubei Travel History":
        //             if (editedValue == "no" || editedValue == "n")
        //             {
        //                 EmployeeData[indexOfEmployee].HasHubeiTravelHistory = false;
        //             }
        //             else
        //             {
        //                 EmployeeData[indexOfEmployee].HasHubeiTravelHistory = true;
        //             }
        //             break;
        //         case "5":
        //         case "Has Symptoms":
        //             if (editedValue == "no" || editedValue == "n")
        //             {
        //                 EmployeeData[indexOfEmployee].HasSymptoms = false;
        //             }
        //             else
        //             {
        //                 EmployeeData[indexOfEmployee].HasSymptoms = true;
        //             }
        //             break;
        //     }
        // }

        public void EditEmployeeInfo(string ginNumber, string option, string editedValue)
        {
            Employee employee = GetEmployee(ginNumber);

            if (employee != null)
            {
                switch (option)
                {
                    case "1":
                    case "GinNumber":
                        employee.GinNumber = editedValue;
                        break;
                    case "2":
                    case "Name":
                        employee.Name = editedValue;
                        break;
                    case "3":
                    case "Body Temperature":
                        employee.BodyTemperature = double.Parse(editedValue);
                        break;
                    case "4":
                    case "Has Hubei Travel History":
                        if (editedValue == "no" || editedValue == "n")
                        {
                            employee.HasHubeiTravelHistory = false;
                        }
                        else
                        {
                            employee.HasHubeiTravelHistory = true;
                        }
                        break;
                    case "5":
                    case "Has Symptoms":
                        if (editedValue == "no" || editedValue == "n")
                        {
                            employee.HasSymptoms = false;
                        }
                        else
                        {
                            employee.HasSymptoms = true;
                        }
                        break;
                }
            }
        }

        // public void EditEmployeeInfo(string ginNumber, string name, string option, string editedValue)
        // {
        //     int indexOfEmployee = FindEmployee(ginNumber, name);

        //     switch (option)
        //     {
        //         case "GinNumber":
        //             EmployeeData[indexOfEmployee].GinNumber = editedValue;
        //             break;
        //         case "Name":
        //             EmployeeData[indexOfEmployee].Name = editedValue;
        //             break;
        //         case "Body Temperature":
        //             EmployeeData[indexOfEmployee].BodyTemperature = double.Parse(editedValue);
        //             break;
        //         case "Has Hubei Travel History":
        //             if (editedValue == "no" || editedValue == "n")
        //             {
        //                 EmployeeData[indexOfEmployee].HasHubeiTravelHistory = false;
        //             }
        //             else
        //             {
        //                 EmployeeData[indexOfEmployee].HasHubeiTravelHistory = true;
        //             }
        //             break;
        //         case "Has Symptoms":
        //             if (editedValue == "no" || editedValue == "n")
        //             {
        //                 EmployeeData[indexOfEmployee].HasSymptoms = false;
        //             }
        //             else
        //             {
        //                 EmployeeData[indexOfEmployee].HasSymptoms = true;
        //             }
        //             break;
        //     }
        // }

        public void AddEmployee(string ginNumber, string name, double bodyTemperature, bool hasHubeiTravelHistory, bool hasSymptoms)
        {
            Employee newEmployee = new Employee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);

            // EmployeeData.Add(newEmployee);
            EmployeeData.Add(ginNumber, newEmployee);
        }

        public void RemoveEmployee(string ginNumber)
        {
            // int indexOfEmployee = FindEmployee(ginNumber);

            // if (indexOfEmployee != -1)
            // {
            //     EmployeeData.RemoveAt(indexOfEmployee);
            // }
            
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