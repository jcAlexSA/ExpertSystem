using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model.Converters
{
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

    public class EnumConverter : System.Windows.Data.IValueConverter
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
