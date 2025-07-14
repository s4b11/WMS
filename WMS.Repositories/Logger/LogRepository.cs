using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WMS.Contracts.ILog;
using WMS.DataLayer;
using WMS.Models;

namespace WMS.Repositories.Log
{
    public class LogRepository : ILogRepository
    {
        private readonly WMSContext _context;

        public LogRepository(WMSContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddErrorLogAsync(ErrorLog errorLog)
        {
            if (errorLog == null)
                throw new ArgumentNullException(nameof(errorLog));

            await _context.ErrorLog.AddAsync(errorLog);
            await _context.SaveChangesAsync();
        }

        public async Task AddExceptionLogAsync(ExceptionLog exceptionLog)
        {
            if (exceptionLog == null)
                throw new ArgumentNullException(nameof(exceptionLog));

            await _context.ExceptionLog.AddAsync(exceptionLog);
            await _context.SaveChangesAsync();
        }
    }
}