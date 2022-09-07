using System;
using Xunit;
using Scoreboard;
using System.Collections.Generic;

namespace ScoreboardTests
{
    public class GameTests
    {
        [Fact]
        public void StartReturnIdWhenHomeAndAwayAreProvidedTest()
        {
            // Given
            string home = "Poland";
            string away = "Germany";
            var games = new List<Game>();
            var gameService = new GameService(games);
            
            // When
            var gameId = gameService.Start(home, away);

            // Then
            Assert.NotEqual(Guid.Empty, gameId);
        }

        [Fact]
        public void StartAddsElementToTheScoreboardTest()
        {
            // Given
            string home = "Poland";
            string away = "Germany";
            List<Game> games = new List<Game>();
            var gameService = new GameService(games);
            
            // When
            var gameId = gameService.Start(home, away);

            // Then
            var addedGame = games.Find(g => g.Id == gameId);
            Assert.NotNull(addedGame);
            Assert.Equal(home, addedGame.HomeTeam);
            Assert.Equal(away, addedGame.AwayTeam);
            Assert.Equal(0, addedGame.TotalScore);
        }

        [Fact]
        public void StartThrowsEArgumentExceptionWhenHomeTeamNameIsNotProvidedTest()
        {
            // Given
            string home = null;
            string away = "Germany";
            var games = new List<Game>();
            var gameService = new GameService(games);
            
            // When
             Action act = () => gameService.Start(home, away);

            // Then
            var exception = Assert.Throws<System.ArgumentNullException>(act);
            Assert.Equal("Value cannot be null.", exception.Message);
        }

                [Fact]
        public void StartThrowsEArgumentExceptionWhenAwayTeamNameIsNotProvidedTest()
        {
            // Given
            string home = "Poland";
            string away = null;
            var games = new List<Game>();
            var gameService = new GameService(games);
            
            // When
             Action act = () => gameService.Start(home, away);

            // Then
            var exception = Assert.Throws<System.ArgumentNullException>(act);
            Assert.Equal("Value cannot be null.", exception.Message);
        }
    }
}
