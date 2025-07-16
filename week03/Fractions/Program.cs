using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(2, 3);
        Fraction f4 = new Fraction(4, 3);

        Console.WriteLine($"{f1.GetFractionString()} = {f1.GetDecimalValue()}");

        f1.SetTop(2);
        f1.SetBottom(5);
        Console.WriteLine($"Top: {f1.GetTop()}, Bottom: {f1.GetBottom}");

        Console.WriteLine("\nFraction Representations:");
        Console.WriteLine($"{f1.GetFractionString()} = {f1.GetDecimalValue()}");
        Console.WriteLine($"{f2.GetFractionString()} = {f2.GetDecimalValue()}");
        Console.WriteLine($"{f3.GetFractionString()} = {f3.GetDecimalValue()}");
        Console.WriteLine($"{f4.GetFractionString()} = {f4.GetDecimalValue()}");

        Fraction f5 = new Fraction(0, 1);
        Console.WriteLine($"\n{f5.GetFractionString()} = {f5.GetDecimalValue()}");
    }
}