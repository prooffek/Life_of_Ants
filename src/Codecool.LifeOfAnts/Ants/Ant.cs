using System;

namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public abstract char Symbol { get; protected set; }

        public Position Position { get; set; }

        protected Random _random = new Random();

        public abstract void ActOnUpdate();
    }
}