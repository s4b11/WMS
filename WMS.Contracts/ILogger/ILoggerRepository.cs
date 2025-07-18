﻿using System.Threading.Tasks;
using WMS.Models;

namespace WMS.Contracts.ILog
{
    public interface ILogRepository
    {
        Task AddErrorLogAsync(ErrorLog errorLog);
        Task AddExceptionLogAsync(ExceptionLog exceptionLog);
    }
}