using System;

class Program
{
    static void Main(string[] args)
    {
        Square square1 = new Square("Red", 2.5);
        Rectangle rectangle1 = new Rectangle("Red", 2.5, 3);
        Circle circle1 = new Circle("Red", 2.5);
        List<Shape> shapes = new List<Shape>();

        shapes.Add(square1);
        shapes.Add(rectangle1);
        shapes.Add(circle1);

        Console.Clear();

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The color of the {shape.GetShape()} is {shape.GetColor()} and the area is {shape.GetArea()}\n");
        }

    }
}