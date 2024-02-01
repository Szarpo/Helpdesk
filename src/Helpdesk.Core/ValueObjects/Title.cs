using Helpdesk.Core.Exceptions;

namespace Helpdesk.Core.ValueObjects;

public sealed record Title
{
    public string Value { get; }

    public Title(string value)
    {

        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
        {
            throw new InvalidTitleException(value);
        }

        Value = value;
    }

    public static implicit operator string(Title title) => title.Value;
    public static implicit operator Title(string title) => new Title(title);
}