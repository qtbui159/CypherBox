using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CypherBoxControl.Converters
{
    class PlainTextToCypherTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 3)
            {
                return string.Empty;
            }

            if (!(values[0] is string && values[1] is bool && values[2] is char))
            {
                return string.Empty;
            }

            string stringValue = values[0] as string;
            bool showPlainText = (bool)values[1];
            char cypherChar = (char)values[2];

            if (string.IsNullOrEmpty(stringValue))
            {
                return string.Empty;
            }

            if (showPlainText)
            {
                return stringValue;
            }

            return new string(cypherChar, stringValue.Length);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
