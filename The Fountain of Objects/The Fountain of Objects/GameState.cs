namespace FountainOfObjects;

using ConsoleUtilities;
using MenuManagerUtility;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

public class GameState
{
    //Fields
    private readonly ConsoleColor _optionColor = ConsoleColor.Cyan;
    private readonly string _introText = "You enter the cavern housing the Fountain of Objects. An unnatural darkness pervades these caverns extinguishing human-made light and natural light alike. You must navigate through the dark in search of the Fountain relying only on your sense of smell and hearing to navigate the dangers lurking within.";
    private readonly string _winMessage = "You have ventured deep through the darkness, found the Fountain of Objects, returned the Fountain to it's former glory spewing objects out for all, and returned the entrance safely. Congratulations!";
    private readonly string _loseMessage = "You have left the cave having failed your quest. All in the land will suffer due to your failure.";
    private readonly string _deathMessage = "You have succumb to one of the many dangers lurking in these caves. Tales will be told of your adventures and their subsequent end during your final quest to restore the Fountain of Objects.";

    //Properties
    private Point FountainLocation { get; set; }
    private Point EntranceLocation { get; set; }
    private bool PlayerMoved { get; set; } = true;
    private bool FountainEnabled { get; set; }
    public bool Running { get; private set; } = true;
    private string GameMessage { get; set; }
    private ConsoleColor GameMessageColor { get; set; }
    private int CaveDimensions { get; set; }
    private int PlayerPosX { get { return _player.PlayerPosition.X; } }
    private int PlayerPosY { get { return _player.PlayerPosition.Y; } }
    private Rooms CurrentRoom { get { return _board[PlayerPosY, PlayerPosX]; }}

    //Game Objects
    private Rooms[,] _board;
    private Player _player;

    //Actions
    private List<MenuItem> moveOptions;
    private  MenuItem Move;
    private  MenuItem EnableFountain;
    private  MenuItem DisableFountain;
    private MenuItem Map;
    private MenuItem ExitCave;

    //Dangers
    private List<(int y, int x)> PitList;
    private List<(int y, int x)> AmarokList;


    //Map Size Options
    private List<MenuItem> SizeOptions;

