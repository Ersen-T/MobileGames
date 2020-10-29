public static class StateMachine
{
    public static States GameState { get; private set; }

    public static void SetState(States _state)
    {
        GameState = _state;
    }
}