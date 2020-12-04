using CoreCsharpProgramming.Classes;
using System;

namespace ConvertShortSFIdsToLong
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc c = new Calc();
            int ans = c.Add(10, 84);
            Console.WriteLine("10 + 84 is {0}.", ans);
            //Wait for user to press the Enter key
            Console.ReadLine();
        }
    }
}
