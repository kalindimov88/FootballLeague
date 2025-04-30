using System;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
