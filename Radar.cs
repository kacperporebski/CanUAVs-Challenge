
using System.Collections.Generic;


namespace CanUAVs_Challenge
{
    //Container class for the Radar which holds and isolates the two different sensors.
    public class Radar
    {
        public List<SensorData> csvSensor { get; set; }
        public List<SensorData> jsonSensor { get; set; }
        
        public Radar(List<SensorData> csv, List<SensorData> json)
        {
            csvSensor = csv;
            jsonSensor = json;
            
        }


    }
}