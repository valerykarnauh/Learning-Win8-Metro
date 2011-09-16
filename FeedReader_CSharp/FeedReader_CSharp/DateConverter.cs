using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace FeedReader
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, string targetType, object parameter, string culture)
        {
            return ((DateTime)value).ToString("d");
        }

        public object ConvertBack(object value, string targetType, object parameter, string culture)
        {
            DateTime resultDateTime;
            if (DateTime.TryParse(value as string, out resultDateTime))
                return resultDateTime;
            
            return DependencyProperty.UnsetValue;
        }
    }
}
