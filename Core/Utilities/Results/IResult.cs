namespace Core.Utilities.Results
{
    public interface IResult
    {
        string Message { get; set; }
        bool IsSuccess { get; set; }
    }
}
