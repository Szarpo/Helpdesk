using Helpdesk.Core.Exceptions;

namespace Helpdesk.Core.ValueObjects;

public sealed record Company
{
    public string Value { get; }

    public Company(string value)
    {

        if (string.IsNullOrWhiteSpace(value) || value.Length > 20)
        {
            throw new InvalidCompanyException(value);
        }
        
        Value = value;
    }

    public static implicit operator string(Company company) => company.Value;
    public static implicit operator Company(string company) => new Company(company);
}   