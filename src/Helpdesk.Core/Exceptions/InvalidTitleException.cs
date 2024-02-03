namespace Helpdesk.Core.Exceptions;

public class InvalidTitleException : CustomException
{
    public string Title { get; }
    
    public InvalidTitleException(string title) : base($"Title: {title} is too long or empty")
    {
        
        Title = title;
    }
}