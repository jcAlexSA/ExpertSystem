using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExpertSystem.Model.Converters
{
    /// <summary>
    /// this class using in RuleBlockWizard to COPY (????WTF) values 
    /// and to possibility transfer both 
    /// listBoxes (with input variables and output)
    /// </summary>
    /// TODO   TO COME UP WITH SOME WAY TO PASS BOTH LIST_BOX WITHOUT THIS SHIT CLASS
    public class MultiParametersConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null)
                return null;

            return this.Copy(values);
        }

        private object[] Copy(object[] values)
        {
            object[] objArr = new object[values.Length];
            for (int i = 0; i < objArr.Length; i++)
            {
                objArr[i] = values[i];
            }
            return objArr;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("IN MULTI_PARAMETER_CONVERTER IN METHOD ConvertBack() THROW THIS EXEPTIONS");
        }
    }
}
