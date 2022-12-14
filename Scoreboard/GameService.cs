using System;
using System.Collections.Generic;
using System.Linq;

namespace Scoreboard
{
    public class GameService
    {
        private readonly List<Game> Scoreboard;

        public GameService()
        {
            this.Scoreboard = new List<Game>();
        }

        public GameService(List<Game> games)
        {
            this.Scoreboard = games;
        }

        public Guid Start(string homeTeam, string awayTeam)
        {
            ValidateStartParameters(homeTeam, awayTeam);

            var game = new Game(homeTeam, awayTeam);
            this.Scoreboard.Add(game);

            return game.Id;
        }

        public void Finish(Guid gameId)
        {
            var game = this.GetGameById(gameId);

            Scoreboard.Remove(game);
        }

        public void Update(Guid gameId, uint homeScore, uint awayScore)
        {
            var game = this.GetGameById(gameId);

            game.HomeScore = homeScore;
            game.AwayScore = awayScore;
        }

        public List<Game> Summary()
        {
            return Scoreboard.OrderByDescending(g => g.TotalScore).ThenByDescending(g => g.CreatedOn).ToList();
        }

        private static void ValidateStartParameters(string homeTeam, string awayTeam)
        {
            if (string.IsNullOrEmpty(homeTeam))
            {
                throw new ArgumentNullException(homeTeam);
            }
            if (string.IsNullOrEmpty(awayTeam))
            {
                throw new ArgumentNullException(awayTeam);
            }
            if (string.Equals(homeTeam, awayTeam, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("The teams' names in the game have to different.");
            }
        }

        private Game GetGameById(Guid gameId)
        {
            var game = this.Scoreboard.Find(g => g.Id == gameId);

            if (game == null)
            {
                throw new KeyNotFoundException($"Game with id {gameId} doesnt exist or it's already finished.");
            }

            return game;
        }
    }
}
