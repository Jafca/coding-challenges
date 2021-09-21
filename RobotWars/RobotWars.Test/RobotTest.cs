using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotWars.Test
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        [DataRow("5 5", "0 0 N", "M", "0 1 N")]
        [DataRow("5 5", "0 5 N", "M", "0 5 N")]
        [DataRow("5 5", "5 0 N", "M", "5 1 N")]
        [DataRow("5 5", "5 5 N", "M", "5 5 N")]
        [DataRow("5 5", "2 2 N", "M", "2 3 N")]
        public void MoveNorth(string arena_coordinates, string position, string instructions, string expected)
        {
            Arena arena = new Arena(arena_coordinates);
            Robot robot = new Robot(arena, position, instructions);

            string actual = robot.FollowInstructions();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("5 5", "0 0 E", "M", "1 0 E")]
        [DataRow("5 5", "0 5 E", "M", "1 5 E")]
        [DataRow("5 5", "5 0 E", "M", "5 0 E")]
        [DataRow("5 5", "5 5 E", "M", "5 5 E")]
        [DataRow("5 5", "2 2 E", "M", "3 2 E")]
        public void MoveEast(string arena_coordinates, string position, string instructions, string expected)
        {
            Arena arena = new Arena(arena_coordinates);
            Robot robot = new Robot(arena, position, instructions);

            string actual = robot.FollowInstructions();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("5 5", "0 0 S", "M", "0 0 S")]
        [DataRow("5 5", "0 5 S", "M", "0 4 S")]
        [DataRow("5 5", "5 0 S", "M", "5 0 S")]
        [DataRow("5 5", "5 5 S", "M", "5 4 S")]
        [DataRow("5 5", "2 2 S", "M", "2 1 S")]
        public void MoveSouth(string arena_coordinates, string position, string instructions, string expected)
        {
            Arena arena = new Arena(arena_coordinates);
            Robot robot = new Robot(arena, position, instructions);

            string actual = robot.FollowInstructions();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("5 5", "0 0 W", "M", "0 0 W")]
        [DataRow("5 5", "0 5 W", "M", "0 5 W")]
        [DataRow("5 5", "5 0 W", "M", "4 0 W")]
        [DataRow("5 5", "5 5 W", "M", "4 5 W")]
        [DataRow("5 5", "2 2 W", "M", "1 2 W")]
        public void MoveWest(string arena_coordinates, string position, string instructions, string expected)
        {
            Arena arena = new Arena(arena_coordinates);
            Robot robot = new Robot(arena, position, instructions);

            string actual = robot.FollowInstructions();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("5 5", "0 0 N", "R", "0 0 E")]
        [DataRow("5 5", "0 0 E", "R", "0 0 S")]
        [DataRow("5 5", "0 0 S", "R", "0 0 W")]
        [DataRow("5 5", "0 0 W", "R", "0 0 N")]
        [DataRow("5 5", "0 0 N", "RRRR", "0 0 N")]
        public void TurnRight(string arena_coordinates, string position, string instructions, string expected)
        {
            Arena arena = new Arena(arena_coordinates);
            Robot robot = new Robot(arena, position, instructions);

            string actual = robot.FollowInstructions();

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [DataRow("5 5", "0 0 N", "L", "0 0 W")]
        [DataRow("5 5", "0 0 E", "L", "0 0 N")]
        [DataRow("5 5", "0 0 S", "L", "0 0 E")]
        [DataRow("5 5", "0 0 W", "L", "0 0 S")]
        [DataRow("5 5", "0 0 N", "LLLL", "0 0 N")]
        public void TurnLeft(string arena_coordinates, string position, string instructions, string expected)
        {
            Arena arena = new Arena(arena_coordinates);
            Robot robot = new Robot(arena, position, instructions);

            string actual = robot.FollowInstructions();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("5 5", "0 0 N", "MMMMMRMMMMMRMMMMMRMMMMMR", "0 0 N")]
        [DataRow("5 5", "0 0 E", "MMMMMLMMMMMLMMMMMLMMMMML", "0 0 E")]
        [DataRow("5 5", "2 2 N", "MRMRMRMR", "2 2 N")]
        [DataRow("5 5", "2 2 E", "MLMLMLML", "2 2 E")]
        public void FullCircle(string arena_coordinates, string position, string instructions, string expected)
        {
            Arena arena = new Arena(arena_coordinates);
            Robot robot = new Robot(arena, position, instructions);

            string actual = robot.FollowInstructions();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [DataRow("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void SampleData(string arena_coordinates, string position, string instructions, string expected)
        {
            Arena arena = new Arena(arena_coordinates);
            Robot robot = new Robot(arena, position, instructions);

            string actual = robot.FollowInstructions();

            Assert.AreEqual(expected, actual);
        }
    }
}
