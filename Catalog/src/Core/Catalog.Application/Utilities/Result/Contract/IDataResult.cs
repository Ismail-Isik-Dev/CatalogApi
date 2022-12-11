namespace Catalog.Application.Utilities.Result.Contract
{
    public interface IDataResult<T> : IResult
    {
        public T Data { get; set; }
    }
}
