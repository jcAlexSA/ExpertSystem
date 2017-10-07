using ExpertSystem.Model.MMBF_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExpertSystem.Model
{
    public class TermModel
    {
        private string _nameTerm;

        private IMembershipFunction _function;

        public string NameTerm
        {
            get
            {
                return _nameTerm;
            }
            set
            {
                _nameTerm = value;
            }
        }

        public IMembershipFunction Function
        {
            get
            {
                if (_function == null)
                    _function = new TriangleFunction();
                return _function;
            }
            set
            {
                _function = value;
            }
        }

        public TermModel()
        {
            _function = new TriangleFunction();
        }
        
    }        
}
