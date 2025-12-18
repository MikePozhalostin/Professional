namespace GuessGame
{
    internal static class Generator
    {
        public static int GenerateNumber(int from, int to)
        {
            return new Random().Next(from, to);
        }
    }
}
