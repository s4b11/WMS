using System.Collections.Generic;
using WMS.Utilities;

namespace WMS.Services
{
    public class ServiceResultPage<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public PageResult PageResult { get; set; }
        public T Result { get; set; }
        public List<ValidationResult> Errors { get; set; }

        public ServiceResultPage(bool isSuccess, string message, T result)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.PageResult = null;
            this.Result = result;
        }

        public ServiceResultPage(bool isSuccess, string message, PageResult pageResult, T result)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.PageResult = pageResult;
            this.Result = result;
        }

        public ServiceResultPage(bool isSuccess, string message, T result, List<ValidationResult> errors)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.Result = result;
            this.Errors = errors;
        }
    }
}