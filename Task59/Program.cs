// **Задача 59**: Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец,
// на пересечении которых расположен наименьший элемент массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Наименьший элемент - 1, на выходе получим следующий массив:
// 9 4 2
// 2 2 6
// 3 4 7

int m = ReadInteger("Введите количество строк m=");
int n = ReadInteger("Введите количество столбцов n=");
int minimum = 0;
int maximum = 9;

int[,] array = CreateArrayRandom(m, n, minimum, maximum);
PrintArray(array);

int rowMinItem = 0;
int columnMinItem = 0;
for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        if (array[i, j] < array[rowMinItem, columnMinItem])
        {
            rowMinItem = i;
            columnMinItem = j;
        }
    }
}

Console.WriteLine($"Минимальны элемент массива: array[{rowMinItem}, {columnMinItem}] = {array[rowMinItem, columnMinItem]}");
array = RemoveRowColumn(array, rowMinItem, columnMinItem);
PrintArray(array);

int[,] CreateArrayRandom(int rows, int columns, int minValue, int maxValue)
{
    int[,] array = new int[rows, columns];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
            array[i, j] = new Random().Next(minValue, maxValue + 1);

    return array;
}

int[,] RemoveRowColumn(int[,] array, int rowRemove, int columnRemove)
{
    if (array.GetLength(0) < 2 || array.GetLength(1) < 2)
        return new int[0, 0];

    int[,] newArrray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    for (int i = 0; i < newArrray.GetLength(0); i++)
    {
        for (int j = 0; j < newArrray.GetLength(1); j++)
        {
            if (i < rowRemove && j < columnRemove)
                newArrray[i, j] = array[i, j];
            else if (i < rowRemove && j >= columnRemove)
                newArrray[i, j] = array[i, j + 1];
            else if (i >= rowRemove && j < columnRemove)
                newArrray[i, j] = array[i + 1, j];
            else
                newArrray[i, j] = array[i + 1, j + 1];
        }
    }
    return newArrray;
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
