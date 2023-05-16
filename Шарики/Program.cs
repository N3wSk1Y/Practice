namespace lines
{
    internal class Program
    {
        private static int fieldSize = 9;
        private static int[,] field = new int[fieldSize, fieldSize];
        private static int score = 0;
        private static int fieldPointX = 4,
            fieldPointY = 4;
        private static int firstPointX = -1,
            firstPointY = -1;
        private static int secondPointX = -2,
            secondPointY = -2;
        private static string label =
            @"                                                                                                                        
`7MMF' `7MMF' `7MMF'                                                    
  MM     MM     MM                                                      
  MM     MM     MM   ,6Yb. `7MMpdMAo.`7MMF'`7MMF'`7MM' ,M8 `7MMF'`7MMF'
  MM     MM     MM  8)   MM   MM   `Wb  MM   ,MM    MM  j     MM   ,MM  
  MM     MM     MM   ,pm9MM   MM    M8  MM ,' MM    MMmd      MM ,' MM  
  MM     MM     MM  8M   MM   MM   ,AP  MM'   MM    MM `M     MM'   MM  
.JMMmmmmmMMmmmmmMML.`Moo9^Yo. MMbmmd' .JMML..JMML..JMM. YMk .JMML..JMML.
                              MM                                        
                            .JMML.                                      
";

        static void CreateField(int ballsAmount)
        {
            Random random = new Random();
            int k,
                l;
            for (int i = 0; i < ballsAmount; )
            {
                k = random.Next(9);
                l = random.Next(9);
                if (field[k, l] == 0)
                {
                    field[k, l] = random.Next(7) + 1;
                    i++;
                }
            }
        }

        static void ShowTitle()
        {
            Console.CursorTop = 0;
            Console.CursorLeft = Console.BufferWidth / 2 - 3 + Console.BufferWidth % 2;
            Console.WriteLine("Шарики");
        }

        static void PrintField()
        {
            Console.Clear();
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            const string ball = "●";
            const string selectedBall = "★";
            const string empty = "■";
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 9; j++)
                {
                    if (firstPointX == j && firstPointY == i)
                    {
                        Console.ForegroundColor = (ConsoleColor)field[i, j];
                        Console.Write(" " + selectedBall);
                    }
                    else if (fieldPointX == j && fieldPointY == i)
                    {
                        Console.ForegroundColor = (ConsoleColor)field[i, j];
                        Console.Write(" " + empty);
                    }
                    else
                    {
                        Console.ForegroundColor = (ConsoleColor)field[i, j];
                        if (field[i, j] == 0)
                            Console.Write("  ");
                        else
                            Console.Write(" " + ball);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            ShowTitle();
            Console.CursorTop = 11;
            Console.WriteLine($"Счет: {score}");
        }

        static void BeginGame()
        {
            Console.Title = "Шарики";
            Console.CursorVisible = false;
        }

        static void StartGame()
        {
            Console.Clear();
            Console.WriteLine(label);

            Console.CursorTop = 15;
            Console.CursorLeft = 0;
            Console.Write("Сколько шариков должно появлятся [15-70]: ");
            int ballsAmount = Convert.ToInt32(Console.ReadLine());

            while (ballsAmount > 70 || ballsAmount < 15)
            {
                Console.Clear();
                Console.WriteLine(label);
                Console.CursorTop = 15;
                Console.CursorLeft = 0;
                Console.WriteLine("Введите число от 15 до 70");
                ballsAmount = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            int status;
            do
            {
                field = new int[9, 9];
                CreateField(ballsAmount);
                IsInLine();
                status = GetGameStatus();
            } while (status != 0);
        }

        static int UpdateGame()
        {
            int temp,
                gameStatus;
            score = 0;
            PrintField();
            ConsoleKeyInfo keyboardButton;
            do
            {
                keyboardButton = Console.ReadKey(true);
                switch (keyboardButton.Key)
                {
                    case ConsoleKey.A:
                        if (fieldPointX > 0)
                        {
                            if (
                                (firstPointX == -1 && firstPointY == -1)
                                || field[fieldPointY, fieldPointX - 1] == 0
                            )
                            {
                                fieldPointX--;
                            }
                        }
                        break;

                    case ConsoleKey.W:
                        if (fieldPointY > 0)
                        {
                            if (
                                (firstPointX == -1 && firstPointY == -1)
                                || field[fieldPointY - 1, fieldPointX] == 0
                            )
                            {
                                fieldPointY--;
                            }
                        }
                        break;

                    case ConsoleKey.D:
                        if (fieldPointX < 8)
                        {
                            if (
                                (firstPointX == -1 && firstPointY == -1)
                                || field[fieldPointY, fieldPointX + 1] == 0
                            )
                            {
                                fieldPointX++;
                            }
                        }
                        break;

                    case ConsoleKey.S:
                        if (fieldPointY < 8)
                        {
                            if (
                                (firstPointX == -1 && firstPointY == -1)
                                || field[fieldPointY + 1, fieldPointX] == 0
                            )
                            {
                                fieldPointY++;
                            }
                        }
                        break;

                    case ConsoleKey.Q:
                        if (field[fieldPointY, fieldPointX] != 0)
                        {
                            firstPointY = fieldPointY;
                            firstPointX = fieldPointX;
                        }
                        else
                        {
                            firstPointY = -1;
                            firstPointX = -1;
                        }
                        break;
                    case ConsoleKey.E:
                        if (
                            (fieldPointX != firstPointX || fieldPointY != firstPointY)
                            && firstPointY != -1
                            && firstPointX != -1
                        )
                        {
                            if (
                                (secondPointY == fieldPointY && secondPointX == fieldPointX)
                                || field[fieldPointY, fieldPointX] != 0
                            )
                            {
                                secondPointY = -2;
                                secondPointX = -2;
                            }
                            else
                            {
                                secondPointY = fieldPointY;
                                secondPointX = fieldPointX;
                            }
                        }
                        if (
                            firstPointX != -1
                            && firstPointY != -1
                            && secondPointX != -2
                            && secondPointY != -2
                        )
                        {
                            temp = field[firstPointY, firstPointX];
                            field[firstPointY, firstPointX] = 0;
                            field[secondPointY, secondPointX] = temp;
                            if (!IsInLine())
                            {
                                field[secondPointY, secondPointX] = 0;
                                field[firstPointY, firstPointX] = temp;
                            }
                            firstPointX = -1;
                            firstPointY = -1;
                            secondPointX = -2;
                            secondPointY = -2;
                        }
                        break;
                }
                PrintField();
                gameStatus = GetGameStatus();
            } while (gameStatus == 0);
            return gameStatus;
        }

        static bool IsInLine()
        {
            bool flag = false;
            int k;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (
                        i < 7
                        && field[i, j] == field[i + 1, j]
                        && field[i + 1, j] == field[i + 2, j]
                        && field[i, j] != 0
                    )
                    {
                        if (i < 6 && field[i + 2, j] == field[i + 3, j])
                        {
                            if (i < 5 && field[i + 3, j] == field[i + 4, j])
                            {
                                field[i, j] = 0;
                                field[i + 1, j] = 0;
                                field[i + 2, j] = 0;
                                field[i + 3, j] = 0;
                                field[i + 4, j] = 0;
                                score += 5;
                                flag = true;
                            }
                            else
                            {
                                field[i, j] = 0;
                                field[i + 1, j] = 0;
                                field[i + 2, j] = 0;
                                field[i + 3, j] = 0;
                                score += 4;
                                flag = true;
                            }
                        }
                        else
                        {
                            field[i, j] = 0;
                            field[i + 1, j] = 0;
                            field[i + 2, j] = 0;
                            score += 3;
                            flag = true;
                        }
                    }

                    if (
                        j < 7
                        && field[i, j] == field[i, j + 1]
                        && field[i, j + 1] == field[i, j + 2]
                        && field[i, j] != 0
                    )
                    {
                        if (j < 6 && field[i, j + 2] == field[i, j + 3])
                        {
                            if (j < 5 && field[i, j + 3] == field[i, j + 4])
                            {
                                field[i, j] = 0;
                                field[i, j + 1] = 0;
                                field[i, j + 2] = 0;
                                field[i, j + 3] = 0;
                                field[i, j + 4] = 0;
                                score += 5;
                                flag = true;
                            }
                            else
                            {
                                field[i, j] = 0;
                                field[i, j + 1] = 0;
                                field[i, j + 2] = 0;
                                field[i, j + 3] = 0;
                                score += 4;
                                flag = true;
                            }
                        }
                        else
                        {
                            field[i, j] = 0;
                            field[i, j + 1] = 0;
                            field[i, j + 2] = 0;
                            score += 3;
                            flag = true;
                        }
                    }

                    if (
                        j < 7
                        && i < 7
                        && field[i, j] == field[i + 1, j + 1]
                        && field[i + 1, j + 1] == field[i + 2, j + 2]
                        && field[i, j] != 0
                    )
                    {
                        if (j < 6 && i < 6 && field[i + 2, j + 2] == field[i + 3, j + 3])
                        {
                            if (j < 5 && i < 5 && field[i + 3, j + 3] == field[i + 4, j + 4])
                            {
                                field[i, j] = 0;
                                field[i + 1, j + 1] = 0;
                                field[i + 2, j + 2] = 0;
                                field[i + 3, j + 3] = 0;
                                field[i + 4, j + 4] = 0;
                                score += 5;
                                flag = true;
                            }
                            else
                            {
                                field[i, j] = 0;
                                field[i + 1, j + 1] = 0;
                                field[i + 2, j + 2] = 0;
                                field[i + 3, j + 3] = 0;
                                score += 4;
                                flag = true;
                            }
                        }
                        else
                        {
                            field[i, j] = 0;
                            field[i + 1, j + 1] = 0;
                            field[i + 2, j + 2] = 0;
                            score += 3;
                            flag = true;
                        }
                    }
                    k = 8 - i;
                    if (
                        k > 1
                        && j < 7
                        && field[k, j] == field[k - 1, j + 1]
                        && field[k - 1, j + 1] == field[k - 2, j + 2]
                        && field[k, j] != 0
                    )
                    {
                        if (j < 6 && k > 3 && field[k - 2, j + 2] == field[k - 3, j + 3])
                        {
                            if (j < 5 && k > 4 && field[k - 3, j + 3] == field[k - 4, j + 4])
                            {
                                field[k, j] = 0;
                                field[k - 1, j + 1] = 0;
                                field[k - 2, j + 2] = 0;
                                field[k - 3, j + 3] = 0;
                                field[k - 4, j + 4] = 0;
                                score += 5;
                                flag = true;
                            }
                            else
                            {
                                field[k, j] = 0;
                                field[k - 1, j + 1] = 0;
                                field[k - 2, j + 2] = 0;
                                field[k - 3, j + 3] = 0;
                                score += 4;
                                flag = true;
                            }
                        }
                        else
                        {
                            field[k, j] = 0;
                            field[k - 1, j + 1] = 0;
                            field[k - 2, j + 2] = 0;
                            score += 3;
                            flag = true;
                        }
                    }
                }
            }
            if (
                secondPointX != -2
                && (
                    (
                        secondPointY < 8
                        && field[secondPointY, secondPointX]
                            == field[secondPointY + 1, secondPointX]
                    )
                    || (
                        secondPointY < 8
                        && secondPointX < 8
                        && field[secondPointY, secondPointX]
                            == field[secondPointY + 1, secondPointX + 1]
                    )
                    || (
                        secondPointX < 8
                        && field[secondPointY, secondPointX]
                            == field[secondPointY, secondPointX + 1]
                    )
                    || (
                        secondPointY > 0
                        && secondPointX < 8
                        && field[secondPointY, secondPointX]
                            == field[secondPointY - 1, secondPointX + 1]
                    )
                    || (
                        secondPointY > 0
                        && field[secondPointY, secondPointX]
                            == field[secondPointY - 1, secondPointX]
                    )
                    || (
                        secondPointY > 0
                        && secondPointX > 0
                        && field[secondPointY, secondPointX]
                            == field[secondPointY - 1, secondPointX - 1]
                    )
                    || (
                        secondPointX > 0
                        && field[secondPointY, secondPointX]
                            == field[secondPointY, secondPointX - 1]
                    )
                    || (
                        secondPointY < 8
                        && secondPointX > 0
                        && field[secondPointY, secondPointX]
                            == field[secondPointY + 1, secondPointX - 1]
                    )
                )
            )
            {
                flag = true;
            }
            return flag;
        }

        static int GetGameStatus()
        {
            int counter;
            bool isEmpty = true;
            for (int i = 1; i < 8; i++)
            {
                counter = 0;
                foreach (int j in field)
                {
                    if (i == j)
                    {
                        counter++;
                        isEmpty = false;
                        if (counter > 2)
                            break;
                    }
                }
                if (counter == 1 || counter == 2)
                    return 1;
            }
            if (isEmpty)
                return 2;
            else
                return 0;
        }

        static void EndGame(int gameStatus)
        {
            Console.CursorTop = 10;
            // if (gameStatus == 1)
            //     Console.WriteLine($"Игра ");
            // else if (gameStatus == 2)
            //     Console.WriteLine($"Вы выиграли со счетом {score}");
            Console.WriteLine($"Игра закончена со счетом {score}.");
        }

        static void Main()
        {
            BeginGame();
            StartGame();
            EndGame(UpdateGame());
        }
    }
}
