class Hero : Character
{
    int _def;
    string _nameAlter;
    int _rec;
    int _handSize;
    int _altHandSize;
    string _alterSpe;
    bool _isHero = false;

    public Hero(string name, int hP, int pla, int atk, string spe, int def, string nameAlter, int rec, int handSize, int altHandSize, string alterSpe) : base(name, hP, pla, atk, spe)
    {
        _def = def;
        _nameAlter = nameAlter;
        _rec = rec;
        _handSize = handSize;
        _altHandSize = altHandSize;
        _alterSpe = alterSpe;
    }

    public override string GetName()
    {   
        string name;
        if (_isHero)
        {
            name = _name;
        }
        else
        {
            name = _nameAlter;
        }
        return name;
    }

    public override string GetSpe()
    {   
        string spe;
        if (_isHero)
        {
            spe = _spe;
        }
        else
        {
            spe = _alterSpe;
        }
        return spe;
    }

    public void Change()
    {
        _isHero = !_isHero;
    }

    public bool IsHero()
    {
        return _isHero;
    }

    public int GetRec()
    {
        return _rec;
    }

    public int GetDef()
    {
        return _def;
    }
}