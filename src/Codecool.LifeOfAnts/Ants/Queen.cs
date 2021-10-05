using System;

namespace Codecool.LifeOfAnts.Ants
{
    public class Queen : Ant
    {
        public int MatingMood { get; private set; }
        public bool MatingInProgress { get; private set; }

        public Queen(int width = 10)
        {
            Symbol = 'Q';
            int boardCenter = width / 2;
            var square = Colony.FindSquare(boardCenter);
            Position = new Position(boardCenter, boardCenter);
            ResetMood();
        }

        public void ResetMood()
        {
            MatingMood = _random.Next(50, 100);
        }

        public void DecreseMood()
        {
            if (!QueenIsInMood()) MatingMood--;
        }

        public void KickDrone(Drone drone)
        {
            int positionX = _random.Next(Colony.Width);
            int positionY = Colony.Width - positionX;

            Colony.FindSquare(this).RemoveAnt(this);
            drone.ChangePosition(positionX, positionY);
            Colony.FindSquare(Position.X, Position.Y).AddAnt(this);
        }

        private bool QueenIsInMood()
        {
            return MatingMood <= 0;
        }

        private ActOnUpdate()
        {
            if (MatingMood > 0)
                DecreseMood();
        }

        public void ChangeMatingInProgressStatus()
        {
            MatingInProgress = !MatingInProgress;
        }
    }
}