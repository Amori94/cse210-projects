class Villain : Character
{
    public Villain(string name, int hP, int pla, int atk, string spe) : base(name, hP, pla, atk, spe)
    {
    }

    public Villain()
    {}

    public void Loader(String line)
    {
        string[] parts = line.Split(",");

        _name = parts[0];
        _hP = int.Parse(parts[1]);
        _pla = int.Parse(parts[2]);
        _atk = int.Parse(parts[3]);
        _spe = parts[4];
    }
}