using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WMS.Contracts;
using WMS.Contracts.ILogger;
using WMS.Contracts.IRepository;
using WMS.Dtos.Dtos;
using WMS.LoggerService;
using WMS.Models.Models;
using WMS.Services.IServices;
using WMS.Services.Results;

namespace WMS.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ILoggerManager _logger;

        public UserService(IUserRepository userRepository, IConfiguration configuration, ILoggerManager logger)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);

                if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
                {
                    return new ServiceResult<LoginResponseDto>(true, Handling.InvalidCredentials, null);
                }

                var token = GenerateJwtToken(user);

                var result = new LoginResponseDto
                {
                    Token = token,
                    Username = user.Username,
                    Role = user.Role
                };

                return new ServiceResult<LoginResponseDto>(true, Handling.LoginSuccess, result);
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(LoginAsync), e.Message);
                return new ServiceResult<LoginResponseDto>(true, e.Message, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(LoginAsync), e.Message);
                return new ServiceResult<LoginResponseDto>(true, Handling.ErrorOccured, null);
            }
        }


        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryInMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            // In production, use proper password hashing (e.g., BCrypt)
            // This is a placeholder; replace with secure hashing
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}