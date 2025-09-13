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
            File.WriteAllText(path, entry);
        }
    }
}