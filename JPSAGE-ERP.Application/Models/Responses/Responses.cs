using System;
using System.Collections.Generic;
using System.Text;

namespace JPSAGE_ERP.Application.Models.Responses
{
    public class ErrorResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T errors { get; set; }
    }

    public class SucessResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }

    public class FileUploadResult
    {
        public string FileName { get; set; }
        public string Url { get; set; }
    }

    public class BaseResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
    public static class Response<T>
    {
        public static BaseResponse InternalError(string exceptionMessage)
        {
            return new BaseResponse
            {
                success = false,
                message = exceptionMessage
            };
        }
    }
}
