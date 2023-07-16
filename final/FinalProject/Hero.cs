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

    public Hero()
    {}

    public void Loader(string line)
    {
        string[] parts = line.Split(",");

        _name = parts[0];
        _hP = int.Parse(parts[1]);
        _pla = int.Parse(parts[2]);
        _atk = int.Parse(parts[3]);
        _spe = parts[4];
        _def = int.Parse(parts[5]);
        _nameAlter = parts[6];
        _rec = int.Parse(parts[7]);
        _handSize = int.Parse(parts[8]);
        _altHandSize = int.Parse(parts[9]);
        _alterSpe = parts[10];
        _isHero = bool.Parse(parts[11]);
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

    public override string ExportData()
    {
        string data = "";
        data = $"{_name},{_hP},{_atk},{_pla},{_spe},{_def},{_nameAlter},{_rec},{_handSize},{_altHandSize},{_alterSpe},{_isHero}";
        return data;
    }
}