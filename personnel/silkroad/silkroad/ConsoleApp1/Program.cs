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
if (CheckWay(silkyWay, (0, 0), hasPassed))
{
    Console.SetCursorPosition(0, 15);
    Console.WriteLine("Doable");
}

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

bool CheckWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed)
{
    if (pos.x == 7 && pos.y == 7) { return true; } //Win condition
    if (pos.x < 0 || pos.y < 0 || pos.x > 7 || pos.y > 7) { return false; } //Check border
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