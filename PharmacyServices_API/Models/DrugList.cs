﻿using System.ComponentModel.DataAnnotations;

namespace PharmacyServices_API.Models
{
    public class DrugList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DrugId { get; set; }
        public Drug Drug { get; set; }
        public DateTime ProductionDate { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
    }
}
