using System;

namespace zipcodeMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Aymon aymon = new Aymon();
            aymon.Check();
            Kaempfer kaempfer = new Kaempfer();
            kaempfer.Check();
            VerrientiBertschinger verrientiBertschinger = new VerrientiBertschinger();
            verrientiBertschinger.Check();
            Zanello zanello = new Zanello();
            zanello.Check();

            Console.WriteLine("the end.");
        }
    }
}
