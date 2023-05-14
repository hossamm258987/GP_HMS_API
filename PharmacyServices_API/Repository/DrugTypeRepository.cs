using AutoMapper;
using PharmacyServices_API.Data;
using PharmacyServices_API.Models;
using PharmacyServices_API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PharmacyServices_API.Repository
{
    public class DrugTypeRepository : IDrugTypeRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public DrugTypeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DrugTypeDTO> CreateUpdateDrugType(DrugTypeDTO drugTypeDTO)
        {
            DrugType dType = _mapper.Map<DrugTypeDTO, DrugType>(drugTypeDTO);
            
            if(dType.Id > 0)
            {
                _db.DrugTypes.Update(dType);
            }
            else
            {
                _db.DrugTypes.Add(dType);
            }
            await _db.SaveChangesAsync();

            return _mapper.Map<DrugType, DrugTypeDTO>(dType);
        }

        public async Task<bool> DeleteDrugType(int drugTypeId)
        {
            try
            {
                DrugType dType = await _db.DrugTypes.FirstOrDefaultAsync(c => c.Id == drugTypeId);
                if (dType == null)
                {
                    return false;
                }

                _db.DrugTypes.Remove(dType);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DrugTypeDTO> GetDrugTypeById(int id)
        {
            DrugType dType = await _db.DrugTypes.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<DrugTypeDTO>(dType);
        }

        public async Task<List<DrugTypeDTO>> GetDrugTypeByName(string name)
        {
            List<DrugType> dType = await _db.DrugTypes.Where(t => t.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<DrugTypeDTO>>(dType);
        }

        public async Task<List<DrugTypeDTO>> GetDrugTypeList()
        {
            List<DrugType> dType = await _db.DrugTypes.ToListAsync();
            return _mapper.Map<List<DrugTypeDTO>>(dType);
        }
    }
}
