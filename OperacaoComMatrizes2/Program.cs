int lineLength = 0, columnLength = 0, diagonalSum = 0, reverseDiagonalSum = 0;
int[] sumLineResults = new int[lineLength], sumColumnResults = new int[lineLength]; 
int[,] mainMatrix = new int[lineLength, columnLength];

void getMatrixLengths()
{
    do
    {
        Console.Write("Selecione quantidade de linhas das matrizes: ");
        lineLength = int.Parse(Console.ReadLine());
        Console.Write("Selecione quantidade de colunas das matrizes: ");
        columnLength = int.Parse(Console.ReadLine());
        
        if (lineLength < 1 || columnLength < 1)
        {
            Console.WriteLine("Os valores devem ser maiores que 0. Tente novamente.\n");
        }
        else
        {
            Console.Clear();
        }

    } while (lineLength < 1 || columnLength < 1);
}

void printMatrix(int[,] matrix, string header)
{
    Console.WriteLine($"{header}\n");
    for (int line = 0; line < lineLength; line++)
    {
        for (int column = 0; column < columnLength; column++)
        {
            Console.Write($"{matrix[line, column]:00} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void printResults(int[] results, int resultsLength, string header) 
{
    Console.WriteLine($"{header}\n");
    for (int i = 0; i < resultsLength; i++)
    {
        Console.WriteLine($"linha {i + 1}: {results[i]}");
    }
    Console.WriteLine();
}

int[,] genRandomMatriz(int lineLength, int columnLength)
{
    int[,] matrix = new int[lineLength, columnLength];
    for (int line = 0; line < lineLength; line++)
    {
        for (int column = 0; column < columnLength; column++)
        {
            matrix[line, column] = new Random().Next(0, 100);
        }
    }
    return matrix;
}

int[] sumMatrixLines(int[,] matrix)
{
    int[] results = new int[lineLength];
    for (int line = 0; line < lineLength; line++)
    {
        for (int column = 0; column < columnLength; column++)
        {
            results[line] += matrix[line, column];
        }
    }

    return results;
}

int[] sumMatrixColumns(int[,] matrix)
{
    int[] results = new int[lineLength];
    for (int line = 0; line < lineLength; line++)
    {
        for (int column = 0; column < columnLength; column++)
        {
            results[line] += matrix[column, line];
        }
    }
    return results;
}

int sumMatrixDiagonal(int[,] matrix, bool reverse = false)
{
    int result = 0;
    if (reverse)
    {
        for (int line = 0; line < lineLength; line++)
        {
            for (int column = 0; column < columnLength; column++)
            {
                if (line + column == columnLength - 1)
                {
                    result += matrix[line, column];
                }
            }
        }
    }
    else
    {
        for (int line = 0; line < lineLength; line++)
        {
            for (int column = 0; column < columnLength; column++)
            {
                if (line == column)
                {
                    result += matrix[line, column];
                }
            }
        }
    }
    return result;
}

do
{
    // Iniciar matriz para operações
    getMatrixLengths();
    mainMatrix = genRandomMatriz(lineLength, columnLength);
    printMatrix(mainMatrix, "Matriz gerada:");

    // Fazer operações
    sumLineResults = sumMatrixLines(mainMatrix);
    sumColumnResults = sumMatrixColumns(mainMatrix);
    diagonalSum = sumMatrixDiagonal(mainMatrix);
    reverseDiagonalSum = sumMatrixDiagonal(mainMatrix, true);

    // Apresentar resultados
    printResults(sumLineResults, lineLength, "Soma das linhas:");
    printResults(sumColumnResults, columnLength, "Soma das colunas: ");
    Console.WriteLine($"Soma das diagonal: {diagonalSum}");
    Console.WriteLine($"Soma das diagonal inversa: {reverseDiagonalSum}");

    Console.Write("\nDeseja repetir com outros valores? (s) Sim / (n) Não : ");
    char input = char.Parse(Console.ReadLine());
    if (input == 's' || input == 'S')
    {
        Console.Clear();
    }
    else
    {
        break;
    }
}
while (true);