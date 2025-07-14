using System.Collections.Generic;

namespace WMS.Services
{
    public class ServiceResult<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public List<ValidationResult> Errors { get; set; }

        public ServiceResult(bool isSuccess, string message, T result)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.Result = result;
        }

        public ServiceResult(bool isSuccess, string message, T result, List<ValidationResult> errors)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.Result = result;
            this.Errors = errors;
        }
    }

    public class ValidationResult
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationResult(string propertyName, string errorMessage)
        {
            PropertyName = propertyName != string.Empty ? propertyName : null;
            ErrorMessage = errorMessage;
        }
    }
}