namespace FitControl.WebAPI.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public string? TraceId { get; set; }
        public string? Path { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
