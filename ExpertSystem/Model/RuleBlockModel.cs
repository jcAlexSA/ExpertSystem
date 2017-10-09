using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model
{
    public class RuleBlockModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<FuzzyVariableModel> _inputVariables;

        public List<FuzzyVariableModel> InputVariables
        {
            get { return _inputVariables; }
            set { _inputVariables = value; }
        }

        private List<FuzzyVariableModel> _outputVariables;

        public List<FuzzyVariableModel> OutputVatiables
        {
            get { return _outputVariables; }
            set { _outputVariables = value; }
        }

        
        public RuleBlockModel()
        {

        }

        public RuleBlockModel(string name)
        {
            _name = name;
        }

    }
}
