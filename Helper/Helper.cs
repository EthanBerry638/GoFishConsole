namespace GoFish.HelperMethods
{
    public static class Utils
    {
        public static void Pause(int ms) => Thread.Sleep(ms);
        public static string StrikeThrough(string text)
        {
            return string.Concat(text.Select(c => $"{c}\u0336"));
        }
    }
}