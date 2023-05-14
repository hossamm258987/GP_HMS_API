using HospitalManagementSystem_API.Models;

namespace HospitalManagementSystem_API.Services.IServices
{
    public interface IEmployeeServices
    {
        Task<T> GetEmployeeList<T>(); //Done
        Task<T> GetEmployeeById<T>(int id); //Done 
        Task<T> GetEmployeeByName<T>(string fName, string mName, string lName); //Done
        Task<T> GetEmployeeByNN<T>(string nn); //Done
        Task<T> GetEmployeeBySNN<T>(string snn); //Done
        Task<T> OrderEmployee<T>(string order); //Done
        Task<T> SearchEmployee<T>(string search); //Done
        Task<T> GetEmployeeByWard<T>(int wardId); //Done
        Task<T> GetEmployeeByJobTittle<T>(int jobTittleId); //Done
        Task<T> GetEmployeeBySpecialization<T>(int specializationId); //Done
        Task<T> CreateUpdateEmployee<T>(EmployeeDTO employeeDTO); //Done
        Task<T> DeleteEmployee<T>(int employeeId); //Done
    }
}
