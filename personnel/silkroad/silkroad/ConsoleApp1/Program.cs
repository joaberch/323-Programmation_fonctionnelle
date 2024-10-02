bool[,] silkyWay = new bool[8, 8];
bool[,] hasPassed = new bool[8, 8];

silkyWay[0, 0] = true; // A1
silkyWay[7, 7] = true; // H8

for (int i = 0; i < 30; i++)
{
    Random random = new Random();
    int x;
    int y;
    do {
        x = random.Next(8);
        y = random.Next(8);
    } while (silkyWay[x, y]);

    silkyWay[x, y] = true;
}

DrawBoard(silkyWay);
bool[,] boardHasPassed = silkyWay;
CheckWay(silkyWay, (0, 0), hasPassed);

void DrawBoard(bool[,] board)
{
    Console.WriteLine("  12345678");
    Console.WriteLine(" ┌────────┐");
    for (char row = 'A'; row <= 'H'; row++)
    {
        Console.Write(row + "│");
        for (int col = 1; col <= 8; col++)
        {
            if (board[row - 'A', col - 1])
            {
                Console.Write("█");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine("│");
    }
    Console.WriteLine(" └────────┘");
}

void CheckWay(bool[,] board, (int x, int y) position, bool[,] hasPassed)
{
    hasPassed[position.x, position.y] = true;
    //Console.WriteLine($"{position}");
    //X + 1
    if (position.x < 7)
    {
        if (board[position.x + 1, position.y] && !hasPassed[position.x + 1, position.y])
        {
            CheckWay(board, (position.x + 1, position.y), hasPassed);
        }
    }
    //X - 1
    if (position.x >0)
    {
        if (board[position.x - 1, position.y] && !hasPassed[position.x - 1, position.y])
        {
            CheckWay(board, (position.x - 1, position.y), hasPassed);
        }
    }
    //Y + 1
    if(position.y < 7)
    {
        if (board[position.x, position.y + 1] && !hasPassed[position.x, position.y + 1])
        {
            CheckWay(board, (position.x, position.y + 1), hasPassed);
        }
    }
    //Y - 1
    if (position.y >0)
    {
        if(board[position.x, position.y - 1] && !hasPassed[position.x, position.y-1])
        {
            CheckWay(board, (position.x, position.y - 1), hasPassed);
        }
    }
    //X + 1 && Y + 1
    if (position.x < 7 && position.y < 7)
    {
        if (board[position.x + 1, position.y + 1] && !hasPassed[position.x + 1, position.y + 1])
        {
            CheckWay(board, (position.x + 1, position.y + 1), hasPassed);
        }
    }
    //X - 1 && Y - 1
    if (position.x > 0 && position.y > 0)
    {
        if (board[position.x - 1, position.y - 1] && !hasPassed[position.x - 1, position.y-1])
        {
            CheckWay(board, (position.x - 1, position.y - 1), hasPassed);
        }
    }
    //X + 1 && Y - 1
    if (position.y > 0 && position.x < 7)
    {
        if (board[position.x + 1, position.y - 1] && !hasPassed[position.x + 1, position.y - 1])
        {
            CheckWay(board, (position.x+1, position.y - 1), hasPassed);
        }
    }
    //X - 1 && Y + 1
    if (position.x > 0 && position.y < 7)
    {
        if (board[position.x - 1, position.y + 1] && !hasPassed[position.x - 1, position.y+1])
        {
            CheckWay(board, (position.x - 1, position.y + 1), hasPassed);
        }
    }
    //Check has arrived
    if (position.x == 7 && position.y == 7)
    {
        Console.WriteLine("Doable");
    }
}

// TODO Create a data structure that allow us to remember which square has already been tested

// TODO Create a data structure that allow us to remember the successful steps

// TODO Write the recursive function
// Recursive function that tells if we can reach H8 from the given position
// The algorithm is in fact simple to spell out (even in french ;)):
//
//      Je peux sortir depuis cette case si:
//          1. Je suis sur H8
//
//              ou
//
//          2. Je peux sortir depuis une des cases où je peux aller (et où je ne suis pas encore allé)

// TODO Call the function and show the results

Console.ReadLine();