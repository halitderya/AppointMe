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
                UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
                var repo = unitOfWork.CustomerRepository.GetByID((int)value);

                string CustomerFullName = repo.CustomerName.ToUpper() +" "+ repo.CustomerSurname.ToUpper();
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
