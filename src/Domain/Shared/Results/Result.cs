namespace Domain.Shared.Results
{
    public class Result<T>(T data, bool success, string message) : ResultBase(success, message), IResult<T>
    {
        public T Data { get; } = data;

        public static Result<T> SuccessResult(T data, string message = "") =>
            new(data, true, message);

        public static new Result<T> FailureResult(string message) =>
            new(default!, false, message);
    }
}
