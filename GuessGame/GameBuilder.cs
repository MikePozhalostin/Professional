using GuessGame.Interfaces;

namespace GuessGame
{
    internal class GameBuilder : IGameBuilder
    {
        private readonly GuessGame _game = new GuessGame();

        public GameBuilder AddAttemps(int attempts)
        {
            _game.NumberOfAttempts = attempts;
            return this;
        }

        public GameBuilder AddFromNumber(int from)
        {
            _game.FromNumber = from;
            return this;
        }

        public GameBuilder AddToNumber(int to)
        {
            _game.ToNumber = to;
            return this;
        }

        public IGame Build()
        {
            return _game;
        }
    }
}
