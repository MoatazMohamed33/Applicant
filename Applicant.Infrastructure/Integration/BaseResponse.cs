using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Applicant.Infrastructure.Integration
{
    public class BaseResponse<T>
    {

        public BaseResponse()
        {
        }

        public BaseResponse(HttpStatusCode code)
        {
            Code = code;
        }

        public BaseResponse(HttpStatusCode code, T data)
        {
            Code = code;
            Data = data;
        }

        public BaseResponse(HttpStatusCode code, T data, string message)
        {
            Code = code;
            Data = data;
            Message = message;
        }

        public HttpStatusCode Code
        {
            set;
            get;
        }

        public string Message
        {
            set;
            get;
        }

        public T Data
        {
            set;
            get;
        }
    }
}
