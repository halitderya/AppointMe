using System;
using System.Windows.Data;
using System.Windows.Markup;
using ICPartners.DAL;
using ICPartners.Domains;

namespace ICPartners.DevxUI.ViewModels
{
   public class DisplayConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {

            if (value == null) { return null; }
            if(value is Domains.Customer)
            {
                Customer customer = (value as ICPartners.Domains.Customer);
                return customer.CustomerName + " " + customer.CustomerSurname;
            }
            else
            {
                UnitOfWork work = new UnitOfWork(new ICPartnersContext());
                var Customer = work.CustomerRepository.GetByID((int)(value));
                return Customer.CustomerName + " " + Customer.CustomerSurname;
            }
            
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
