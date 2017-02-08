using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace TravelTreats.Models
{
    [Table("Experiences")]
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        public int LocationId { get; set; }
        public string Description { get; set; }
        public string MealType { get; set; }
        public ICollection<Encounter> Encounters { get; set; }
    }
}