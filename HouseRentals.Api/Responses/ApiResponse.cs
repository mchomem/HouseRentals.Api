namespace HouseRentals.Api.Responses;

public class ApiResponse<T> where T : class
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; } = null!;
    public List<string> Errors { get; set; } = new();

    public ApiResponse(T data, string message = "Operation successfully completed")
    {
        Success = true;
        Message = message;
        Data = data;
    }

    public ApiResponse(List<string> errors, string message = "Operation Error", bool isError = true)
    {
        Success = false;
        Message = message;
        Errors = errors;
    }
}
