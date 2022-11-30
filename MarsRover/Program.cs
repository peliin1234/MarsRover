// See https://aka.ms/new-console-template for more information
using MarsRover;

while (true)
{
    try
    {
        Console.WriteLine("Please enter upper-right coordinates of the plateau. Example (5 5):");
        string boardSize = Console.ReadLine().Trim();

        List<int> XY = boardSize.Split(' ').ToList().Select(x => Convert.ToInt32(x)).ToList();

        if (XY.Count != 2 || XY.Any(x => x < 0))
        {
            //Rover class also checks validity
            throw new Exception("Invalid board size.");
        }

        while (true)
        {
            try
            {

                Console.WriteLine("Please enter plateau exploration information. Example (1 2 N):");
                string text = Console.ReadLine().ToUpper();
                List<string> roverStartingStats = text.Trim().Split(' ').ToList();

                if (roverStartingStats.Count != 3)
                {
                    //Rover class also checks validity
                    throw new Exception("Invalid rover input.");
                }
                int startingX = Convert.ToInt32(roverStartingStats[0]);
                int startingY = Convert.ToInt32(roverStartingStats[1]);

                Directions direction = (Directions)Enum.Parse(typeof(Directions), roverStartingStats[2]);

                Console.WriteLine("Please enter comands.Only L, M, R routing commands must be used. Example (LMLMLMLMM):");
                string roverCommands = Console.ReadLine();

                Command rover = new Command(startingX, startingY, direction, XY[0], XY[1]);

                Console.WriteLine(rover.ApplyCommands(roverCommands));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}