namespace EFCore.Models;

public  class ApiResponse<T>
{

    public string Message { get; set; }
    public T? Data { get; set; }
    public int StatusCode { get; set; }
    public bool  IsSuccess { get; set; }
    public static ApiResponse<T> Success(T data, string message = "", int statusCode = 200)
    {
        return new ApiResponse<T>
        {
            Data = data,
            Message = message,
            StatusCode = statusCode,
            IsSuccess = true
        };
    }

    public static ApiResponse<T> Error(string message = "", int statusCode = 400)
    {
        return new ApiResponse<T>
        {
            Message = message,
            StatusCode = statusCode,
            IsSuccess = false
        };
    }
}