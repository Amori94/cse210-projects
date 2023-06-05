using System;

class Scripture
{
    private int _userScripture;
    //private string _scripture;

    public Scripture(string selector)
    {
        _userScripture = int.Parse(selector);
    }

    public string GetScripture()
    {
        string scripture = "";
        List<string> scriptures = System.IO.File.ReadLines("Scriptures.txt").ToList();

        scripture = scriptures[_userScripture - 1];
        return scripture;
    }

    public bool FullHidden(string scripture)
    {
        bool fullHidden = !scripture.Any(x => char.IsLetter(x));
        return fullHidden;
    }
}   