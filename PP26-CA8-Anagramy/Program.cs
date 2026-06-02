string[] lines = File.ReadAllLines("anagram.txt");

List<string> anagramLines = new List<string>();

foreach (string line in lines)
{
    string[] words = line.Split(' ');
    char[] chars = words[0].ToCharArray();

    bool isAnagram = true;
    for (int i = 1; i < words.Length; i++)
    {
        if (words[i].Length != words[0].Length)
        {
            isAnagram = false;
            break;
        }

        char[] testChars = words[i].ToCharArray();

        Array.Sort(chars);
        Array.Sort(testChars);
        if (!chars.SequenceEqual(testChars))
        {
            isAnagram = false;
            break;
        }
    }

    if (isAnagram)
    {
        anagramLines.Add(line);
    }
}

foreach (string anagramLine in anagramLines)
{
    Console.WriteLine(anagramLine);
}

File.WriteAllLines("znalezione.txt", anagramLines);