using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FInalprojectAPI.Models
{
    [Table("SwimmingResults")]
    public class SwimmingResult
    {
        [Key]
        public int Id { get; set; } // New Id property with [Key] attribute
        public string? Rank { get; set; }
        public string? Location { get; set; }
        public string? Year { get; set; }
        [Column("Distance (in meters)")]
        [Display(Name = "Distance (in meters)")]
        public string? Distance { get; set; }
        public string? Stroke { get; set; }
        public string? Gender { get; set; }
        public string? Team { get; set; }
        public string? Athlete { get; set; }
        public string? Results { get; set; }
        public string? AddedBy { get; set; } 
    }
}
