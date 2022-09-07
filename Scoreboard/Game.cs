using System;

namespace Scoreboard
{
  public class Game
  {
    public Guid Id { get; set;}
    public string HomeTeam { get; set; }
    public string AwayTeam { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public int TotalScore => HomeScore + AwayScore;
 
    public Game(string homeTeam, string awayTeam)
    {
      this.Id = Guid.NewGuid();
      this.HomeTeam = homeTeam;
      this.AwayTeam = awayTeam;
    }
   }
}
