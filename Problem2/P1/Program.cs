using System;
using System.Text.RegularExpressions;

string input = File.ReadAllText("input.txt");

int validQtdRed = 12;
int validQtdGreen = 13;
int validQtdBlue = 14;

Regex regexForId = new Regex(@"Game (\d+):");
Regex regexForRed = new Regex(@"(\d+) red");
Regex regexForGreen = new Regex(@"(\d+) green");
Regex regexForBlue = new Regex(@"(\d+) blue");

string[] lines = Regex.Split(input, "\r\n|\r|\n");
int sumValidGameIds = 0;
foreach (var line in lines)
{
    var matchID = regexForId.Match(line).Groups[1].Value;
    int id = matchID == "" ? 0 : int.Parse(matchID);
    if (id == 0) continue;

    string[] splitGameId = line.Split(":");
    string gamesString = splitGameId[1];
    string[] games = gamesString.Split(";");
    bool validGame = true;
    foreach (var game in games)
    {
        var redMath = regexForRed.Match(game).Groups[1].Value;
        int red = redMath == "" ? 0 : int.Parse(redMath);
        var greenMath = regexForGreen.Match(game).Groups[1].Value;
        int green = greenMath == "" ? 0 : int.Parse(greenMath);
        var blueMath = regexForBlue.Match(game).Groups[1].Value;
        int blue = blueMath == "" ? 0 : int.Parse(blueMath);
        if (red > validQtdRed || green > validQtdGreen || blue > validQtdBlue)
        {
            validGame = false;
            break;
        }
    }

    if (!validGame) continue;

    sumValidGameIds += id;
}

Console.WriteLine(sumValidGameIds);
