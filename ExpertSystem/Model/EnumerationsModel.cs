using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExpertSystem.Model
{
    public enum VariableType
    {
        Input = 0,
        Output,
        Intermediate
    };
    

    /* 
     * value = значение которое задает источник данных
     * 
     * targetType = тип целевого свойства (который нужно вернуть)
     * 
     * parameter = дополнительные параметры
     * 
     * culture = культура
     * 
     * Returns = конвертированное значение
     */

    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((byte)value == System.Convert.ToByte(parameter))
                return true;
            return false; 

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToByte(parameter);
        }
    }
}
