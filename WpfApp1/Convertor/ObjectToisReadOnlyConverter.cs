using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WorkTogetherDBLib.Class;

namespace WorkTogetherWPF.Convertor;

class ObjectToisReadOnlyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isReadOnly = true;

        if (value is not null && ((User)value).Roles.Contains(((string)parameter)))
        {
            isReadOnly = true;
        }
        return isReadOnly;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
