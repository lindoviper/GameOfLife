using System;

namespace GameOfLife
{
    public class Grid
    {

        public Position GridSize
        {
            get;
            set;
        }
        public LifeCell[,] Cells
        {
            get;
            set;
        }

        public Grid(Position size, LifeCell[,] seed)
        {
            GridSize = size;
            Cells = seed;
        }

        public void run()
        {
            Console.WriteLine();

            printGrid();

            SetNeighbours();

            for (int x = 0; x < GridSize._x; x++)
            {
                for (int y = 0; y < GridSize._y; y++)
                {
                    ProcessRules(Cells[x, y]);
                }

            }
            printGrid();

        }

        private void SetNeighbours()
        {
            for (int x = 0; x < GridSize._x; x++)
            {
                for (int y = 0; y < GridSize._y; y++)
                {
                    Cells[x, y].Neighbours = GetAliveNeighbours(new Position(x, y));

                }
            }
        }

        private void ProcessRules(LifeCell lifeCell)
        {

            var result = false;
            if (lifeCell.IsAlive && lifeCell.Neighbours < 2)
            {
                result = false;
            }

            if (lifeCell.IsAlive && lifeCell.Neighbours > 3)
            {
                result = false;
            }

            if (lifeCell.IsAlive && (lifeCell.Neighbours == 2 || lifeCell.Neighbours == 3))
            {
                result = true;
            }

            if (!lifeCell.IsAlive && lifeCell.Neighbours == 3)
            {
                result = true;

            }
            lifeCell.IsAlive = result;

        }

        public void printGrid()
        {
            for (int x = 0; x < GridSize._x; x++)
            {
                for (int y = 0; y < GridSize._y; y++)
                {
                    if (Cells[x, y].IsAlive)
                    {
                        Console.Write(" * ");

                    }
                    else
                    {
                        Console.Write(" . ");

                    }

                }
                Console.WriteLine();

            }
        }

        private int GetAliveNeighbours(Position position)
        {
            int count = 0;

            int _x = GridSize._x - 1;
            int _y = GridSize._y - 1;

            //bottom
            if (position._x < _x)
                if (Cells[position._x + 1, position._y].IsAlive)
                    count++;

            //bottom right
            if (position._x < _x && position._y < _y)
                if (Cells[position._x + 1, position._y + 1].IsAlive)
                    count++;

            //bottom left
            if (position._x < _x && position._y > 0)
                if (Cells[position._x + 1, position._y - 1].IsAlive)
                    count++;

            //right
            if (position._y < _y)
                if (Cells[position._x, position._y + 1].IsAlive)
                    count++;

            //top right
            if (position._x > 0 && position._y < _y)
                if (Cells[position._x - 1, position._y + 1].IsAlive)
                    count++;

            //top
            if (position._x > 0)
                if (Cells[position._x - 1, position._y].IsAlive)
                    count++;

            //top left
            if (position._x > 0 && position._y > 0)
                if (Cells[position._x - 1, position._y - 1].IsAlive)
                    count++;

            //left
            if (position._y > 0)
                if (Cells[position._x, position._y - 1].IsAlive)
                    count++;

            return count;
        }

    }
}
