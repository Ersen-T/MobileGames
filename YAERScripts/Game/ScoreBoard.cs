public static class ScoreBoard
{
    public static int Score { get; private set; }

    public static void SetToZero()
    {
        Score = 0;
    }

    public static void SetScore()
    {
        Score += 100;
    }
}
