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
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Please enter the phone number in the followng form: XXX-XXX-XXXX")]
        public string ShelterPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string ShelterEmail { get; set; }

    }
}