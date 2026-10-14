namespace FountainOfObjects;

using ConsoleUtilities;
using MenuManagerUtility;
using System.Drawing;
using System.Runtime.InteropServices;

public class GameState
{
    //Fields
    private readonly Point _fountainLocation = new(0, 2);
    private readonly Point _entranceLocation = new(0, 0);
    private readonly ConsoleColor _optionColor = ConsoleColor.Cyan;
    private readonly string _introText = "You enter the cavern housing the Fountain of Objects. An unnatural darkness pervades these caverns extinguishing human-made light and natural light alike. You must navigate through the dark in search of the Fountain relying only on your sense of smell and hearing to navigate the dangers lurking within.";

    //Properties
    private bool FountainEnabled { get; set; }
    private bool Running { get; set; } = true;

    //Game Objects
    private Rooms[,] _board;
    private Player _player;

    //Actions
    private List<MenuItem> moveOptions;
    public  MenuItem Move;
    public  MenuItem EnableFountain;
    public  MenuItem DisableFountain;

    //Constructor
    public GameState()
    {
        _board = new Rooms[4, 4];
        FountainEnabled = false;
        _player = new Player();
        
        moveOptions = new()
        {
            new("North", () => TryMove(0, -1)),
            new("South", () => TryMove(0, 1)),
            new("East", () => TryMove(1, 0)),
            new("West", () => TryMove(-1, 0))
        };
        Move = new("Move", () =>
        {
            var selection = new MenuManager().Run(moveOptions, "Which direction would you like to move?", _optionColor);
            selection.Execute();
        });
        EnableFountain = new("Enable Fountain", () => FountainEnabled = true);
        DisableFountain = new("Disable Fountain", () => FountainEnabled = false);
        _board[_entranceLocation.X, _entranceLocation.Y] = new Rooms(RoomContents.Entrance);
        _board[_fountainLocation.X, _fountainLocation.Y] = new Rooms(RoomContents.Fountain);

    }

    //Gameloop
    public void run()
    {
        Console.BufferHeight = 30;
        Console.BufferWidth = 120;
        ConsoleUtility.TypewriterEffect(_introText, 50, ConsoleColor.Magenta);
        Console.BufferWidth = 240;
        Console.WindowWidth = 240;
        Console.BufferHeight = 60;
        Console.WindowHeight = 60;
        Console.Clear();
       /* do
        {

        } while (Running);*/
    }

    //Helper methods
    private void TryMove(int x, int y)
    {
        bool success = _player.Move(x, y);
        if (!success)
        {
            var selection = new MenuManager().Run(GetMenuOptions(), "What would you like to do?", "You cannot move in that direction.", ConsoleColor.Red, _optionColor);
            selection.Execute();
        }
    }
    private List<MenuItem> GetMenuOptions()
    {
        List<MenuItem> options = new()
        {
            Move
        };
        if (_player.PlayerPosition == _fountainLocation)
        {
            if (FountainEnabled)
            {
                options.Add(DisableFountain);
            }
            else
            {
                options.Add(EnableFountain);
            }
        }

        return options;
    }
}