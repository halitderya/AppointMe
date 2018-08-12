using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace ICPartners.DevxUI.ViewModels {
    #region #HtmlColorCodeToHexConverter
    public class HtmlColorCodeToHexConverter : MarkupExtension, IValueConverter  {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var str = value as string;
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            return (Color)System.Windows.Media.ColorConverter.ConvertFromString(str);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? null : value.ToString();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;        }
    }
    #endregion #HtmlColorCodeToHexConverter
}
