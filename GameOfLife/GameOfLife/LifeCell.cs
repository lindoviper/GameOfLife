using System.Collections.Generic;
using System;

namespace GameOfLife
{
    public class LifeCell
    {
        public Position CellPosition
        {
            get;
            set;
        }
        public bool IsAlive
        {
            get;
            set;
        }
        public int Neighbours
        {
            get;
            set;
        }
        public LifeCell(Position position)
        {
            CellPosition = position;
            IsAlive = false;
        }
    }
}
