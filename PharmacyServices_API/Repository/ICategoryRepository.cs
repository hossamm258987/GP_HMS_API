using PharmacyServices_API.Models.DTOs;

namespace PharmacyServices_API.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDTO>> GetCategoryList();
        Task<CategoryDTO> GetCategoryById(int id);
        Task<List<CategoryDTO>> GetCategoryByName(string name);
        Task<CategoryDTO> CreateUpdateCategory(CategoryDTO categoryDTO);
        Task<bool> DeleteCategory(int categoryId);
    }
}
