using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model
{
    public class FuzzyVariableModel
    {
        private string _name;
        private ObservableCollection<TermModel> _terms;
        private string _comment;
        private VariableType _type;
        private int _minValue = 0;
        private int _maxValue = 1;

        
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.Compare(_name, value, true) != 0)
                    _name = value;
            }
        }

        public ObservableCollection<TermModel> Terms
        {
            get
            {
                if (_terms == null)
                    _terms = new ObservableCollection<TermModel>();
                return _terms;
            }
            set
            {
                _terms = value;
            }
        }
        
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }
        
        public byte Type
        {
            get
            {
                return (byte)_type;
            }
            set
            {
                _type = (VariableType)value;
            }
        }

        public int Max
        {
            get
            {
                return _maxValue;
            }
            set
            {
                if (_maxValue != value && _maxValue >= _minValue)
                    _maxValue = value;
            }
        }

        public int Min
        {
            get
            {
                return _minValue;
            }
            set
            {
                if (_minValue != value && _minValue <= _maxValue)
                    _minValue = value;
            }
        }

        public void AddTerm(TermModel newTerm)
        {
            if (_terms == null)
                _terms = new ObservableCollection<TermModel>();
            _terms.Add(newTerm);
        }

        public FuzzyVariableModel()
        {

        }
        
        public FuzzyVariableModel(string name)
        {
            _name = name;
        }

        public FuzzyVariableModel(string name, ObservableCollection<TermModel> terms)
        {
            _name = name;
            _terms = terms;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return false;
            //if (obj == null)
            //    return false;

            //return string.Equals((obj as FuzzyVariableModel).Name, this.Name);
        }
    }
}
