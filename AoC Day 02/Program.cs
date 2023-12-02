using Utilities;

SolvePuzzleOneAndTwo();

void SolvePuzzleOneAndTwo()
{
    var data = DataLoader.GetStringDataFromFile();

    var power = 0;
    var sumGameIds = 0;

    foreach (var game in data)
    {
        var colors = new Dictionary<string, int>();
        var gameId = int.Parse(game.Substring(5, game.IndexOf(':') - 5));

        foreach (var draw in game.Substring(game.IndexOf(':') + 2).Split("; "))
        {
            foreach(var packs in draw.Split(", "))
            {
                var count = int.Parse(packs.Split(' ').First());
                var color = packs.Split(' ').Last();

                if (colors.ContainsKey(color))
                {
                    if (colors[color] < count)
                    {
                        colors[color] = count;
                    }
                }
                else
                {
                    colors.Add(color, count);
                }
            }
        }

        var setPower = 1;
        foreach (var set in colors)
        {
            setPower *= set.Value;
        }

        power += setPower;

        if (colors["red"] <= 12 && colors["green"] <= 13 && colors["blue"] <= 14)
            sumGameIds += gameId;
    }

    Console.WriteLine($"Réponse 1 : " + sumGameIds);
    Console.WriteLine($"Réponse 2 : " + power);
}