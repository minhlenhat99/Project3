using AutoMapper;
using CompanyPropertyManagement.Data.Domain;
using CompanyPropertyManagement.DTOs.Authentication;
using CompanyPropertyManagement.DTOs.BU;
using CompanyPropertyManagement.DTOs.Inventory;
using CompanyPropertyManagement.DTOs.Property;

namespace CompanyPropertyManagement.APIs.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Property, PropertyReadDto>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.SeatCode, opts => opts.MapFrom(src => src.SeatCode.Id))
                .ForMember(dest => dest.BuName, opts => opts.MapFrom(src => src.SeatCode.BU.Name))
                .ForMember(dest => dest.BuId, opts => opts.MapFrom(src => src.SeatCode.BU.Id));

            CreateMap<BU, BUReadDto>();
            
            CreateMap<UserForRegistrationDto, AppUser>();
            
            CreateMap<InventoryCreateDto, Inventory>();
            CreateMap<Inventory, InventoryReadDto>()
                .ForMember(dest => dest.BuName, opts => opts.MapFrom(src => src.BU.Name))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName));
        }
    }
}
