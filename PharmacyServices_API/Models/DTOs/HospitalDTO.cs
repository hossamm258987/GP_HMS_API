namespace PharmacyServices_API.Models.DTOs
{
    public class HospitalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string OwnerName { get; set; }
        public string LogoURL { get; set; }
    }
}
