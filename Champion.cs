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
        public List<string> rangeType = new List<string>();
        public List<string> Region = new List<string>();
        public int releaseYear;

        public Champion(string name, string gen, string[] pos, string[] species, string res, string[] rangeT, string[] reg, int releaseY)
        {
            Name = name;
            Gender = gen;
            Position = pos.ToList();
            Species = species.ToList();
            Resource = res;
            rangeType = rangeT.ToList();
            Region = reg.ToList();
            releaseYear = releaseY;
        }
        public override string ToString()
        {
            //return string.Format(@"Name: {0}
//Release Year: {1}", Name, releaseYear);
            return string.Format(@"Name: {0}", Name);
        }
    }
}
