using System.Collections.Generic;

namespace API.ViewModels
{
    public class ApiValidationErrorsResponse : ApiResponse
    {
        public ApiValidationErrorsResponse() : base(400)
        {
        }
        public List<string> Errors { get; set; }
    }
}