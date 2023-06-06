using System;

class Word
{
    private string _word;
    private bool _isHidden = false;

    public Word(string currentWord)
    {
        _word = currentWord;
        
        if((_word.Contains("_")) == true)
        {
            _isHidden = true;
        }
        else
        {
            _isHidden = false;
        }
    }

    public bool CheckHidden()
    {
        return _isHidden;
    }

    public string GetWord()
    {
        return _word;
    }

    public string GetUnderscores()
    {
        string underscores = "";
        
        foreach (char letter in _word)
        {
            underscores = underscores + "_";
        }

        return underscores;
    }

}