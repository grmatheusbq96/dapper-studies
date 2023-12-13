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

        public static ResponseBase<T> CreateSuccess(T response) => new(response, 200);

        public static ResponseBase<T> CreateBadRequest() => new(404);

        public static ResponseBase<T> CreateInternalServerError() => new(500);

        public static ResponseBase<T> Create(int statusCode) => new(statusCode);

        public ResponseBase<T> AddMessage(string message)
        {
            Message = message;

            return this;
        }

        public int GetStatusCode() => StatusCode;
    }
}