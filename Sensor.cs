using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Web.Script.Serialization;


namespace CanUAVs_Challenge
{
    internal class Sensor
    {
        public List<SensorData> sensorDataList { get; set; }

        public Sensor(string filepath)
        {
            sensorDataList = new List<SensorData>();
            if (filepath.Contains(".csv"))
                populateCSV(filepath);
            else if (filepath.Contains(".json"))
                populateJSON(filepath);
            else
            {
                System.Diagnostics.Debug.WriteLine("wrong path provided");
            }

        }

        private void populateCSV(string path)
        {
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
        }

        private void populateJSON(string path)
        {
            var serializer = new JavaScriptSerializer();
            sensorDataList = serializer.Deserialize<List<SensorData>>(new StreamReader(path).ReadToEnd());
           
        }

        public void print()
        {
            foreach (var x in sensorDataList)
            {
                Console.Write(x + "\n");
            }
        }


    }
    
    
}