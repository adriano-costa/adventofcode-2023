using System;
using System.Text.RegularExpressions;

string input = File.ReadAllText("input.txt");

IList<Tuple<int, int>> symbols = new List<Tuple<int, int>>();
Regex regexSymbol = new Regex("[^a-zA-Z0-9.]");

string[] lines = Regex.Split(input, "\r\n|\r|\n");

for (var i = 0; i < lines.Length; i++)
{
    for (var j = 0; j < lines[i].Length; j++)
    {
        var isSymbol = regexSymbol.IsMatch(lines[i][j].ToString());
        if (isSymbol) symbols.Add(new Tuple<int, int>(i, j));
    }
}
