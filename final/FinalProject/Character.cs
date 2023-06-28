public abstract class Character
{
    protected string _name;
    int _hP;
    int _pla;
    int _atk;
    string _spe;

    public Character(string name, int hP, int pla, int atk, string spe)
    {
        _name = name;
        _hP = hP;
        _pla = pla;
        _atk = atk;
        _spe = spe;
    }
}