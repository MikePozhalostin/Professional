using GuessGame.Interfaces;

namespace GuessGame
{
    internal class GuessGame : IGame
    {
        public int NumberOfAttempts { get; set; } = 1;
        public int FromNumber { get; set; } = 0;
        public int ToNumber { get; set; } = 10;

        public void Play()
        {
            Console.WriteLine("Игра началась. Для выхода введите q");
            var generatedNumber = Generator.GenerateNumber(FromNumber, ToNumber);

            var count = 0;

            var success = false;
            while (count == NumberOfAttempts)
            {
                var enteredString = Console.ReadLine();

                if (enteredString == "q")
                {
                    Console.WriteLine("Игра закончилась.");
                    break;
                }

                if (GameValidator.TryValidateNumber(enteredString, out var number))
                {
                    if (number == generatedNumber)
                    {
                        Console.WriteLine($"Вы угадали. Загаданное число: {generatedNumber}");
                        success = true;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы не угадали. Попробуйте снова");

                    if (Comparer.Compare(generatedNumber, number))
                    {
                        Console.WriteLine("Ваше число меньше загаданного");
                    }
                    else
                    {
                        Console.WriteLine("Ваше число больше загаданного");
                    }
                    count++;
                }
            }

            if (!success)
            {
               Console.WriteLine($"Загаданное число {generatedNumber}");
            }
        }
    }
}
