using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
    public class AnimalShelter
    {
        [Key]
        public int ShelterId { get; set; }

        [DisplayName("Shelter Address")]
        public string ShelterAddress { get; set; }


        [DisplayName("Shelter Name")]
        public string ShelterName { get; set; }


        [DisplayName("Phone Number")]
        public string ShelterPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string ShelterEmail { get; set; }

    }
}