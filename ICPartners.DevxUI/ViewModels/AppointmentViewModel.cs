using ICPartners.Domains;
using System.Collections.ObjectModel;
using System.Data.Entity;
using DevExpress.Mvvm.DataAnnotations;
using ICPartners.DAL;
using DevExpress.Mvvm.POCO;
using System.Linq;
using ICPartners.Logic.Customer;
using ICPartners.Logic.Appointment;
using ICPartners.DevxUI.UserControls;
using System.Windows.Media;
using ICPartners.DevxUI.Models;

namespace ICPartners.DevxUI.ViewModels
{
[POCOViewModel]
#region declarations
    public class AppointmentViewModel
    {
        public static string[] StatusLabels = { "Open", "In Progress", "Cancelled", "Waiting For Update", "Completed - Waiting Payment", "Completed - Payment Made" };
        public static Brush[] StatusBrushes = { new SolidColorBrush(Colors.Yellow), new SolidColorBrush(Colors.Blue), new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Orange), new SolidColorBrush(Colors.GreenYellow), new SolidColorBrush(Colors.Green) };
        
        public virtual ObservableCollection<Resource> Resources { get; set; }
        public virtual ObservableCollection<Appointment> Appointments { get; set; }
        public virtual ObservableCollection<Job> Jobs { get; set; }
        public virtual ObservableCollection<DependentJobs> DependentJobs { get; set; }
        public virtual ObservableCollection<StatusesState> StatusState { get; set; }


        ICPartnersContext IcPartnersContext;
        #endregion
#region #savechanges

        public void AppointmentsUpdated(Appointment[] appointment)
        {
            if (appointment != null)
            {
            }
            
            if(this.Appointments.Any(x=>x.AppointmentID==0))
            if (JobSelector.JobtoCreate > 0)
            {
                Appointment NewMainAppointment = this.Appointments.FirstOrDefault(x => x.AppointmentID == 0);
                this.Appointments.Remove(NewMainAppointment);
                NewMainAppointment.JobRefId = JobSelector.JobtoCreate;
                NewMainAppointment.EndDate = NewMainAppointment.StartDate.Add(Jobs.FirstOrDefault(x => x.JobId == NewMainAppointment.JobRefId).JobTimeSpan);
                NewMainAppointment.CustomerRefId = CustomerSelector.CustomerToSelect;
                this.Appointments.Add(NewMainAppointment);
                var ddf = IcPartnersContext.SaveChanges();
                JobSelector.JobtoCreate = 0;


                //if (JobSelector.DependentJobs.Count > 0)
                //{
                //    foreach (var item in JobSelector.DependentJobs)
                //    {
                //        Appointment app = new Appointment();
                //        app.StartDate = Appointments.LastOrDefault().EndDate;

                //        app.JobRefId = Jobs.FirstOrDefault(x => x.JobId == item.DependentJob).JobId;
                //        app.CustomerRefId = Appointments.LastOrDefault().CustomerRefId;
                //        app.EndDate = app.StartDate.Add(Jobs.FirstOrDefault(x => x.JobId == app.JobRefId).JobTimeSpan);
                //        if (item.DefaultResource == 0)
                //        {
                //            app.ResourceRefID = Appointments.LastOrDefault().ResourceRefID;
                //        }
                //        else
                //        {
                //            app.ResourceRefID = item.DefaultResource;

                //        }
                //        Appointments.Add(app);
                //        //UCAppointment ucAppointment = new UCAppointment();
                //        //ucAppointment.MainScheduler.RefreshData();

                //    }
                //    JobSelector.DependentJobs = null;
                //}
            }
            IcPartnersContext.SaveChanges();
        }



        #endregion
#region #InitNewAppointment


        #endregion #InitNewAppointment
#region #filldata
        public AppointmentViewModel()
{
      IcPartnersContext = new ICPartnersContext();
            StatusState = CreateStatuses();
            IcPartnersContext.Resources.Load();
      Resources = IcPartnersContext.Resources.Local;
    
      IcPartnersContext.Jobs.Load();
      Jobs = IcPartnersContext.Jobs.Local;
      IcPartnersContext.DependentJobs.Load();
      DependentJobs = IcPartnersContext.DependentJobs.Local;
            IcPartnersContext.Appointments.Load();
            Appointments = IcPartnersContext.Appointments.Local;



        }


        ObservableCollection<StatusesState> CreateStatuses()
        {
            ObservableCollection<StatusesState> result = new ObservableCollection<StatusesState>();
            int count = StatusLabels.Length;
            for (int i = 0; i < count; i++)
            {
                StatusesState statuses = StatusesState.Create();
                statuses.Id = i;
                statuses.Brush = StatusBrushes[i];
                statuses.Caption = StatusLabels[i];
                result.Add(statuses);
            }
            return result;
        }
        #endregion #filldata
        public static AppointmentViewModel Create()
{
     return ViewModelSource.Create(() => new AppointmentViewModel());
}
    }
}
