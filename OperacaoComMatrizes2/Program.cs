int tamanhoLinha = 10, tamanhoColuna = 10;
int somaDiagonal = 0;
int[] somaLinhas = new int[tamanhoLinha], somaColunas = new int[tamanhoLinha]; 
int[,] matriz = new int[tamanhoLinha, tamanhoColuna];

for (int linha = 0; linha < tamanhoLinha; linha++)
{
    for (int coluna = 0; coluna < tamanhoColuna; coluna++)
    {
        matriz[linha, coluna] = new Random().Next(0, 11);
    }
}

for (int linha = 0; linha < tamanhoLinha; linha++)
{
    for (int coluna = 0; coluna < tamanhoColuna; coluna++)
    {
        somaLinhas[linha] += matriz[linha, coluna];
        somaColunas[linha] += matriz[coluna, linha];
        if (linha == coluna)
        {
            somaDiagonal += matriz[linha, coluna];
        }
    }
}


Console.WriteLine("\nMatriz gerada: \n");
for (int linha = 0; linha < tamanhoLinha; linha++)
{
    for (int coluna = 0; coluna < tamanhoColuna; coluna++)
    {
        Console.Write($"{matriz[linha, coluna]:00} ");
    }
    Console.WriteLine();
}

Console.WriteLine("\nSoma das linhas: \n");
for (int i = 0; i < tamanhoLinha; i++)
{
    Console.WriteLine($"linha {i + 1}: {somaLinhas[i]}");
}

Console.WriteLine("\nSoma das colunas: \n");
for (int i = 0; i < tamanhoLinha; i++)
{
    Console.WriteLine($"coluna {i + 1}: {somaColunas[i]}");
}

Console.WriteLine($"\nSoma das diagonais: {somaDiagonal}");