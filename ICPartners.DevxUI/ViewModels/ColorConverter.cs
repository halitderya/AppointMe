using ICPartners.DAL;
using ICPartners.Domains;
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
    public class ColorConverter : MarkupExtension, IValueConverter

    {
        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       {
            var ComingJobs = (value as ICollection<Job>);
            if (ComingJobs.Count==1)
            {
                
            }
            string oldcolor=null;
            //string oldcolor = unitOfWork.jobRepository.GetByID((int)value).Color;
            if ((ComingJobs.FirstOrDefault().GetType() == typeof(Domains.Job)) && ComingJobs.FirstOrDefault().Color.ToString().StartsWith("0x"))
            {
                return String.Concat("#", ComingJobs.FirstOrDefault().Color.ToString().Remove(0, 1));
            }

            else
            {
                return oldcolor;
            }
                
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value.GetType() == typeof(string)) && value.ToString().StartsWith("0x"))
                return String.Concat("#", value.ToString().Remove(0, 2));
            else
                return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
