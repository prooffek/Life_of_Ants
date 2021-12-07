using System;

namespace Codecool.LifeOfAnts.Ants
{
    public abstract class MovableAnts : Ant
    {
        public abstract void Move();

        protected void SetStartingPosition()
        {
            var x = _random.Next(Colony.Width);
            var y = _random.Next(Colony.Width);
            Position = new Position(x, y);
        }

        public void ChangePosition(int positionX, int positionY)
        {
            var newX = ManagePositionOnBoard(positionX);
            var newY = ManagePositionOnBoard(positionY);
            Position = new Position(newX, newY);
            Colony.FindSquare(Position.X, Position.Y);
        }

        protected int ManagePositionOnBoard(int position)
        {
            if (position < 0)
                return 0;

            if (position >= Colony.Width)
                return Colony.Width - 1;

            return position;
        }

        public override void ActOnUpdate()
        {
            Move();
        }
    }
}