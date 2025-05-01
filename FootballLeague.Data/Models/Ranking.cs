using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeague.Data.Models
{
    public class Ranking
    {
        [Key]
        public int Id { get; set; }

        public int Rank { get; set; }

        [Required]
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public int GoalDifference { get; set; }

        public int Points { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Team Team { get; set; }
    }
}
