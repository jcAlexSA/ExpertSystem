using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model.MMBF_Functions
{
    public class TriangleFunction : I_MMBF_Function
    {
        private string _name = "Triangle";
        private float _low;
        private float _mid;
        private float _high;

        public string Name
        {
            get { return _name; }
        }

        public float Low
        {
            get { return _low; }
            set { _low = value; }
        }

        public float Mid
        {
            get { return _mid; }
            set { _mid = value; }
        }
        public float High
        {
            get { return _high; }
            set { _high = value; }
        }
    }
}
