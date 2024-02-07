namespace Helpdesk.Core.Exceptions;

public sealed class UserIsNotActiveException : CustomException
{
    public string Value { get; }

    public UserIsNotActiveException(string message) : base($"{message}: needs to be activated.")
    {
        Value = message;
    }
}