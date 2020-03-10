using System;


namespace CsharpTest
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

            if (employeeDatabase.EmployeeData.Count != 0)
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

            if (employeeDatabase.EmployeeData.Count != 0)
            {
                int suspectsCount = 0;
                foreach (Employee employee in employeeDatabase.EmployeeData)
                {
                    if (!string.IsNullOrEmpty(employee.FormatForAbnormalInfoPrinting()))
                    {
                        Console.WriteLine(employee.FormatForAbnormalInfoPrinting());
                        suspectsCount++;
                    }
                }
                if (suspectsCount == 0)
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
            InputValidator.ValidExistingGinNumberInput(employeeDatabase, out ginNumber);
            if (ginNumber == "q")
            {
                return;
            }
            else
            {
                int indexOfEmployee;

                employeeDatabase.HasEmployee(ginNumber, out indexOfEmployee);

                Console.WriteLine(employeeDatabase.EmployeeData[indexOfEmployee]);

            }
        }

        public static void AddNewEmployeeData()
        {
            Console.WriteLine("Note that valid and complete inputs include GinNumber, Name, Body Temperature, Hubei Travel History and Symptoms.");

            // valid GinNumber input
            string ginNumber;
            InputValidator.ValidNewGinNumberInput(employeeDatabase, out ginNumber);
            if (ginNumber == "q")
            {
                return;
            }


            // valid name input ?
            string name;
            InputValidator.ValidNameInput(out name);


            // valid body tempeature input
            string inputBodyTemperature;
            InputValidator.ValidBodyTemperatureInput(out inputBodyTemperature);
            if (inputBodyTemperature == "q")
            {
                return;
            }

            double bodyTemperature = double.Parse(inputBodyTemperature);


            // valid Hubei travel history input
            string inputHubeiTravelHistory;
            InputValidator.ValidHasHubeiTravelHistoryInput(out inputHubeiTravelHistory);
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
            InputValidator.ValidHasSymptomsInput(out inputHasSymptoms);
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

        public static void EditSelectedEmployeeData()
        {
            // input valid ginnumber to edit
            string ginNumber;
            InputValidator.ValidExistingGinNumberInput(employeeDatabase, out ginNumber);
            if (ginNumber == "q")
            {
                return;
            }


            //input valid option to edit
            string option;
            InputValidator.ValidOptionInput(out option);
            if (option == "q")
            {
                return;
            }


            // input valid option value to edit
            string optionValue;
            InputValidator.ValidOptionValueInput(employeeDatabase, option, out optionValue);
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
            InputValidator.ValidFilePathToWriteInput(out fileName);
            if (fileName == "q")
            {
                return;
            }

            Console.WriteLine("Trying to save data to file: {0}.csv", fileName);
            EmployeeDataFileOperation.SaveDatabaseToCSVFile(fileName, employeeDatabase);
            Console.WriteLine("Saving data succeeded...");
        }

        public static void ReadDataFromFile()
        {
            string fileName;
            InputValidator.ValidFilePathToReadInput(out fileName);
            if (fileName == "q")
            {
                return;
            }

            Console.WriteLine("Trying to read data from file: {0}.csv", fileName);
            EmployeeDataFileOperation.ReadDatabaseFromCSVFile(fileName, out employeeDatabase);
            Console.WriteLine("Reading data succeeded...");
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
                Console.WriteLine("5. Edit Selected Employee Data");
                Console.WriteLine("6. Save data to a file");
                Console.WriteLine("7. Read data from a file");
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
                        EditSelectedEmployeeData();
                        break;
                    case "6":
                        SaveDataToFile();
                        break;
                    case "7":
                        ReadDataFromFile();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}