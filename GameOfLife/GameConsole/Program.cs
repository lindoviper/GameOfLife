using System;
using GameOfLife;
using System.Collections.Generic;

namespace GameConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please specify the grid size -:");
            var inputSize = Console.ReadLine().Split(',');
            var size = new Position(int.Parse(inputSize[0]), int.Parse(inputSize[1]));
            var seed = GetSeed(size, GetAlivePositions());

            var grid = new Grid(size, seed);
            grid.run();
            //Console.WriteLine($"Your input was {int.Parse(inputSize[0])} and {int.Parse(inputSize[1])}");
        }

        public static LifeCell[,] GetSeed(Position size, List<Position> aliveCellPositions)
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
