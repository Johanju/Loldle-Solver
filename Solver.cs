using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Loldle_Solver
{
    public class Solver
    {
        public int[] SortedByRelease; // Not used
        public List<Champion> Guesses = new List<Champion>();
        private List<Champion> remainChamps = new List<Champion>();
        private Trait[] traits;
        private int[] correctness;
        private Random rng = new Random();

        public Solver(List<Champion> champList)     
        {
            remainChamps = new List<Champion>(champList);
        }       

        private bool CompareTrait(string type1, string type2, int correctness)
        {
            switch (correctness)
            {
                case 1:
                    if (type1 == type2)
                    {
                        return true;
                    }
                    return false;

                case -1:
                    if (type1 != type2)
                    {
                        return true;
                    }
                    return false;
            }
            return false;
        }

        private bool CompareTrait(List<string> list1, List<string> list2, int correctness)
        {
            switch (correctness)
            {
                case -1:
                    if (!list1.SequenceEqual(list2))
                    {
                        return true;
                    }
                    return false;
                case 0:
                    if (list1.Intersect(list2).Any())
                    {
                        return true;
                    }
                    return false;
                case 1:
                    if (list1.SequenceEqual(list2))
                    {
                        return true;
                    }
                    return false;
            }
            return false;
        }

        private bool CompareTrait(int year1, int year2, int correctness)
        {
            switch (correctness)
            {
                case -1:
                    if (year1 < year2)
                    {
                        return true;
                    }
                    return false;
                case 0:
                    if (year1 == year2)
                    {
                        return true;
                    }
                    return false;
                case 1:
                    if (year1 > year2)
                    {
                        return true;
                    }
                    return false;
            }
            return false;
        }

        public bool CompareTrait(Trait trait1, Trait trait2, int correctness)
        {
            // 0 string | 1 List<string> | 2 int
            switch (trait1.Id)
            {
                case 0:
                    return CompareTrait((string)trait1.Value, (string)trait2.Value, correctness);
                case 1:
                    return CompareTrait((List<string>)trait1.Value, (List<string>)trait2.Value, correctness);
                case 2:
                    return CompareTrait((int)trait1.Value, (int)trait2.Value, correctness);
            }
            return false;
        }

        private void searchValidChampions()
        {
            Champion tempChamp;
            bool traitResult;
            for (int i = remainChamps.Count - 1; i >= 0; i--)
            {
                tempChamp = remainChamps[i];
                for (int t = 1; t < tempChamp.Traits.Length; t++)
                {
                    traitResult = CompareTrait(tempChamp.Traits[t], traits[t], correctness[t]);
                    if (!traitResult)
                    {
                        remainChamps.RemoveAt(i);
                        break;
                    }
                }
            }
        } // Goes through every champion remaining and removes them if any trait do not match.

        private void updateTraitCorrect(Trait[] t, int[] correct)
        {
            for (int i = 1;i < t.Length - 1; i++)
            {
                if (correct[i] > correctness[i])
                {
                    correctness[i] = correct[i];
                    traits[i] = t[i];
                }
                else if (correct[i] == correctness[i])
                {
                    if (t[i].Id == 1)
                    {
                        traits[i].AddValues((List<string>)t[i].Value);
                    }
                }
            }
            if (correct[^1] == 0)
            {
                traits[^1] = t[^1];
                correctness[^1] = correct[^1];
            }
        } // Goes through how correct each trait is and updates the list accordingly

        public void Think(Game game)
        {
            // Guesses a champion, updates trait list and searches for valid champions.
            if (Guesses.Count == 0)
            {
                (traits, correctness) = game.CheckGuess(Guess());
                if (game.gameOver)
                {
                    Won();
                    return;
                }
                searchValidChampions();
            }
            Trait[] t;
            int[] correct;
            for (int i = 1; i < 167; i++) // "Should" be done in less than 167 iterations
            {
                (t, correct) = game.CheckGuess(Guess());
                if (game.gameOver)
                {
                    Won();
                    break;
                }
                updateTraitCorrect(t, correct);
                searchValidChampions();
            }
        }

        public Champion Guess()
        {
            int index = rng.Next(remainChamps.Count);
            Champion guess = remainChamps[index];
            Guesses.Add(guess);
            remainChamps.RemoveAt(index);
            return guess;
        }
        public void Reset()
        {
            for (int i = Guesses.Count - 1; i >= 0; i--)
            {
                remainChamps.Add(Guesses[i]);
            }
        } // Reset function for solver. Currently not used

        public void Won() // Debug Print
        {
            //Console.WriteLine("Champion was " + Guesses[^1].Name);
            return;
        }
    }
}
