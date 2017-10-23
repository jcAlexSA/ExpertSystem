using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<FuzzyVariableModel> _inputVariables;

        public ObservableCollection<FuzzyVariableModel> InputVariables
        {
            get { return _inputVariables; }
            set { _inputVariables = value; }
        }

        private ObservableCollection<FuzzyVariableModel> _outputVariables;

        public ObservableCollection<FuzzyVariableModel> OutputVatiables
        {
            get { return _outputVariables; }
            set { _outputVariables = value; }
        }

        
        public RuleBlockModel() : this(null, null, null)
        {
        }

        public RuleBlockModel(string name) : this(name, null, null)
        {
        }

        public RuleBlockModel(string name, ObservableCollection<FuzzyVariableModel> inputVariables,
            ObservableCollection<FuzzyVariableModel> outputVariables)
        {
            _name = name;
            _inputVariables = inputVariables ?? new ObservableCollection<FuzzyVariableModel>();
            _outputVariables = outputVariables ?? new ObservableCollection<FuzzyVariableModel>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return (obj as RuleBlockModel).Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    //public class MultiParametersConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (values[0] == null || values[1] == null)
    //            return null;

    //        return this.Copy(values);
    //    }

    //    private object[] Copy(object[] values)
    //    {
    //        object[] objArr = new object[values.Length];
    //        for (int i = 0; i < objArr.Length; i++)
    //        {
    //            objArr[i] = values[i];
    //        }
    //        return objArr;
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
