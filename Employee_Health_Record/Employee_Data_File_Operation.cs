using System;
using System.IO;
using System.Collections.Generic;

namespace CsharpTest
{
    public static class EmployeeDataFileOperation
    {
        public static void SaveDatabaseToCSVFile(string fileName, EmployeeDatabase employeeDatabase)
        {
            using (StreamWriter sw = new StreamWriter(fileName + ".csv"))
            {
                string header = "GinNumber,Name,BodyTemperature,HasHubeiTravelHistory,HasSymptoms,Symptoms";
                sw.WriteLine(header);
                
                employeeDatabase.EmployeeData.Sort();
                foreach (Employee employee in employeeDatabase.EmployeeData)
                {
                    sw.WriteLine(employee.FormatForSave());
                }
            }
        }

        public static void ReadDatabaseFromCSVFile(string fileName, out EmployeeDatabase employeeDatabase)
        {
            char splitter = ',';

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
                    employeeDatabase.EmployeeData.Add(new Employee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms));
                }
            }
        }


    }

}