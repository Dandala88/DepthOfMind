using System.Text;

Console.SetCursorPosition(Console.WindowWidth / 2, 0);

Console.WriteLine("Press Enter to meditate");
var key = Console.ReadKey().Key;
Console.Clear();
Console.OutputEncoding = Encoding.UTF8;
Console.CursorVisible = false;
var depth = 0;
var stream = "";
if (key == ConsoleKey.Enter)
{
    for(int i = 10; i > 0; i--)
    {
        var random = new Random();
        var roll = random.Next(37, 1000);
        Console.Beep((i + 1) * 100, 100);
    }
    var action = "";
    var input = ConsoleKey.None;
    while (action.ToLower() != "exit")
    {
        Console.WriteLine("Ohm.");
        Console.WriteLine($"Depth: {depth}");
        Console.WriteLine($"Stream: {stream}");
        if (Console.KeyAvailable)
        {
            input = Console.ReadKey(true).Key;
        }
        if(input == ConsoleKey.T)
        {
            Console.WriteLine("What are you thinking?");
            var thought = Console.ReadLine();
            if (string.IsNullOrEmpty(thought))
            {
                depth++;
                Console.WriteLine("Clear mind is a deep mind.");
            }
            else
            {
                var total = 0;
                for (int i = 0; i < thought.Length; i++)
                {
                    total += thought[i];
                }

                while (total > 999)
                    total /= 2;
                stream += (char)total;
            }
            Console.WriteLine("Press enter to continue.");
            while (input != ConsoleKey.Enter)
                input = Console.ReadKey(true).Key;
            Console.Clear();
        }
        if(input == ConsoleKey.C)
        {
            var currentChar = 33;
            while (input != ConsoleKey.Enter)
            {
                Console.Write((char)currentChar);
                currentChar++;
                if(currentChar > 50000)
                    currentChar =33;
                if (Console.KeyAvailable)
                {
                    input = Console.ReadKey(true).Key;
                }
                var cursorPosition = Console.GetCursorPosition();
                Console.SetCursorPosition(0, cursorPosition.Top);
            }
            Console.WriteLine("Press enter to continue.");
            while (input != ConsoleKey.Enter)
                input = Console.ReadKey(true).Key;
            Console.Clear();
        }

        input = ConsoleKey.None;
        Console.SetCursorPosition(0, 0);
    }
}