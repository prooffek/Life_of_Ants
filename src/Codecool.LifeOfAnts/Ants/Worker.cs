namespace Codecool.LifeOfAnts.Ants
{
    public class Worker : MovableAnts
    {
        public override char Symbol { get; protected set; }
        public Worker()
        {
            Symbol = 'W';
            SetStartingPosition();
        }

        public override void Move()
        {
            int randomNumber = _random.Next(4);
            Colony.FindSquare(this).RemoveAnt(this);

            switch (randomNumber)
            {
                case (int)Direction.North:
                    ChangePosition(Position.X, Position.Y - 1);
                    break;
                case (int)Direction.South:
                    ChangePosition(Position.X, Position.Y + 1);
                    break;
                case (int)Direction.East:
                    ChangePosition(Position.X + 1, Position.Y);
                    break;
                case (int)Direction.West:
                    ChangePosition(Position.X - 1, Position.Y);
                    break;
            }

            Colony.FindSquare(Position.X, Position.Y).AddAnt(this);
        }
    }
}