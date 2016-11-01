using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    class Game
    {
        private bool[,] _currentGrid { get; set; }
        private bool[,] _newGrid { get; set; }
        private int _sizeX { get; set; }
        private int _sizeY { get; set; }

        public Game(bool[,] currentGrid)
        {
            _currentGrid = currentGrid;
            _sizeX = currentGrid.GetLength(0);
            _sizeY = currentGrid.GetLength(1);

            _newGrid = new bool[_sizeX,_sizeY];
        }

        public bool[,] Update()
        {
            for (int x = 0; x < _sizeX; x++)
            {
                for (int y = 0; y < _sizeY; y++)
                {
                    var cell = _currentGrid[x, y];
                    var liveNeighbors = CountNeighbors(x, y);
                    _newGrid[x, y] = WillLive(_currentGrid[x, y], liveNeighbors);
                }
            }
            return _newGrid;
        }
//Any live cell with fewer than two live neighbours dies, as if caused by under-population.
//Any live cell with two or three live neighbours lives on to the next generation.
//Any live cell with more than three live neighbours dies, as if by over-population.
//Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

        private bool WillLive(bool cell, int liveNeighbors)
        {
            
            return cell ? !(liveNeighbors < 2 || liveNeighbors > 3) : liveNeighbors == 3;
            
        }
        //x is row
        //y is column
        private int CountNeighbors(int x, int y)
        {
            var count = 0;
            //left
            if (y > 0 && _currentGrid[x, y - 1])
            {
                count++;
            }
            //left up
            if ((x > 0 && y > 0) && _currentGrid[x - 1, y - 1])
            {
                count++;
            }
            //left down
            if ((x < _sizeX && y > 0) && _currentGrid[x + 1, y - 1])
            {
                count++;
            }
            //up
            if (x > 0 && _currentGrid[x - 1, y])
            {
                count++;
            }
            //down
            if (x < _sizeX && _currentGrid[x + 1, y])
            {
                count++;
            }
            //right
            if (y < _sizeY && _currentGrid[x, y + 1])
            {
                count++;
            }
            //right up
            if ((x > 0 && y < _sizeY) && _currentGrid[x - 1, y + 1])
            {
                count++;
            }
            //right down
            if ((x < _sizeX && y < _sizeY) && _currentGrid[x + 1, y + 1])
            {
                count++;
            }
            return count;
        }
    }
}
