const int BOARDSIZE = 10;
bool[,] silkyWay = new bool[BOARDSIZE, BOARDSIZE];
bool[,] hasPassed = new bool[BOARDSIZE, BOARDSIZE];

silkyWay[0, 0] = true; // A1
silkyWay[BOARDSIZE-1, BOARDSIZE-1] = true; // H8

for (int i = 0; i < 4*BOARDSIZE; i++)
{
    Random random = new Random();
    int x;
    int y;
    do {
        x = random.Next(BOARDSIZE);
        y = random.Next(BOARDSIZE);
    } while (silkyWay[x, y]);

    silkyWay[x, y] = true;
}

DrawBoard(silkyWay);

bool[,] boardHasPassed = silkyWay;

//Check if doable
if (CheckWay(silkyWay, (0, 0), hasPassed))
{
    Console.SetCursorPosition(0, 15);
    Console.WriteLine("Doable");
}

void DrawBoard(bool[,] board)
{
    Console.Write("  ");
    for (int i = 1; i <= BOARDSIZE; ++i) { Console.Write(i); }
    Console.WriteLine();
    //Console.WriteLine("  12345678");
    Console.WriteLine(" ┌────────┐");
    for (char row = 'A'; row <= 'H'; row++)
    {
        Console.Write(row + "│");
        for (int col = 1; col <= BOARDSIZE; col++)
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

bool CheckWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed)
{
    if (pos.x == BOARDSIZE-1 && pos.y == BOARDSIZE-1) { return true; } //Win condition
    if (pos.x < 0 || pos.y < 0 || pos.x > BOARDSIZE-1 || pos.y > BOARDSIZE - 1) { return false; } //Check border
    if (hasPassed[pos.x, pos.y]) { return false; } //Check if has already passed
    if (!board[pos.x, pos.y]) { return false; } //Check is silky
    hasPassed[pos.x, pos.y] = true; //Make him pass here
    if (CheckWay(board, (pos.x + 1, pos.y), hasPassed) ||
    CheckWay(board, (pos.x, pos.y + 1), hasPassed) ||
    CheckWay(board, (pos.x - 1, pos.y), hasPassed) ||
    CheckWay(board, (pos.x, pos.y - 1), hasPassed) ||
    CheckWay(board, (pos.x + 1, pos.y + 1), hasPassed) ||
    CheckWay(board, (pos.x - 1, pos.y - 1), hasPassed) ||
    CheckWay(board, (pos.x + 1, pos.y - 1), hasPassed) ||
    CheckWay(board, (pos.x - 1, pos.y + 1), hasPassed)) { return true; }
    else { return false; }
}

Console.ReadLine();