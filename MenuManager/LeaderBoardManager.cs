using System.Text;

namespace LeaderBoardManager
{
    public class LeaderBoards
    {
        private static string path = @"C:\Users\ethan\Desktop\Coding Projects\CSharpSelfMiniProjects\GoFishConsole\MenuManager\LeaderBoard.csv";
        public string[] lines = File.ReadAllLines(path);

        public void WriteToLeaderBoard(LeaderBoardEntry leaderBoardEntry)
        {
            DateTime dateTime = DateTime.Now;
            string entry = leaderBoardEntry.Name + "/" + leaderBoardEntry.Score + "/" + dateTime;
            File.AppendAllText(path, entry);
        }

        private void OrderLines()
        {
            foreach (string line in lines)
            {
                int firstIndex = line.IndexOf("/");
                int secondIndex = line.IndexOf("/", firstIndex + 1);

                if (firstIndex != -1 && secondIndex != -1 && secondIndex > firstIndex)
                {
                    string scoreFromFile = line.Substring(firstIndex + 1, secondIndex - firstIndex - 1);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}