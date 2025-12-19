using GuessNumber.Interfaces;
using GuessNumber.Settings;

namespace GuessGame
{
    public class GuessGame
    {
        private readonly INumberGenerator _generator;
        private readonly INumberComparer _comparer;
        private readonly IUserInput _input;
        private readonly IUserOutput _output;
        private readonly GameSettings _settings;

        public GuessGame(
            INumberGenerator generator,
            INumberComparer comparer,
            IUserInput input,
            IUserOutput output,
            GameSettings settings)
        {
            _generator = generator;
            _comparer = comparer;
            _input = input;
            _output = output;
            _settings = settings;
        }

        public void Run()
        {
            var secret = _generator.Generate(_settings.Min, _settings.Max);

            _output.Write($"Загаданное число от: {_settings.Min} до: {_settings.Max}. Количество попыток: {_settings.MaxAttempts}");

            for (var attempt = 1; attempt <= _settings.MaxAttempts; attempt++)
            {
                _output.Write($"Попытка {attempt}. Введите число:");
                var userNumber = _input.ReadNumber();

                var result = _comparer.Compare(secret, userNumber);

                if (result == CompareResult.Equal)
                {
                    _output.Write("Вы угадали число!");
                    return;
                }

                _output.Write(result == CompareResult.Greater ? "Меньше" : "Больше");
            }

            _output.Write($"Попытки закончились. Загаданное число: {secret}");
        }
    }
}
