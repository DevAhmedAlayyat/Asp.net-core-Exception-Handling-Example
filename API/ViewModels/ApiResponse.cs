using System;

namespace API.ViewModels
{
    public class ApiResponse
    {
        public ApiResponse(int code, string message = null)
        {
            StatusCode = code;
            Message = message ?? GetDefaultMessageForStatusCode(code);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }


        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request",
                401 => "You are not authorized",
                404 => "Resource not found",
                500 => "Server error exception",
                _ => null
            };
        }
    }
}