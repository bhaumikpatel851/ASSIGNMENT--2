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

