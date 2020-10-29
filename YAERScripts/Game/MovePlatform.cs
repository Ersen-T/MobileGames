public static class MovePlatform
{
    public static int TriggerCount { get; private set; }

    public static void Count()
    {
        TriggerCount += 1;
    }

    public static void SetToZero()
    {
        TriggerCount = 0;
    }

    public static void SetToOne()
    {
        TriggerCount = 1;
    }
}
