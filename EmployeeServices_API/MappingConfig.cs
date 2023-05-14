using AutoMapper;
using EmployeeServices_API.Models;
using EmployeeServices_API.Models.DTOs;

namespace EmployeeServices_API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDTO, Employee>().ReverseMap();
                config.CreateMap<WardDTO, Ward>().ReverseMap();
                config.CreateMap<JobTittleDTO, JobTittle>().ReverseMap();
                config.CreateMap<SpecializationDTO, Specialization>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
