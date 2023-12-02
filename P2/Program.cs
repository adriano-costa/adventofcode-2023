// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

string input = File.ReadAllText("input.txt");

Console.WriteLine(GetCalibrationValue(input));

int GetCalibrationValue(string input)
{
    string[] lines = Regex.Split(input, "\r\n|\r|\n");
    int numberFromLine = 0;
    foreach (var line in lines)
    {
        int first = findFirstNumber(line);
        int last = findLastNumber(line);

        if (first == -1 || last == -1) continue;

        string lineNumber = String.Concat(first, last);
        numberFromLine += Int32.Parse(lineNumber);
    }
    return numberFromLine;
}


int findFirstNumber(string text)
{
    for (var i = 0; i < text.Length; i++)
    {
        if (Char.IsDigit(text[i])) return Int32.Parse(text.Substring(i, 1));
        int spelledNumber = findSpelledNumber(text.Substring(0, i + 1));
        if (spelledNumber != -1) return spelledNumber;
    }

    return -1;
}

int findSpelledNumber(string text)
{
    (string, int)[] translation = new (string, int)[]
    {
        ("one", 1),
        ("two", 2),
        ("three", 3),
        ("four", 4),
        ("five", 5),
        ("six", 6),
        ("seven", 7),
        ("eight", 8),
        ("nine", 9)
    };

    foreach (var number in translation)
    {
        var numberPos = text.IndexOf(number.Item1);
        if (numberPos >= 0) return number.Item2;
    }

    return -1;
}

int findLastNumber(string text)
{
    for (var i = text.Length - 1; i >= 0; i--)
    {
        if (Char.IsDigit(text[i])) return Int32.Parse(text.Substring(i, 1));
        var spelledNumber = findSpelledNumber(text.Substring(i, text.Length - i));
        if (spelledNumber != -1) return spelledNumber;
    }

    return -1;
}
