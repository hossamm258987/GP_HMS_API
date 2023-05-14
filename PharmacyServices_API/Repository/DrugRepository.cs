using AutoMapper;
using PharmacyServices_API.Data;
using PharmacyServices_API.Models;
using PharmacyServices_API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PharmacyServices_API.Repository
{
    public class DrugRepository : IDrugRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public DrugRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DrugDTO> CreateUpdateDrug(DrugDTO drugDTO)
        {
            Drug drug = _mapper.Map<DrugDTO, Drug>(drugDTO);
            Supplier supplier = await _db.Suppliers.FirstOrDefaultAsync(s => s.Id == drug.SupplierId);

            if (supplier == null)
            {
                _db.Suppliers.Add(drug.Supplier);
                await _db.SaveChangesAsync();
            }

            if (drug.Id > 0)
            {
                _db.Drugs.Update(drug);
            }
            else
            {
                _db.Drugs.Add(drug);
            }
            await _db.SaveChangesAsync();

            return _mapper.Map<Drug, DrugDTO>(drug);
        }

        public async Task<DrugListDTO> CreateUpdateDrugList(DrugListDTO drugListDTO)
        {
            DrugList drugList = _mapper.Map<DrugListDTO, DrugList>(drugListDTO);
            Drug drug = await _db.Drugs.FirstOrDefaultAsync(d => d.Id == drugList.DrugId);

            if (drug == null)
            {
                _db.Drugs.Add(drugList.Drug);
                await _db.SaveChangesAsync();
            }

            if (drugList.Id > 0)
            {
                _db.DrugLists.Update(drugList);
            }
            else
            {
                _db.DrugLists.Add(drugList);
            }
            await _db.SaveChangesAsync();

            return _mapper.Map<DrugList, DrugListDTO>(drugList);
        }


        public async Task<bool> DeleteDrug(int drugId)
        {
            try
            {
                Drug drug = await _db.Drugs.FirstOrDefaultAsync(d => d.Id == drugId);

                if(drug == null)
                {
                    return false;
                }
                _db.Drugs.Remove(drug);
                await _db.SaveChangesAsync();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDrugList(int drugListId)
        {
            try
            {
                DrugList drugList = await _db.DrugLists.FirstOrDefaultAsync(d => d.Id == drugListId);

                if (drugList == null)
                {
                    return false;
                }
                _db.DrugLists.Remove(drugList);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<DrugDTO>> GetDrugByCatId(int cId)
        {
            List<Drug> drugs = await _db.Drugs.Where(d => d.CategoryId == cId)
                .Include(c => c.Category).Include(t => t.DrugType)
                .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DrugDTO>>(drugs);
        }

        public async Task<List<DrugListDTO>> GetDrugListByPId(int dId)
        {
            List<DrugList> drugLists = await _db.DrugLists.Where(d => d.DrugId == dId)
                .Include(d => d.Drug).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DrugListDTO>>(drugLists);
        }

        public async Task<DrugDTO> GetDrugById(int id)
        {
            Drug drug = await _db.Drugs.Include(c => c.Category).Include(t => t.DrugType)
                .Include(s => s.Supplier).Include(p => p.Pharmacy)
                .IgnoreAutoIncludes().FirstOrDefaultAsync(d => d.Id == id);
            return _mapper.Map<DrugDTO>(drug);
        }

        public async Task<List<DrugDTO>> GetDrugByName(string name)
        {
            List<Drug> drugs = await _db.Drugs.Where(d => d.Name.Contains(name))
                .Include(c => c.Category).Include(t => t.DrugType)
                .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DrugDTO>>(drugs);
        }

        public async Task<List<DrugDTO>> GetDrugByOrder(string order)
        {
            List<Drug> drugs = await _db.Drugs.Include(c => c.Category).Include(t => t.DrugType)
                .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();

            switch (order)
            {
                case "Name_asc":
                    drugs = await _db.Drugs.OrderBy(n => n.Name).Include(c => c.Category).Include(t => t.DrugType)
                    .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
                    break;
                case "Name_desc":
                    drugs = await _db.Drugs.OrderByDescending(n => n.Name).Include(c => c.Category).Include(t => t.DrugType)
                    .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
                    break;
                case "Buy_asc":
                    drugs = await _db.Drugs.OrderBy(n => n.BuingPrice).Include(c => c.Category).Include(t => t.DrugType)
                    .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
                    break;
                case "Buy_desc":
                    drugs = await _db.Drugs.OrderByDescending(n => n.BuingPrice).Include(c => c.Category).Include(t => t.DrugType)
                    .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
                    break;
                case "Sell_asc":
                    drugs = await _db.Drugs.OrderBy(n => n.SellingPrice).Include(c => c.Category).Include(t => t.DrugType)
                    .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
                    break;
                case "Sell_desc":
                    drugs = await _db.Drugs.OrderByDescending(n => n.SellingPrice).Include(c => c.Category).Include(t => t.DrugType)
                    .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
                    break;
                case "cat_asc":
                    drugs = await _db.Drugs.OrderBy(n => n.CategoryId).Include(c => c.Category).Include(t => t.DrugType)
                    .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
                    break;
                case "cat_desc":
                    drugs = await _db.Drugs.OrderByDescending(n => n.CategoryId).Include(c => c.Category).Include(t => t.DrugType)
                    .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
                    break;
            }
            return _mapper.Map<List<DrugDTO>>(drugs);
        }

        public async Task<List<DrugDTO>> GetDrugBySupId(int sId)
        {
            List<Drug> drugs = await _db.Drugs.Where(d => d.SupplierId == sId)
                .Include(c => c.Category).Include(t => t.DrugType)
                .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DrugDTO>>(drugs);
        }

        public async Task<List<DrugDTO>> GetDrugByTypeId(int tId)
        {
            List<Drug> drugs = await _db.Drugs.Where(d => d.TypeId == tId)
                .Include(c => c.Category).Include(t => t.DrugType)
                .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DrugDTO>>(drugs);
        }

        public async Task<List<DrugDTO>> GetDrugList()
        {
            List<Drug> drugs = await _db.Drugs.Include(c => c.Category).Include(t => t.DrugType)
                .Include(s => s.Supplier).Include(p => p.Pharmacy).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DrugDTO>>(drugs);
        }
    }
}
