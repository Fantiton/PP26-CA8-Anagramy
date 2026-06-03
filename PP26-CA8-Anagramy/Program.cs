string path = Path.Combine(Environment.CurrentDirectory, "../", "../", "../");

//Zadanie 1
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
Console.WriteLine();

File.WriteAllLines(Path.Combine(path, "znalezione.txt"), anagramLines);



//Zadanie 1.1
string[] years = File.ReadAllLines("lata.txt");
List<(string year, int count)> grouppedYears = new List<(string year, int count)>();

foreach(string year in years)
{
    if(grouppedYears.Any(x => x.year == year))
    {
        int groupIndex = grouppedYears.FindIndex(x => x.year == year);
        grouppedYears[groupIndex] = (year, grouppedYears[groupIndex].count + 1);
    }
    else
    {
        grouppedYears.Add((year, 1));
    }
}

(string year, int count) max = grouppedYears[0];

foreach (var item in grouppedYears)
{
    if (item.count > max.count)
    {
        max = item;
    }
}

Console.WriteLine($"Najczęściej występuje rok {max.year} ({max.count} razy)");
File.WriteAllText(Path.Combine(path, "ramy.txt"), $"Najczęściej występuje rok {max.year} ({max.count} razy)");



//Zadanie 1.2
string[] paintings = File.ReadAllLines("lista.txt");

for (int i = 0; i < paintings.Length - 1; i++)
{
    for (int j = 0; j < paintings.Length - i - 1; j++)
    {
        int first = int.Parse(paintings[j].Substring(0, 3));
        int second = int.Parse(paintings[j + 1].Substring(0, 3));

        if (first < second)
        {
            string temp = paintings[j];
            paintings[j] = paintings[j + 1];
            paintings[j + 1] = temp;
        }
    }
}

File.WriteAllLines(Path.Combine(path, "kolejność.txt"), paintings);