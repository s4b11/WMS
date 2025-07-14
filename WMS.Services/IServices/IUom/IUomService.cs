using WMS.Dtos;
using WMS.Services.IServices;

namespace WMS.Services.IServices
{
    public interface IUomService : IBaseService<UomDto, UomCreateDto, UomEditDto, UomCompactDto>
    {
    }
}