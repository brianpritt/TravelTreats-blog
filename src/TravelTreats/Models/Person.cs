using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelTreats.Models
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public ICollection<Encounter> Encounters { get; set; }
    }
}