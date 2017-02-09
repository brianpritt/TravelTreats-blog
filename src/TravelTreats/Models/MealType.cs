using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelTreats.Models
{
    [Table("MealTypes")]
    public class MealType
    {
        [Key]
        public int MealTypeId { get; set; }
        public string MealTypeName { get; set; }
        public ICollection<Experience> Experiences { get; set; }

    }
}
