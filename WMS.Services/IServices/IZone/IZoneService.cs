using WMS.Dtos;
using WMS.Services.IServices;

namespace WMS.Services.IServices
{
    public interface IZoneService : IBaseService<ZoneDto, ZoneCreateDto, ZoneEditDto, ZoneCompactDto>
    {
    }
}