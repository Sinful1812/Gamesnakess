using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;

public class Table
{
    public string[,] Board { get; private set; }
    public int Size { get; private set; }

    public Table()
    {
        Random randomSize = new Random();
        int[] possibleSizes = { 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41 };
        Size = possibleSizes[0+1]; // For this example, we'll use a fixed size of 9x9
        Board = new string[Size, Size];
        GeneratePatternA();
    }

    private void GeneratePatternA()
    {
        int value = 1;
        Random random = new Random();

        for (int row = Size - 1; row >= 0; row--)
        {
            if ((Size - 1 - row) % 2 == 0)
            {
                for (int col = 0; col < Size; col++)
                {
                    string prefix = (random.NextDouble() < 0.6) ? "A" : "B";
                    Board[row, col] = $"{prefix}P{value++}";
                }
            }
            else
            {
                for (int col = Size - 1; col >= 0; col--)
                {
                    string prefix = (random.NextDouble() < 0.6) ? "A" : "B";
                    Board[row, col] = $"{prefix}P{value++}";
                }
            }
        }
    }

    public void PrintBoard()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                Console.Write("[ " + $"{Board[row, col]} " + " ]");
            }
            Console.WriteLine();
        }
    }
}