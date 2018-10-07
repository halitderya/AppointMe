using ICPartners.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ICPartners.DevxUI.ViewModels
{
    public class CustomerNameConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                ICPartnersContext context = new ICPartnersContext();
                var repo2 = context.Customers.FirstOrDefault(x => x.CustomerID == (int)value);
                //var repo = unitOfWork.CustomerRepository.GetByID((int)value);

                string CustomerFullName = repo2.CustomerName.ToUpper() +" "+ repo2.CustomerSurname.ToUpper();
                return CustomerFullName;


            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
