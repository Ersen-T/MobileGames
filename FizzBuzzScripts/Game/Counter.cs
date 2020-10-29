public static class Counter
{
    public static int CurrentNumber { get; private set; }

    public static void Count()
    {
        CurrentNumber += 1;
    }

    public static void SetToZero()
    {
        CurrentNumber = 0;
    }
}
