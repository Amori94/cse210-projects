public abstract class Shape
{
    protected string _color;
    protected string _shape;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public abstract double GetArea();

    public string GetShape()
    {
        return _shape;
    }

}