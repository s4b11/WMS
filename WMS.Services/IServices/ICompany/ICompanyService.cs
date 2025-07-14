using WMS.Dtos;

namespace WMS.Services.IServices
{
    public interface ICompanyService : IBaseService<CompanyDto, CompanyCreateDto, CompanyEditDto, CompanyCompactDto>
    {
    }
}