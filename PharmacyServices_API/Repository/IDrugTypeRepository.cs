using PharmacyServices_API.Models.DTOs;

namespace PharmacyServices_API.Repository
{
    public interface IDrugTypeRepository
    {
        Task<List<DrugTypeDTO>> GetDrugTypeList();
        Task<DrugTypeDTO> GetDrugTypeById(int id);
        Task<List<DrugTypeDTO>> GetDrugTypeByName(string name);
        Task<DrugTypeDTO> CreateUpdateDrugType(DrugTypeDTO drugTypeDTO);
        Task<bool> DeleteDrugType(int drugTypeId);
    }
}
