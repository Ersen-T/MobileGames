public static class FizzBuzzChecker
{
    public static Bubble Check()
    {
        if (Counter.CurrentNumber % 3 == 0 && Counter.CurrentNumber % 5 == 0)
        {
            // FizzBuzz
            return Bubble.FizzBuzz;
        }
        else if (Counter.CurrentNumber % 3 == 0)
        {
            //Fizz
            return Bubble.Fizz;
        }
        else if (Counter.CurrentNumber % 5 == 0)
        {
            // Buzz
            return Bubble.Buzz;
        }
        else
        {
            //Next
            return Bubble.Next;
        }
    }

    //public static int Check()
    //{
    //    if (Counter.CurrentNumber % 3 == 0 && Counter.CurrentNumber % 5 == 0)
    //    {
    //        // FizzBuzz
    //        return 4;
    //    }
    //    else if (Counter.CurrentNumber % 3 == 0)
    //    {
    //        //Fizz
    //        return 2;
    //    }
    //    else if (Counter.CurrentNumber % 5 == 0)
    //    {
    //        // Buzz
    //        return 3;
    //    }
    //    else
    //    {
    //        //Next
    //        return 1;
    //    }
    //}
}
