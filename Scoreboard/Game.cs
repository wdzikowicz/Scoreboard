using System;

namespace Scoreboard
{
    public class Game
    {
        public Guid Id { get; private set; }
        public string HomeTeam { get; private set; }
        public string AwayTeam { get; private set; }

        public DateTime CreatedOn { get; private set; }
        public uint HomeScore { get; set; }
        public uint AwayScore { get; set; }
        public uint TotalScore => HomeScore + AwayScore;

        public Game(string homeTeam, string awayTeam, uint homeScore, uint awayScore) : this(homeTeam, awayTeam)
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
