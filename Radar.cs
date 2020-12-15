using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Xml.XPath;

namespace CanUAVs_Challenge
{
    public class Radar
    {
        private Sensor csvSensor;
        private Sensor jsonSensor;
        private List<String> result;
        
        public Radar(string csv, string json)
        {
            csvSensor = new Sensor(csv);
            jsonSensor = new Sensor(json);
            result = new List<string>();
            compareSensors();
            outputToFile();

        }

        void outputToFile()
        {
            Console.Write("Enter output file path: ");
            String path = Console.ReadLine();
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@path + "output.txt"))
            {
                foreach (string line in result)
                {
                   file.WriteLine(line);
                }
            }

        }


        void compareSensors()
       {
        List<String> sameEntities = getSameEntities(csvSensor.sensorDataList, jsonSensor.sensorDataList);
        List<String> missedSensorsList = getNonMatchingEntities(csvSensor.sensorDataList, jsonSensor.sensorDataList, sameEntities);
        result = sameEntities;
        result.AddRange(missedSensorsList);
            
       }

        List<String> getNonMatchingEntities(List<SensorData> csv, List<SensorData> json, List<String> matchingList)
       {
           List<String> result = new List<string>();

           foreach (var VARIABLE in csv)
           {
               for (int i = 0; i < matchingList.Count; i++)
               {
                   if (VARIABLE.Id == matchingList[i].Split(':')[0])
                       break;
                   if (i == matchingList.Count-1)
                   {
                       result.Add(VARIABLE.Id + ":-1"); 
                   }
               }
               
           }

           foreach (var VARIABLE in json)
           {
               for (int i = 0; i < matchingList.Count; i++)
               {
                   if (VARIABLE.Id == matchingList[i].Split(':')[1])
                       break;
                   if (i == matchingList.Count-1)
                   {
                       result.Add("-1:" + VARIABLE.Id );
                   }
               }

           }



           return result;
       }

        List<String> getSameEntities(List<SensorData> csv , List<SensorData> json)
       {
           List<String> result = new List<string>();

           foreach (var x in json)
           {
               foreach (var y in csv)
               { 
                   if (calcDistance(x.Latitude, x.Longitude , y.Latitude, y.Longitude) < 100 )
                       result.Add(y.Id + ":" + x.Id);
                   
               }
               
               
           }
           
           return result;
           
       }

       double calcDistance(double lat1, double longi1, double lat2, double longi2)
       {
           double earthRadius = 6371;

            double dlat = (lat1 - lat2) * Math.PI / 180;
           double dlong = (longi1 - longi2) * Math.PI / 180;

           double sinLat = Math.Sin(dlat / 2);
           double sinLong = Math.Sin(dlong / 2);

           double a = Math.Pow(sinLat, 2) + Math.Pow(sinLong, 2)
               * Math.Cos(lat1 * Math.PI / 180)
               * Math.Cos(lat2 * Math.PI / 180);

           return earthRadius * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }
       
    }
}