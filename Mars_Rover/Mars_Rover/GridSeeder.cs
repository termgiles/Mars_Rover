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
        private int _r = 0;
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
            if (_r != 0) return;

            SeedX(density);
            SeedY(density);
            _r++;
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

        public void SeedInterior()
        {
            return;
        }

    }
}
