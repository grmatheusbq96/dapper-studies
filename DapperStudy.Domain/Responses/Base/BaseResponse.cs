namespace DapperStudy.Domain.Responses.Base
{
    public abstract class BaseResponse<T>
    {
        public T Response { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}