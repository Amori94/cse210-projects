using System;

class Reference
{
    private List<string> allReferences = System.IO.File.ReadLines("References.txt").ToList();
    private int _userRef;

    public Reference(string userRef)
    {
        _userRef = int.Parse(userRef);
    }

    public Reference()
    {
        _userRef = 0;
    }

    public void ShowAllRef()
    {
        foreach (string r in allReferences)
        {
            List<string> splitRef = new List<string>(r.Split(";"));
            if (splitRef.Count() == 3)
            {
                string book = splitRef[0];
                string chapter = splitRef[1];
                string verse = splitRef[2];

                Console.WriteLine($"{book} {chapter}: {verse}");
            }
            else if (splitRef.Count() == 4)
            {
                string book = splitRef[0];
                string chapter = splitRef[1];
                string verse1 = splitRef[2];
                string verse2 = splitRef[3];
                Console.WriteLine($"{book} {chapter}: {verse1}-{verse2}");
            }
        }
    }

    public string GetUserRef()
    {
        string userFullRef = "";

        List<string> splitRef = new List<string>(allReferences[_userRef - 1].Split(";"));

        if (splitRef.Count() == 3)
        {
            string book = splitRef[0];
            string chapter = splitRef[1];
            string verse = splitRef[2];

            userFullRef = $"{book} {chapter}: {verse}\n";
        }
        else if (splitRef.Count() == 4)
        {
            string book = splitRef[0];
            string chapter = splitRef[1];
            string verse1 = splitRef[2];
            string verse2 = splitRef[3];

            userFullRef = $"{book} {chapter}: {verse1}-{verse2}\n";
        }

        return userFullRef;
    }
}