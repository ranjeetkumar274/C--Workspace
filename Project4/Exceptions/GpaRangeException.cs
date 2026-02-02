using System;

namespace Project4.Exceptions
{
    public class GpaRangeException : Exception
    {
        public GpaRangeException(string Message):base(Message){}
    }
}