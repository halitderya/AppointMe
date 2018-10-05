using ICPartners.DAL;
using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace ICPartners.DevxUI.ViewModels
{
    public class ColorConverter : MarkupExtension, IValueConverter

    {
        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HashSet<Job> list = (HashSet<Job>)value;

        
                string oldcolor = list.FirstOrDefault().Color;
                if (oldcolor.ToString().StartsWith("0x"))
                    return String.Concat("#", oldcolor.ToString().Remove(0, 1));
                else
                    return oldcolor;
        

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HashSet<Job> list = (HashSet<Job>)value;

          
                string oldcolor = list.FirstOrDefault().Color;
                if (oldcolor.ToString().StartsWith("0x"))
                    return String.Concat("#", oldcolor.ToString().Remove(0, 1));
                else
                    return oldcolor;
           
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
