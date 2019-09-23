using System;
using System.IO;


namespace FunctionalTestCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = new string(@"c:\textreader\readme.txt");
            string text = new StreamReader(path).Using(stream => stream.ReadToEnd());
            Console.WriteLine("text output: " + text);
            var end = Console.ReadKey();
        }
    }
}
