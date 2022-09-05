using System;
using Xunit;
using Scoreboard;

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
            var gameService = new GameService();
            
            // When
            var gameId = gameService.Start(home, away);

            // Then
            Assert.NotEqual(Guid.Empty, gameId);
        }
    }
}
