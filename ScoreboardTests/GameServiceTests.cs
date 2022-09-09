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
            var games = new List<Game>();
            var gameService = new GameService(games);

            // When
            var gameId = gameService.Start(home, away);

            // Then
            var addedGame = games.Find(g => g.Id == gameId);

            Assert.NotNull(addedGame);
            Assert.Equal(home, addedGame.HomeTeam);
            Assert.Equal(away, addedGame.AwayTeam);
            Assert.Equal((uint)0, addedGame.TotalScore);
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
            void act() => gameService.Start(home, away);

            // Then
            var exception = Assert.Throws<System.ArgumentNullException>(act);
            Assert.Equal("Value cannot be null.", exception.Message);
        }

        [Fact]
        public void StartThrowsArgumentExceptionWhenAwayTeamNameIsNotProvidedTest()
        {
            // Given
            string home = "Poland";
            string away = null;
            var games = new List<Game>();
            var gameService = new GameService(games);

            // When
            void act() => gameService.Start(home, away);

            // Then
            var exception = Assert.Throws<System.ArgumentNullException>(act);
            Assert.Equal("Value cannot be null.", exception.Message);
        }

        [Fact]
        public void FinishThrowsKeyNotFoundExceptionWhenGameWithProvidedIdDoesntExistTest()
        {
            // Given
            var gameService = new GameService();

            // When
            void act() => gameService.Finish(Guid.Empty);

            // Then
            var exception = Assert.Throws<KeyNotFoundException>(act);
            Assert.Equal($"Game with id {Guid.Empty} doesnt exist or it's already finished.", exception.Message);
        }

        [Fact]
        public void FinishRemovesGameFromScoreboardByProviedIdTest()
        {
            // Given
            var game = new Game("Poland", "Germany");

            var games = new List<Game> { game };
            var gameService = new GameService(games);

            // When
            gameService.Finish(game.Id);

            // Then
            var gameExists = games.Exists(g => g.Id == game.Id);
            Assert.False(gameExists);
        }

        [Fact]
        public void UpdateThrowsKeyNotFoundExceptionWhenGameWithProvidedIdDoesntExistTest()
        {
            // Given
            var gameService = new GameService();

            // When
            void act() => gameService.Update(Guid.Empty, 0, 0);

            // Then
            var exception = Assert.Throws<KeyNotFoundException>(act);
            Assert.Equal($"Game with id {Guid.Empty} doesnt exist or it's already finished.", exception.Message);
        }

        [Fact]
        public void UpdateChangesScoreOfTeamsTest()
        {
            // Given
            var game = new Game("Poland", "Germany");

            var games = new List<Game> { game };
            var gameService = new GameService(games);

            // When
            gameService.Update(game.Id, 4, 5);

            // Then
            Assert.Equal((uint)4, game.HomeScore);
            Assert.Equal((uint)5, game.AwayScore);
        }

        [Fact]
        public void SummaryReturnsScoreboardSortedByTotalScoreAndCreationTimeTest()
        {
            // Given
            var game1 = new Game("Mexico", "Canada", 0, 5);
            var game2 = new Game("Spain", "Brazil", 10, 2);
            var game3 = new Game("Germany", "France", 2, 2);
            var game4 = new Game("Uruguay", "Italy", 6, 6);
            var game5 = new Game("Argentina", "Australia", 3, 1);

            var games = new List<Game> { game1, game2, game3, game4, game5 };
            var gameService = new GameService(games);

            // When
            var scoreboard = gameService.Summary();

            // Then
            Assert.Equal(game4.Id, scoreboard[0].Id);
            Assert.Equal(game2.Id, scoreboard[1].Id);
            Assert.Equal(game1.Id, scoreboard[2].Id);
            Assert.Equal(game5.Id, scoreboard[3].Id);
            Assert.Equal(game3.Id, scoreboard[4].Id);
        }
    }
}
