using Helpdesk.Core.Enums;

namespace Helpdesk.Core.ValueObjects;

public sealed record TicketStatus
{
    public TicketStatusEnum Value { get; }

    public TicketStatus(TicketStatusEnum value)
    {
        Value = value;
    }

    public static implicit operator string(TicketStatus ticketStatus) => ticketStatus.Value.ToString();
    public static implicit operator TicketStatus(int status) => new TicketStatus((TicketStatusEnum)status);

}