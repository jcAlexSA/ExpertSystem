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
     * 
     * value = значение которое задает источник данных
     * 
     * targetType = тип целевого свойства (который нужно вернуть)
     * 
     * parameter = дополнительные параметры
     * 
     * culture = культура
     * 
     * Returns = конвертированное значение
     * 
     */

    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Console.WriteLine("to: value: {0}, param: {1}", value, System.Convert.ToByte(parameter));

            if ((byte)value == System.Convert.ToByte(parameter))
                return true;
            return false; 

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Console.WriteLine("from: value: {0}, param: {1}", value, System.Convert.ToByte(parameter));

            if (System.Convert.ToBoolean(value))
            {
                switch (System.Convert.ToByte(parameter))
                {
                    case 0: Console.WriteLine("at 0 val"); return 0;
                    case 1: Console.WriteLine("at 1 val"); return 1;
                    case 2: Console.WriteLine("at 2 val"); return 2;
                    default: Console.WriteLine("at default val"); return 0;
                }
            }
            return false;
        }
    }
}
