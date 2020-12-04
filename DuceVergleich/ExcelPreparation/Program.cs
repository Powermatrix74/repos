using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zipcodeMatching;

namespace ExcelPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 --> Aymon
            Aymon aymon = new Aymon();
            Console.WriteLine("Aymon");
            //1. are all zip from Aymon excel contained
            aymon.CheckIfZipsAreContained();
            //2. are all zip codes in the correct region as defined by the zipcode master (territory in SF)
            string resultZipCodesAymon = aymon.matchZipCodesAgainstMaster();
            Console.WriteLine(resultZipCodesAymon);
            //3. are the SMA and SMD in the correct region as defined by Aymon excel
            string resultSmaSmdAymon = aymon.SmaSmdOkAll();
            Console.WriteLine(resultSmaSmdAymon);
            
            // 2 --> Kaempfer
            Kaempfer kaempfer = new Kaempfer();
            Console.WriteLine("Kaempfer");
            //1.are all zip from Kaempfer excel contained
            kaempfer.CheckIfZipsAreContained();
            //2. are all zip codes in the correct region as defined by the zipcode master
            string resultZipCodesKaempfer = kaempfer.matchZipCodesAgainstMaster();
            Console.WriteLine(resultZipCodesKaempfer);
            //3. are SMD and SMA correct
            string resultSmaSmdKaempfer = kaempfer.SmaSmdOkAll();
            Console.WriteLine(resultSmaSmdKaempfer);

            // 3 --> Verrienti and Bertschinger
            Console.WriteLine("Verrienti and Bertschinger");
            VerrientiBertschinger verrientiBertschinger = new VerrientiBertschinger();
            //1. are all zip from VerrientiAndBertschingerContained
            verrientiBertschinger.CheckIfZipsAreContained();
            //2. are all zip codes in the correct region according to master
            string resultZipCodesVerrientiBertschinger = verrientiBertschinger.matchZipCodesAgainstMaster();
            Console.WriteLine(resultZipCodesVerrientiBertschinger);
            //3. are all SMA and SMDs ok?
            string resultBertschingerVerrienti = verrientiBertschinger.SmaSmdOkAll();
            Console.WriteLine(resultBertschingerVerrienti);
            
            // 4 --> Zanello
            Zanello zanello = new Zanello();
            Console.WriteLine("Zanello");
            //1. check if all Zipcodes from Zanello are contained
            zanello.CheckIfZipCodesAreContained();
            //2. check if all zipcodes are in the correct area according to master zip file
            string resultZanellozipMatching = zanello.matchAllZipAgainstMaster();
            Console.WriteLine(resultZanellozipMatching);
            //3. check if all SMA and SMD are correctly assigned
            string resultZanello = zanello.SmaSmdOkAll();
            Console.WriteLine(resultZanello);
            
            Console.WriteLine("the end.");
            var result = Console.ReadKey();
        }
    }
}
