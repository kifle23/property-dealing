using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Errors
{
    public class APIError
    {
        public APIError(int errorCode, string? errorMessage, string? errorDetails)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorDetails = errorDetails;
        }

        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorDetails { get; set; }
    }
}