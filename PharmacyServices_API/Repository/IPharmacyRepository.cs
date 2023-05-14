using PharmacyServices_API.Models.DTOs;

namespace PharmacyServices_API.Repository
{
    public interface IPharmacyRepository
    {
        Task<List<PharmacyDTO>> GetPharmacyList();
        Task<PharmacyDTO> GetPharmacyById(int id);
        Task<List<PharmacyDTO>> GetPharmacyByHId(int hid);
        Task<List<PharmacyDTO>> GetPharmacyByName(string name);
        Task<PharmacyDTO> CreateUpdatePharmacy(PharmacyDTO pharmacyDTO);
        Task<bool> DeletePharmacy(int pharmacyId);
    }
}
