namespace Codecool.LifeOfAnts.Ants
{
    public class Soldier : MovableAnts
    {
        private int _moveCount = default;
        public Soldier()
        {
            Symbol = 'S';
            SetStartingPosition();
        }

        public override void Move()
        {
            Colony.FindSquare(this).RemoveAnt(this);
            
            switch (_moveCount % 4)
            {
                case 0:
                    ChangePosition(Position.X - 1, Position.Y);
                    break;
                case 1:
                    ChangePosition(Position.X, Position.Y + 1);
                    break;
                case 2:
                    ChangePosition(Position.X + 1, Position.Y);
                    break;
                case 3:
                    ChangePosition(Position.X, Position.Y - 1);
                    break;
            }
            
            Colony.FindSquare(Position.X, Position.Y).AddAnt(this);
        }
    }
}