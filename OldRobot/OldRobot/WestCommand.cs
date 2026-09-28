namespace OldRobot;

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X--;
    }
}