using System;

class Program
{
    static void Main(string[] args)
    {
        Square s = new Square("Red", 4);
        Rectangle r = new Rectangle("Blue", 3, 5);
        Circle c = new Circle("Green", 2.5);

        Console.WriteLine("Single tests:");
        Console.WriteLine(s.GetColor() + " square area: " + s.GetArea());
        Console.WriteLine(r.GetColor() + " rectangle area: " + r.GetArea());
        Console.WriteLine(c.GetColor() + " circle area: " + c.GetArea());
        Console.WriteLine();

        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Yellow", 2));
        shapes.Add(new Rectangle("Purple", 2, 6));
        shapes.Add(new Circle("Orange", 3));

        Console.WriteLine("List test:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor() + " area: " + shape.GetArea());
        }
    }
}