class Hero : Character
{
    string _nameAlter;
    int _rec;
    int _handSize;

    public Hero(string name, int hP, int pla, int atk, string spe, string nameAlter, int rec, int handSize) : base(name, hP, pla, atk, spe)
    {
        _nameAlter = nameAlter;
        _rec = rec;
        _handSize = handSize;
    }

    public string GetName()
    {
        return _name;
    }
}