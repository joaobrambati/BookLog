namespace Application.Response;

public class Response<T>
{
    public T? Data { get; set; }
    public bool Status { get; set; }
    public required string Message { get; set; }


    public static Response<T> Success(T data, string message)
    {
        return new Response<T> { Data = data, Status = true, Message = message };
    }

    public static Response<T> Error(string message)
    {
        return new Response<T> { Status = false, Message = message };
    }

    public static Response<T> NotFound(string message)
    {
        return new Response<T> { Status = false, Message = message };
    }

}
