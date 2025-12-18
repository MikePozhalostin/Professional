namespace GuessGame
{
    internal static class GameValidator
    {
        public static bool TryValidateNumber(string? strNumber, out int result)
        {
            if (int.TryParse(strNumber, out result) && !string.IsNullOrEmpty(strNumber)) return true;

            return false;
        }
    }
}
