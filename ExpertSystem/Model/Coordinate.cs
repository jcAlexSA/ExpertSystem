using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model
{
    public class Coordinate
    {
        private int _x;
        private int _y;

        public Coordinate()
        {
            _x = _y = 0;
        }

        public Coordinate(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

}
