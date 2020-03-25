using System;
using System.Collections.Generic;


namespace EmployeeHealthRecord
{
    public class ConsoleApp
    {
        private static EmployeeDatabase employeeDatabase;

        static ConsoleApp()
        {
            employeeDatabase = new EmployeeDatabase();
        }

        public static void PrintAllEmployeeData()
        {
            Console.WriteLine("Trying to print all employee data...");

            if (!employeeDatabase.IsEmpty())
            {
                foreach (var employee in employeeDatabase.EmployeeData)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("No Employee in the database.");
            }
        }

        public static void PrintSuspectedEmployeeData()
        {
            Console.WriteLine("Trying to print all suspects data...");

            if (!employeeDatabase.IsEmpty())
            {
                List<Employee> suspectEmployee = employeeDatabase.GetListOfSuspectEmployee();

                if (suspectEmployee.Count != 0)
                {
                    foreach (Employee employee in suspectEmployee)
                    {
                        Console.WriteLine(employee.FormatForAbnormalInfoPrinting());
                    }
                }
                else
                {
                    Console.WriteLine("All employees are healthy!");
                }
            }
            else
            {
                Console.WriteLine("No Employee in the database.");
            }
        }

        public static void PrintSelectedEmployeeData()
        {
            string ginNumber;
            ConsoleInputValidator.ValidExistingGinNumberInput(employeeDatabase, out ginNumber);
            if (ginNumber == "q")
            {
                return;
            }

            // int indexOfEmployee = employeeDatabase.FindEmployee(ginNumber);
            // Console.WriteLine(employeeDatabase.EmployeeData[indexOfEmployee]);

            Employee employee = employeeDatabase.FindEmployee(ginNumber);
            Console.WriteLine(employee);

        }

        public static void AddNewEmployeeData()
        {
            Console.WriteLine("Note that valid and complete inputs include GinNumber, Name, Body Temperature, Hubei Travel History and Symptoms.");

            // valid GinNumber input
            string ginNumber;
            ConsoleInputValidator.ValidNewGinNumberInput(employeeDatabase, out ginNumber);
            if (ginNumber == "q")
            {
                return;
            }


            // valid name input ?
            string name;
            ConsoleInputValidator.ValidNameInput(out name);


            // valid body tempeature input
            string inputBodyTemperature;
            ConsoleInputValidator.ValidBodyTemperatureInput(out inputBodyTemperature);
            if (inputBodyTemperature == "q")
            {
                return;
            }

            double bodyTemperature = double.Parse(inputBodyTemperature);


            // valid Hubei travel history input
            string inputHubeiTravelHistory;
            ConsoleInputValidator.ValidHasHubeiTravelHistoryInput(out inputHubeiTravelHistory);
            if (inputHubeiTravelHistory == "q")
            {
                return;
            }

            bool hasHubeiTravelHistory = false;
            if (inputHubeiTravelHistory == "y" || inputHubeiTravelHistory == "yes")
            {
                hasHubeiTravelHistory = true;
            }

            // valid Symptoms input
            string inputHasSymptoms;
            ConsoleInputValidator.ValidHasSymptomsInput(out inputHasSymptoms);
            if (inputHasSymptoms == "q")
            {
                return;
            }

            bool hasSymptoms = false;
            if (inputHasSymptoms == "y" || inputHasSymptoms == "yes")
            {
                hasSymptoms = true;
            }


            // add valid employee data input
            employeeDatabase.AddEmployee(ginNumber, name, bodyTemperature, hasHubeiTravelHistory, hasSymptoms);
            Console.WriteLine("Adding new employee data succeeded...");

        }

        public static void DeleteSelectedEmployee()
        {
            // input valid ginnumber to edit
            string ginNumber;
            ConsoleInputValidator.ValidExistingGinNumberInput(employeeDatabase, out ginNumber);
            if (ginNumber == "q")
            {
                return;
            }

            employeeDatabase.RemoveEmployee(ginNumber);
            Console.WriteLine("Deleting Employee succeeded...");
        }

        public static void EditSelectedEmployeeData()
        {
            // input valid ginnumber to edit
            string ginNumber;
            ConsoleInputValidator.ValidExistingGinNumberInput(employeeDatabase, out ginNumber);
            if (ginNumber == "q")
            {
                return;
            }


            //input valid option to edit
            string option;
            ConsoleInputValidator.ValidOptionInput(out option);
            if (option == "q")
            {
                return;
            }


            // input valid option value to edit
            string optionValue;
            ConsoleInputValidator.ValidOptionValueInput(employeeDatabase, option, out optionValue);
            if (optionValue == "q")
            {
                return;
            }


            // edit existing employee with new option value
            employeeDatabase.EditEmployeeInfo(ginNumber, option, optionValue);
            Console.WriteLine("Editing succeeded...");

        }

        public static void SaveDataToFile()
        {
            string fileName;
            ConsoleInputValidator.ValidFilePathToWriteInput(out fileName);
            if (fileName == "q")
            {
                return;
            }

            Console.WriteLine("Trying to save data to file: {0}.csv", fileName);

            string saveOperationResult = EmployeeDataFileOperation.SaveDatabaseToCSVFile(fileName, employeeDatabase);

            if (saveOperationResult == "done")
            {
                Console.WriteLine("Saving database succeeded...");
            }
            else if (saveOperationResult == "error")
            {
                Console.WriteLine("Saving database failed...");
            }
            else
            {
                Console.WriteLine("Saving operation error: " + saveOperationResult);
            }
        }

        public static void ReadDataFromFile()
        {
            string fileName;
            ConsoleInputValidator.ValidFilePathToReadInput(out fileName);
            if (fileName == "q")
            {
                return;
            }

            Console.WriteLine("Trying to read data from file: {0}.csv", fileName);

            string readOperationResult = EmployeeDataFileOperation.ReadDatabaseFromCSVFile(fileName, ref employeeDatabase);

            switch (readOperationResult)
            {
                case "0":
                    Console.WriteLine("Reading database from file succeeded...");
                    break;
                case "-1":
                    Console.WriteLine("Format error in data of database saved in file.");
                    break;
                case "error":
                    Console.WriteLine("Reading operation error.");
                    break;
            }
        }

        public void Run()
        {
            while (true)
            {
                // Console.WriteLine();
                Console.WriteLine("\nChoose Module:");
                Console.WriteLine("1. Print All Employee Data");
                Console.WriteLine("2. Print Suspected Employee Data");
                Console.WriteLine("3. Print Selected Employee Data");
                Console.WriteLine("4. Add New Employee Data");
                Console.WriteLine("5. Delete Selected Employee Data");
                Console.WriteLine("6. Edit Selected Employee Data");
                Console.WriteLine("7. Save data to a file");
                Console.WriteLine("8. Read data from a file");
                Console.WriteLine("===============");

                string moduleSelected = Console.ReadLine();
                switch (moduleSelected)
                {
                    case "1":
                        PrintAllEmployeeData();
                        break;
                    case "2":
                        PrintSuspectedEmployeeData();
                        break;
                    case "3":
                        PrintSelectedEmployeeData();
                        break;
                    case "4":
                        AddNewEmployeeData();
                        break;
                    case "5":
                        DeleteSelectedEmployee();
                        break;
                    case "6":
                        EditSelectedEmployeeData();
                        break;
                    case "7":
                        SaveDataToFile();
                        break;
                    case "8":
                        ReadDataFromFile();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}