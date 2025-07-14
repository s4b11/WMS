using WMS.Dtos;

namespace WMS.Services.IServices
{
    public interface ICurrencyService : IBaseService<CurrencyDto, CurrencyCreateDto, CurrencyEditDto, CurrencyCompactDto>
    {
    }
}