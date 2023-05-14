using static HospitalManagementSystem_API.SD;

namespace HospitalManagementSystem_API.Models
{
    public class APIRequest
    {
        public APIType ApiType { get; set; } = APIType.GET;
        public string Uri { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
