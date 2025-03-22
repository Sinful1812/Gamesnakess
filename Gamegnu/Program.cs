using System;

public class Program
{
    public static void Main(string[] args)
    {
        Table table = new Table();
        table.PrintBoard();
        GameLoop gameLoop = new GameLoop(table);
        gameLoop.Main();
    }
}