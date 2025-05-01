using System;

namespace FootballLeague.Core.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }

        public DateTime MatchDate { get; set; }
    }
}
