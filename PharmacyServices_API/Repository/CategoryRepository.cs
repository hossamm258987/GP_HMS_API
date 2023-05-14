using AutoMapper;
using PharmacyServices_API.Data;
using PharmacyServices_API.Models;
using PharmacyServices_API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PharmacyServices_API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateUpdateCategory(CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            if(category.Id > 0)
            {
                _db.Categories.Update(category);
            }
            else
            {
                _db.Categories.Add(category);
            }
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                Category category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (category == null)
                {
                    return false;
                }

                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            Category category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<List<CategoryDTO>> GetCategoryByName(string name)
        {
            List<Category> category = await _db.Categories.Where(c => c.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<CategoryDTO>>(category);
        }

        public async Task<List<CategoryDTO>> GetCategoryList()
        {
            List<Category> category = await _db.Categories.ToListAsync();
            return _mapper.Map<List<CategoryDTO>>(category);
        }
    }
}
