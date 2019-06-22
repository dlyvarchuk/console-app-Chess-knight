using System;
using System.Collections.Generic;

namespace ConsoleAppChessKnight
{
    class Program
    {
        static void Main()
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();

                Square start = null;
                Square end = null;
                bool correctStartSquare = false;
                bool correctEndSquare = false;

                while (!correctStartSquare)
                {
                    Console.Write("Enter Start chess square: ");
                    var fromSquare = Console.ReadLine();
                    try
                    {
                        start = new Square(fromSquare);
                        correctStartSquare = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Argument Exception: " + ex.Message);
                        correctStartSquare = false;
                    }
                }

                while (!correctEndSquare)
                {
                    Console.Write("Enter End chess square: ");
                    var toSquare = Console.ReadLine();
                    try
                    {
                        end = new Square(toSquare);
                        correctEndSquare = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Argument Exception: " + ex.Message);
                        correctEndSquare = false;
                    }
                }

                List<Square> calculatedSteps = KnightSteps.CalculateKnightSteps(start, end, new Knight());
                Console.WriteLine(KnightSteps.GetKnightSteps(calculatedSteps));
                Console.WriteLine("Press <Esc> key to quit or Any other key to continue...");
                cki = Console.ReadKey();
            }
            while (cki.Key != ConsoleKey.Escape);
        }
    }
}
