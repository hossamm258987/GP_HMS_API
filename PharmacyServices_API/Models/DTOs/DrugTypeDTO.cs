﻿namespace PharmacyServices_API.Models.DTOs
{
    public class DrugTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
