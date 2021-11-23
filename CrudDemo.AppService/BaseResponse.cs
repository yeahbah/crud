using System;
using System.Net;

namespace CrudDemo.App
{
    public record BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string ErrorMessage { get; set; }
    }
}
