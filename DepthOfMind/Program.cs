using System.Text;

Draw("Press Enter to meditate");
var key = Console.ReadKey().Key;
Console.Clear();
Console.OutputEncoding = Encoding.UTF8;
Console.CursorVisible = false;
var rnd = new Random();
if (key == ConsoleKey.Enter)
{
    //for (int i = 10; i > 0; i--)
    //{
    //    var random = new Random();
    //    var roll = random.Next((i + 1) * 37, 1000);
    //    Console.Beep(roll, 100);
    //}
    var input = ConsoleKey.None;
    while (input != ConsoleKey.Enter)
    {
        if(Console.KeyAvailable)
        {
            input = Console.ReadKey(true).Key;
        }

        if (input == ConsoleKey.C)
            Console.SetCursorPosition(0, 0);

        var maxStreamLength = 91;
        var total = rnd.Next(1, maxStreamLength);
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
        if (input == ConsoleKey.M)
        {
            Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top + 1);
        }
        Thread.Sleep(100);
        input = ConsoleKey.None;
    }
}

void Draw(string text)
{
    var cursorPosition = Console.GetCursorPosition();
    Console.SetCursorPosition(Console.WindowWidth / 2 - (text.Length / 2), cursorPosition.Top);
    Console.WriteLine(text);
}