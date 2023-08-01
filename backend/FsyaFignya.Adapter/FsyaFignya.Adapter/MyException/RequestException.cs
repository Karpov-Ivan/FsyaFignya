using System;

namespace FsyaFignya.Adapter.MyException
{
    public class RequestException : Exception
    {
        public RequestException() : base("Request failed.") { }

        public RequestException(string? message) : base(message) { }

        public RequestException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}