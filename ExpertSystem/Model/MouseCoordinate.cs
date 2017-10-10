using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model
{
    public class MouseCoordinate
    {
        private int _x;

        public int X
        {
            get { return _x; }
            set
            {
                if(value >= 0)
                    _x = value;
            }
        }

        private int _y;

        public int Y
        {
            get { return _y; }
            set
            {
                if (value >= 0)
                    _y = value;
            }
        }

        public MouseCoordinate(int xParam, int yParam)
        {
            _x = xParam;
            _y = yParam;
        }

    }
}
