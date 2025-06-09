using System;

class Program
{
    static void Main(string[] args)
    {
        Shape circle = new Circle("Red", 5);
        Shape rectangle = new Rectangle("Blue", 4, 6);
        Shape square = new Square("Green", 3);

        List<Shape> shapes = new List<Shape> { circle, rectangle, square };
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}