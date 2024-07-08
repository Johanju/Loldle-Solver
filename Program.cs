using System;
using System.Reflection;

namespace Loldle_Solver
{

    public class Program
    {
        static void Main(string[] args)
        {
            string path = @""; // Path of championdata.txt file
            List<Champion> championData = FileLoader.LoadAndProcessData(path);
        }
    }
}
