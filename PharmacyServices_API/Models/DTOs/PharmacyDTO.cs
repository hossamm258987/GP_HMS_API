namespace PharmacyServices_API.Models.DTOs
{
    public class PharmacyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int employeeId { get; set; }
        public Employee Employee { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public bool IsActive { get; set; }
    }
}
