using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Web.Script.Serialization;


namespace CanUAVs_Challenge
{
    //FileParser for this challenge
    public class MyFileParser
    {
        //Depending on the file provided this method decides which type of parsing to do
        public List<SensorData> parseFile(string filepath)
        {
            if (filepath.Contains(".csv"))
              return  populateCSV(@filepath);       //if its a csv use the CSV method
            else if (filepath.Contains(".json"))
               return populateJSON(@filepath);      //if its a json use the JSON method
            else
            {
                System.Diagnostics.Debug.WriteLine("wrong path provided");
                return null;
            }
        }

        //Parses a CSV file and returns a list of SensorData which holds the id , latitude and longitude.
        private List<SensorData> populateCSV(string path)
        {
            var sensorDataList = new List<SensorData>();
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.SetDelimiters(",");
                csvParser.ReadLine(); //skip first line
                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    sensorDataList.Add(new SensorData(fields[0], Convert.ToDouble(fields[1]), Convert.ToDouble(fields[2])));
                    
                }
                
            }

            return sensorDataList;

        }

        //Parses a JSON file and returns a list of SensorData which holds the id , latitude and longitude.
        private List<SensorData> populateJSON(string path)
        {
            var sensorDataList = new List<SensorData>();
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<List<SensorData>>(new StreamReader(path).ReadToEnd());
           
        }

        //This method asks the user to input a file path and outputs the passed in strings to a file called "output.txt" in the selected location.
        public void outputToFile(List<string> output)
        {
            Console.Write("Enter output file path: ");
            String path = Console.ReadLine();
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@path + "output.txt"))
            {
                foreach (string line in output)
                {
                    file.WriteLine(line);
                }
            }

        }


    }
    
    
}