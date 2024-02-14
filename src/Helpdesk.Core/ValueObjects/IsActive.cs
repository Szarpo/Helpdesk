using Helpdesk.Core.Enums;

namespace Helpdesk.Core.ValueObjects;

public sealed record IsActive
{
    public bool Value { get; }

    public IsActive(bool value)
    {

        Value = value;
    }

    public static implicit operator string(IsActive isActive) => isActive.Value.ToString();
    public static implicit operator IsActive(bool userStatus) => new IsActive(userStatus);

} 