namespace Helpdesk.Core.Exceptions;

public sealed class IdNotExist : CustomException
{
    public string Content { get; }
    
    public IdNotExist(string content) : base($"{content} not exist.")
    {
        Content = content;
    }
}