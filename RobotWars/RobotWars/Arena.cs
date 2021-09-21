namespace RobotWars
{
    public class Arena
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Arena(string input)
        {
            var coordinates = input.Split(' ');
            X = int.Parse(coordinates[0]);
            Y = int.Parse(coordinates[1]);
        }
    }
}