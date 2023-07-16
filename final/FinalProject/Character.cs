public abstract class Character
{
    protected string _name;
    protected int _hP;
    protected int _pla;
    protected int _atk;
    protected string _spe;

    public Character(string name, int hP, int pla, int atk, string spe)
    {
        _name = name;
        _hP = hP;
        _pla = pla;
        _atk = atk;
        _spe = spe;
    }

    public Character()
    {}

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

    public virtual string ExportData()
    {
        string data = "";
        data = $"{_name},{_hP},{_atk},{_pla},{_spe}";
        return data;
    }
}