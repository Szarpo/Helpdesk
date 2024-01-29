namespace Helpdesk.Core.Exceptions;

public abstract class CustomException : System.Exception
{
    protected CustomException(string message) : base(message)
    {
        
    }
}