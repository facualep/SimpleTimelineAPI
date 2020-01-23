using System;
using System.Net;

namespace Timeline.Models
{
    public class Response
    {
        public HttpStatusCode Code { get; set; }
        public string ErrorMessage { get; set; }
        public Boolean Error { get; set; }
        public Object Result { get; set; }

        public Response()
        {

        }

        public Response(HttpStatusCode Code, Boolean Error, Object Result = null, string ErrorMessage = "")
        {
            this.Code = Code;
            this.Result = Result;
            this.ErrorMessage = ErrorMessage;
            this.Error = Error;
        }
    }
}
