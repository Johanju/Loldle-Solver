using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loldle_Solver
{
    public class Trait
    {
        public object Value;
        public int Id;

        public Trait(object value, int id)
        {
            Value = value;
            Id = id;
        }

        public override string ToString()
        {
            string tempS = "";
            switch (Id)
            {
                case 0:
                    tempS = $"[{(string)Value}]";
                    break;
                case 1:
                    tempS = listToString((List<string>)Value);
                    break;
                case 2:
                    tempS = $"[{(int)Value}]";
                    break;
            }
            return tempS;
        }
        public string listToString(List<string> strings)
        {
            string tempS = "[";
            for (int i = 0; i < strings.Count - 1; i++)
            {
                tempS += $"{strings[i]}, ";
            }
            tempS += $"{strings[^1]}]";
            return tempS;
        }

        public void AddValues(List<string> strings)
        {
            if (Id != 1)
            {
                return;
            }
            List<string> list = (List<string>)Value;
            for (int i = 0;i < strings.Count - 1; i++)
            {
                if (!list.Contains(strings[i]))
                {
                    list.Add(strings[i]);
                }
            }
            Value = list;
        }
    }
}
