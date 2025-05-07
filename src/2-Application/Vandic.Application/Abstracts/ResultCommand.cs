namespace Vandic.Application.Abstracts
{
    public class ResultCommand<TData>
    {
        public bool Success { get; private set; }
        public TData? Data { get; private set; }
        public string? Message { get; private set; }
        public List<string> Errors { get; private set; } = new();

     
        public static ResultCommand<TData> Ok(TData data, string? message = null)
            => new()
            {
                Success = true,
                Data = data,
                Message = message
            };

        public static ResultCommand<TData> Fail(string message, List<string>? errors = null)
            => new()
            {
                Success = false,
                Message = message,
                Errors = errors ?? new List<string>()
            };

        public static ResultCommand<TData> Fail(string message, string error)
            => Fail(message, new List<string> { error });

        public static ResultCommand<TData> FailFromException(Exception ex)
            => Fail("Ocorreu um erro interno.", ex.Message);
    }


}
