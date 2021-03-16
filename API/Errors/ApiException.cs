namespace API.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string messsage=null, string details=null)
        {
            StatusCode = statusCode;
            Messsage = messsage;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string Messsage { get; set; }
        public string Details { get; set; }
    }
}