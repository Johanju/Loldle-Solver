using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loldle_Solver
{
    public class Game
    {
        public Champion gameAnswer;
        public void GetRandomChampion(Champion[] champions, Random rng)
        {
            gameAnswer = champions[rng.Next(champions.Length)];
        }

        public int[] CheckGuess(Champion champion)
        {
            if (gameAnswer == null) 
            {
                Console.WriteLine("There is no champion hiding.");
                return []; 
            }
            int[] verdict = new int[7] {
                CompareStrings(gameAnswer.Gender, champion.Gender),
                CompareLists(gameAnswer.Position, champion.Position),
                CompareLists(gameAnswer.Species, champion.Species),
                CompareStrings(gameAnswer.Resource, champion.Resource),
                CompareLists(gameAnswer.rangeType, champion.rangeType),
                CompareLists(gameAnswer.Region, champion.Region),
                CompareYears(champion.releaseYear)};
            return verdict;
        }

        private  int CompareStrings(string type1, string type2)
        {
            return type1 == type2 ? 1 : -1;
        }

        private  int CompareLists(List<string> list1, List<string> list2)
        {
            if (list1.SequenceEqual(list2))
            {
                return 1;
            }
            else if (list1.Intersect(list2).Any())
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        private int CompareYears(int releaseYear)
        {
            if (releaseYear < gameAnswer.releaseYear)
            {
                return -1;
            }
            else if (releaseYear > gameAnswer.releaseYear)
            {
                return 1;
            }
            return 0;
        }
    }
}
