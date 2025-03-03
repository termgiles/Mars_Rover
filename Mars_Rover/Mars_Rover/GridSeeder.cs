using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    public class GridSeeder
    {
        protected Grid _grid;
        private int _borderSeeded = 0;

        //coin related varibales 
        protected int _coins = 0;
        public int score { get; private set; } = 0;
        public GridSeeder(Grid grid)
        {
            _grid = grid;
        }

        public void SeedBorder(int density)
        {
            if (_grid.ElementHistory.Count == 0)
            {
                return;
            }
            if (_borderSeeded != 0) return;

            SeedX(density);
            SeedY(density);
            _borderSeeded++;
        }

        private void SeedX(int density)
        {
            
            int r = density % 100;
            int k = (int)(_grid.Size.xAxis / 5);
            Random rand = new Random();
            for (int i = k; i < _grid.Size.xAxis -k; i = i + k)
            {
                if (rand.Next(100) <= r)
                {
                    int n = rand.Next(k);
                    for (int j = 0; j <= n; j++)
                    {
                        if (_grid.GridArray[i - j, 0] == null)
                        {
                            _grid.GridArray[i - j, 0] = new Rock();
                        }
                    }
                }
            }
            for (int i = k; i < _grid.Size.xAxis; i++)
            {
                if (_grid.GridArray[i, 0] != null) 
                {
                    if(_grid.GridArray[i, 0].Symbol == new Rock().Symbol)
                    {
                        if (rand.Next(10) < 8 && _grid.GridArray[i, 1] == null)
                        {
                            _grid.GridArray[i, 1] = new Rock();
                        }
                    }
                }
            }
            for (int i = k; i < _grid.Size.xAxis; i++)
            {
                if (_grid.GridArray[i, 1] != null)
                {
                    if (_grid.GridArray[i, 1].Symbol == new Rock().Symbol)
                    {
                        if (rand.Next(10) < 6)
                        {
                            _grid.GridArray[i, 2] = new Rock();
                        }
                    }
                }
            }

            if(_grid.Size.yAxis < 7)
            {
                return;
            }

            for (int i = k; i < _grid.Size.xAxis -k; i = i + k)
            {
                if (rand.Next(100) <= r)
                {
                    int n = rand.Next(k);
                    for (int j = 0; j <= n; j++)
                    {
                        if (_grid.GridArray[i - j, _grid.Size.yAxis - 1] == null)
                        {
                            _grid.GridArray[i - j, _grid.Size.yAxis - 1] = new Rock();
                        }
                    }
                }
            }
            for (int i = k; i < _grid.Size.xAxis; i++)
            {
                if (_grid.GridArray[i, _grid.Size.yAxis - 1] != null)
                {
                    if (_grid.GridArray[i, _grid.Size.yAxis - 1].Symbol == new Rock().Symbol)
                    {
                        if (rand.Next(10) < 8)
                        {
                            _grid.GridArray[i, _grid.Size.yAxis - 2] = new Rock();
                        }
                    }
                }
            }
            for (int i = k; i < _grid.Size.xAxis; i++)
            {
                if (_grid.GridArray[i, _grid.Size.yAxis - 2] != null)
                {
                    if (_grid.GridArray[i, _grid.Size.yAxis - 2].Symbol == new Rock().Symbol)
                    {
                        if (rand.Next(10) < 6)
                        {
                            _grid.GridArray[i, _grid.Size.yAxis - 3] = new Rock();
                        }
                    }
                }
            }
        }

        private void SeedY(int density)
        {

            int r = density % 100;
            int k = (int)(_grid.Size.yAxis / 5);
            Random rand = new Random();
            for (int i = k; i < _grid.Size.yAxis; i = i + k)
            {
                if (rand.Next(100) <= r)
                {
                    int n = rand.Next(k);
                    for (int j = 0; j <= n; j++)
                    {
                        if (_grid.GridArray[0,i - j] == null)
                        {
                            _grid.GridArray[0, i - j] = new Rock();
                        }
                    }
                }
            }
            for (int i = 0; i < _grid.Size.yAxis; i++)
            {
                if (_grid.GridArray[0, i] != null && _grid.GridArray[0, i ].Symbol == new Rock().Symbol)
                {

                    if (rand.Next(10) < 8 && _grid.GridArray[1,i] == null)
                    {
                        _grid.GridArray[1,i] = new Rock();
                    }
                }
            }
            for (int i = 0; i < _grid.Size.yAxis; i++)
            {
                if (_grid.GridArray[1, i] != null)
                {
                    if ( _grid.GridArray[1, i].Symbol == new Rock().Symbol)         
                    {
                        if (rand.Next(10) < 6)
                        {
                            _grid.GridArray[2,i] = new Rock();
                        }
                    }
                }
            }

            if (_grid.Size.xAxis < 7)
            {
                return;
            }

            for (int i = k; i < _grid.Size.yAxis; i = i + k)
            {
                if (rand.Next(100) <= r)
                {
                    int n = rand.Next(k);
                    for (int j = 0; j <= n; j++)
                    {
                        if (_grid.GridArray[_grid.Size.xAxis - 1, i - j] == null)
                        {
                            _grid.GridArray[_grid.Size.xAxis - 1, i - j] = new Rock();
                        }
                    }
                }
            }
            for (int i = 0; i < _grid.Size.yAxis; i++)
            {
                if (_grid.GridArray[_grid.Size.xAxis - 1, i] != null) 
                {
                    if (_grid.GridArray[_grid.Size.xAxis - 1, i].Symbol == new Rock().Symbol)
                    {
                        if (rand.Next(10) < 8 && _grid.GridArray[_grid.Size.xAxis - 2, i] == null)
                        {
                            _grid.GridArray[_grid.Size.xAxis - 2, i] = new Rock();
                        }
                    }
                }
            }
            for (int i = 0; i < _grid.Size.yAxis; i++)
            {
                if (_grid.GridArray[_grid.Size.xAxis - 2, i] != null)
                {
                    if (_grid.GridArray[_grid.Size.xAxis - 2, i].Symbol == new Rock().Symbol)
                    {
                        if (rand.Next(10) < 6)
                        {
                            _grid.GridArray[_grid.Size.xAxis - 3, i] = new Rock();
                        }
                    }
                }
            }
        }

        public void SeedInterior(Position startingPosition)
        {
            if (_grid.Size.xAxis < 15 || _grid.Size.yAxis < 15) return;
            int xInteriorBoxes = (int)((_grid.Size.xAxis - 10) / 5);
            int yInteriorBoxes = (int)((_grid.Size.yAxis - 10) / 5);

            int xBoxDim = (int)(_grid.Size.xAxis - 10) / xInteriorBoxes;
            int yBoxDim = (int)(_grid.Size.yAxis - 10) / yInteriorBoxes;

            Random rand = new Random();


            for(int j = 5; j <yInteriorBoxes*yBoxDim; j = j + yBoxDim)
            {
                for(int i = 5; i <xInteriorBoxes*xBoxDim; i = i + xBoxDim)
                {
                    bool seedBox = true;

                    if(startingPosition.x >= i && startingPosition.x <= i + xBoxDim)
                    {
                        if(startingPosition.y >= j && startingPosition.y <= j + yBoxDim)
                        {
                            seedBox = false;
                        }
                    }
                    if (seedBox)
                    {
                        _grid.GridArray[i + (int)((xBoxDim + 1) / 2), j + (int)((yBoxDim + 1) / 2)] = new Rock();
                    }
                }
            }


        }

        public void SeedCoins()
        {
            _coins = (int)(_grid.Size.xAxis * _grid.Size.yAxis / 20);
            if (_coins < 1) _coins = 1;
            int toPlace = _coins;
            List<(int, int)> positions = [];

            Random rand = new Random();
            while(toPlace > 0)
            {
                int xPos = rand.Next(_grid.Size.xAxis);
                int yPos = rand.Next(_grid.Size.yAxis);
                bool squareFree = false;
                if(_grid.GridArray[xPos, yPos] == null)
                {
                    squareFree = true;
                }
                if (squareFree)
                {
                    if(!positions.Contains((xPos, yPos))) 
                    {
                        _grid.GridArray[xPos, yPos] = new Coin();
                        toPlace--;
                        positions.Add((xPos, yPos));
                        _coins++;
                    }
                }
            }

        }

        public int CollectCoin(Position position)
        {
            score++;
            return score;
        }

    }
}
