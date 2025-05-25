namespace Presentation.Models;

public class BookingResult
{
    public bool Succeeded { get; set; }
    public int StatusCode { get; set; }
    public string? Error { get; set; }

}

public class BookingResult<T> : BookingResult
{
    public T? Result { get; set; }
}
