using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace CanUAVs_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Radar challengeRadar = new Radar( @args[0], @args[1]);
            //Radar challengeRadar = new Radar(@"X:\input.csv", @"X:\input.json");
            //Radar challengeRadar = new Radar(@"X:\problem3.csv", @"X:\problem3.json");
        }
    }
}
