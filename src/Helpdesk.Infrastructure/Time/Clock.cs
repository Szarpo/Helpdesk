using Helpdesk.Core.Abstractions;

namespace Helpdesk.Infrastructure.Time;

public class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}