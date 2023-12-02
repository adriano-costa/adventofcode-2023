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
        string digits = FilterNumeric(line);

        if (digits.Length == 0) continue;

        char[] tempNumber = { digits[0], digits[digits.Length - 1] };
        string lineNumber = new string(tempNumber);
        numberFromLine += Int32.Parse(lineNumber);
    }
    return numberFromLine;
}

static string FilterNumeric(string input)
{
    string pattern = @"\D";

    Regex regex = new Regex(pattern);
    string output = regex.Replace(input, "");

    return output;
}
