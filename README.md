# ASSIGNMENT--2
GEM  HUNTER GAME 

OVERVIEW :
In the 2D console game "Gem Hunters," two players fight to gather the greatest number of gems in a predetermined amount of turns. In order to gather gems and dodge obstacles, players must navigate across a 6 by 6 square board in this game.

COMPONENTS OF GAME : 
Players: Player 1 starts in the top-left corner, while Player 2 starts in the bottom-right corner.
Gems are placed on the board at random before the game starts. . Moving onto the matching squares allows players to gather gems.
Players are unable to pass past obstacles, which are random spots on the board denoted by the letter "O".

HOW TO PLAY :
1.Players take turns to move on the board.
2.Input your movement through the console:
* U for up
* D for down
* L for left
* R for right
3.Players can move one square in any direction but cannot move diagonally or through obstacles.
4.If a player moves onto a square containing a gem, they collect the gem, and it's removed from the board.
5.The game ends after 30 moves (15 turns for each player)

CODE STRUCTURE :
Position Class
X: int
Y: int
Constructor: Position(int x, int y)

PLAYER CLASS : 
* Name: string
* Position: Position
* GemCount: int
* Methods: Move(char direction): Updates the player's position based on the input direction (U, D, L, R).

CELL CLASS : 
Occupant: string
Constructor: Cell(string occupant)

BOARD CLASS :
Grid: 2D array of type Cell
Constructor: Board()
Methods:
 * Display(): Prints the current state of the board to the console.
 * IsValidMove(Player player, char direction): Checks if the move is valid.
 * CollectGem(Player player): Checks if the player's new position contains a gem and updates the player's GemCount.

GAME CLASS :
Board: Board
Player1: Player
Player2: Player
CurrentTurn: Player
TotalTurns: int
Constructor: Game()
 Methods:
  * Start(): Begins the game, displays the board, and alternates player turns.
  * SwitchTurn(): Switches between Player1 and Player2.
  * IsGameOver(): Checks if the game has reached its end condition.
  * AnnounceWinner(): Determines and announces the winner based on GemCount of both players.

PROGRAM CLASS : 
 Main(): Entry point of the program; creates a Game instance and starts the game.

HOW TO RUN IT : 
1.Clone the repository.
2.Open the solution in a C# development environment.
3.Run the program.
    Have fun playing "GEM HUNTER GAME"!

