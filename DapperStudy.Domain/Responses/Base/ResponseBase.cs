namespace DapperStudy.Domain.Responses.Base
{
    public class ResponseBase<T>
    {
        public T Data { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }

        private int StatusCode { get; set; }

        private ResponseBase(int statusCode)
        {
            Success = false;
            StatusCode = statusCode;
        }

        private ResponseBase(T response, int statusCode)
        {
            try
            {
                Data = response;
                Message = "";
                Success = true;
                StatusCode = statusCode;
            }
            catch (Exception e)
            {
                Data = default;
                Message = e.Message;
                Success = false;
                StatusCode = 500;
            }
        }

        public static ResponseBase<T> CreateSuccess(T response, int statusCode) => new(response, statusCode);

        public static ResponseBase<T> CreateError(int statusCode) => new(statusCode);

        public ResponseBase<T> AddMessage(string message)
        {
            Message = message;

            return this;
        }

        public int GetStatusCode() => StatusCode;
    }
}