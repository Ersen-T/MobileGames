public static class StateMachine
{
    public static State CurrentState { get; set; }

    public static bool CheckState(State _state)
    {
        if (CurrentState == _state)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
