class Square : Shape
{
    private double _side;


    public Square(string color, double side) : base(color)
    {
        _color = color;
        _side = side;
        _shape = "square";
    }

    public override double GetArea()
    {
        double area = _side * _side;

        return area;
    }
}