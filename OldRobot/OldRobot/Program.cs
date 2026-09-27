using ConsoleUtil;
namespace OldRobot;
public class Program
{
    static void Main()
    {
        Robot robot = new Robot();
        for (int i = 0; i < 3; i++)
        {
            Enum command = new MenuManager<MainCommands>().Run($"Please select command {i + 1}:");
            if ((MainCommands)command == MainCommands.Move)
            {
                command = new MenuManager<MoveCommands>().Run("What direction would you like to move: ");
                RobotCommand newCommand = command switch
                {
                    MoveCommands.North => new NorthCommand(),
                    MoveCommands.East => new EastCommand(),
                    MoveCommands.South => new SouthCommand(),
                    MoveCommands.West => new WestCommand()
                };
                robot.Commands[i] = newCommand;
            }
            else
            {
                RobotCommand newCommand = command switch
                {
                    MainCommands.On => new OnCommand(),
                    MainCommands.Off => new OffCommand(),
                };
                robot.Commands[i] = newCommand;
            }

        }
        robot.Run();
    }
}