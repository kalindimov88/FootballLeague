using System.ComponentModel.DataAnnotations;
using System;

namespace FootballLeague.Core.DTOs
{
    public class CreateMatchDto
    {
        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [Range(0, int.MaxValue)]
        public int HomeTeamScore { get; set; }

        [Range(0, int.MaxValue)]
        public int AwayTeamScore { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }
    }
}
