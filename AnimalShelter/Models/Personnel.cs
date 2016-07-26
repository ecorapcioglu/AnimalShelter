﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.Models
{
    public class Personnel
    {
        [Key]
        public int PersonnelId { get; set; }

        [DisplayName("First Name")]
        public string PersonnelFirstName { get; set; }

        [DisplayName("Last Name")]
        public string PersonnelLastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string PersonnelPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string PersonnelEmail { get; set; }

        [ForeignKey("PersonnelType")]
        public int PersonnelTypeId { get; set; }

        [ForeignKey("AnimalShelter")]
        public int ShelterId { get; set; }

        public virtual PersonnelType PersonnelType { get; set; }
        public virtual AnimalShelter AnimalShelter { get; set; }
    }
}