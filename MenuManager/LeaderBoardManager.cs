using System.Text;

namespace LeaderBoardManager
{
    public class LeaderBoards
    {
        private static string path = @"C:\Users\ethan\Desktop\Coding Projects\CSharpSelfMiniProjects\GoFishConsole\MenuManager\LeaderBoard.csv";

        public void WriteToLeaderBoard(LeaderBoardEntry leaderBoardEntry)
        {
            DateTime dateTime = DateTime.Now;
            string entry = leaderBoardEntry.Name + "," + leaderBoardEntry.Score + "," + dateTime;
            File.AppendAllText(path, entry + Environment.NewLine);
            WriteToFile();
        }

        private List<string> OrderLines()
        {
            string[] lines = File.ReadAllLines(path);
            var parsedEntries = new List<(string OriginalLine, int Score)>();

            foreach (string line in lines)
            {
                int firstIndex = line.IndexOf(",");
                int secondIndex = line.IndexOf(",", firstIndex + 1);

                if (firstIndex != -1 && secondIndex != -1 && secondIndex > firstIndex)
                {
                    string scoreFromFile = line.Substring(firstIndex + 1, secondIndex - firstIndex - 1);
                    if (int.TryParse(scoreFromFile, out int score))
                    {
                        parsedEntries.Add((line, score));
                    }
                }
            }

            var sortedEntries = parsedEntries
        .OrderByDescending(entry => entry.Score)
        .Select((entry, index) => $"{index + 1}. {entry.OriginalLine}")
        .ToList();

            return sortedEntries;
        }

        private void WriteToFile()
        {
            List<string> sortedEntries = OrderLines();
            var withHeader = new List<string> { "Rank,Name,Score,Date" };

            withHeader.AddRange(sortedEntries.Select((line, index) =>
            {
                // Remove any existing prefix and split the original line
                string[] parts = line.Split(',');
                return $"{index + 1},{parts[0]},{parts[1]},{parts[2]}";
            }));

            File.WriteAllLines(path, withHeader);
        }
    }
}