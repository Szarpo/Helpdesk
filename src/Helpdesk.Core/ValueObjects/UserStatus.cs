using Helpdesk.Core.Enums;

namespace Helpdesk.Core.ValueObjects;

public sealed record UserStatus
{
    public UserStatusEnum Value { get; }

    public UserStatus(UserStatusEnum value)
    {

        Value = value;
    }

    public static implicit operator string(UserStatus userStatus) => userStatus.Value.ToString();
    public static implicit operator UserStatus(int userStatus) => new UserStatus((UserStatusEnum)userStatus);

}