using WMS.Dtos;
using WMS.Services.IServices;

namespace WMS.Services.IServices
{
    public interface ICarrierService : IBaseService<CarrierDto, CarrierCreateDto, CarrierEditDto, CarrierCompactDto>
    {
    }
}