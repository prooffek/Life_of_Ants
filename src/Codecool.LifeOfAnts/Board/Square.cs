using System.Collections.Generic;
using Codecool.LifeOfAnts.Ants;

namespace Codecool.LifeOfAnts.Board
{
    public class Square
    {
        public (int x, int y) Position { get; }

        public List<Ant> Ants { get; } = new List<Ant>();

        public Square((int x, int y) position)
        {
            Position = position;
        }

        public void AddAnt(Ant ant)
        {
            Ants.Add(ant);
        }

        public void RemoveAnt(Ant ant)
        {
            Ants.Remove(ant);
        }
    }
}