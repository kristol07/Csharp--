using System;
using System.IO;
using System.Linq;

namespace EmployeeHealthRecord
{
    public static class ConsoleInputValidator
    {

        public static void ValidNewGinNumberInput(EmployeeDatabase employeeDatabase, out string inputGinNumber)
        {
            Console.WriteLine("Input valid GinNumber:");
            inputGinNumber = Console.ReadLine();

            int GinNumber;
            while (!Int32.TryParse(inputGinNumber, out GinNumber))
            {
                Console.WriteLine("Invalid GinNumber!");
                Console.WriteLine("GinNumber is an Integer. (Press 'q' to quit)");
                inputGinNumber = Console.ReadLine();
                if (inputGinNumber == "q")
                {
                    return;
                }
            }

            while (employeeDatabase.HasEmployee(inputGinNumber))
            {
                Console.WriteLine("Employee already existed!");
                Console.WriteLine("Try new GinNumber. (Press 'q' to quit)");
                inputGinNumber = Console.ReadLine();
                if (inputGinNumber == "q")
                {
                    return;
                }
            }
        }

        public static void ValidExistingGinNumberInput(EmployeeDatabase employeeDatabase, out string inputGinNumber)
        {
            Console.WriteLine("Input valid GinNubmer:");
            inputGinNumber = Console.ReadLine();

            int GinNumber;
            while (!Int32.TryParse(inputGinNumber, out GinNumber))
            {
                Console.WriteLine("Invalid GinNumber!");
                Console.WriteLine("GinNumber is an Integer. (Press 'q' to quit)");
                inputGinNumber = Console.ReadLine();
                if (inputGinNumber == "q")
                {
                    return;
                }
            }

            while (!employeeDatabase.HasEmployee(inputGinNumber))
            {
                Console.WriteLine("Employee not found!");
                Console.WriteLine("Try correct GinNumber or Add new Employee. (Press 'q' to quit)");
                inputGinNumber = Console.ReadLine();
                if (inputGinNumber == "q")
                {
                    return;
                }
            }
        }

        public static void ValidNameInput(out string inputName)
        {
            Console.WriteLine("Input valid name:");
            inputName = Console.ReadLine();
        }

        public static void ValidHasHubeiTravelHistoryInput(out string inputHubeiTravelHistory)
        {
            Console.WriteLine("Any Hubei travel history? (y/yes/n/no)");
            inputHubeiTravelHistory = Console.ReadLine().ToLower();
            string[] options = { "y", "yes", "n", "no" };
            while (!options.Contains(inputHubeiTravelHistory))
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("'y'/'Y'/'yes'/'Yes' to confirm. 'n'/'N'/'no'/'No' to deny. (Press 'q' to quit)");
                inputHubeiTravelHistory = Console.ReadLine().ToLower();
                if (inputHubeiTravelHistory == "q")
                {
                    return;
                }
            }
        }

        public static void ValidHasSymptomsInput(out string inputHasSymptoms)
        {
            Console.WriteLine("Any symptoms of being affected? (y/yes/n/no)");
            inputHasSymptoms = Console.ReadLine().ToLower();
            string[] options = { "y", "yes", "n", "no" };
            while (!options.Contains(inputHasSymptoms))
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("'y'/'Y'/'yes'/'Yes' to confirm. 'n'/'N'/'no'/'No' to deny. (Press 'q' to quit)");
                inputHasSymptoms = Console.ReadLine().ToLower();
                if (inputHasSymptoms == "q")
                {
                    return;
                }
            }
        }

        public static void ValidBodyTemperatureInput(out string inputBodyTemperature)
        {
            Console.WriteLine("Input valid Body Temperature:");
            inputBodyTemperature = Console.ReadLine();
            double bodyTemperature;
            while (!double.TryParse(inputBodyTemperature, out bodyTemperature))
            {
                Console.WriteLine("Body Temperature invalid! Retry. (Press 'q' to quit)");
                inputBodyTemperature = Console.ReadLine();
                if (inputBodyTemperature == "q")
                {
                    return;
                }
            }
        }

        public static void ValidOptionInput(out string inputOption)
        {
            Console.WriteLine("Input Option for editing: '1: GinNumber', '2: Name', '3: Body Temperature', '4: Has Hubei Travel History' or '5: Has Symptoms'");
            inputOption = Console.ReadLine();
            string[] options = { "1", "2", "3", "4", "5" };

            while (!options.Contains(inputOption))
            {
                Console.WriteLine("Invalid option input!");
                Console.WriteLine("Available options: '1: GinNumber', '2: Name', '3: Body Temperature', '4: Has Hubei Travel History' or '5: Has Symptoms'. (Press 'q' to quit)");
                inputOption = Console.ReadLine();
                if (inputOption == "q")
                {
                    return;
                }
            }
        }

        public static void ValidOptionValueInput(EmployeeDatabase employeeDatabase, string option, out string inputOptionValue)
        {

            inputOptionValue = "";
            switch (option)
            {
                case "1":
                    ValidNewGinNumberInput(employeeDatabase, out inputOptionValue);
                    break;
                case "2":
                    ValidNameInput(out inputOptionValue);
                    break;
                case "3":
                    ValidBodyTemperatureInput(out inputOptionValue);
                    break;
                case "4":
                    ValidHasHubeiTravelHistoryInput(out inputOptionValue);
                    break;
                case "5":
                    ValidHasSymptomsInput(out inputOptionValue);
                    break;
            }
        }

        public static void ValidFilePathToReadInput(out string inputFileName)
        {
            Console.WriteLine("Input valid file name:");
            inputFileName = Console.ReadLine();

            while (!File.Exists(inputFileName + ".csv"))
            {
                Console.WriteLine("File does not exist, input valid file name!");
                inputFileName = Console.ReadLine();
                if (inputFileName == "q")
                {
                    return;
                }
            }
        }

        public static void ValidFilePathToWriteInput(out string inputFileName)
        {
            Console.WriteLine("Input valid file name:");
            inputFileName = Console.ReadLine();

            while (File.Exists(inputFileName + ".csv"))
            {
                Console.WriteLine("File exists already, give a new file name! Or press 'r' to rewrite.");
                string temporaryFilePath = inputFileName;
                inputFileName = Console.ReadLine();
                if (inputFileName == "q")
                {
                    return;
                }
                if (inputFileName == "r")
                {
                    inputFileName = temporaryFilePath;
                    return;
                }
            }
        }
    }
}