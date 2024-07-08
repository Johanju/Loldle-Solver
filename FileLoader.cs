using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loldle_Solver
{
    static class FileLoader
    {
        public static List<string> LoadFile(string path)
        {
            // Put each line into a List so each champion is nicely sorted for processing
            List<string> output = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        output.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return output;
        }
        /*
        public static Champion[] LoadAndProcessData(string path)
        {
            List<string> Unprocessed = LoadFile(path); // Loading part
            Champion[] champData = new Champion[Unprocessed.Count]; 
            for (int i = 0; i < Unprocessed.Count; i++)
            {
                string[] cArr = Unprocessed[i].Split('#');
                // Only specific "Indexes" can have multiple values. Position, Species and Region | 2, 3, 6
                Champion champion = new Champion(cArr[0], cArr[1], cArr[2].Split(','), cArr[3].Split(','), 
                    cArr[4], cArr[5].Split(','), cArr[6].Split(','), Int32.Parse(cArr[7]));
                champData[i] = champion;
            }
            return champData;
        }
        */
        public static List<Champion> LoadAndProcessData(string path)
        {
            List<string> Unprocessed = LoadFile(path); // Loading part
            List<Champion> champData = new List<Champion>();
            for (int i = 0; i < Unprocessed.Count; i++)
            {
                string[] cArr = Unprocessed[i].Split('#');
                // Only specific "Indexes" can have multiple values. Position, Species and Region | 2, 3, 5, 6
                Champion champion = new Champion(
                    cArr[0], cArr[1], 
                    cArr[2].Split(','), cArr[3].Split(','),
                    cArr[4], cArr[5].Split(','), 
                    cArr[6].Split(','), Int32.Parse(cArr[7]));
                champData.Add(champion);
            }
            return champData;
        }
    }
}
