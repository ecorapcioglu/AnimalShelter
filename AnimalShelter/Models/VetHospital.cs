using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.Models
{
    public class VetHospital
    {
        [Key]
        public int VetHospitalId { get; set; }

        [DisplayName("Name")]
        public string VetHospitalName { get; set; }

        [DisplayName("Address")]
        public string VetHospitalAddress { get; set; }

        [DisplayName("Hours")]
        public string VetHospitalHours { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Please enter the phone number in the followng form: XXX-XXX-XXXX")]
        [DisplayName("Phone Number")]
        public string VetHospitalPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string VetHospitalEmail { get; set; }

        [ForeignKey("AnimalShelter")]
        public int ShelterId { get; set; }

        public virtual AnimalShelter AnimalShelter { get; set; }
    }
}