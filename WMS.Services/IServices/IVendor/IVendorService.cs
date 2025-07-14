using WMS.Dtos;
using WMS.Services.IServices;

namespace WMS.Services.IServices
{
    public interface IVendorService : IBaseService<VendorDto, VendorCreateDto, VendorEditDto, VendorCompactDto>
    {
    }
}