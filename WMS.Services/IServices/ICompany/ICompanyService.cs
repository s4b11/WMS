using WMS.Dtos;
using WMS.Services.IServices;

namespace WMS.Services.IServices
{
    public interface ICompanyService : IBaseService<CompanyDto, CompanyCreateDto, CompanyEditDto, CompanyCompactDto>
    {
    }
}