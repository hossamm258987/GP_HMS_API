using EmployeeServices_API.Models.DTOs;

namespace EmployeeServices_API.Repository
{
    public interface ISpecializationRepository
    {
        Task<List<SpecializationDTO>> GetSpecializationList();
        Task<SpecializationDTO> GetSpecializationById(int id);
        Task<List<SpecializationDTO>> GetSpecializationByName(string name);
        Task<SpecializationDTO> CreateUpdateSpecialization(SpecializationDTO specializationDTO);
        Task<bool> DeleteSpecialization(int specializationId);
    }
}
