using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyServices_API.Models
{
    public class Hospital
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "Name Must Be Less Than 80 Charachtar.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Description Must Be Less Than 250 Charachtar.")]
        public string Description { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Country Must Be Less Than 40 Charachtar.")]
        public string Country { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "City Must Be Less Than 40 Charachtar.")]
        public string City { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "Area Must Be Less Than 40 Charachtar.")]
        public string Area { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "Street Must Be Less Than 80 Charachtar.")]
        public string Street { get; set; }
        [Required]
        [MaxLength(6, ErrorMessage = "Postal Code Must Be Less Than 6 Charachtar.")]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "Owner Name Must Be Less Than 80 Charachtar.")]
        public string OwnerName { get; set; }
        public string LogoURL { get; set; }
    }
}
