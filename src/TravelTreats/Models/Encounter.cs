using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelTreats.Models
{
    [Table("Encounters")]
    public class Encounter
    {
        [Key]
        public int EncounterId { get; set; }
        public int ExperienceId { get; set;}
        public int PersonId { get; set; }
        public virtual Experience Experience { get; set; }
        public virtual Person Persons { get; set; }
    }
}