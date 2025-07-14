using WMS.Dtos;

namespace WMS.Services.IServices
{
    public interface IVendorService : IBaseService<VendorDto, VendorCreateDto, VendorEditDto, VendorCompactDto>
    {
    }
}