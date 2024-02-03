using Helpdesk.Core.Enums;

namespace Helpdesk.Core.ValueObjects;

public sealed record Role
{
    public RoleEnum Value { get; }

    public Role(RoleEnum value)
    {
        Value = value;
    }

    public static implicit operator string(Role role) => role.Value.ToString();
    public static implicit operator Role(int role) => new Role((RoleEnum)role);
    
}