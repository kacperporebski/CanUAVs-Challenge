
using System.Collections.Generic;


namespace CanUAVs_Challenge
{
    //Container class for the Radar which holds and isolates the two different sensors.
    //Might seem kind of pointless now but if theres a situation with more than one radar 
    //or with more than two sensors a container class like this can prove easier to work with.
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