using HospitalManagementSystem_API.Models;

namespace HospitalManagementSystem_API.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
