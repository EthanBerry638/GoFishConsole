using System.Text;
using GoFish.HelperMethods;

namespace LeaderBoardManager
{
    public class LeaderBoards
    {
        private static string path = @"C:\Users\ethan\Desktop\Coding Projects\CSharpSelfMiniProjects\GoFishConsole\MenuManager\LeaderBoard.csv";

        public void WriteToLeaderBoard(LeaderBoardEntry leaderBoardEntry)
        {
            if (!File.Exists(path) || File.ReadAllLines(path).Length == 0)
            {
                File.WriteAllText(path, "Rank,Name,Score,Date" + Environment.NewLine);
            }

            DateTime dateTime = DateTime.Now;
            string entry = $"0,{leaderBoardEntry.Name},{leaderBoardEntry.Score},{dateTime}";
            File.AppendAllText(path, entry + Environment.NewLine);
        }

        private List<string> OrderLines()
{
    string[] lines = File.ReadAllLines(path);
    var parsedEntries = new List<(string OriginalLine, int Score)>();

    for (int i = 1; i < lines.Length; i++)
    {
        string[] parts = lines[i].Split(',');
        if (parts.Length >= 4 && int.TryParse(parts[2], out int score))
        {
            string name = parts[1];
            string date = parts[3];
            parsedEntries.Add(($"{name},{score},{date}", score));
        }
        else
        {
            Console.WriteLine($"Skipped malformed line: {lines[i]}");
        }
    }

    var sortedEntries = parsedEntries
        .OrderByDescending(entry => entry.Score)
        .Select((entry, index) => $"{index + 1},{entry.OriginalLine}")
        .ToList();

    return sortedEntries;
}
        public void WriteToFile()
        {
            List<string> sortedEntries = OrderLines();
            var withHeader = new List<string> { "Rank,Name,Score,Date" };
            withHeader.AddRange(sortedEntries);
            File.WriteAllLines(path, withHeader);
        }

        public void ReadFile()
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string cleanedLine = line.Replace(",", " ");
                Console.WriteLine(cleanedLine);
                Utils.Pause(300);
            }
            Console.WriteLine("\nPress the enter key to return to the main menu");
            Console.ReadLine();
        }
    }
}