using Catalog.Application.Utilities.Result.Contract;

namespace Catalog.Persistance.Utilities.Result
{
    public class Result : IResult
    {
        public Result(bool success, string message)
        {
            Message = message;
            Success = success;
        }

        public Result(bool success)
        {
            Success = success;
        }
    
        public bool Success { get; }

        public string Message { get; }
    }
}
