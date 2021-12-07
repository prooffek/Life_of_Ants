using System;
using System.Collections.Generic;
using Codecool.LifeOfAnts.Ants;
using Codecool.LifeOfAnts.Board;

namespace Codecool.LifeOfAnts
{
    public class Colony
    {
        public static int Width { get; private set; }

        private Queen _queen;
        private List<Ant> _ants = new List<Ant>();
        private static List<Square> Board = new List<Square>();
        private int _firstInTheList = 0;

        public Colony(int width, int drones, int workers, int soldiers)
        {
            Width = width;
            SetBoard();
            GenerateQueen();
            GenerateAnts(drones, workers, soldiers);
        }

        private void SetBoard()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Board.Add(new Square((i, j)));
                }
            }
        }

        public void Display()
        {
            foreach (Square square in Board)
            {
                Console.Write(SetBoardFieldContent(square));
                if (square.Position.y == Width - 1)
                    Console.Out.WriteLine(string.Empty);
            }
        }

        private string SetBoardFieldContent(Square square)
        {
            if (square.Ants.Count != 0)
                return $" {square.Ants[_firstInTheList].Symbol} ";
            return " . ";
        }

        public void Update()
        {
            foreach (Ant ant in _ants)
            {
                ant.ActOnUpdate();
            }
        }

        private void GenerateQueen()
        {
            _queen = new Queen(Width);
            FindSquare(_queen.Position.X, _queen.Position.Y).Ants.Add(_queen);
            _ants.Add(_queen);
        }

        private void GenerateAnts(int dronesNum, int workersNum, int soldiersNum)
        {
            GenerateAnts<Drone>(dronesNum);
            GenerateAnts<Worker>(workersNum);
            GenerateAnts<Soldier>(soldiersNum);
        }

        private void GenerateAnts<T>(int antCounter)
            where T : MovableAnts, new()
        {
            for (int i = 0; i < antCounter; i++)
            {
                GenerateAnt<T>();
            }
        }

        private void GenerateAnt<T>()
            where T : MovableAnts, new()
        {
            T ant;
            Square square;

            do
            {
                ant = new T();
                square = FindSquare(ant.Position.X, ant.Position.Y);
            }
            while (SquareIsOccupied(square, ant));

            if (ant is Drone drone) drone.SetQueen(_queen);

            square.Ants.Add(ant);
            _ants.Add(ant);
        }

        private bool SquareIsOccupied(Square square, Ant ant)
        {
            return square.Ants.Count != 0;
        }

        public static Square FindSquare(int positionX, int positionY)
        {
            foreach (Square square in Board)
            {
                if (square.Position == (positionX, positionY))
                    return square;
            }

            return null;
        }

        public static Square FindSquare(Ant ant)
        {
            foreach (Square square in Board)
            {
                if (square.Ants.Contains(ant))
                    return square;
            }

            return null;
        }
    }
}