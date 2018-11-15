using GameOfLife;
using NUnit.Framework;
using System.Collections.Generic;
using System;
namespace GameOfLifeTests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void canSetInitialState()
        {
            var size = new Position(5, 5);

            var aliveCellPositions = GetAlivePositions();
            var seed = GetSeed(size, aliveCellPositions);

            var grid = new Grid(size, seed);
            grid.printGrid();
        }

        //[Test]
        //public void CanGetAliveCellNeighbours()
        //{
        //    var size = new Position(5, 5);

        //    var aliveCellPositions = GetAlivePositions();
        //    var seed = GetSeed(size, aliveCellPositions);

        //    var grid = new Grid(size, seed);
        //    var neighbours = grid.GetAliveNeighbours(new Position(1, 2));
        //    Assert.AreEqual(2, neighbours);
        //}

        [Test]
        public void AnyCellWithFewerThanTwoNeighboursDies()
        {
            var size = new Position(5, 5);

            var aliveCellPositions = GetAlivePositions();
            var seed = GetSeed(size, aliveCellPositions);

            var grid = new Grid(size, seed);
            grid.run();

        }

        [Test]
        public void AnyCellWithMoreThanThreeNeighboursDies()
        {
            var size = new Position(5, 5);

            var aliveCellPositions = GetAlivePositions();
            var seed = GetSeed(size, aliveCellPositions);

            var grid = new Grid(size, seed);
            grid.run();

        }

        [Test]
        public void AnyCellWithTwoOrThreeNeighboursLives()
        {
            var size = new Position(5, 5);
            var aliveCellPositions = GetAlivePositions();
            var seed = GetSeed(size, aliveCellPositions);

            var grid = new Grid(size, seed);
            grid.run();

        }

        [Test]
        public void AnyDeadCellWithExactlyThreeNeighboursBecomeAlive()
        {
            var size = new Position(5, 5);
            var aliveCellPositions = GetAlivePositions();
            var seed = GetSeed(size, aliveCellPositions);

            var grid = new Grid(size, seed);
            grid.run();

        }

        public LifeCell[,] GetSeed(Position size, List<Position> aliveCellPositions)
        {
            var seed = new LifeCell[size._x, size._y];

            for (int x = 0; x < size._x; x++)
            {
                for (int y = 0; y < size._y; y++)
                {
                    var cellPosition = new Position(x, y);
                    seed[x, y] = new LifeCell(cellPosition);

                    foreach (var item in aliveCellPositions)
                    {
                        if (item._x == x && item._y == y)
                        {
                            seed[x, y].IsAlive = true;

                        }
                    }
                }
            }
            return seed;
        }

        private static List<Position> GetAlivePositions()
        {
            return new List<Position>()
            {
                new Position(1,1),
                new Position(1,2),
                new Position(2,3),
                new Position(3,2),
                new Position(4,3),
                new Position(3,4),
                new Position(2,4)

            };
        }
    }
}
