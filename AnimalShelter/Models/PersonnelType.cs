using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
    public class PersonnelType
    {
        [Key]
        public int PersonnelTypeId { get; set; }

        [DisplayName("Type")]
        public string PersonnelTypeTitle { get; set; }

    }
}