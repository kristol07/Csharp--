using System;
using System.IO;

namespace CsharpTest
{
    public static class EmployeeDataFileOperation
    {
        public static string SaveDatabaseToCSVFile(string fileName, EmployeeDatabase employeeDatabase)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName + ".csv"))
                {
                    string header = "GinNumber,Name,BodyTemperature,HasHubeiTravelHistory,HasSymptoms,Symptoms";
                    sw.WriteLine(header);

                    // employeeDatabase.EmployeeData.Sort();
                    foreach (Employee employee in employeeDatabase.EmployeeData.Values)
                    {
                        sw.WriteLine(employee.FormatForSave());
                    }
                }
                return "done";
            }
            catch (FileLoadException ex)
            {
                return ex.Message;
            }
            catch
            {
                return "error";
            }
        }

        public static string ReadDatabaseFromCSVFile(string fileName, ref EmployeeDatabase employeeDatabase)
        {
            char splitter = ',';

            try
            {
                using (StreamReader sr = new StreamReader(fileName + ".csv"))
                {
                    // update only when open file without problem
                    employeeDatabase = new EmployeeDatabase();
                    string header = sr.ReadLine();

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] employeeInfo = line.Split(splitter);
                        string ginNumber = employeeInfo[0];
                        string name = employeeInfo[1];
                        double bodyTemperature = double.Parse(employeeInfo[2]);
                        bool hasHubeiTravelHistory = bool.Parse(employeeInfo[3]);
                        bool hasSymptoms = bool.Parse(employeeInfo[4]);
                        // employeeDatabase.EmployeeData.Add(new Employee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms));
                        employeeDatabase.AddEmployee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);
                    }
                }

                return "0";
            }
            catch(IndexOutOfRangeException)
            {
                return "-1";
            }
            catch
            {
                return "error";
            }
        }


    }

}