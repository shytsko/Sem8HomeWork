// **Задача 58**: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.


int[,] matrixA = CreateArrayRandom(
    rows: ReadInteger("Введите количество строк матрицы А: "),
    columns: ReadInteger("Введите количество столбцов матрицы А: "),
    minValue: -9,
    maxValue: 9
);

int[,] matrixB = CreateArrayRandom(
    rows: ReadInteger("Введите количество строк матрицы B: "),
    columns: ReadInteger("Введите количество столбцов матрицы B: "),
    minValue: -9,
    maxValue: 9
);
Console.WriteLine("Матрица A:");
PrintArray(matrixA);
Console.WriteLine();
Console.WriteLine("Матрица B:");
PrintArray(matrixB);
Console.WriteLine();

int[,] matrixС = MatrixMultiplication(matrixA, matrixB);

if (matrixС.GetLength(0) != 0)
{
    Console.WriteLine("Матрица A x Матрица B = Матрица C: ");
    PrintArray(matrixС);
}
else
{
    Console.WriteLine("Матрицы не могут быть перемножены");
}

int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
{
    if (matrixA.GetLength(1) != matrixB.GetLength(0))
        return new int[0, 0];

    int[,] matrixС = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int row = 0; row < matrixС.GetLength(0); row++)
        for (int col = 0; col < matrixС.GetLength(1); col++)
        {
            matrixС[row, col] = 0;
            for (int i = 0; i < matrixA.GetLength(1); i++)
                matrixС[row, col] += matrixA[row, i] * matrixB[i, col];
        }
    return matrixС;
}

int[,] CreateArrayRandom(int rows, int columns, int minValue, int maxValue)
{
    int[,] array = new int[rows, columns];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
            array[i, j] = new Random().Next(minValue, maxValue + 1);

    return array;
}

int ReadInteger(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
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
