namespace Loldle_Solver
{
    enum Type
    {
        Gender
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @""; // Path of championdata.txt file | GLÖM INTE ATT TA BORT PATHEN
            Champion[] championData = FileLoader.LoadAndProcessData(path);
            Random rng = new Random();
            Game game = new Game();
            game.GetRandomChampion(championData, rng);
            Console.WriteLine(game.gameAnswer);
            for (int i = 0; i < 20; i++)
            {
                Champion champ = championData[rng.Next(championData.Length)];
                int[] verdict = game.CheckGuess(champ);
                Console.WriteLine(string.Format("Comparing {0} with {1}", champ.Name, game.gameAnswer.Name));

                Console.WriteLine(string.Format("Gender | Correctness: {0}", verdict[0]));
                Console.WriteLine(string.Format("Position | Correctness: {0}", verdict[1]));
                Console.WriteLine(string.Format("Species | Correctness: {0}", verdict[2]));
                Console.WriteLine(string.Format("Resource | Correctness: {0}", verdict[3]));
                Console.WriteLine(string.Format("RangeType | Correctness: {0}", verdict[4]));
                Console.WriteLine(string.Format("Region | Correctness: {0}", verdict[5]));
                Console.WriteLine(string.Format("Release Year | Correctness: {0}", verdict[6]));
                Console.WriteLine("-----------------------------------------");
            }
        }
    }
}
