class Hero : Character
{
    string _nameAlter;
    int _rec;
    int _handSize;
    string _alterSpe;
    bool _isHero = false;

    public Hero(string name, int hP, int pla, int atk, string spe, string nameAlter, int rec, int handSize, string alterSpe) : base(name, hP, pla, atk, spe)
    {
        _nameAlter = nameAlter;
        _rec = rec;
        _handSize = handSize;
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

}