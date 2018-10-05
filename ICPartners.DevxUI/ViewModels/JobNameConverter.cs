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
                    Jobname +=  item.JobName + " ";
                }
                return Jobname;
            }




















            //ICPartnersContext context = new ICPartnersContext();

            //Appointment appointment = new Appointment();
            //int TempID = System.Convert.ToInt16((value as AppointmentItem).Id);
            //string JobName="";
            //appointment = context.Appointments.Include("Jobs").FirstOrDefault(x=>x.AppointmentID== TempID);





            //#region rakamgelirse


            //if (appointment.Jobs.Count>1)
            //{
            //    foreach (var Job in appointment.Jobs)
            //    {
            //        JobName = JobName + Job + "\n" ;
            //    }
            //    return JobName;
            //}

            //if (appointment.Jobs.Count == 1)
            //{
            //    return appointment.Jobs.FirstOrDefault().JobName;
            //}
            //if (appointment.Jobs.Count==0)
            //{
            //    return null;
            //}
            //#endregion






            //}
            //var job = value as List<Job>;
            //List<object> list = new List<object>();
            //list = value as List<object>;
            //if (list.Capacity == 1)
            //{
            //    return job.FirstOrDefault().JobName;

            //}
            //else
            //{
            //    string Jobname = "";
            //    foreach (var item in job)
            //    {
            //        Jobname = Jobname + " \n" + item.JobName;
            //    }
            //    return Jobname;
            //}













            return null;
            //string Jobname = "";
            //ICPartnersContext context = new ICPartnersContext();

            //if (value!=null)
            //{

            //    if ((int)value!=0)
            //    {
            //        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
            //        Appointment current = context.Appointments.Include("Jobs").Where(x => x.AppointmentID == (int)value).FirstOrDefault();
            //        //var repo = unitOfWork.appointmentRepository.GetByID((int)value).Jobs;
            //        if (current != null)
            //        {
            //            if (current.Jobs.Count > 1)
            //            {
            //                foreach (var item in current.Jobs)
            //                {
            //                    Jobname = Jobname + item.JobName.ToUpper() + "\n";
            //                }
            //            }
            //            else
            //            {
            //                Jobname = current.Jobs.FirstOrDefault().JobName.ToUpper();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        //value = context.Appointments.Include("Jobs").ToList().LastOrDefault().AppointmentID;
            //        Appointment appointment = context.Appointments.ToList().LastOrDefault();
            //        int lastclild = (int)context.Appointments.Include("Jobs").ToList().LastOrDefault().ParentID;
            //        List <Appointment> listtest = new List<Appointment>();
            //        listtest= context.Appointments.Where(x=>x.ParentID== lastclild).ToList();
            //        foreach (var item in listtest)
            //        {
            //        return Convert(item.AppointmentID, targetType, parameter, culture);
            //        }
                   
            //    }
            //}
           
            //return Jobname;
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
