using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Loldle_Solver
{
    public class Champion
    {
        public string Name
        {
            get { return (string)Traits[0].Value; }
            set { Traits[0].Value = value; }
        }
        public string Gender
        {
            get { return (string)Traits[1].Value; }
            set { Traits[1].Value = value; }
        }
        public List<string> Position
        {
            get { return (List<string>)Traits[2].Value; }
            set { Traits[2].Value = value; }
        }

        public List<string> Species
        {
            get { return (List<string>)Traits[3].Value; }
            set { Traits[3].Value = value; }
        }
        public string Resource
        {
            get { return (string)Traits[4].Value; }
            set { Traits[4].Value = value; }
        }
        public List<string> rangeType
        {
            get { return (List<string>)Traits[5].Value; }
            set { Traits[5].Value = value; }
        }
        public List<string> Region
        {
            get { return (List<string>)Traits[6].Value; }
            set { Traits[6].Value = value; }
        }
        public int releaseYear
        {
            get { return (int)Traits[7].Value; }
            set { Traits[7].Value = value; }
        }

        public Trait[] Traits;

        public Dictionary<int, string> traitMap = new Dictionary<int, string>() 
        {
            {0, "Name" },
            {1, "Gender" },
            {2, "Position" },
            {3, "Species" },
            {4, "Resource" },
            {5, "Range Type" },
            {6, "Region" },
            {7, "Release Year" },
        };


        public Champion(string name, string gen, string[] pos, string[] species, string res, string[] rangeT, string[] reg, int releaseY)
        {

            Traits = [new Trait(name, 0), new Trait(gen, 0), 
                new Trait(pos.ToList(), 1), new Trait(species.ToList(), 1),
                new Trait(res, 0), new Trait(rangeT.ToList(), 1),
                new Trait(reg.ToList(), 1), new Trait(releaseY, 2)];
            /*
            Name = name;
            Gender = gen;
            Position = pos.ToList();
            Species = species.ToList();
            Resource = res;
            rangeType = rangeT.ToList();
            Region = reg.ToList();
            releaseYear = releaseY;
            */
        }   
        public override string ToString()
        {
            string tempS = "";
            for (int i = 0; i < Traits.Length - 1; i++)
            {
                if (Traits[i].Value is List<string>)
                {
                    tempS += $"{traitMap[i]}: {listToString((List<string>)Traits[i].Value)}\n";
                }
                else
                {
                    tempS += $"{traitMap[i]}: {Traits[i].Value}\n";
                }
            }
            tempS += $"{traitMap[traitMap.Count - 1]}: {Traits[^1].Value}\n";
            return tempS;
        }   

        public string listToString(List<string> strings)
        {
            string tempS = "[";
            for(int i = 0;i < strings.Count - 1; i++)
            {
                tempS += $"{strings[i]}, ";
            }
            tempS += $"{strings[^1]}]";
            return tempS;
        }
    }
}
    