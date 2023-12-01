using Utilities;

SolvePuzzleOne();
SolvePuzzleTwo();

void SolvePuzzleOne()
{
    var data = DataLoader.GetStringDataFromFile();

    var value = 0;

    foreach(var item in data)
        value += int.Parse(item.First(x => char.IsDigit(x)).ToString() + item.Last(x => char.IsDigit(x)));   

    Console.WriteLine($"Réponse 1 : " + value);
}

void SolvePuzzleTwo()
{
    var data = DataLoader.GetStringDataFromFile();

    var value = 0;

    foreach (var rawItem in data)
    {
        var item = insertDigits(rawItem);
        value += int.Parse(item.First(x => char.IsDigit(x)).ToString() + item.Last(x => char.IsDigit(x)));
    }

    Console.WriteLine($"Réponse 2 : " + value);
}

string insertDigits(string original, int startIndex = 0)
{
    var swapList = new Dictionary<string, string>()
    {
        {"one", "1" },
        {"two", "2" },
        {"three", "3" },
        {"four", "4" },
        {"five", "5" },
        {"six", "6" },
        {"seven", "7" },
        {"eight", "8" },
        {"nine", "9" },
    };

    var index = int.MaxValue;
    var item = new KeyValuePair<string, string>("", "");

    foreach (var number in swapList)
    {
        var keyIndex = original.IndexOf(number.Key, startIndex);

        if (keyIndex != -1 && keyIndex < index)
        {
            index = keyIndex;
            item = number;
        }
    }

    if (item.Key != "")
        original = insertDigits(original.Insert(index, item.Value), index + 2);

    return original;
}