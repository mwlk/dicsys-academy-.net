namespace WebApi.Models
{ 
    public class Response
    {
        public int Code { get; set; } = 0;
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
