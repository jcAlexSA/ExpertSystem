using ExpertSystem.Model.MembershipFunctionsModel.CalculateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model.MMBF_Functions
{
    public class TriangleFunction : IMembershipFunction
    {
        private string _name = "Triangle";
        private float _low;
        private float _mid;
        private float _high;
        private ICalculateMembershipFunctionModel _functionCalculate;

        public string Name
        {
            get { return _name; }
        }        
        
        public float Low
        {
            get
            {
                return _low;
            }
            set
            {
                _low = value;
            }
        }

        public float Mid
        {
            get
            {
                return _mid;
            }
            set
            {
                _mid = value;
            }
        }

        public float High
        {
            get
            {
                return _high;
            }
            set
            {
                _high = value;
            }
        }

        public ICalculateMembershipFunctionModel FunctionCalculate
        {
            get
            {
                if (_functionCalculate == null)
                    _functionCalculate = new TriangleCalculateFunctionModel();
                return _functionCalculate;
            }
            set
            {
                _functionCalculate = value;
            }
        }

        public TriangleFunction()
        {
            FunctionCalculate = new TriangleCalculateFunctionModel();
        }

        public TriangleFunction(string name, float low, float mid, float high, ICalculateMembershipFunctionModel functionCalculate)
        {
            _name = name;
            _low = low;
            _mid = mid;
            _high = high;
            _functionCalculate = functionCalculate;
        }
    }
}
