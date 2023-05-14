using AutoMapper;
using PayrollServices_API.Models;
using PayrollServices_API.Models.DTOs;

namespace PayrollServices_API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDTO, Employee>().ReverseMap();
                config.CreateMap<AttendanceDTO, Attendance>().ReverseMap();
                config.CreateMap<DeductionDTO, Deduction>().ReverseMap();
                config.CreateMap<PayrollDTO, Payroll>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
