using System;
using System.Threading.Tasks;
using WMS.Contracts.ILog;
using WMS.Contracts.ILogger;
using WMS.Models.Models;

namespace WMS.LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogRepository _logRepository;

        public LoggerManager(ILogRepository logRepository)
        {
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
        }

        public async Task LogErrorAsync(string className, string methodName, string errorMessage, int? userId = null)
        {
            var errorLog = new ErrorLog
            {
                Class = className,
                Method = methodName,
                ErrorMessage = errorMessage,
                UserID = userId,
            };

            await _logRepository.AddErrorLogAsync(errorLog);
        }

        public async Task LogExceptionAsync(string errorMessage, string controllerName, string actionName, string ipAddress, int? userId = null)
        {
            var exceptionLog = new ExceptionLog
            {
                ErrorMessage = errorMessage,
                ControllerName = controllerName,
                ActionName = actionName,
                IpAddress = ipAddress,
                UserId = userId,
            };

            await _logRepository.AddExceptionLogAsync(exceptionLog);
        }
    }
}