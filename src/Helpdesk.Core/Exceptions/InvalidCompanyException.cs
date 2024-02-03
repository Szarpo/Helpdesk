namespace Helpdesk.Core.Exceptions;

public class InvalidCompanyException : CustomException
{
    public string Company { get; }
    
    public InvalidCompanyException(string company) : base($"Company: {company} is invalid.")
    {

        Company = company;
    }
}