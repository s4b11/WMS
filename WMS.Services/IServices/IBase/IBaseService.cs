using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WMS.Utilities;

namespace WMS.Services.IServices
{
    public interface IBaseService<T, TCreate, TEdit, TCompact>
    {
        Task<ServiceResult<IEnumerable<TCompact>>> GetAllServiceAsync();
        Task<ServiceResult<T>> GetByIdServiceAsync(int id);
        Task<ServiceResult<T>> CreateServiceAsync(TCreate createEntity);
        Task<ServiceResult<T>> UpdateServiceAsync(TEdit editEntity);
        Task<ServiceResult<TCompact>> DeleteServiceAsync(int id);
        Task<ServiceResultPage<PagedList<TCompact>>> GetAllPageServiceAsync(PageParameters pageParams);
    }
}