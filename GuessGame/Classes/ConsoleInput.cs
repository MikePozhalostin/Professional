using GuessNumber.Interfaces;

namespace GuessNumber.Classes
{
    public class ConsoleInput : IUserInput
    {
        public int ReadNumber()
        {
            do
            {
                var res = int.TryParse(Console.ReadLine(), out var number);
                if (!res)
                {
                    Console.Write("Введите корректное число: ");
                }
                else
                {
                    return number;
                }
            }
            while (true);
        }
    }
}
