namespace HospitalManagementSystem_API
{
    public class SD
    {
        public static string EmployeeAPIBase { get; set; }
        public static string PayrollAPIBase { get; set; }
        public static string PharmacyAPIBase { get; set; }
        public enum APIType { 
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
