using WMS.Dtos;

namespace WMS.Services.IServices
{
    public interface ICustomerService : IBaseService<CustomerDto, CustomerCreateDto, CustomerEditDto, CustomerCompactDto>
    {
    }
}