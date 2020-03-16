using System;
using System.IO;
using System.Linq;

namespace DrillTrajectoryPlot
{
    public static class InputValidator
    {
        public static string ValidTrajectoryFilenameForSave()
        {
            Console.WriteLine("Input valid file name:");
            string trajectoryFilename = Console.ReadLine();

            while (File.Exists("Drill_Trajectory_Plot/datafile/" + trajectoryFilename + ".csv"))
            {
                Console.WriteLine("File exists already, give a new file name! Or press 'r' to rewrite.");
                string temporaryFilePath = trajectoryFilename;
                trajectoryFilename = Console.ReadLine();
                if (trajectoryFilename == "q")
                {
                    return trajectoryFilename;
                }
                if (trajectoryFilename == "r")
                {
                    trajectoryFilename = temporaryFilePath;
                    return trajectoryFilename;
                }
            }

            return trajectoryFilename;
        }

        public static string ReadTrajectoryFilename()
        {
            Console.WriteLine("Input valid file name:");
            string trajectoryFilename = Console.ReadLine();

            while (!File.Exists("Drill_Trajectory_Plot/datafile/" + trajectoryFilename + ".csv"))
            {
                Console.WriteLine("File does not exist, input valid file name!");
                trajectoryFilename = Console.ReadLine();
                if (trajectoryFilename == "q")
                {
                    return trajectoryFilename;
                }
            }

            return trajectoryFilename;
        }

        public static string ReadViewName()
        {
            Console.WriteLine("Input View to Plot: '1: Main', '2: Left', '3: Top'");
            string viewName = Console.ReadLine();
            string[] options = { "1", "2", "3" };

            while (!options.Contains(viewName))
            {
                Console.WriteLine("Invalid View input!");
                Console.WriteLine("Available Views: '1: Main', '2: Left', '3: Top'. (Press 'q' to quit)");
                viewName = Console.ReadLine();
                if (viewName == "q")
                {
                    return viewName;
                }
            }

            return viewName;
        }

        public static string ReadMagnification()
        {
            Console.WriteLine("Input magnification for data:");
            string magnification = Console.ReadLine();
            double result;

            while(!double.TryParse(magnification, out result))
            {
                Console.WriteLine("Magnification invalid! Retry. (Press 'q' to quit)");
                magnification = Console.ReadLine();
                if (magnification == "q")
                {
                    return magnification;
                }                
            }

            return magnification;
        }
    }
}