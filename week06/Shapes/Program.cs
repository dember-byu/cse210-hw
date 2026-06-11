
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        List<Shape> shapes = new List<Shape>();

        
        Square square1 = new Square("Red", 4);
        Rectangle rectangle1 = new Rectangle("Blue", 5, 3);
        Circle circle1 = new Circle("Green", 2.5);

        
        shapes.Add(square1);
        shapes.Add(rectangle1);
        shapes.Add(circle1);

        
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            
            Console.WriteLine($"The {color} shape has an area of: {area:F2}");
        }
    }
}
