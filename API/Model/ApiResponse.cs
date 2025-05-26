namespace API.Model
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public bool Success => StatusCode >= 200 && StatusCode < 300;

        public ApiResponse(int statusCode, string message, object? data = null)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
