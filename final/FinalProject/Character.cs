public abstract class Character
{
    protected string _name;
    int _hP;
    int _pla;
    int _atk;
    protected string _spe;

    public Character(string name, int hP, int pla, int atk, string spe)
    {
        _name = name;
        _hP = hP;
        _pla = pla;
        _atk = atk;
        _spe = spe;
    }

    public virtual string GetName()
    {
        return _name;
    }

    public int GetHP()
    {
        return _hP;
    }

    public int GetPla()
    {
        return _pla;
    }

    public int GetAtk()
    {
        return _atk;
    }

    public virtual string GetSpe()
    {
        return _spe;
    }

    public virtual void Damage(int points)
    {
        _hP = _hP - points;
    }

    public virtual void Recovery(int points)
    {
        _hP = _hP + points;
    }
}