using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }

        [DisplayName("Name")]
        public string AnimalName { get; set; }

        [DisplayName("Gender")]
        public string AnimalGender { get; set; }

        [DisplayName("Age")]
        public int AnimalAge { get; set; }

        [ForeignKey("AnimalType")]
        public int AnimalTypeId { get; set; }

        [ForeignKey("AnimalShelter")]
        public int ShelterId { get; set; }

        public virtual AnimalType AnimalType { get; set; }
        public virtual AnimalShelter AnimalShelter { get; set; }

    }
}