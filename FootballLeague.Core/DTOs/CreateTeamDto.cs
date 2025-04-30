using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Core.DTOs
{
    public class CreateTeamDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
