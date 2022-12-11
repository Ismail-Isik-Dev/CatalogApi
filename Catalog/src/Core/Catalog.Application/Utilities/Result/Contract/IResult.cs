namespace Catalog.Application.Utilities.Result.Contract
{
    public interface IResult
    {
        public bool Success { get; }
        public string Message { get; }
    }
}
