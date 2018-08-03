using ICPartners.Domains;
using System.Collections.ObjectModel;
using System.Data.Entity;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Scheduling;
using ICPartners.DAL;
using DevExpress.Mvvm.POCO;
using System.Windows;

namespace ICPartners.DevxUI.ViewModels
{
    [POCOViewModel]
    #region declarations
    public class AppointmentViewModel
    {


        public virtual ObservableCollection<Resource> Resources { get; set; }
        public virtual ObservableCollection<Appointment> Appointments { get; set; }
        public virtual ObservableCollection<Job> Jobs { get; set; }



        ICPartnersContext IcPartnersContext;
        #endregion

        #region #savechanges

        public void AppointmentsUpdated()
        {
            
            IcPartnersContext.SaveChanges();
        }

   

        #endregion

        #region #InitNewAppointment
        public void InitNewAppointment(AppointmentItemEventArgs args)
        {

            args.Appointment.Reminders.Clear();


            
        }

        #endregion #InitNewAppointment


        #region #filldata
        public AppointmentViewModel()
        {
            IcPartnersContext = new ICPartnersContext();

            IcPartnersContext.Resources.Load();
            Resources = IcPartnersContext.Resources.Local;

            IcPartnersContext.Appointments.Load();
            Appointments = IcPartnersContext.Appointments.Local;

            IcPartnersContext.Jobs.Load();
            Jobs = IcPartnersContext.Jobs.Local;

        }
        #endregion #filldata
        public static AppointmentViewModel Create()
        {
            return ViewModelSource.Create(() => new AppointmentViewModel());
        }
    }


}
