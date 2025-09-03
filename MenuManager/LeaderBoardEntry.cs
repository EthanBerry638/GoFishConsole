namespace LeaderBoardManager
{
    public struct LeaderBoardEntry
    {
        public string Name { get; }
        public int Score { get; }

        public LeaderBoardEntry(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return $"{Name},{Score}";
        }
    }
}