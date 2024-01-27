using Helpdesk.Core.Enums;

namespace Helpdesk.Core.ValueObjects;

public sealed record Role
{
    public RolesEnum Value { get; }

    public Role(RolesEnum value)
    {
        Value = value;
    }

    public static implicit operator string(Role role) => role.Value.ToString();
    public static implicit operator Role(int role) => new Role((RolesEnum)role);
    
}