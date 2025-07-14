using AutoMapper;
using WMS.Dtos;
using WMS.Models;

namespace WMS.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Country Mappings
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryEditDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Country, CountryCreateDto>().ReverseMap();
            CreateMap<Country, CountryCompactDto>().ReverseMap();

            // Company Mappings
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CompanyEditDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Company, CompanyCreateDto>().ReverseMap();
            CreateMap<Company, CompanyCompactDto>().ReverseMap();

            // Vendor Mappings
            CreateMap<Vendor, VendorDto>().ReverseMap();
            CreateMap<Vendor, VendorEditDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Vendor, VendorCreateDto>().ReverseMap();
            CreateMap<Vendor, VendorCompactDto>().ReverseMap();

            // Customer Mappings
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerEditDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerCompactDto>().ReverseMap();

            // Carrier Mappings
            CreateMap<Carrier, CarrierDto>().ReverseMap();
            CreateMap<Carrier, CarrierEditDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Carrier, CarrierCreateDto>().ReverseMap();
            CreateMap<Carrier, CarrierCompactDto>().ReverseMap();

            // Currency Mappings
            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<Currency, CurrencyEditDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Currency, CurrencyCreateDto>().ReverseMap();
            CreateMap<Currency, CurrencyCompactDto>().ReverseMap();

            // Uom Mappings
            CreateMap<Uom, UomDto>().ReverseMap();
            CreateMap<Uom, UomEditDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Uom, UomCreateDto>().ReverseMap();
            CreateMap<Uom, UomCompactDto>().ReverseMap();

            // Zone Mappings
            CreateMap<Zone, ZoneDto>().ReverseMap();
            CreateMap<Zone, ZoneEditDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Zone, ZoneCreateDto>().ReverseMap();
            CreateMap<Zone, ZoneCompactDto>().ReverseMap();
        }
    }
}
