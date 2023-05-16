namespace duel;

internal class Program
{
    static int[] inputCards()
    {
        int[] output = new int[3];
        string[] input;
        while (true)
        {
            Console.Write("Выберите карты и введите их через запятую: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            input = Console.ReadLine().Trim().Split(',');
            Console.ForegroundColor = ConsoleColor.Gray;
            if (input.Length == 3)
            {
                int i;
                for (i = 0; i < input.Length; i++)
                    if (Int32.TryParse(input[i], out int value) && (value > 0 && value < 6))
                        output[i] = value;
                    else
                    {
                        Console.WriteLine("Неверный формат ввода");
                        break;
                    }
                if (i == input.Length)
                    break;
            }
            else
                Console.WriteLine("Неверный формат ввода");
        }
        return output;
    }

    static void Main(string[] args)
    {
        Game game = new Game();
        Console.WriteLine("Карты 1 игрока:");
        Console.WriteLine(game.Pack1);
        int[] cardIndexes1 = inputCards();
        Console.WriteLine("Карты 2 игрока:");
        Console.WriteLine(game.Pack2);
        int[] cardIndexes2 = inputCards();
        game.createSoldiers(cardIndexes1, cardIndexes2);

        Console.WriteLine("Боец 1 игрока: ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(game.Soldier1);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Боец 2 игрока: ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(game.Soldier2);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        game.duel();

        Console.WriteLine(game.Result);
        Console.ReadKey();
    }
}
