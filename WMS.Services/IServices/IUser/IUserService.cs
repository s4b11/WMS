using WMS.Dtos.Dtos;

namespace WMS.Services.IServices
{
    public interface IUserService
    {
        Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginDto loginDto);
    }
}