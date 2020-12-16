
namespace CanUAVs_Challenge
{
    
    //Container class for sensor data 
    //Makes handling the data significantly easier and more convenient
    public class SensorData
    {
        public string Id { get; set; }  
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public SensorData(string id, double lat , double longi)
        {
            Id = id;
            Longitude = longi;
            Latitude = lat;
        }

        public SensorData()
        {
            // need for json parsing
        }

        public override string ToString()
        {
            return Id  + Latitude.ToString() + Longitude.ToString();
        }
        
        
    }
}