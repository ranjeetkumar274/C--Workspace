using System;


namespace Project5.Exceptions
{
    public class BookAvailabilityException : Exception
    {
        public BookAvailabilityException(string msg):base(msg){}
    }
}