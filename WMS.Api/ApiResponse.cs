using System.Collections.Generic;
using WMS.Utilities;

namespace WMS.Api
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public PageResult PageResult { get; set; }
        public T Result { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse(bool isSuccess, string message)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
        }

        public ApiResponse(bool isSuccess, string message, T result)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.Result = result;
        }

        public ApiResponse(bool isSuccess, string message, PageResult pageResult, T result)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.PageResult = pageResult;
            this.Result = result;
        }

        public ApiResponse(bool isSuccess, string message, T result, List<string> errors)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.Result = result;
            this.Errors = errors;
        }
    }
}