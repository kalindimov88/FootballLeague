using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeague.Data.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Team")]
        public int HomeTeamId { get; set; }

        [Required]
        [ForeignKey("Team")]
        public int AwayTeamId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int HomeTeamScore { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int AwayTeamScore { get;set; }

        [Required]
        public DateTime MatchDate { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }
    }
}
