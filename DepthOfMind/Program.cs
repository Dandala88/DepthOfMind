using System.Text;
using static System.Net.Mime.MediaTypeNames;

int depth = 5000;
start:
Console.Clear();
Console.SetCursorPosition(0, 0);
DrawMenu();
var key = Console.ReadKey().Key;
Console.OutputEncoding = Encoding.UTF8;
Console.CursorVisible = false;
var rnd = new Random();
if (key == ConsoleKey.Enter)
{
    Console.Clear();
    Console.SetCursorPosition(0, 0);
    var input = ConsoleKey.None;
    var lastWidth = 1;
    var scaling = 4;
    var keyPressed = false;
    Task.Run(() => Console.Beep(136, depth));
    var elapsed = 0;
    var tick = 100;
    while (input != ConsoleKey.Enter && elapsed < depth)
    {
        if (Console.KeyAvailable)
        {
            if (!keyPressed)
            {
                keyPressed = true;
                input = Console.ReadKey(true).Key;
            }
        }
        else
            keyPressed = false;

            var maxStreamLength = lastWidth + scaling;
        var minStreamLength = lastWidth - scaling;
        if (minStreamLength <= 0) minStreamLength = 1;
        var total = rnd.Next(minStreamLength, maxStreamLength);
        var nextStream = string.Empty;
        for (int i = 0; i < maxStreamLength; i++)
        {
            var min = (maxStreamLength / 2) - (total / 2); 
            var max = (maxStreamLength / 2) + (total / 2);
            if (i < min || i > max) 
                nextStream += " ";
            else
                nextStream += (char)rnd.Next(33, 10000);
        }
        var color = rnd.Next(0, 15);
        Console.ForegroundColor = (ConsoleColor)color;
        Draw(nextStream);
        Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top - 1);
        Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top + 1);
        lastWidth = total;

        Task.Delay(tick).Wait();
        elapsed += tick;
        if(input != ConsoleKey.Enter)
            input = ConsoleKey.None;
    }
    goto start;
}

void Draw(string text)
{
    var cursorPosition = Console.GetCursorPosition();
    Console.SetCursorPosition(Console.WindowWidth / 2 - (text.Length / 2), cursorPosition.Top);
    Console.WriteLine(text);
}

void DrawMenu()
{
    var enterText = "Press Enter to meditate.";
    var cursorPosition = Console.GetCursorPosition();
    Console.SetCursorPosition(Console.WindowWidth / 2 - (enterText.Length / 2), Console.WindowHeight / 2);
    Console.WriteLine(enterText);
    Console.SetCursorPosition(Console.WindowWidth / 2 - (enterText.Length / 2), Console.GetCursorPosition().Top);
    Console.WriteLine($"Depth: {depth}");
}