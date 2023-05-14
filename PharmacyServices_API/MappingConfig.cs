using AutoMapper;
using PharmacyServices_API.Models;
using PharmacyServices_API.Models.DTOs;

namespace PharmacyServices_API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDTO, Employee>().ReverseMap();
                config.CreateMap<CategoryDTO, Category>().ReverseMap();
                config.CreateMap<DrugDTO, Drug>().ReverseMap();
                config.CreateMap<DrugListDTO, DrugList>().ReverseMap();
                config.CreateMap<DrugTypeDTO, DrugType>().ReverseMap();
                config.CreateMap<HospitalDTO, Hospital>().ReverseMap();
                config.CreateMap<PharmacyDTO, Pharmacy>().ReverseMap();
                config.CreateMap<SupplierDTO, Supplier>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
