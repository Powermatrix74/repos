using System;

namespace RechnenAlina
{
    class Program
    {
        public class Operands
        {
            public Int32 Operator1 { get; set; }
            public Int32 Operator2 { get; set; }
            public char Operand { get; set; }

            public Int32 Calculate()
            {
                switch (Operand)
                {
                    case '+':
                        return Operator1 + Operator2;
                    case '-':
                        return Operator1 - Operator2;
                    case '*':
                        return Operator1 * Operator2;
                    case '/':
                        {
                            if( Operator2 != 0) return (Operator1 / Operator2);
                            return -1;
                        }
                    default :
                        return -1;
                }
            }

        }
        public static Operands ReadNextOperands()
        {
            Operands operands = new Operands();
            Console.WriteLine("Operator1 eingeben, x für Abbruch: ");
            var input1 = Console.ReadLine().ToString();
            Int32 finalOperator1;
            bool success = Int32.TryParse(input1, out finalOperator1);
            if (!success)
            {
                return null;
            }
            else
            {
                operands.Operator1 = finalOperator1;
            }
            Console.WriteLine("Operand eingeben: ");
            operands.Operand = Char.Parse(Console.ReadLine().ToString());
            Console.WriteLine("Operator2 eigeben");
            operands.Operator2 = Int32.Parse(Console.ReadLine().ToString());
            return operands;
        }

        static void Main(string[] args)
        {
            int operator1 = 0;
            int operator2 = 0;
            char operand = '+';
            if (args.Length == 0)
            {
                Console.WriteLine("bitte Zahl + Addieren/Subtrahieren/Multiplizieren eingeben");
            }
            if (args.Length > 0 && args[0] != "X")
            {
                if (args.Length == 3)
                {
                    bool successOperand1 = Int32.TryParse(args[0], out operator1);
                    if (successOperand1)
                    {
                        bool successOperand2 = Int32.TryParse(args[2], out operator2);
                        if (successOperand2)
                        {
                            _ = Char.TryParse(args[1], out operand);
                            switch (operand)
                            {
                                case '+':
                                    Console.WriteLine($"Das Ergebnis ist: {operator1 + operator2}");
                                    Console.ReadKey();
                                    break;
                                case '-':
                                    Console.WriteLine($"Das Ergebnis ist: {operator1 - operator2}");
                                    Console.ReadKey();
                                    break;
                                case '*':
                                    Console.WriteLine($"Das Ergebnis ist: {operator1 * operator2}");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("Ungültige Eingabe");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Fehler bei Operand2");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fehler bei Operand1");
                    }
                }
            }
            Operands operands = null;
            // loop now
            while ((operands = ReadNextOperands()) != null)
            {
                var result = operands.Calculate();
                Console.WriteLine("Das Ergebnis ist: " + result);
            }
        }
    }
}


