using System;
using System.IO;
using System.Collections.Generic;

namespace CsharpTest
{
    public static class DrillTrajectoryDataFileOperation
    {
        public static int ReadDataFromCSVFile(ref PolyLineIn3D wellTrajectory, string fileName, string filePath = "Drill_Trajectory_Plot/datafile/")
        {
            char splitter = ',';
            try
            {
                using (StreamReader sr = new StreamReader(filePath + fileName + ".csv"))
                {
                    string line;
                    wellTrajectory = new PolyLineIn3D();
                    while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                    {
                        try
                        {
                            string[] coordinates = line.Split(splitter);
                            double x = double.Parse(coordinates[0]);
                            double y = double.Parse(coordinates[1]);
                            double z = double.Parse(coordinates[2]);
                            wellTrajectory.AddNodes(x, y, z);
                        }
                        catch (ArgumentException)  // Parse: coordinates are not double
                        {
                            return -2;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            return -1;
                        }
                    }
                }

                return 0;
            }
            catch (FileNotFoundException)
            {
                return 1;
            }
            catch (Exception ex)
            {
                return ex.GetHashCode();
            }
        }

        public static int SaveDataToCSVFile(PolyLineIn3D wellTrajectory, string fileName, string filePath = "Drill_Trajectory_Plot/datafile/")
        {
            try
            {
                if (wellTrajectory.PolyLineNodes.Count == 0)
                {
                    return -1;
                }

                using (StreamWriter sw = new StreamWriter(filePath + fileName + ".csv"))
                {

                    foreach (var wellTrajectoryPoint in wellTrajectory.PolyLineNodes)
                    {
                        sw.WriteLine(wellTrajectoryPoint.FormatForSave());
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return ex.GetHashCode();
            }
        }

        public static int SavePlotToTxtFile(List<List<char>> matrixOfPixels, string fileName, string viewName, string filePath = "Drill_Trajectory_Plot/datafile/")
        {
            try
            {
                if (matrixOfPixels.Count == 0)
                {
                    return -1;
                }

                using (StreamWriter sw = new StreamWriter(filePath + fileName + "-" + viewName +"-View.txt"))
                {
                    foreach (var row in matrixOfPixels)
                    {
                        sw.WriteLine(new string(row.ToArray()));
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return ex.GetHashCode();
            }
        }
    }
}