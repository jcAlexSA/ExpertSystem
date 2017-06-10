using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExpertSystem.Model
{
    public enum VariableType : byte
    {
        Input = 0,
        Output,
        Intermediate
    };
    

    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Console.WriteLine("value: {0}, param: {1}", value, System.Convert.ToByte(parameter));
            return System.Convert.ToByte(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Console.WriteLine("value: {0}, param: {1}", value, System.Convert.ToByte(parameter));
            return System.Convert.ToByte(parameter);
        }
    }
}
