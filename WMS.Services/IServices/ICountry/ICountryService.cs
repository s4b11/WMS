using WMS.Dtos;

namespace WMS.Services.IServices
{
    public interface ICountryService : IBaseService<CountryDto, CountryCreateDto, CountryEditDto, CountryCompactDto>
    {
    }
}