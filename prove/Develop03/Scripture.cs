using System;

class Scripture
{
    private int _userScripture;
    private string _scripture;
    private List<string> _scriptureList = new List<string>();
    private List<int> _excludedWords = new List<int>();

    public Scripture(string selector)
    {
        List<string> scriptures = System.IO.File.ReadLines("Scriptures.txt").ToList(); 
        _userScripture = int.Parse(selector);
        _scripture = scriptures[_userScripture - 1];

        foreach (string word in _scripture.Split(" "))
        {
            _scriptureList.Add(word);
        }        
    }

    public string GetScripture()
    {
        return _scripture;
    }

    public bool FullHidden()
    {
        bool fullHidden = !_scripture.Any(x => char.IsLetter(x));
        return fullHidden;
    }

    public List<string> GetScriptureList()
    {
        return _scriptureList;
    }

    public void SwapWord()
    {
        Random rnd = new Random();
        int rndNum;
        do
        {
            rndNum = rnd.Next(_scriptureList.Count());
        } while (_excludedWords.Contains(rndNum));

        Word currentWord = new Word(_scriptureList[rndNum]);
        
        if (currentWord.CheckHidden() == false)
        {                
            _scriptureList[rndNum] = currentWord.GetUnderscores();
        }
        _scripture = string.Join(" ", _scriptureList);

        _excludedWords.Add(rndNum);
    }
}   