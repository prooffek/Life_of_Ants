namespace Codecool.LifeOfAnts.Ants
{
    public class Drone : MovableAnts
    {
        public int MatingCounter { get; private set; } = 0;
        private Queen _queen;

        public Drone()
        {
            Symbol = 'D';
            SetStartingPosition();
        }

        public void SetQueen(Queen queen)
        {
            _queen = queen;
        }

        public override void Move()
        {
            Colony.FindSquare(this).RemoveAnt(this);

            if (Position.X > _queen.Position.X)
            {
                Position = new Position(Position.X - 1, Position.Y);
            }
            else if (Position.X < _queen.Position.X)
            {
                Position = new Position(Position.X + 1, Position.Y);
            }
            else if (Position.Y > _queen.Position.Y)
            {
                Position = new Position(Position.X, Position.Y - 1);
            }
            else if (Position.Y < _queen.Position.Y)
            {
                Position = new Position(Position.X, Position.Y + 1);
            }

            Colony.FindSquare(Position.X, Position.Y).AddAnt(this);
        }

        public override void ActOnUpdate()
        {
            Move();

            if (IsOnQueen() && QueenIsReadyToMate())
            {
                _queen.ResetMood();
                _queen.ChangeMaitingInProgrssStatus();
                MatingCount = 12;
            }
            else if (IsOnQueen() && IsStillMating())
                MatingCount--;
            else if (IsOnQueen() && StopsMatingInNextTour())
            {
                _queen.ChangeMaitingInProgrssStatus();
                MatingCount--;
            }
            else if (IsOnQueen() && QueenWillNotMate())
            {
                _queen.KickDrone(this);
            }
        }

        private bool IsOnQueen()
        {
            return _queen.PositionX == PositionX && _queen.PositionY == PositionY;
        }

        private bool QueenIsReadyToMate()
        {
            return _queen.MatingMood == 0 && !_queen.MatingInProgress;
        }

        private bool IsStillMating()
        {
            return _queen.MatingInProgress && MatingCount > 1;
        }

        private bool StopsMatingInNextTour()
        {
            return _queen.MatingInProgress && MatingCount == 1;
        }

        private bool QueenWillNotMate()
        {
            return _queen.MatingMood > 0 || _queen.MatingInProgress;
        }
    }
}