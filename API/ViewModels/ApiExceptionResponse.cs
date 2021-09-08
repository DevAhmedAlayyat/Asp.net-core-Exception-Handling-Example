namespace API.ViewModels
{
    public class ApiExceptionResponse : ApiResponse
    {
        public ApiExceptionResponse(int code, string message = null, string details = null) : base(code, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}