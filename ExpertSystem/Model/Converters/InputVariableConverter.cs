//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Data;

//namespace ExpertSystem.Model.Converters
//{
//    public class InputVariableConverter : IValueConverter
//    {
//        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            if (value == null)
//                return null;
            
//            var inputVariables = GetOnlyInputVariablesFromList(value as ObservableCollection<FuzzyVariableModel>);

//            return inputVariables;
//        }

//        private ObservableCollection<FuzzyVariableModel> GetOnlyInputVariablesFromList(ObservableCollection<FuzzyVariableModel> variables)
//        {
//            ObservableCollection<FuzzyVariableModel> inputVariables = new ObservableCollection<FuzzyVariableModel>();
//            foreach (var var in variables)
//            {
//                if (var.Type == (byte)VariableType.Input)
//                    inputVariables.Add(var);
//            }
//            return inputVariables;
//        }

//        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            throw new NotImplementedException("In Converter TO_InputVariables exception");
//        }
//    }
//}
