using System.Drawing;

const int BOARDSIZE = 8;
bool[,] silkyWay = new bool[BOARDSIZE, BOARDSIZE];
bool[,] hasPassed;

silkyWay[0, 0] = true; // A1
silkyWay[BOARDSIZE-1, BOARDSIZE-1] = true; // H8

for (int i = 0; i < 4.5*BOARDSIZE; i++)
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

// Check doable by king
hasPassed = new bool[BOARDSIZE, BOARDSIZE]; // Reset value
if (CheckKingWay(silkyWay, (0, 0), hasPassed))
{
    Console.SetCursorPosition(0, 15);
    Console.WriteLine("Doable by king");
} else
{
    Console.SetCursorPosition(0, 15);
    Console.WriteLine("Not Doable by king");
}

// Check doable by horse
hasPassed = new bool[BOARDSIZE, BOARDSIZE]; // Reset value
if (CheckHorseWay(silkyWay, (0, 0), hasPassed))
{
	Console.SetCursorPosition(0, 16);
	Console.WriteLine("Doable by horse");
} else
{
    Console.SetCursorPosition(0, 16);
    Console.WriteLine("Not doable by horse");
}

// Check doable by tower
hasPassed = new bool[BOARDSIZE, BOARDSIZE]; // Reset value
if (CheckTowerWay(silkyWay, (0, 0), hasPassed))
{
    Console.SetCursorPosition(0, 17);
    Console.WriteLine("Doable by tower");
} else
{
    Console.SetCursorPosition(0, 17);
    Console.WriteLine("Not doable by tower");
}

// Check doable by bishop
hasPassed = new bool[BOARDSIZE, BOARDSIZE]; // Reset value
if (CheckBishopWay(silkyWay, (0, 0), hasPassed))
{
    Console.SetCursorPosition(0, 18);
    Console.WriteLine("Doable by bishop");
} else
{
    Console.SetCursorPosition(0, 18);
    Console.WriteLine("Not doable by bishop");
}

bool CheckBishopWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed)
{
	if (pos.x == BOARDSIZE - 1 && pos.y == BOARDSIZE - 1) { return true; } //Win condition
	if (pos.x < 0 || pos.y < 0 || pos.x > BOARDSIZE - 1 || pos.y > BOARDSIZE - 1) { return false; } //Check border
	if (hasPassed[pos.x, pos.y]) { return false; } //Check if has already passed
	if (!board[pos.x, pos.y]) { return false; } //Check is silky
	hasPassed[pos.x, pos.y] = true; //Mark as passed

    if (
        CheckBishopWay(board, (pos.x+1, pos.y+1), hasPassed) ||
		CheckBishopWay(board, (pos.x+1, pos.y-1), hasPassed) ||
		CheckBishopWay(board, (pos.x-1, pos.y+1), hasPassed) ||
		CheckBishopWay(board, (pos.x-1, pos.y-1), hasPassed)
		) { return true; } else { return false; }
}

bool CheckTowerWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed)
{
	if (pos.x == BOARDSIZE - 1 && pos.y == BOARDSIZE - 1) { return true; } //Win condition
	if (pos.x < 0 || pos.y < 0 || pos.x > BOARDSIZE - 1 || pos.y > BOARDSIZE - 1) { return false; } //Check border
	if (hasPassed[pos.x, pos.y]) { return false; } //Check if has already passed
	if (!board[pos.x, pos.y]) { return false; } //Check is silky
	hasPassed[pos.x, pos.y] = true; //Mark as passed

    if (
        CheckTowerWay(board, (pos.x+1, pos.y), hasPassed) ||
		CheckTowerWay(board, (pos.x-1, pos.y), hasPassed) ||
		CheckTowerWay(board, (pos.x, pos.y+1), hasPassed) ||
		CheckTowerWay(board, (pos.x, pos.y-1), hasPassed)
		) { return true; } else { return false; }
}

