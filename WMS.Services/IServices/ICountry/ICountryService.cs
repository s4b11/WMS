using WMS.Dtos;
using WMS.Services.IServices;

namespace WMS.Services.IServices
{
    public interface ICountryService : IBaseService<CountryDto, CountryCreateDto, CountryEditDto, CountryCompactDto>
    {
    }
}