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
    private MenuItem ShootBow;
    private List<MenuItem> shootOptions;




    //Map Size Options
    private List<MenuItem> SizeOptions;

    //Constructor
    public GameState()
    {
        //Initializing a couple properties
        FountainEnabled = false;
        FountainLocation = new(-1, -1);

        //Game size options
        SizeOptions = new()
        {
            new("Small", () => CaveDimensions = 4),
            new("Medium", () => CaveDimensions = 6),
            new("Large", () => CaveDimensions = 8)
        };
        //Get game size choice
        var selection = new MenuManager().Run(SizeOptions, "How large of a game would you like?");
        selection.Execute!();
        //Initialize _board array
        _board = new Rooms[CaveDimensions, CaveDimensions];

        //Initializing rooms with content
        GenerateEntranceLocation();
        _board[EntranceLocation.Y, EntranceLocation.X] = new Rooms(RoomContents.Entrance);
        _board[EntranceLocation.Y, EntranceLocation.X].VisitRoom();
        GenerateFountainLocation();
        _board[FountainLocation.Y, FountainLocation.X] = new Rooms(RoomContents.Fountain);

        //Initialize player object and set location to entrance
        _player = new Player(EntranceLocation);

        //Initializing Dangerous rooms
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
                //Get maelstrom positions
                foreach (var maelstrom in GetRoomPositions(1))
                {
                    _board[maelstrom.y, maelstrom.x] = new Rooms(RoomContents.Maelstrom);
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
                //Get maelstrom positions
                foreach (var maelstrom in GetRoomPositions(1))
                {
                    _board[maelstrom.y, maelstrom.x] = new Rooms(RoomContents.Maelstrom);
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
                //Get maelstrom positions
                foreach (var maelstrom in GetRoomPositions(2))
                {
                    _board[maelstrom.y, maelstrom.x] = new Rooms(RoomContents.Maelstrom);
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
            new("West", () => TryMove(-1, 0)),
            new("Back")
        };
        Move = new("Move", () =>
        {
            Console.Clear();
            var selection = new MenuManager().Run(moveOptions, "Which direction would you like to move?", _optionColor);
            selection.Execute?.Invoke();
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
        shootOptions = new()
        {
            new("Shoot North", () =>
            {
                _player.ShootArrow();
                SendArrowToRoom(0, -1);
                GameMessage = "You fired an arrow into the room to the north.";
                GameMessageColor = ConsoleColor.DarkGreen;
            }),
            new("Shoot East", () =>
            {
                _player.ShootArrow();
                SendArrowToRoom(1, 0);
                GameMessage = "You fired an arrow into the room to the east.";
                GameMessageColor = ConsoleColor.DarkGreen;
            }),
            new("Shoot South", () =>
            {
                _player.ShootArrow();
                SendArrowToRoom(0, 1);
                GameMessage = "You fired an arrow into the room to the south.";
                GameMessageColor = ConsoleColor.DarkGreen;
            }),
            new("Shoot West", () =>
            {
                _player.ShootArrow();
                SendArrowToRoom(-1, 0);
                GameMessage = "You fired an arrow into the room to the west.";
                GameMessageColor = ConsoleColor.DarkGreen;
            }),
            new("Back")

        };
        ShootBow = new("Shoot Bow", () =>
        {
            if (_player.Arrows != 0)
            {
                PlayerMoved = false;
                var selection = new MenuManager().Run(shootOptions, $"You have {_player.Arrows} arrows remaining in your quiver. What direction would you like to fire your bow?", _optionColor);
                selection.Execute?.Invoke();
            }
            else
            {
                PlayerMoved = false;
                GameMessage = "Your quiver is empty!";
                GameMessageColor = ConsoleColor.DarkGray;
            }
            
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
            selection.Execute!();
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
            Map,
            ShootBow
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
        int xOffset = 2;
        int yOffset = -1;
        int targetX = 0;
        int targetY = 0;
        bool maelstromMoved = false;
        bool moveFailed = false;
        //Move the maelstrom
        CurrentRoom.SetContent(RoomContents.Empty);
        do
        {
            if (!moveFailed)
            {
                if (PlayerPosX <= 1)
                    targetX = CaveDimensions + PlayerPosX + (xOffset * -1);
                else
                    targetX = PlayerPosX + (xOffset * -1);
                if (PlayerPosY == (CaveDimensions - 1))
                    targetY = 0;
                else
                    targetY = PlayerPosY + (yOffset * -1);
                if (_board[targetY, targetX].Contents == RoomContents.Empty)
                {
                    _board[targetY, targetX].SetContent(RoomContents.Maelstrom);
                    maelstromMoved = true;
                }
                else
                    moveFailed = true;
            }
            else
            {
                if (targetX + (xOffset * -1) == -1)
                    targetX = CaveDimensions - 1;
                else
                    targetX += xOffset * -1;
                if (targetY == CaveDimensions - 1)
                    targetY = 0;
                else
                    targetY += yOffset * -1;
                if (_board[targetY, targetX].Contents == RoomContents.Empty)
                {
                    _board[targetY, targetX].SetContent(RoomContents.Maelstrom);
                    maelstromMoved = true;
                }
            }
        } while (!maelstromMoved);
        
        //Move the player
        if (PlayerPosY == 0)
            targetY = CaveDimensions + yOffset;
        else
            targetY = PlayerPosY + yOffset;
        if ((PlayerPosX + xOffset) > (CaveDimensions - 1))
            targetX = (PlayerPosX + xOffset) - CaveDimensions;
        else
            targetX = PlayerPosX + xOffset;
        _player.FlyPlayer(targetX, targetY);
        CurrentRoom.Contents.OnEnter?.Invoke(this);
    }
    private void SendArrowToRoom(int xOffset, int yOffset)
    {
        int targetX = PlayerPosX + xOffset;
        int targetY = PlayerPosY + yOffset;
        if (!(targetX == CaveDimensions || targetX == -1 || targetY == CaveDimensions || targetY == -1))
        {
            if (_board[targetY, targetX].Contents == RoomContents.Amarok)
                _board[targetY, targetX].SetContent(RoomContents.DeadAmarok);
        }
    }
    private void GenerateEntranceLocation()
    {
        int placementX;
        int placementY;
        int XorYfirst = Random.Shared.Next(0, 2);
        if (XorYfirst == 0) //X coordinate placed first
        {
            placementX = Random.Shared.Next(0, CaveDimensions); //Set placementX
            if (placementX == 0 || placementX == CaveDimensions - 1) //If the x coordinate is on a corner
                placementY = Random.Shared.Next(0, CaveDimensions - 1); //Place the y coordinate anywhere
            else //X wasn't placed on a corner
            {
                int topOrBottom = Random.Shared.Next(0, 2); //Since X wasn't on a corner either put X on the top or bottom rather than the sides.
                if (topOrBottom == 0)
                    placementY = 0;
                else
                    placementY = CaveDimensions - 1;
            }
        }
        else
        {
            placementY = Random.Shared.Next(0, CaveDimensions);
            if (placementY == 0 || placementY == CaveDimensions - 1)
                placementX = Random.Shared.Next(0, CaveDimensions);
            else
            {
                int leftOrRight = Random.Shared.Next(0, 2);
                if (leftOrRight == 0)
                    placementX = 0;
                else
                    placementX = CaveDimensions - 1;
            }
        }
        EntranceLocation =  new Point(placementX, placementY);
    }
    private void GenerateFountainLocation()
    {
        int placementX;
        int placementY;
        do
        {
            placementX = Random.Shared.Next(0, CaveDimensions);
            placementY = Random.Shared.Next(0, CaveDimensions);
            if (_board[placementY, placementX] == null)
                FountainLocation = new(placementX, placementY);
        } while (FountainLocation == new Point (-1, -1));
    }
}