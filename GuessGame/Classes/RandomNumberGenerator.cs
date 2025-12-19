using GuessNumber.Interfaces;

namespace GuessNumber.Classes
{
    public class RandomNumberGenerator : INumberGenerator
    {
        private readonly Random _random = new();

        public int Generate(int min, int max)
        {
            return _random.Next(min, max + 1);
        }
    }
}
