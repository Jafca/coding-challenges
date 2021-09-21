using System;

namespace RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Assumptions
             * Input is always valid
             * If a robot tries to leave the arena, it's position doesn't change
            */
            Arena arena = new Arena("5 5");

            Robot robot1 = new Robot(arena, "1 2 N", "LMLMLMLMM");
            Console.WriteLine(robot1.FollowInstructions());

            Robot robot2 = new Robot(arena, "3 3 E", "MMRMMRMRRM");
            Console.WriteLine(robot2.FollowInstructions());
        }
    }
}