bool CheckHorseWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed)
{
	if (pos.x == BOARDSIZE - 1 && pos.y == BOARDSIZE - 1) { return true; } //Win condition
	if (pos.x < 0 || pos.y < 0 || pos.x > BOARDSIZE - 1 || pos.y > BOARDSIZE - 1) { return false; } //Check border
	if (hasPassed[pos.x, pos.y]) { return false; } //Check if has already passed
	if (!board[pos.x, pos.y]) { return false; } //Check is silky
	hasPassed[pos.x, pos.y] = true; //Mark as passed

    if (
        CheckHorseWay(board, (pos.x+2, pos.y+1), hasPassed) ||
        CheckHorseWay(board, (pos.x+1, pos.y+2), hasPassed)||
		CheckHorseWay(board, (pos.x - 1, pos.y + 2), hasPassed) ||
		CheckHorseWay(board, (pos.x - 2, pos.y + 1), hasPassed) ||
		CheckHorseWay(board, (pos.x - 2, pos.y -1), hasPassed) ||
		CheckHorseWay(board, (pos.x - 1, pos.y -2), hasPassed) ||
		CheckHorseWay(board, (pos.x + 1, pos.y - 2), hasPassed) ||
		CheckHorseWay(board, (pos.x + 2, pos.y -1), hasPassed)
		) { return true; } else { return false; }
}

void DrawBoard(bool[,] board)
{
    Console.Write("  ");
    for (int i = 1; i <= BOARDSIZE; ++i) { Console.Write(i); }
    Console.WriteLine();
    Console.Write(" ┌");
    for (int i = 1; i<= BOARDSIZE; ++i) { Console.Write("─"); }
    Console.WriteLine("┐");
    for (char row = 'A'; row <= (char)((char)'A'+(BOARDSIZE-1)); row++)
    {
        Console.Write(row + "│");
        for (int col = 1; col <= BOARDSIZE; col++)
        {
            if (board[row - 'A', col - 1])
            {
                if ((row - 'A' == 0 && col-1 == 0) || (row - 'A' == BOARDSIZE-1 && col - 1 == BOARDSIZE-1))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write("█");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine("│");
    }
	Console.Write(" └");
	for (int i = 1; i <= BOARDSIZE; ++i) { Console.Write("─"); }
	Console.WriteLine("┘");
}

bool CheckKingWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed)
{
    if (pos.x == BOARDSIZE-1 && pos.y == BOARDSIZE-1) { return true; } //Win condition
    if (pos.x < 0 || pos.y < 0 || pos.x > BOARDSIZE-1 || pos.y > BOARDSIZE - 1) { return false; } //Check border
    if (hasPassed[pos.x, pos.y]) { return false; } //Check if has already passed
    if (!board[pos.x, pos.y]) { return false; } //Check is silky
    hasPassed[pos.x, pos.y] = true; //Mark as passed

    //Console.SetCursorPosition(pos.y+2, pos.x+2);
    //Console.ForegroundColor = ConsoleColor.Red;
    //Console.Write("█");
    //Console.ForegroundColor = ConsoleColor.White;

    if (CheckKingWay(board, (pos.x + 1, pos.y), hasPassed) ||
    CheckKingWay(board, (pos.x, pos.y + 1), hasPassed) ||
    CheckKingWay(board, (pos.x - 1, pos.y), hasPassed) ||
    CheckKingWay(board, (pos.x, pos.y - 1), hasPassed) ||
    CheckKingWay(board, (pos.x + 1, pos.y + 1), hasPassed) ||
    CheckKingWay(board, (pos.x - 1, pos.y - 1), hasPassed) ||
    CheckKingWay(board, (pos.x + 1, pos.y - 1), hasPassed) ||
    CheckKingWay(board, (pos.x - 1, pos.y + 1), hasPassed)) { return true; }
    else { return false; }
}

Console.ReadLine();