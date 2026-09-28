namespace OldRobot;

public class OnCommand : IRobotCommand
{
    public  void Run(Robot robot) => robot.IsPowered = true;
}