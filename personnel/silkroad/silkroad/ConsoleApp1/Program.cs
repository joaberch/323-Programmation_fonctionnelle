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
if (CheckKingWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false))
{
    Console.SetCursorPosition(0, 15);
    Console.WriteLine("Doable by king");
} else
{
    Console.SetCursorPosition(0, 15);
    Console.WriteLine("Not Doable by king");
}

// Check doable by horse
if (CheckHorseWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false))
{
	Console.SetCursorPosition(0, 16);
	Console.WriteLine("Doable by horse");
} else
{
    Console.SetCursorPosition(0, 16);
    Console.WriteLine("Not doable by horse");
}

// Check doable by tower
if (CheckTowerWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false))
{
    Console.SetCursorPosition(0, 17);
    Console.WriteLine("Doable by tower");
} else
{
    Console.SetCursorPosition(0, 17);
    Console.WriteLine("Not doable by tower");
}

// Check doable by bishop
if (CheckBishopWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false))
{
    Console.SetCursorPosition(0, 18);
    Console.WriteLine("Doable by bishop");
} else
{
    Console.SetCursorPosition(0, 18);
    Console.WriteLine("Not doable by bishop");
}

//Display path
Console.SetCursorPosition(0, 20);
Console.Write("Display path of (0) Nothing, (1) King, (2) Horse, (3) Tower, (4) Bishop : ");
while (true)
{
    int input = 5;
    while (input<0||input>4)
    {
        Console.SetCursorPosition(74, 20);
        input = Convert.ToInt32(Console.ReadKey().Key-48);
    }
    switch (input)
    {
        case 0:
			CheckKingWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckHorseWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckTowerWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckBishopWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			break;
        case 1:
            CheckHorseWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
            CheckTowerWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
            CheckBishopWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckKingWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], true);
			break;
        case 2:
			CheckKingWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckTowerWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckBishopWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckHorseWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], true);
			break;
		case 3:
			CheckKingWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckHorseWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckBishopWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckTowerWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], true);
			break;
		case 4:
			CheckKingWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckHorseWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckTowerWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], false);
			CheckBishopWay(silkyWay, (0, 0), new bool[BOARDSIZE, BOARDSIZE], true);
			break;
	}
}

void DrawPath(bool colorPath, int x, int y)
{
	Console.SetCursorPosition(y, x);
	if (colorPath)
	{
		Console.ForegroundColor = ConsoleColor.Red;
	}
	else
	{
		Console.ForegroundColor = ConsoleColor.White;
	}
	Console.Write("█");

	Console.ForegroundColor = ConsoleColor.White;
}

bool CheckBishopWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed, bool displayPath)
{
	if (pos.x == BOARDSIZE - 1 && pos.y == BOARDSIZE - 1) { return true; } //Win condition
	if (pos.x < 0 || pos.y < 0 || pos.x > BOARDSIZE - 1 || pos.y > BOARDSIZE - 1) { return false; } //Check border
	if (hasPassed[pos.x, pos.y]) { return false; } //Check if has already passed
	if (!board[pos.x, pos.y]) { return false; } //Check is silky
	hasPassed[pos.x, pos.y] = true; //Mark as passed

	DrawPath(displayPath, pos.x+2, pos.y+2);

	if (
        CheckBishopWay(board, (pos.x+1, pos.y+1), hasPassed, displayPath) ||
		CheckBishopWay(board, (pos.x+1, pos.y-1), hasPassed, displayPath) ||
		CheckBishopWay(board, (pos.x-1, pos.y+1), hasPassed, displayPath) ||
		CheckBishopWay(board, (pos.x-1, pos.y-1), hasPassed, displayPath)
		) { return true; }
	hasPassed[pos.x, pos.y] = false;
	return false;
}

