using AutoMapper;
using PharmacyServices_API.Data;
using PharmacyServices_API.Models;
using PharmacyServices_API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PharmacyServices_API.Repository
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public PharmacyRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PharmacyDTO> CreateUpdatePharmacy(PharmacyDTO pharmacyDTO)
        {
            Pharmacy pharmacy = _mapper.Map<PharmacyDTO, Pharmacy>(pharmacyDTO);
            Hospital hospital = await _db.Hospitals.FirstOrDefaultAsync(h => h.Id == pharmacy.HospitalId);
            Employee employee = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == pharmacy.employeeId);

            if(hospital == null)
            {
                _db.Hospitals.Add(pharmacy.Hospital);
                await _db.SaveChangesAsync();
            }

            if(employee == null)
            {
                _db.Employees.Add(pharmacy.Employee);
                await _db.SaveChangesAsync();
            }

            if(pharmacy.Id > 0)
            {
                _db.Pharmacies.Update(pharmacy);
            }
            else
            {
                _db.Pharmacies.Add(pharmacy);
            }
            await _db.SaveChangesAsync();

            return _mapper.Map<Pharmacy, PharmacyDTO>(pharmacy);
        }

        public async Task<bool> DeletePharmacy(int pharmacyId)
        {
            try
            {
                Pharmacy pharmacy = await _db.Pharmacies.FirstOrDefaultAsync(p => p.Id == pharmacyId);
                if(pharmacy == null)
                {
                    return false;
                }
                _db.Pharmacies.Remove(pharmacy);
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        public async Task<List<PharmacyDTO>> GetPharmacyByHId(int hid)
        {
            List<Pharmacy> pharmacies = await _db.Pharmacies.Where(p => p.HospitalId == hid)
                .Include(h => h.Hospital).Include(m => m.Employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PharmacyDTO>>(pharmacies);
        }

        public async Task<PharmacyDTO> GetPharmacyById(int id)
        {
            Pharmacy pharmacy = await _db.Pharmacies.Include(h => h.Hospital).Include(m => m.Employee)
                .IgnoreAutoIncludes().FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PharmacyDTO>(pharmacy);
        }

        public async Task<List<PharmacyDTO>> GetPharmacyByName(string name)
        {
            List<Pharmacy> pharmacies = await _db.Pharmacies.Where(p => p.Name.Contains(name))
                .Include(h => h.Hospital).Include(m => m.Employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PharmacyDTO>>(pharmacies);
        }

        public async Task<List<PharmacyDTO>> GetPharmacyList()
        {
            List<Pharmacy> pharmacies = await _db.Pharmacies.Include(h => h.Hospital)
                .Include(m => m.Employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PharmacyDTO>>(pharmacies);
        }
    }
}
