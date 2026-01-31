using System;


namespace Project3.Exceptions
{
    public class InvalidSalaryExc : Exception
    {
        public InvalidSalaryExc(string message) : base(message) { }
    }
}