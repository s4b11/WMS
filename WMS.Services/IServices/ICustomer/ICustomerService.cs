using WMS.Dtos;
using WMS.Services.IServices;

namespace WMS.Services.IServices
{
    public interface ICustomerService : IBaseService<CustomerDto, CustomerCreateDto, CustomerEditDto, CustomerCompactDto>
    {
    }
}