using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestDateG
{
    public class RecordRandomGenerator
    {
        public List<string> ReadNameFromFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                List<string> names = new List<string>();
                string name;
                while ((name = sr.ReadLine()) != null)
                {
                    names.Add(name);
                }

                return names;
            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                string header = "GinNumber,Date,Name,BodyTemperature,HasHubeiTravelHistory,HasSymptoms,Notes,EditHistory";
                sw.WriteLine(header);

                var ran = new Random();
                List<string> names = ReadNameFromFile("../../../RecordsGenerated/names.txt");

                for (int gin = 1; gin <= 100; gin++)
                {
                    string ginNumber = gin.ToString();
                    string name = names[ran.Next(100)];
                    for (int numOfRecordPerPerson = 0; numOfRecordPerPerson < 100; numOfRecordPerPerson++)
                    {
                        int year = ran.Next(2019, 2021);
                        int month = ran.Next(1, 13);
                        int day = ran.Next(1, 29);
                        if(year == 2020 && month >= 5)
                        {
                            continue;
                        }
                        string checkDate = year + "/" + month + "/" + day;
                        string bodyTemperature = Math.Round(ran.NextDouble() * (ran.NextDouble() > 0.8 ? 7 : 2) + 35, 1).ToString();
                        string hasHubeiTravelHistory = ran.NextDouble() > 0.9 ? "TRUE" : "FALSE";
                        string hasSymptoms = ran.NextDouble() > 0.9 ? "TRUE" : "FALSE";

                        string[] allInfo = {ginNumber,
                                            checkDate,
                                            name,
                                            bodyTemperature,
                                            hasHubeiTravelHistory,
                                            hasSymptoms,
                                            DateTime.Now.ToString(),
                                            //string.Join("|", EditTimeHistory)
                        };
                        string seperator = ",";
                        sw.WriteLine(string.Join(seperator, allInfo));
                    }

                }
            }
        }

        public void Run()
        {
            SaveToFile("../../../RecordsGenerated/records-large.csv");
        }

    }
}
