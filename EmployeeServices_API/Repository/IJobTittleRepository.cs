using EmployeeServices_API.Models.DTOs;

namespace EmployeeServices_API.Repository
{
    public interface IJobTittleRepository
    {
        Task<List<JobTittleDTO>> GetJobTittleList();
        Task<JobTittleDTO> GetJobTittleById(int id);
        Task<List<JobTittleDTO>> GetJobTittleByName(string name);
        Task<JobTittleDTO> CreateUpdateJobTittle(JobTittleDTO jobTittleDTO);
        Task<bool> DeleteJobTittle(int jobTittleId);
    }
}
