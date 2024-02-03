using Helpdesk.Core.Enums;

namespace Helpdesk.Core.ValueObjects;

public sealed record State
{
    public StateEnum Value { get; }

    public State(StateEnum value)
    {
        
        Value = value;
    }

    public static implicit operator string(State state) => state.Value.ToString();
    public static implicit operator State(int state) => new State((StateEnum)state);

}