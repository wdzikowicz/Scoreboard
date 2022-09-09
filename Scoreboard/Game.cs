using System;

namespace Scoreboard
{
    public class Game
    {
        public Guid Id { get; private set; }
        public string HomeTeam { get; private set; }
        public string AwayTeam { get; private set; }

        public DateTime CreatedOn { get; private set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int TotalScore => HomeScore + AwayScore;

        public Game(string homeTeam, string awayTeam, int homeScore, int awayScore) : this(homeTeam, awayTeam)
        {
            this.HomeScore = homeScore;
            this.AwayScore = awayScore;
        }

        public Game(string homeTeam, string awayTeam)
        {
            this.Id = Guid.NewGuid();
            this.CreatedOn = DateTime.UtcNow;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
        }
    }
}
