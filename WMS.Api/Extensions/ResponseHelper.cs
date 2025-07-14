using WMS.LoggerService;
using WMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace WMS.Api.Extensions
{
    public class ResponseHelper
    {
        public const int OkStatusCode = 200;
        public const int CreatedStatusCode = 201;
        public const int NoContentStatusCode = 204;
        public const int BadRequestStatusCode = 400;
        public const int UnauthorizedStatusCode = 401;

        /// <summary>
        /// This will return a result value, with the status Message
        /// 1. If there are no errors and the result is not null it will return a HTTP 200 response
        ///    plus a json containing the message from the status and the results object
        /// 2. If there are no errors but result is null it will return:
        ///    - HTTP 204 (NoContent) for genuine no-content scenarios
        ///    - HTTP 200 for "soft" failures (like "not found")
        /// 3. For authentication failures returns HTTP 401
        /// 4. If there are validation errors returns HTTP 400 with error information
        /// 5. For other errors returns HTTP 400 with error message
        /// </summary>
        public ActionResult<ApiResponse<T>> GetResponse<T>(ServiceResult<T> result)
        {
            if (result is null)
            {
                return new ObjectResult(new ApiResponse<T>(false, "Business Logic Failed."))
                { StatusCode = NoContentStatusCode };
            }

            // Special handling for authentication failures
            if (result.Message.Contains(Handling.InvalidCredentials))
            {
                return new UnauthorizedObjectResult(new ApiResponse<T>(result.IsSuccess, result.Message));
            }

            if (result.IsSuccess)
            {
                // Handle "soft" failure messages that should return 200 with message
                var softFailureMessages = new[]
                {
                    Handling.AlreadyExists,
                    Handling.NotExists,
                    Handling.NoRecordFound,
                    Handling.NoRecordsFound,
                    Handling.CreationFailed,
                    Handling.UpdationFailed,
                    Handling.DeletionFailed,
                    Handling.RegistrationFailed,
                    Handling.FailedToFetchRecord,
                    Handling.FailedToFetchRecords
                };

                if (softFailureMessages.Any(m => result.Message.Contains(m)))
                {
                    return new OkObjectResult(new ApiResponse<T>(result.IsSuccess, result.Message, result.Result));
                }

                // Genuine no-content scenario
                if (result.Result == null)
                {
                    return new ObjectResult(new ApiResponse<T>(result.IsSuccess, result.Message))
                    { StatusCode = NoContentStatusCode };
                }

                // Normal success case with data
                return new OkObjectResult(new ApiResponse<T>(result.IsSuccess, result.Message, result.Result));
            }

            // Handle validation errors
            if (result.Errors?.Any() == true)
            {
                var modelState = new ModelStateDictionary();
                foreach (var validationResult in result.Errors)
                {
                    modelState.AddModelError(validationResult.PropertyName, validationResult.ErrorMessage);
                }
                return new BadRequestObjectResult(modelState);
            }

            // Generic error case
            return new BadRequestObjectResult(new ApiResponse<T>(result.IsSuccess, result.Message));
        }

        public ActionResult<ApiResponse<T>> GetResponse<T>(ServiceResultPage<T> result)
        {
            if (result is null)
            {
                return new ObjectResult(new ApiResponse<T>(false, "Business Logic Failed."))
                { StatusCode = NoContentStatusCode };
            }

            if (result.IsSuccess)
            {
                // Handle paged results - always return 200 for consistency
                return new OkObjectResult(new ApiResponse<T>(
                    result.IsSuccess,
                    result.Message,
                    result.PageResult,
                    result.Result));
            }

            // Handle validation errors
            if (result.Errors?.Any() == true)
            {
                var modelState = new ModelStateDictionary();
                foreach (var validationResult in result.Errors)
                {
                    modelState.AddModelError(validationResult.PropertyName, validationResult.ErrorMessage);
                }
                return new BadRequestObjectResult(modelState);
            }

            // Generic error case
            return new BadRequestObjectResult(new ApiResponse<T>(result.IsSuccess, result.Message));
        }
    }
}