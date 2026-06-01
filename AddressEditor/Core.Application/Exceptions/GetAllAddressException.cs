namespace Core.Application.Exceptions
{
    public class GetAllAddressException : Exception
    {
        public GetAllAddressException(string message) : base(message) { }
        public GetAllAddressException(string message, Exception inner) : base(message, inner) { }
    }
}