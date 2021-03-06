namespace WebApi.Models
{ 
    /// <summary>
    /// generic class for response, by @hdeleon 
    /// </summary>
    public class Response
    {
        /// <summary>
        /// code for return response, 1 is correct
        /// </summary>
        public int Code { get; set; } = 0;
        
        /// <summary>
        /// string with detalils
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// service's data response 
        /// </summary>
        public object Data { get; set; }
    }
}
