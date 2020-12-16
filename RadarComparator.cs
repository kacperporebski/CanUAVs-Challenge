using System;
using System.Collections.Generic;

namespace CanUAVs_Challenge
{
    //This class is responsible for calculating the distance between each sensor points and appropriately deciding if both the sensors picked up the object.
    public class RadarComparator
    {
        public List<string> result { get; set; }

        //Using the container Radar class with data for both sensors.
        public RadarComparator()
        {
            result = new List<string>();
        }


        public void compareSensors(Radar radar)
        {
            List<String> sameEntities = getSameEntities(radar.csvSensor, radar.jsonSensor);         //Find the data that corresponds to hits for both sensors
            List<String> missedSensorsList = getNonMatchingEntities(radar.csvSensor, radar.jsonSensor, sameEntities);       //Find the data that only corresponds to hits for one sensor
            result = sameEntities;
            result.AddRange(missedSensorsList);         //combined the above results

        }


        //This function finds the sensor data that corresponds to only one sensor detecting the object.

       private List<string> getSameEntities(List<SensorData> csv, List<SensorData> json)
        {
            List<string> result = new List<string>();

            foreach (var x in json)
            {
                foreach (var y in csv)
                {
                    if (calcDistance(x.Latitude, x.Longitude, y.Latitude, y.Longitude) < 100)
                        result.Add(y.Id + ":" + x.Id);

                }
            }
            return result;
        }


        //This function finds the sensor data that corresponds to only one sensor detecting the object.
        private List<String> getNonMatchingEntities(List<SensorData> csv, List<SensorData> json, List<String> matchingList)
        {
            List<String> result = new List<string>();

            foreach (var sensorData in csv)
            {
                for (int i = 0; i < matchingList.Count; i++)
                {
                    if (sensorData.Id == matchingList[i].Split(':')[0])
                        break;
                    if (i == matchingList.Count - 1)
                    {
                        result.Add(sensorData.Id + ":-1");
                    }
                }

            }

            foreach (var sensorData in json)
            {
                for (int i = 0; i < matchingList.Count; i++)
                {
                    if (sensorData.Id == matchingList[i].Split(':')[1])
                        break;
                    if (i == matchingList.Count - 1)
                    {
                        result.Add("-1:" + sensorData.Id);
                    }
                }
            }
            return result;
        }

        
        //This function is used to calculate the distance in METERS between two sets of co-ordinates
         private double calcDistance(double lat1, double longi1, double lat2, double longi2)
        {
            double earthRadius = 6371000;  

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
