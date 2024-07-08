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
        public bool gameOver;

        public Game(List<Champion> champions, Random rng)
        {
            gameAnswer = champions[rng.Next(champions.Count)];
            gameOver = false;
        }
        public (Trait[], int[]) CheckGuess(Champion champion)
        {
            // Calculates "correctness" of every trait and returns a trait and int correctness array.
            // The trait array will probably be removed because it only returns an unchanged trait array from the guessed champion.
            if (champion.Name == gameAnswer.Name)
            {
                gameOver = true;
                return ([], []);
            }
            Trait[] traits = champion.Traits;
            int[] correctness = [
                -5,
                Compare(gameAnswer.Gender, champion.Gender),
                Compare(gameAnswer.Position, champion.Position),
                Compare(gameAnswer.Species, champion.Species),
                Compare(gameAnswer.Resource, champion.Resource),
                Compare(gameAnswer.rangeType, champion.rangeType),
                Compare(gameAnswer.Region, champion.Region),
                Compare(champion.releaseYear)];
            return (traits, correctness);
        }

        private  int Compare(string type1, string type2)
        {
            return type1 == type2 ? 1 : -1;
        }

        private  int Compare(List<string> list1, List<string> list2)
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

        public int Compare(int releaseYear)
        {
            if (releaseYear < gameAnswer.releaseYear)
            {
                return 1;
            }
            else if (releaseYear > gameAnswer.releaseYear)
            {
                return -1;
            }
            return 0;
        }

        public void Reset(List<Champion> champions, Random rng)
        {
            gameAnswer = champions[rng.Next(champions.Count)];
            gameOver = false;
        }
    }
}
