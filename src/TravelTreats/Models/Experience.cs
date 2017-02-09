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
        public int MealTypeId { get; set; }
        public string Description { get; set; }
        public virtual Location Locations { get; set; }
        public virtual MealType MealType { get; set; }
        public virtual Person Person { get; set; }
        public ICollection<Encounter> Encounters { get; set; }
    }
}