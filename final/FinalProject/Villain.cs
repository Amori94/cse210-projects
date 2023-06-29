class Villain : Character
{
    int _phase;

    public Villain(string name, int hP, int pla, int atk, string spe, string difficulty) : base(name, hP, pla, atk, spe)
    {
        _phase = 1;
    }
}