using System;
using System.IO;
using System.Security;

namespace EmployeeHealthInfoRecord
{
    public static class EmployeeRecordsFileOperation
    {
        public static string SaveDatabaseToCSVFile(string filePath, EmployeeRecords employeeRecords)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    string header = "GinNumber,Date,Name,BodyTemperature,HasHubeiTravelHistory,HasSymptoms,Notes";
                    sw.WriteLine(header);

                    foreach (EmployeeRecord employeeRecord in employeeRecords.GetAllRecords())
                    {
                        sw.WriteLine(employeeRecord.FormatForSave());
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

        public static string ReadDatabaseFromCSVFile(string filePath, ref EmployeeRecords employeeRecords)
        {
            char splitter = ',';

            try
            {
                EmployeeRecords newEmployeeRecords = new EmployeeRecords();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    // update only when open file without problem
                    
                    string header = sr.ReadLine();

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] employeeRecord = line.Split(splitter);
                        string ginNumber = employeeRecord[0];
                        DateTime date = DateTime.Parse(employeeRecord[1]);
                        string name = employeeRecord[2];
                        double bodyTemperature = double.Parse(employeeRecord[3]);
                        bool hasHubeiTravelHistory = bool.Parse(employeeRecord[4]);
                        bool hasSymptoms = bool.Parse(employeeRecord[5]);
                        string notes = employeeRecord[6];
                        newEmployeeRecords.AddRecord(ginNumber, date, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms, notes);
                    }
                }

                employeeRecords = newEmployeeRecords;
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