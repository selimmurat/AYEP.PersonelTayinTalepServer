namespace Domain.Shared.Results
{
    public interface IResultBase
    {
        bool Success { get; }
        string Message { get; }
    }
}
