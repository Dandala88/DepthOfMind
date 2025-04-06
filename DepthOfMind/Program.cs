using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

int depth = 5000;
int depthWin = 50000;
List<char> thoughts = new List<char>();
while (true)
{
    Console.Clear();
    Console.SetCursorPosition(0, 0);
    DrawMenu();
    var key = Console.ReadKey(true).Key;
    Console.OutputEncoding = Encoding.UTF8;
    Console.CursorVisible = false;
    var rnd = new Random();
    if (key == ConsoleKey.Enter)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        var input = ConsoleKey.None;
        var lastWidth = 1;
        var scaling = 6;
        var pitch = 136;
        Task.Run(() => Console.Beep(pitch, depth));
        var elapsed = 0;
        var tick = 100;
        var thought = ' ';
        var tempDepth = 0;

        Task? soundTask = null;
        Task? ohmSoundTask = null;
        while (elapsed < depth)
        {
            if (Console.KeyAvailable)
            {
                var tempInput = Console.ReadKey(true).Key;
                var influenceScale = rnd.Next(31, 1000);
                thought = (char)(influenceScale);
                if (thought < 37) thought = (char)37;
                soundTask = Task.Run(() => Console.Beep(thought, 100));
                thoughts.Add(thought);
            }
            if (soundTask != null && soundTask.IsCompleted)
            {
                soundTask = null;
                ohmSoundTask = Task.Run(() => Console.Beep(pitch, depth - elapsed));
            }

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
                {
                    var nextChar = (char)rnd.Next(31, 1000);
                    //If I want an end but maybe just want to capture all characters
                    //if (depth > depthWin)
                    //    nextChar = (char)0x03A9;
                    if (thoughts.Contains(nextChar))
                    {
                        nextChar = (char)0x03A9;
                        tempDepth += 10;
                    }


                    nextStream += nextChar;
                }
            }
            SetRndTextColor();
            Draw(nextStream);
            Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top - 1);
            Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top + 1);
            lastWidth = total;

            Task.Delay(tick).Wait();
            elapsed += tick;
        }
        depth += tempDepth;
        soundTask = null;
    }
}
void Draw(string text)
{
    var cursorPosition = Console.GetCursorPosition();
    Console.SetCursorPosition(Console.WindowWidth / 2 - (text.Length / 2), cursorPosition.Top);
    Console.WriteLine(text);
}

void DrawMenu()
{
    var rnd = new Random();
    var titleText = "Depth of Mind\n";
    Console.SetCursorPosition(Console.WindowWidth / 2 - (titleText.Length / 2), Console.WindowHeight / 2);
    Console.WriteLine(titleText);
    var enterText = "Press Enter to meditate.";
    var cursorPosition = Console.GetCursorPosition();
    Console.SetCursorPosition(Console.WindowWidth / 2 - (enterText.Length / 2), Console.GetCursorPosition().Top);
    Console.WriteLine(enterText);
    var depthText = $"Depth: {depth}";
    Console.SetCursorPosition(Console.WindowWidth / 2 - (depthText.Length / 2), Console.GetCursorPosition().Top);
    Console.WriteLine($"Depth: {depth}");
    foreach (var thought in thoughts)
    {
        SetRndTextColor();
        Console.Write(thought);
    }
}

void SetRndTextColor()
{
    var rnd = new Random();

    var color = rnd.Next(0, 15);
    if ((ConsoleColor)color != Console.BackgroundColor)
    {
        Console.ForegroundColor = (ConsoleColor)color;
    }
}