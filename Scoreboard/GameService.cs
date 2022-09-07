using System;
using System.Collections.Generic;

namespace Scoreboard
{
  public class GameService
  {
    private List<Game> Games;

    public GameService()
    {
      this.Games = new List<Game>();
    }

    public GameService(List<Game> games)
    {
      this.Games = games;
    }

    public Guid Start(string homeTeam, string awayTeam)
    {
      ValidateStartParameters(homeTeam, awayTeam);

      var game = new Game(homeTeam, awayTeam);
      this.Games.Add(game);

      return game.Id;
    }

    public void Finish()
    {

    }

    public void Summary()
    {

    }

    private void ValidateStartParameters(string homeTeam, string awayTeam)
    {
      if(string.IsNullOrEmpty(homeTeam))
      {
        throw new ArgumentNullException(homeTeam);
      }
      if(string.IsNullOrEmpty(awayTeam))
      {
        throw new ArgumentNullException(awayTeam);
      }

    }
  }
}
