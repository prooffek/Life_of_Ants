using System;

namespace Codecool.LifeOfAnts
{
    public class Simulation
    {
        private Colony _colony;

        public Simulation(int width, int drones, int workers, int soldiers)
        {
            _colony = new Colony(width, drones, workers, soldiers);
        }

        public void Tour()
        {
            string input;

            do
            {
                _colony.Display();
                _colony.Update();
                input = GetInput().ToLower().Trim();
            }
            while (!QuitGame(input));
        }

        private string GetInput()
        {
            Console.Out.WriteLine("Press \"q\" to quit");
            return Console.ReadLine();
        }

        private bool QuitGame(string input)
        {
            input = input.ToLower();
            return input == "q" || input == "quit";
        }
    }
}