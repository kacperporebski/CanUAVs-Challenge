using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Xml.XPath;

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