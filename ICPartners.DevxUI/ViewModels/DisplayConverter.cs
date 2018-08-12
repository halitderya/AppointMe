using System;
using System.Windows.Data;
using System.Windows.Markup;
using ICPartners.Domains;

namespace ICPartners.DevxUI.ViewModels
{
   public class DisplayConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value == null) return null;
            Customer cus = value as Customer;
            return cus.CustomerName + " " + cus.CustomerSurname;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
