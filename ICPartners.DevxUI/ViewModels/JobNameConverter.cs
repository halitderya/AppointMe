using DevExpress.Xpf.Scheduling;
using ICPartners.DAL;
using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ICPartners.DevxUI.ViewModels
{
    public class JobNameConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value!=null)
            {
                HashSet<Job> list = (HashSet<Job>)value;

                if (list.Count == 1)
                {
                    return list.FirstOrDefault().JobName;

                }
                else
                {
                    string Jobname = "";
                    
                    foreach (var item in list)
                    {

                        Jobname += item.JobName + " ";
                    }
                    return Jobname;
                }
            }
            return null;

        }
        void Recall()
        {

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
