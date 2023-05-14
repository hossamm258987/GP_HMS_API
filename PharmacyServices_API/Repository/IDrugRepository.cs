using PharmacyServices_API.Models.DTOs;

namespace PharmacyServices_API.Repository
{
    public interface IDrugRepository
    {
        Task<List<DrugDTO>> GetDrugList(); //Done
        Task<DrugDTO> GetDrugById(int id); //Done
        Task<List<DrugDTO>> GetDrugByCatId(int cId); //Done
        Task<List<DrugDTO>> GetDrugByTypeId(int tId); //Done
        Task<List<DrugDTO>> GetDrugBySupId(int sId); //Done
        Task<List<DrugDTO>> GetDrugByName(string name); //Done
        Task<List<DrugDTO>> GetDrugByOrder(string order); //Done
        Task<DrugDTO> CreateUpdateDrug(DrugDTO drugDTO); //Done
        Task<bool> DeleteDrug(int drugId); //Done
        Task<DrugListDTO> CreateUpdateDrugList(DrugListDTO drugListDTO); //Done
        Task<bool> DeleteDrugList(int drugListId); //Done
        Task<List<DrugListDTO>> GetDrugListByPId(int dId); //Done
    }
}
