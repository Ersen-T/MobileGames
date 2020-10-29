public static class Vibration
{
    public static bool Status { get; private set; }

    public static void On()
    {
        Status = true;
    }

    public static void Off()
    {
        Status = false;
    }
}