bool CheckTowerWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed, bool displayPath)
{
	if (pos.x == BOARDSIZE - 1 && pos.y == BOARDSIZE - 1) { return true; } //Win condition
	if (pos.x < 0 || pos.y < 0 || pos.x > BOARDSIZE - 1 || pos.y > BOARDSIZE - 1) { return false; } //Check border
	if (hasPassed[pos.x, pos.y]) { return false; } //Check if has already passed
	if (!board[pos.x, pos.y]) { return false; } //Check is silky
	hasPassed[pos.x, pos.y] = true; //Mark as passed

	DrawPath(displayPath, pos.x + 2, pos.y + 2);

	if (
        CheckTowerWay(board, (pos.x+1, pos.y), hasPassed, displayPath) ||
		CheckTowerWay(board, (pos.x-1, pos.y), hasPassed, displayPath) ||
		CheckTowerWay(board, (pos.x, pos.y+1), hasPassed, displayPath) ||
		CheckTowerWay(board, (pos.x, pos.y-1), hasPassed, displayPath)
		) { return true; }
	hasPassed[pos.x, pos.y] = false;
	return false;
}

bool CheckHorseWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed, bool displayPath)
{
	if (pos.x == BOARDSIZE - 1 && pos.y == BOARDSIZE - 1) { return true; } //Win condition
	if (pos.x < 0 || pos.y < 0 || pos.x > BOARDSIZE - 1 || pos.y > BOARDSIZE - 1) { return false; } //Check border
	if (hasPassed[pos.x, pos.y]) { return false; } //Check if has already passed
	if (!board[pos.x, pos.y]) { return false; } //Check is silky
	hasPassed[pos.x, pos.y] = true; //Mark as passed

	DrawPath(displayPath, pos.x + 2, pos.y + 2);

	if (
        CheckHorseWay(board, (pos.x+2, pos.y+1), hasPassed, displayPath) ||
        CheckHorseWay(board, (pos.x+1, pos.y+2), hasPassed, displayPath)||
		CheckHorseWay(board, (pos.x - 1, pos.y + 2), hasPassed, displayPath) ||
		CheckHorseWay(board, (pos.x - 2, pos.y + 1), hasPassed, displayPath) ||
		CheckHorseWay(board, (pos.x - 2, pos.y -1), hasPassed, displayPath) ||
		CheckHorseWay(board, (pos.x - 1, pos.y -2), hasPassed, displayPath) ||
		CheckHorseWay(board, (pos.x + 1, pos.y - 2), hasPassed, displayPath) ||
		CheckHorseWay(board, (pos.x + 2, pos.y -1), hasPassed, displayPath)
		) { return true; }
	return false;
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

bool CheckKingWay(bool[,] board, (int x, int y) pos, bool[,] hasPassed, bool displayPath)
{
    if (pos.x == BOARDSIZE-1 && pos.y == BOARDSIZE-1) { return true; } //Win condition
    if (pos.x < 0 || pos.y < 0 || pos.x > BOARDSIZE-1 || pos.y > BOARDSIZE - 1) { return false; } //Check border
    if (hasPassed[pos.x, pos.y]) { return false; } //Check if has already passed
    if (!board[pos.x, pos.y]) { return false; } //Check is silky
    hasPassed[pos.x, pos.y] = true; //Mark as passed

	DrawPath(displayPath, pos.x + 2, pos.y + 2);

	if (CheckKingWay(board, (pos.x + 1, pos.y), hasPassed, displayPath) ||
    CheckKingWay(board, (pos.x, pos.y + 1), hasPassed, displayPath) ||
    CheckKingWay(board, (pos.x - 1, pos.y), hasPassed, displayPath) ||
    CheckKingWay(board, (pos.x, pos.y - 1), hasPassed, displayPath) ||
    CheckKingWay(board, (pos.x + 1, pos.y + 1), hasPassed, displayPath) ||
    CheckKingWay(board, (pos.x - 1, pos.y - 1), hasPassed, displayPath) ||
    CheckKingWay(board, (pos.x + 1, pos.y - 1), hasPassed, displayPath) ||
    CheckKingWay(board, (pos.x - 1, pos.y + 1), hasPassed, displayPath)) { return true; }
    
    hasPassed[pos.x, pos.y] = false;
    return false;
}

Console.ReadLine();