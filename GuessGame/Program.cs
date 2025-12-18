namespace GuessGame
{
    internal class Program
    {
        const string UncorrectString = "Введено некорректное число";
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Сыграем в угадай число!");

            Console.WriteLine("Введи число, с которого хочешь, чтобы игра загадала число. По умолчанию 0.");
            var numberFromConsole = Console.ReadLine();
            var validation = GameValidator.TryValidateNumber(!string.IsNullOrEmpty(numberFromConsole) ?numberFromConsole : "0", out var numberFrom);

            if (!validation)
            {
                Console.WriteLine(UncorrectString);
                return;
            }

            Console.WriteLine("Введи число, до которого хочешь, чтобы игра загадала число. По умолчанию 10.");

            var numberToConsole = Console.ReadLine();

            validation = GameValidator.TryValidateNumber(!string.IsNullOrEmpty(numberToConsole) ? numberToConsole : "10", out var numberTo);

            if (!validation)
            {
                Console.WriteLine(UncorrectString);
                return;
            }

            Console.WriteLine("Введите количество попыток, за которое отгадаете число. По умолчанию 10");

            var numberAttemptsConsole = Console.ReadLine();

            validation = GameValidator.TryValidateNumber(!string.IsNullOrEmpty(numberAttemptsConsole) ? numberAttemptsConsole : "10", out var numberAttempts);

            if (!validation)
            {
                Console.WriteLine(UncorrectString);
                return;
            }

            var game = new GameBuilder()
                .AddFromNumber(numberFrom)
                .AddToNumber(numberTo)
                .AddAttemps(numberAttempts)
                .Build();

            game.Play();
        }
    }
}
