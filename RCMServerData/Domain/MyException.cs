using Core.Model;

namespace RCMServerData.Domain
{
    public class MyException : BaseDomain
    {
        public int Id { get; set; }
        public int UId { get; set; }
        public System.DateTime Date { get; set; }
        public string HResultCode { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string ParamName { get; set; }
        public string Errors { get; set; }
        public string InnerMessage { get; set; }
        public string InnerSource { get; set; }
        public string InnerStackTrace { get; set; }
        public string InnerParamName { get; set; }
        public string InnerErrors { get; set; }
    }
}
