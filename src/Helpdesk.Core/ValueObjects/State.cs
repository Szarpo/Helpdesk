using Helpdesk.Core.Enums;

namespace Helpdesk.Core.ValueObjects;

public sealed record State
{
    public StatesEnum Value { get; }

    public State(StatesEnum value)
    {
        
        Value = value;
    }

    public static implicit operator string(State state) => state.Value.ToString();
    public static implicit operator State(int state) => new State((StatesEnum)state);

}