    //Constructor
    public GameState()
    {
        //Initializing properties and danger lists
        FountainEnabled = false;
        AmarokList = new();
        PitList = new();

        //Game size options
        SizeOptions = new()
        {
            new("Small", () =>
            {
                CaveDimensions = 4;
                EntranceLocation = new(0, 0);
                FountainLocation = new(Random.Shared.Next(0, 3), Random.Shared.Next(0, 3));

            }),
            new("Medium", () =>
            {
                CaveDimensions = 6;
                EntranceLocation = new(5, 4);
                FountainLocation = new(Random.Shared.Next(0, 5), Random.Shared.Next(0, 5));
            }),
            new("Large", () =>
            {
                CaveDimensions = 8;
                EntranceLocation = new(0, 7);
                FountainLocation = new(Random.Shared.Next(0, 7), Random.Shared.Next(0, 7));
            })
        };
        //Set game size and player location to entrance
        var selection = new MenuManager().Run(SizeOptions, "How large of a game would you like?");
        selection.Execute();
        _player = new Player(EntranceLocation);
        _board = new Rooms[CaveDimensions, CaveDimensions];
        
        //Initializing rooms with content
        _board[EntranceLocation.Y, EntranceLocation.X] = new Rooms(RoomContents.Entrance);
        _board[EntranceLocation.Y, EntranceLocation.X].VisitRoom();
        _board[FountainLocation.Y, FountainLocation.X] = new Rooms(RoomContents.Fountain);
        switch (CaveDimensions)
        {
            case 4: //Small size
                //Get pit positions
                foreach (var pit in GetRoomPositions(1))
                {
                    _board[pit.y, pit.x] = new Rooms(RoomContents.Pit);
                }
                //Get amarok positions
                foreach (var amarok in GetRoomPositions(1))
                {
                    _board[amarok.y, amarok.x] = new Rooms(RoomContents.Amarok);
                }
                break;

            case 6: //Medium size
                //Get pit positions
                foreach (var pit in GetRoomPositions(2))
                {
                    _board[pit.y, pit.x] = new Rooms(RoomContents.Pit);
                }
                //Get amarok positions
                foreach (var amarok in GetRoomPositions(2))
                {
                    _board[amarok.y, amarok.x] = new Rooms(RoomContents.Amarok);
                }
                break;

            case 8: //Large size
                //Get pit positions
                foreach (var pit in GetRoomPositions(4))
                {
                    _board[pit.y, pit.x] = new Rooms(RoomContents.Pit);
                }
                //Get amarok positions
                foreach (var amarok in GetRoomPositions(3))
                {
                    _board[amarok.y, amarok.x] = new Rooms(RoomContents.Amarok);
                }
                break;
        }

        //Initializing empty rooms
        int col = _board.GetLength(0);
        int row = _board.GetLength(1);
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                if (_board[i, j] == null)
                {
                    _board[i, j] = new Rooms();
                }
            }
        }


        //Initializing Actions
        moveOptions = new()
        {
            new("North", () => TryMove(0, -1)),
            new("South", () => TryMove(0, 1)),
            new("East", () => TryMove(1, 0)),
            new("West", () => TryMove(-1, 0))
        };
        Move = new("Move", () =>
        {
            Console.Clear();
            var selection = new MenuManager().Run(moveOptions, "Which direction would you like to move?", _optionColor);
            selection.Execute();
        });
        Map = new("Map", () => 
        {
            MapRender.DrawMap(_board, _player.PlayerPosition, CaveDimensions);
            Console.ReadKey(true);
            Console.Clear();
        });
        ExitCave = new("Exit Cave", () => EndGame());
        EnableFountain = new("Enable Fountain", () =>
        {
            FountainEnabled = true;
            _board[FountainLocation.Y, FountainLocation.X].SetContent(RoomContents.FountainEnabled);
        });
        DisableFountain = new("Disable Fountain", () =>
        {
            FountainEnabled = false;
            _board[FountainLocation.Y, FountainLocation.X] = new Rooms(RoomContents.Fountain);
        });
    }

    //Gameloop
    public void run()
    {

        Intro();
        do
         {
            Console.Clear();
            if (PlayerMoved == true)
            { 
                GameMessage = CurrentRoom.Contents.message;
                GameMessageColor = CurrentRoom.Contents.roomMessageColor;
            }
            var selection = new MenuManager().Run(GetMenuOptions(), "What action would you like to take:", GameMessage, GetExtraInformation(), GameMessageColor, _optionColor);
            selection.Execute();
         } while (Running);
        Exit();
    }

    //Helper methods
    private void TryMove(int x, int y)
    {
        PlayerMoved = _player.Move(x, y, CaveDimensions);
        if (!PlayerMoved)
        {
            GameMessage = GameMessages.FailedMovement.message;
            GameMessageColor = GameMessages.FailedMovement.messageColor;
        }
        else
        {
            CurrentRoom.Contents.OnEnter?.Invoke(this);
            PlayerMoved = true;
            CurrentRoom.VisitRoom();
        }
            
    }
    private List<(int y, int x)> GetRoomPositions(int count)
    {
        List<(int y, int x)> roomPositions = new();
        do
        {
            int placementX = Random.Shared.Next(0, CaveDimensions);
            int placementY = Random.Shared.Next(0, CaveDimensions);
            if (_board[placementY, placementX] == null)
                roomPositions.Add((placementY, placementX));
        } while (roomPositions.Count != count);
        return roomPositions;
    }
    private List<(string, ConsoleColor)> GetExtraInformation()
    {
        List<(string, ConsoleColor)> adjacentRooms = new();
        
        //Iterate over X and Y offsets forming a 3x3 grid
        for (int yOffset = -1; yOffset <= 1; yOffset++)
        {
            for (int xOffset = -1; xOffset <= 1; xOffset++)
            {
                if (yOffset == 0 && xOffset == 0) //Checks if the offset is going to equal the current player position
                    continue;
                //Store target locations based on the player's location and offsets
                int targetX = PlayerPosX + xOffset;
                int targetY = PlayerPosY + yOffset;
                
                if (!(targetX == -1 || targetX == CaveDimensions || targetY == -1 || targetY == CaveDimensions)) //Checks for map bounds
                {
                    Rooms targetRoom = _board[targetY, targetX];
                    if (targetRoom.Contents != RoomContents.Empty && targetRoom.Contents != RoomContents.DeadAmarok) //Checks to make sure target room isn't empty
                        adjacentRooms.Add((targetRoom.Contents.roomAdjacencyMessage, targetRoom.Contents.roomMessageColor));
                }
            }
        }
        if (adjacentRooms.Count == 0) //Check to see if none of the adjacent rooms had content inside
            adjacentRooms.Add(("There is an eerie quiet in this part of the cave. There must be nothing around.", ConsoleColor.Gray));
        return adjacentRooms;
    }
    private List<MenuItem> GetMenuOptions()
    {
        List<MenuItem> options = new()
        {
            Move,
            Map
        };
        if (_player.PlayerPosition == FountainLocation)
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
        if (_player.PlayerPosition == EntranceLocation)
            options.Add(ExitCave);

        return options;
    }
    private void Intro()
    {
        ConsoleUtility.TypewriterEffectCentered(_introText, 50, ConsoleColor.Magenta);
        Console.Clear();
    }
    private void Exit()
    {
        if (_player.Alive)
            if (FountainEnabled)
                ConsoleUtility.TypewriterEffectCentered(_winMessage, 50, ConsoleColor.Yellow);
            else
                ConsoleUtility.TypewriterEffectCentered(_loseMessage, 50, ConsoleColor.DarkRed);
        else
            ConsoleUtility.TypewriterEffectCentered(_deathMessage, 50, ConsoleColor.Red);
    }
    private void EndGame()
    {
        Running = false;
    }

    public void HazardRoom()
    {
        _player.KillPlayer();
        EndGame();
    }
    public void DisplacePlayer()
    {
        int xOffset = -1;
        int yOffset = 2;
        int targetX;
        int targetY;
        //Move the maelstrom
        CurrentRoom.SetContent(RoomContents.Empty);
        if (PlayerPosY <= 1)
            targetY = CaveDimensions + PlayerPosY + (yOffset * -1);
        else
            targetY = PlayerPosY + (yOffset * -1);
        if (PlayerPosX == (CaveDimensions - 1))
            targetX = 0;
        else
            targetX = PlayerPosX + (xOffset * -1);
        _board[targetY, targetX].SetContent(RoomContents.Maelstrom);
        //Move the player
        if (PlayerPosX == 0)
            targetX = CaveDimensions + xOffset;
        else
            targetX = PlayerPosX + xOffset;
        if ((PlayerPosY + yOffset) > (CaveDimensions - 1))
            targetY = (PlayerPosY + yOffset) - CaveDimensions;
        else
            targetY = PlayerPosY + yOffset;
        _player.FlyPlayer(targetX, targetY);
        CurrentRoom.Contents.OnEnter?.Invoke(this);
    }
}