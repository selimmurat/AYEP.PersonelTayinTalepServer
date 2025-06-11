namespace Domain.Shared.Results
{
    public class ResultBase(bool success, string message) : IResultBase
    {
        public bool Success { get; } = success;
        public string Message { get; } = message;

        public static ResultBase SuccessResult(string message = "") => new(true, message);
        public static ResultBase FailureResult(string message = "") => new(false, message);
    }
}
