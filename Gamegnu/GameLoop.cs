using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class GameLoop
    {
    private List<Player> players = new List<Player>();
    private int currentPlayerIndex = 0;
    private Table table;
    private Random random = new Random();

    public GameLoop(Table table)
    {
        this.table = table;
    }

    public void AddPlayer(string name, int initialSTR)
    {
        if (players.Count < 8)
        {
            players.Add(new Player(name, initialSTR));
        }
        else
        {
            Console.WriteLine("Cannot add more than 8 players.");
        }
    }

    public void NextPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
    }

    public void Check()
    {
        Player currentPlayer = players[currentPlayerIndex];
        string cell = table.Board[currentPlayer.Position / table.Size, currentPlayer.Position % table.Size];

        if (cell.StartsWith("A"))
        {
            NextPlayer();
        }
        else
        {
            Event();
        }
    }

    public void Event()
    {
        Player currentPlayer = players[currentPlayerIndex];
        int plan = random.Next(1, 5); // 1: PlanA, 2: PlanB, 3: PlanC, 4: PlanD

        switch (plan)
        {
            case 1: // PlanA
                if (random.NextDouble() < 0.3)
                {
                    int move = random.Next(1, 5); // +1, +2, +3, +4
                    currentPlayer.Position += move;
                    Console.WriteLine($"Player {currentPlayer.Name} moves forward by {move}.");
                }
                break;
            case 2: // PlanB
                if (random.NextDouble() < 0.3)
                {
                    int move = random.Next(1, 5) * -1; // -1, -2, -3, -4
                    currentPlayer.Position += move;
                    Console.WriteLine($"Player {currentPlayer.Name} moves backward by {move}.");
                    Check();
                }
                break;
            case 3: // PlanC
                if (random.NextDouble() < 0.2)
                {
                    int swapIndex = random.Next(players.Count);
                    int tempPosition = currentPlayer.Position;
                    currentPlayer.Position = players[swapIndex].Position;
                    players[swapIndex].Position = tempPosition;
                    Console.WriteLine($"Player {currentPlayer.Name} swaps position with {players[swapIndex].Name}.");
                }
                break;
            case 4: // PlanD
                if (random.NextDouble() < 0.2)
                {
                    currentPlayer.SkipNextTurn = true;
                    Console.WriteLine($"Player {currentPlayer.Name} will skip the next turn.");
                }
                break;
        }
    }

    public void Main()
    {
        // Example of adding players and starting the game
        AddPlayer("Player1", 0);
        AddPlayer("Player2", 0);

        // Example game loop
        while (players.Count > 1)
        {
            Player currentPlayer = players[currentPlayerIndex];
            Console.WriteLine($"Current player: {currentPlayer.Name}");

            if (currentPlayer.SkipNextTurn)
            {
                currentPlayer.SkipNextTurn = false;
                NextPlayer();
                continue;
            }

            Console.Write("Give up? (Y/N): ");
            string response = Console.ReadLine();
            if (response.ToUpper() == "N")
            {
                players.RemoveAt(currentPlayerIndex);
                if (currentPlayerIndex >= players.Count)
                {
                    currentPlayerIndex = 0;
                }
            }
            else
            {
                int[] strArray = { -3, -1, -1, 0, 0, 0, 1, 1, 1, 1, 2, 4 };
                int strChange = strArray[random.Next(strArray.Length)];
                currentPlayer.STR = Math.Max(0, currentPlayer.STR + strChange);

                int[] moveArray = { 0, 1, 2, 3, 4, 8 };
                int move = moveArray[random.Next(moveArray.Length)];
                currentPlayer.Position = (currentPlayer.Position + move) % (table.Size * table.Size);

                Check();
            }

            if (currentPlayer.Position >= table.Size * table.Size - 1)
            {
                Console.WriteLine($"Player {currentPlayer.Name} wins!");
                break;
            }
        }
    }
}


