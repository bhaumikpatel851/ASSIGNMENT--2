using System;

class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Player
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public int GemCount { get; set; }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
        GemCount = 0;
    }
    public void Move(char direction)
    {
        // Handle movement logic based on the direction
        // You can add boundary checks and obstacle checks here
        switch (direction)
        {
            case 'u':
                Position.Y--;
                break;
            case 'd':
                Position.Y++;
                break;
            case 'l':
                Position.X--;
                break;
            case 'r':
                Position.X++;
                break;
        }
    }
}
class Cell
{
    public string Occupant { get; set; }

    public Cell(string occupant)
    {
        Occupant = occupant;
    }
}

class Board
{
    public Cell[,] Grid { get; set; }

    public Board()
    {
        // Initialize the board with empty cells
        Grid = new Cell[6, 6];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = new Cell("-");
            }
        }

        // Add players, gems, and obstacles
        // You may want to randomize the positions
        Grid[0, 0].Occupant = "P1";
        Grid[5, 5].Occupant = "P2";

        Grid[2, 2].Occupant = "G";
        Grid[3, 3].Occupant = "G";

        Grid[1, 1].Occupant = "O";
        Grid[4, 4].Occupant = "O";
    }

    public void Display()
    {
        // Display the current state of the board
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write(Grid[i, j].Occupant + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public bool IsValidMove(Player player, char direction)
    {
        // Check if the move is within bounds and does not go through obstacles
        int newX = player.Position.X;
        int newY = player.Position.Y;

        switch (direction)
        {
            case 'u':
                newY--;
                break;
            case 'd':
                newY++;
                break;
            case 'l':
                newX--;
                break;
            case 'r':
                newX++;
                break;
        }

        return newX >= 0 && newX < 6 && newY >= 0 && newY < 6 && Grid[newY, newX].Occupant != "O";
    }
    public bool CollectGem(Player player)
    {
        // Check if the player's new position contains a gem
        if (Grid[player.Position.Y, player.Position.X].Occupant == "G")
        {
            Grid[player.Position.Y, player.Position.X].Occupant = "-";
            player.GemCount++;
            return true;
        }
        return false;
    }
}

class Game
{
    public Board Board { get; set; }
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public Player CurrentTurn { get; set; }
    public int TotalTurns { get; set; }

    public Game()
    {
        Board = new Board();
        Player1 = new Player("P1", new Position(0, 0));
        Player2 = new Player("P2", new Position(5, 5));
        CurrentTurn = Player1;
        TotalTurns = 0;
    }

    public void Start()
    {
        while (!IsGameOver())
        {
            Board.Display();
            Console.WriteLine($"{CurrentTurn.Name}'s turn. Enter move (u/d/l/r): ");
            char move = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (Board.IsValidMove(CurrentTurn, move))
            {
                CurrentTurn.Move(move);
                if (Board.CollectGem(CurrentTurn))
                {
                    Console.WriteLine($"{CurrentTurn.Name} collected a gem!");
                }

                TotalTurns++;
                SwitchTurn();
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }

        AnnounceWinner();
    }

    public void SwitchTurn()
    {
        CurrentTurn = (CurrentTurn == Player1) ? Player2 : Player1;
    }

    public bool IsGameOver()
    {
        return TotalTurns >= 30;
    }

    public void AnnounceWinner()
    {
        Board.Display();
        if (Player1.GemCount > Player2.GemCount)
        {
            Console.WriteLine($"Player {Player1.Name} wins!");
        }
        else if (Player1.GemCount < Player2.GemCount)
        {
            Console.WriteLine($"Player {Player2.Name} wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Game gemHuntersGame = new Game();
        gemHuntersGame.Start();
    }
}

