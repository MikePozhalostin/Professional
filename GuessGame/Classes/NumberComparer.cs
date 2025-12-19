using GuessNumber.Interfaces;

namespace GuessNumber.Classes
{
    public class NumberComparer : INumberComparer
    {
        public CompareResult Compare(int secretNumber, int userNumber)
        {
            if (userNumber == secretNumber) return CompareResult.Equal;
            return userNumber < secretNumber ? CompareResult.Less : CompareResult.Greater;
        }
    }
}
