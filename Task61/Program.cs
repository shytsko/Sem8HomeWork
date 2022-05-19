// **Дополнительная задача 61**: Вывести первые N строк треугольника Паскаля. Сделать вывод в виде равнобедренного треугольника

int n = ReadInteger("Введите количество строк треугольника Паскаля n=");

int[,] trianglePascal = new int[n, 2 * n + 1];

trianglePascal[0, n] = 1;
for (int row = 1; row < n; row++)
{
    for (int column = n - row; column <= n + row; column++)
    {
        trianglePascal[row, column] =
            trianglePascal[row - 1, column - 1] + trianglePascal[row - 1, column + 1];
    }
}

string[] trianglePascalStrings = new string[n];
for (int row = 0; row < n; row++)
{
    for (int column = n - row; column <= n + row; column++)
    {
        if(trianglePascal[row, column] != 0)
            trianglePascalStrings[row] += $"{trianglePascal[row, column]}";
        else
            trianglePascalStrings[row] += " ";
    }
}

int maxStrLength = trianglePascalStrings[trianglePascalStrings.Length-1].Length;
for (int i = 0; i < trianglePascalStrings.Length; i++)
{   
    int countSpace = (maxStrLength - trianglePascalStrings[i].Length) /2;
    for (int j = 0; j < countSpace; j++)
    {
        Console.Write(" ");
    }
    Console.WriteLine(trianglePascalStrings[i]);
}

int ReadInteger(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}
