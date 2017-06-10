using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model
{
    public class FuzzyVariable
    {
        private string _name;
        private List<Term> _terms;
        private string _comment;
        private VariableType _type;
        private int _minValue;
        private int _maxValue;

        
        public string Name
        {
            get { Console.WriteLine("_name: " + _name); return _name; }
            set { if (string.Compare(_name, value, true) != 0) _name = value; }
        }

        public List<Term> Terms
        {
            get { return _terms; }
            set { _terms = value; }
        }

        public void AddTerm(Term newTerm)
        {
            if(_terms != null)
                _terms.Add(newTerm);
            else
            {
                _terms = new List<Term>();
                _terms.Add(newTerm);
            }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public int CountTerms
        {
            get
            {
                if (_terms != null) return _terms.Count;
                else return 0;
            }
        }

        public byte Type
        {
            get { Console.WriteLine("TYPE : " + (byte)_type); return (byte)_type; }
            set { _type = (VariableType)value; Console.WriteLine("VALUE : " + value); }
        }
        public int Max
        {
            get { return _maxValue; }
            set { if (_maxValue != value && _maxValue >= _minValue) _maxValue = value; }
        }

        public int Min
        {
            get { return _minValue; }
            set { if (_minValue != value && _minValue <= _maxValue)  _minValue = value; }
        }

        public FuzzyVariable() { }
        
        public FuzzyVariable(string name)
        {
            _name = name;
        }

        public FuzzyVariable(string name, List<Term> terms)
        {
            _name = name;
            _terms = terms;
        }
        
    }
}
