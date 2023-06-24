class Shape
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

    public void SetColor(string color)
    {

    }

    public virtual double GetArea()
    {
        return 0;
    }

    public string GetShape()
    {
        return _shape;
    }

}