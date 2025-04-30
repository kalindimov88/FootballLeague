using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Core.DTOs
{
    public class UpdateTeamDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
