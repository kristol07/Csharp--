using System;
using System.IO;
using System.Security;

namespace EmployeeHealthRecord
{
    public static class EmployeeDataFileOperation
    {
        public static string SaveDatabaseToCSVFile(string filePath, EmployeeDatabase employeeDatabase)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
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
                EmployeeDatabase newEmployeeDatabase = new EmployeeDatabase();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    // update only when open file without problem
                    
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
                        newEmployeeDatabase.AddEmployee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);
                    }
                }

                employeeDatabase = newEmployeeDatabase;
                return "success";
            }
            catch(IndexOutOfRangeException)
            {
                return "formatError";
            }
            catch(UnauthorizedAccessException)
            {
                return "loadError"; // without read permission
            }
            catch
            {
                return "error";
            }
        }


    }

}