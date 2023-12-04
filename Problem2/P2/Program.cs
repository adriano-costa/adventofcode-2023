using System;
using System.Text.RegularExpressions;

string input = File.ReadAllText("input.txt");

Regex regexForRed = new Regex(@"(\d+) red");
Regex regexForGreen = new Regex(@"(\d+) green");
Regex regexForBlue = new Regex(@"(\d+) blue");

string[] lines = Regex.Split(input, "\r\n|\r|\n");
int sumPowerSets = 0;
foreach (var line in lines)
{
    string[] splitGameId = line.Split(":");
    if (splitGameId.Length < 2) continue;

    string gamesString = splitGameId[1];
    string[] games = gamesString.Split(";");

    int minimumRed = 1;
    int minimumGreen = 1;
    int minimumBlue = 1;
    foreach (var game in games)
    {
        var redMath = regexForRed.Match(game).Groups[1].Value;
        int red = redMath == "" ? 0 : int.Parse(redMath);
        var greenMath = regexForGreen.Match(game).Groups[1].Value;
        int green = greenMath == "" ? 0 : int.Parse(greenMath);
        var blueMath = regexForBlue.Match(game).Groups[1].Value;
        int blue = blueMath == "" ? 0 : int.Parse(blueMath);

        if (red > minimumRed) minimumRed = red;
        if (green > minimumGreen) minimumGreen = green;
        if (blue > minimumBlue) minimumBlue = blue;
    }


    sumPowerSets += minimumRed * minimumGreen * minimumBlue;
}

Console.WriteLine(sumPowerSets);
