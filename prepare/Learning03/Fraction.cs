using System;

class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string strTop = _top.ToString();
        string strBot = _bottom.ToString();
        string fraction = strTop + "/" + strBot;
        return fraction;
    }

    public double GetDecimalValue()
    {
        double decNum = (double)_top / (double)_bottom;
        return decNum;
    }
}