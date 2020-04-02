using System;
using System.IO;

namespace EmployeeHealthRecord
{
    public static class EmployeeDataFileOperation
    {
        public static string SaveDatabaseToCSVFile(string filePath, EmployeeDatabase employeeDatabase)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath + ".csv"))
                {
                    string header = "GinNumber,Name,BodyTemperature,HasHubeiTravelHistory,HasSymptoms,Symptoms";
                    sw.WriteLine(header);

                    // employeeDatabase.EmployeeData.Sort();
                    foreach (Employee employee in employeeDatabase.GetAllEmployee())
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

        public static string ReadDatabaseFromCSVFile(string filePath, ref EmployeeDatabase employeeDatabase)
        {
            char splitter = ',';

            try
            {
                using (StreamReader sr = new StreamReader(filePath + ".csv"))
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