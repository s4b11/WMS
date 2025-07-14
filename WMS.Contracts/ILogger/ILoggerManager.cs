using System.Threading.Tasks;

namespace WMS.Contracts.ILogger
{
    public interface ILoggerManager
    {
        Task LogErrorAsync(string className, string methodName, string errorMessage, int? userId = null);
        Task LogExceptionAsync(string errorMessage, string controllerName, string actionName, string ipAddress, int? userId = null);
    }
}