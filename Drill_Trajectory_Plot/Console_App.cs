using System;
using System.Collections.Generic;
using PlotTool;
using GeometricObject;


namespace DrillTrajectoryPlot
{
    public class ConsoleApp
    {
        private PolyLineIn3D drillTrajectory;
        private string dataFilename;
        public double Magnification
        {
            get; set;
        }

        public ConsoleApp()
        {
            drillTrajectory = new PolyLineIn3D();
            Magnification = 1;
        }

        public void ReadTrajectoryFromFile()
        {
            string fileName = InputValidator.ReadTrajectoryFilename();
            if (fileName == "q")
            {
                return;
            }

            dataFilename = fileName;

            Console.WriteLine("Trying to read data from file: {0}.csv", fileName);

            int readOperationResult = DataFileOperation.ReadDataFromCSVFile(ref drillTrajectory, fileName);

            switch (readOperationResult)
            {
                case 0:
                    Console.WriteLine("Reading database from file succeeded...");
                    break;
                case -1:
                    Console.WriteLine("Format error or lack of data in the database saved.");
                    break;
                case -2:
                    Console.WriteLine("Coordinates can not be converted to double value.");
                    break;
                case 1:
                    Console.WriteLine("Error: No such file exists.");
                    break;
                default:
                    Console.WriteLine("Reading operation failed...");
                    break;
            }

        }

        public void SaveTrajectoryToFile()
        {
            string fileName = InputValidator.ValidTrajectoryFilenameForSave();
            if (fileName == "q")
            {
                return;
            }

            Console.WriteLine("Trying to save data to file: {0}.csv", fileName);

            int saveOperationResult = DataFileOperation.SaveDataToCSVFile(drillTrajectory, fileName);

            switch (saveOperationResult)
            {
                case 0:
                    Console.WriteLine("Saving trajectory succeeded...");
                    break;
                case -1:
                    Console.WriteLine("No data point in the trajectory.");
                    break;
                default:
                    Console.WriteLine("Saving operation failed...");
                    break;
            }
        }

        public void SetMagnification()
        {
            string inputMagnification = InputValidator.ReadMagnification();
            if (inputMagnification == "q")
            {
                return;
            }

            Magnification = double.Parse(inputMagnification);
            Console.WriteLine("Magnification set to: {0}", Magnification);
        }

        public int PlotView(string fileName, string viewName, double magnification)
        {
            List<Point> projectionInPlane = drillTrajectory.GetProjectionInPlane(viewName);

            List<List<char>> matrixOfPixels = FigureTool.PlotPolyLineWithAnnotation(projectionInPlane, magnification);

            FigureTool.AddAxisNotationFoFigure(matrixOfPixels, viewName);

            int saveResult = DataFileOperation.SavePlotToTxtFile(matrixOfPixels, fileName, viewName);

            return saveResult;
        }

        public void plotViewToFile()
        {

            if(string.IsNullOrWhiteSpace(dataFilename))
            {
                Console.WriteLine("You didn't read trajectory data from file!");
                return;
            }

            string inputViewName = InputValidator.ReadViewName();

            Dictionary<string, string> viewNameDict = new Dictionary<string, string>();
            viewNameDict["1"] = "Main";
            viewNameDict["2"] = "Left";
            viewNameDict["3"] = "Top";
            viewNameDict["q"] = "q";

            string viewName = viewNameDict[inputViewName];

            if (viewName == "q")
            {
                return;
            }

            Console.WriteLine("Trying to plot view to file: {0}-{1}-View.txt", dataFilename, viewName);

            int plotResult = PlotView(dataFilename, viewName, Magnification);

            switch (plotResult)
            {
                case 0:
                    Console.WriteLine("Saving {0} View succeeded...", viewName);
                    break;
                case -1:
                    Console.WriteLine("Nothing to plot.");
                    break;
                default:
                    Console.WriteLine("Saving operation failed...");
                    break;
            }

        }

        public void AutoPlot()
        {
            string[] viewNames = { "Main", "Left", "Top" };

            string[] filenames = DataFileOperation.GetFilenamesToPlot();

            foreach (var filename in filenames)
            {
                DataFileOperation.ReadDataFromCSVFile(ref drillTrajectory, filename);
                foreach (var viewName in viewNames)
                {
                    Console.WriteLine("Trying to plot view to file: {0}-{1}-View.txt", filename, viewName);
                    int plotResult = PlotView(filename, viewName, Magnification);

                    switch (plotResult)
                    {
                        case 0:
                            Console.WriteLine("Saving {0} View succeeded...", viewName);
                            break;
                        case -1:
                            Console.WriteLine("Nothing to plot.");
                            break;
                        default:
                            Console.WriteLine("Saving operation failed...");
                            break;
                    }
                }
            }
        }

        public void Run()
        {
            while (true)
            {
                // Console.WriteLine();
                Console.WriteLine("\nChoose Module:");
                Console.WriteLine("1. Plot Trajectory in Different Views");
                Console.WriteLine("2. Save Trajectory to CSV file");
                Console.WriteLine("3. Read Trajectory from CSV file");
                Console.WriteLine("4. Set Magnification for data plot");
                Console.WriteLine("5. AutoPlot for data files.");
                Console.WriteLine("===============");

                string moduleSelected = Console.ReadLine();
                switch (moduleSelected)
                {
                    case "1":
                        plotViewToFile();
                        break;
                    case "2":
                        SaveTrajectoryToFile();
                        break;
                    case "3":
                        ReadTrajectoryFromFile();
                        break;
                    case "4":
                        SetMagnification();
                        break;
                    case "5":
                        AutoPlot();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}