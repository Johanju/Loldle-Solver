using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loldle_Solver
{
    public class Champion
    {
        public string Name;
        public string Gender;
        public List<string> Position = new List<string>();
        public List<string> Species = new List<string>();
        public string Resource;
        public string rangeType;
        public List<string> Region = new List<string>();
        public int releaseYear;

        public Champion(string name, string gen, List<string> pos, List<string> species, string res, string rangeT, List<string> reg, int releaseY)
        {
            Name = name;
            Gender = gen;
            Position = pos;
            Species = species;
            Resource = res;
            rangeType = rangeT;
            Region = reg;
            releaseYear = releaseY;
        }
    }
}
