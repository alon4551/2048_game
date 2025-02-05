
using System.Drawing;
using System.Xml.Serialization;
Console.WriteLine("Wellcome to 2048 Console Game");
Console.WriteLine("Please enter the Dimationls:");
int H = int.Parse(Console.ReadLine());
Random random = new Random();
int[,] board = new int[H, H];
ConsoleColor GetTileColor(int value)
{
    return value switch
    {
        2 => ConsoleColor.DarkGray,
        4 => ConsoleColor.Gray,
        8 => ConsoleColor.Yellow,
        16 => ConsoleColor.DarkYellow,
        32 => ConsoleColor.Red,
        64 => ConsoleColor.DarkRed,
        128 => ConsoleColor.Green,
        256 => ConsoleColor.DarkGreen,
        512 => ConsoleColor.Cyan,
        1024 => ConsoleColor.Blue,
        2048 => ConsoleColor.Magenta,
        4096 => ConsoleColor.DarkMagenta,
        8192 => ConsoleColor.DarkBlue,
        16384 => ConsoleColor.DarkCyan,
        _ => ConsoleColor.Black // Default for larger numbers
    };
}
ConsoleColor GetTileForegroundColor(int value)
{
    return value switch
    {
        2 or 4 or 8 or 16 or 32 or 64 => ConsoleColor.Black, // Light backgrounds
        _ => ConsoleColor.White // Dark backgrounds
    };
}
void PrintMap()
{
    int big = board[0, 0];
    foreach(int number in board)
        if(number > big)
            big = number;
    
    for (int i = 0; i < board.GetLength(0); i++,Console.WriteLine())
        for (int j = 0; j < board.GetLength(1); j++)
        {
            Console.Write($"|");//{}
            Console.BackgroundColor =GetTileColor(board[i,j]);
            Console.ForegroundColor = GetTileForegroundColor(board[i,j]);  
            for (int k = 0; k < big.ToString().Length -board[i,j].ToString().Length; k++, Console.Write(" "));
            Console.Write(board[i, j]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor =ConsoleColor.White;
        }
}

bool IsBoardFilled()
{
    for(int i = 0;i<board.GetLength(0);i++)
        for(int j = 0;j < board.GetLength(1); j++)
            if (board[i,j] ==0)
                return false;
    return true;
}
void EnterRandomNumbers()
{
    int value = random.Next(1, 3) * 2;
    if (IsBoardFilled())
    {
        return;
    }
    do
    {
        int i = random.Next(0, board.GetLength(0)), j = random.Next(0, board.GetLength(1));
        if (board[i, j] == 0)
        {
            board[i, j] = value;
            return;
        }

    } while (true);
}


bool marge(string diraction)
{
    diraction = diraction.ToLower();
    bool move = false;
    switch (diraction)
    {
        case "up":
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0, k; j < board.GetLength(1); j++)
                {
                    bool add = false;
                    for (k = j + 1; k < board.GetLength(1); k++)
                    {
                        if (board[k, i] == 0)
                            continue;
                        else
                        {
                            if (board[j, i] == 0)
                            {
                                board[j, i] = board[k, i];
                                board[k, i] = 0;
                                move = true;
                            }
                            else if (board[j, i] != board[k, i] && board[k, i] != 0)
                            {
                                add = true;
                            }
                            else if (board[j, i] == board[k, i] && !add)
                            {
                                add = true;
                                board[j, i] *= 2;
                                board[k, i] = 0;
                                move = true;
                            }

                        }
                    }

                }
            break;
        case "down":
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = board.GetLength(1)-1, k; j >= 0; j--)
                {
                    bool add = false;
                    for (k = j - 1; k >= 0; k--)
                    {
                        if (board[k, i] == 0)
                            continue;
                        else
                        {
                            if (board[j, i] == 0)
                            {
                                board[j, i] = board[k, i];
                                board[k, i] = 0;
                                move = true;
                            }
                            else if (board[j, i] != board[k, i] && board[k, i] != 0)
                            {
                                add = true;
                            }
                            else if (board[j, i] == board[k, i] && !add)
                            {
                                add = true;
                                board[j, i] *= 2;
                                board[k, i] = 0;
                                move = true;
                            }

                        }
                    }

                }
            break;
        case "left":
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0, k; j < board.GetLength(1); j++)
                {
                    bool add = false;
                    for (k = j + 1; k < board.GetLength(1); k++)
                    {
                        if (board[i, k] == 0)
                            continue;
                        else
                        {
                            if (board[i, j] == 0)
                            {
                                board[i, j] = board[i, k];
                                board[i, k] = 0;
                                move = true;
                            }
                            else if (board[i, j] != board[i, k] && board[i, k] != 0)
                            {
                                add = true;
                            }
                            else if (board[i, j] == board[i, k] && !add)
                            {
                                add = true;
                                board[i, j] *= 2;
                                board[i, k] = 0;
                                move = true;
                            }

                        }
                    }

                }
            break;
        case "right":
            for (int i = 0; i < board.GetLength(1); i++)
                for (int j = board.GetLength(1)-1, k; j >= 0; j--)
                {
                    bool add = false;
                    for (k = j - 1; k >= 0; k--)
                    {
                        if (board[i, k] == 0)
                            continue;
                        else
                        {
                            if (board[i, j] == 0)
                            {
                                board[i, j] = board[i, k];
                                board[i, k] = 0;
                                move = true;
                            }
                            else if (board[i, j] != board[i, k] && board[i, k] != 0)
                            {
                                add = true;
                            }
                            else if (board[i, j] == board[i, k] && !add)
                            {
                                add = true;
                                board[i, j] *= 2;
                                board[i, k] = 0;
                                move = true;
                            }

                        }
                    }

                }
            break;
        default:
            return false;
    }
    return move;
}
bool verify()
{
    foreach (int number in board)
        if (number >= 2048)
            return true;
    return false;
}
bool move = true;
Console.Clear();
while (true)
{
    Console.WriteLine($"2048 {H}X{H}");
    if (move)
        EnterRandomNumbers();
    PrintMap();
    ConsoleKey result = Console.ReadKey().Key;
    if (result == ConsoleKey.Escape)
    {
        move = false;
        break;
    }
    if (result == ConsoleKey.UpArrow)
        move = marge("up");
    else if (result == ConsoleKey.DownArrow)
        move = marge("down");
    else if (result == ConsoleKey.LeftArrow)
        move = marge("left");
    else if (result == ConsoleKey.RightArrow)
        move = marge("right");
    else
        move = false;
    if (verify())
    {
        Console.WriteLine("you won the game");
        break;
    }
    else if (move == false)
    {
        bool check = true;
        foreach (int number in board)
            if (number ==0)
                check = false;
        if (check)
        {
            Console.WriteLine("you lost");
            break;
        }
    }
    Console.Clear();
}

