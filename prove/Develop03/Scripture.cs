using System;

class Scripture
{
    private int _userScripture;
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
}   