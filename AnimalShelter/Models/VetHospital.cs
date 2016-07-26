using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.Models
{
    public class VetHospital
    {
        [Key]
        public int VetHospitalId { get; set; }

        [DisplayName("Hospital Name")]
        public string VetHospitalName { get; set; }

        [DisplayName("Address")]
        public string VetHospitalAddress { get; set; }

        [DisplayName("Hospital Hours")]
        public string VetHospitalHours { get; set; }

        [DataType(DataType.PhoneNumber)]
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