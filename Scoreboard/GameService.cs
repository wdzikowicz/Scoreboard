using System;

namespace Scoreboard
{
  public class GameService
  {
    
    public Guid Start(string homeTeam, string awayTeam)
    {
      return Guid.NewGuid();
    }

    public void Finish()
    {

    }

    public void Summary()
    {

    }
  }
}
