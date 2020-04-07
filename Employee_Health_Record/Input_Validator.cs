using System;
using System.IO;
using System.Linq;

namespace EmployeeHealthRecord
{
    public delegate bool InputValidator(string input);

    public class ConsoleInputValidator
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

    public static class WFAPPInputValidator
    {
        public static bool IsValidNewGinNumber(string ginNumber, ref EmployeeDatabase employeeDatabase)
        {
            return IsValidNotExistedGinNumber(ginNumber, ref employeeDatabase) && IsValidGinNumberType(ginNumber);
        }

        public static bool IsValidNotExistedGinNumber(string ginNumber, ref EmployeeDatabase employeeDatabase)
        {
            return !employeeDatabase.HasEmployee(ginNumber);
        }

        public static bool IsValidExistedGinNumber(string ginNumber, ref EmployeeDatabase employeeDatabase)
        {
            return employeeDatabase.HasEmployee(ginNumber);
        }

        public static bool IsValidGinNumberType(string ginNumber)
        {
            return Int32.TryParse(ginNumber, out _);
        }

        public static bool IsValidNewName(string name, ref EmployeeDatabase employeeDatabase)
        {
            return true;
        }

        public static bool IsValidExistedName(string name, ref EmployeeDatabase employeeDatabase)
        {
            return true;
        }

        public static bool IsValidBodyTemperatureType(string bodyTemperature)
        {
            double result;
            if (double.TryParse(bodyTemperature, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidBodyTemperatureValue(string bodyTemperature)
        {
            double result;
            double.TryParse(bodyTemperature, out result);
            if (result >= 35 && result <= 43)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidBodyTemperature(string bodyTemperature)
        {
            return IsValidBodyTemperatureType(bodyTemperature) && IsValidBodyTemperatureValue(bodyTemperature);
        }

        public static bool IsValidCheckDate(DateTime checkDate)
        {
            return (checkDate.Date <= DateTime.Today);
        }

        //public static bool IsValidComboBoxInput(string input)
        //{

        //    string[] options = { "yes", "y", "Y", "no", "n", "N" };

        //    return options.Contains(input.ToLower());
        //}

        public static bool IsValidHasHubeiTravelHistoryChoice(string hasHubeiTravelHistoryChoice)
        {
            string[] options = { "yes", "y", "Y", "no", "n", "N" };

            return options.Contains(hasHubeiTravelHistoryChoice.ToLower());
        }

        public static bool IsValidHasSymptomsChoice(string hasSymptomsChoice)
        {
            string[] options = { "yes", "y", "Y", "no", "n", "N" };

            return options.Contains(hasSymptomsChoice.ToLower());
        }
    }

}