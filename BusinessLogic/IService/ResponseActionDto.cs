namespace BusinessLogic.IService
{
    public class ResponseActionDto<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string Attr { get; set; }
        public ResponseActionDto(T data, int code, string message, string attr) 
        {
            this.Data = data;
            this.Code = code;                
            this.Message = message;
            this.Attr = attr;
        }
    }
}
