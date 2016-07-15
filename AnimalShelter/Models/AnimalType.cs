using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
    public class AnimalType
    {
        [Key]
        public int AnimalTypeId { get; set; }

        [DisplayName("Type")]
        public string AnimalTypeDescription { get; set; }

    }
}