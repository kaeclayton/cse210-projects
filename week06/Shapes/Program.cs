using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        Square square = new Square("green", 5);

        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        Rectangle rectangle = new Rectangle("blue", 10, 4);

        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());

        Circle circle = new Circle("orange", 7);

        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}