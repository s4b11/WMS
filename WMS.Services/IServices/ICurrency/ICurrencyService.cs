using WMS.Dtos;
using WMS.Services.IServices;

namespace WMS.Services.IServices
{
    public interface ICurrencyService : IBaseService<CurrencyDto, CurrencyCreateDto, CurrencyEditDto, CurrencyCompactDto>
    {
    }
}