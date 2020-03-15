using System;
using System.IO;
using System.Linq;

namespace CsharpTest
{
    public static class DrillTrajectoryAppInputValidator
    {
        public static void ValidFileNameForSave(out string inputFileName)
        {
            Console.WriteLine("Input valid file name:");
            inputFileName = Console.ReadLine();

            while (File.Exists("Drill_Trajectory_Plot/datafile/" + inputFileName + ".csv"))
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

        public static void ValidFileNameForRead(out string inputFileName)
        {
            Console.WriteLine("Input valid file name:");
            inputFileName = Console.ReadLine();

            while (!File.Exists("Drill_Trajectory_Plot/datafile/" + inputFileName + ".csv"))
            {
                Console.WriteLine("File does not exist, input valid file name!");
                inputFileName = Console.ReadLine();
                if (inputFileName == "q")
                {
                    return;
                }
            }
        }

        public static void ValidViewNameInput(out string inputViewName)
        {
            Console.WriteLine("Input View to Plot: '1: Main', '2: Left', '3: Top'");
            inputViewName = Console.ReadLine();
            string[] options = { "1", "2", "3" };

            while (!options.Contains(inputViewName))
            {
                Console.WriteLine("Invalid View input!");
                Console.WriteLine("Available Views: '1: Main', '2: Left', '3: Top'. (Press 'q' to quit)");
                inputViewName = Console.ReadLine();
                if (inputViewName == "q")
                {
                    return;
                }
            }
        }

        public static void ValidMagnificationInput(out string inputMagnification)
        {
            Console.WriteLine("Input magnification for data:");
            inputMagnification = Console.ReadLine();
            double result;

            while(!double.TryParse(inputMagnification, out result))
            {
                Console.WriteLine("Magnification invalid! Retry. (Press 'q' to quit)");
                inputMagnification = Console.ReadLine();
                if (inputMagnification == "q")
                {
                    return;
                }                
            }
        }
    }
}