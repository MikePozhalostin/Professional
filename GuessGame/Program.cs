using GuessNumber.Classes;
using GuessNumber.Settings;

namespace GuessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var settings = new GameSettings(1, 10, 4);
            var game = new GuessGame(
                new RandomNumberGenerator(),
                new NumberComparer(),
                new ConsoleInput(),
                new ConsoleOutput(),
                settings
            );

            game.Run();
        }
    }
}
