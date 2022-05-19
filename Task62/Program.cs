// **Задача 62**: Заполните спирально массив 4 на 4.
// 1 2 3 4
// 12 13 14 5
// 11 16 15 6
// 10 9 8 7

int[,] array = new int[4, 4];

FillArraySnail(array);
PrintArray(array);

void FillArraySnail(int[,] array)
{
    int directionRight = 0,
        directionLeft = 1,
        directionUp = 3,
        directionDown = 4,
        direction = directionRight,
        row = 0,
        column = 0,
        stepRow = 0,
        stepColumn = 1,
        minRow = 1,
        maxRow = array.GetLength(0) - 1,
        minColumn = 0,
        maxColumn = array.GetLength(1) - 1;

    for (int step = 1; step <= array.Length; step++)
    {
        array[row, column] = step;
        if (direction == directionRight && column == maxColumn)
        {
            maxColumn--;
            direction = directionDown;
            stepRow = 1;
            stepColumn = 0;
        }
        else if (direction == directionDown && row == maxRow)
        {
            maxRow--;
            direction = directionLeft;
            stepRow = 0;
            stepColumn = -1;
        }
        else if (direction == directionLeft && column == minColumn)
        {
            minColumn++;
            direction = directionUp;
            stepRow = -1;
            stepColumn = 0;
        }
        else if (direction == directionUp && row == minRow)
        {
            minRow++;
            direction = directionRight;
            stepRow = 0;
            stepColumn = 1;
        }
        row += stepRow;
        column += stepColumn;
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j]} ");
        Console.WriteLine();
    }
}
