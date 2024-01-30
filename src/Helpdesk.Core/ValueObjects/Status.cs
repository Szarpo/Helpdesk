using Helpdesk.Core.Enums;

namespace Helpdesk.Core.ValueObjects;

public sealed record Status
{
    public StatusesEnum Value { get; }

    public Status(StatusesEnum value)
    {
        Value = value;
    }

    public static implicit operator string(Status status) => status.Value.ToString();
    public static implicit operator Status(int status) => new Status((StatusesEnum)status);

}