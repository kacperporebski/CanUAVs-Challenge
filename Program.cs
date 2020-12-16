
namespace CanUAVs_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFileParser myFileParser = new MyFileParser();     //instantiate my file parser
            Radar challengeRadar = new Radar(myFileParser.parseFile(args[0]), myFileParser.parseFile(args[1]));     //parse files and generate the appropriate sensors in the radar.
            RadarComparator resultGenerator = new RadarComparator();      //Compare the data and generate the requested result of <ID sensor 1 : ID sensor 2>
            resultGenerator.compareSensors(challengeRadar);
            myFileParser.outputToFile(resultGenerator.result);              // Output the result to a  text file
           
        }
    }
}
