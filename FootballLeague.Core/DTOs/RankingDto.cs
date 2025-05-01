using System;

namespace FootballLeague.Core.DTOs
{
    public class RankingDto
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public int TeamId { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public int GoalDifference { get; set; }

        public int Points { get; set; }

        public TeamDto Team { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
