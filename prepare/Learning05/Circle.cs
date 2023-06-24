class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _color = color;
        _radius = radius;
        _shape = "circle";
    }

    public override double GetArea()
    {
        double pi = Math.PI;
        double area = pi * (_radius*_radius);

        return area;
    }
}