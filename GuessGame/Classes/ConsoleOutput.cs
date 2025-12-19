using GuessNumber.Interfaces;

namespace GuessNumber.Classes
{
    public class ConsoleOutput : IUserOutput
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
