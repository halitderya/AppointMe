using ICPartners.Domains;
using System.Collections.ObjectModel;
using System.Data.Entity;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Scheduling;
using ICPartners.DAL;
using DevExpress.Mvvm.POCO;
using System.Windows;
using System.Linq;
using ICPartners.Logic.Customer;
using System;
using ICPartners.Logic.Appointment;
using System.Collections.Generic;
using ICPartners.DevxUI.UserControls;

namespace ICPartners.DevxUI.ViewModels
{
    [POCOViewModel]
    #region declarations
    public class AppointmentViewModel
    {
      
        public virtual ObservableCollection<Resource> Resources { get; set; }
        public virtual ObservableCollection<Appointment> Appointments { get; set; }
        public virtual ObservableCollection<Job> Jobs { get; set; }
        public virtual ObservableCollection<DependentJobs> DependentJobs { get; set; }



        ICPartnersContext IcPartnersContext;
        #endregion

        #region #savechanges

        public void AppointmentsUpdated(Appointment[] appointment)
        {
            if (appointment != null)
            {

            }
            if (JobSelector.JobtoCreate > 0)
            {

                Appointment NewMainAppointment = this.Appointments.FirstOrDefault(x => x.AppointmentID == 0);
                this.Appointments.Remove(NewMainAppointment);

                NewMainAppointment.JobRefId = JobSelector.JobtoCreate;
                NewMainAppointment.EndDate = NewMainAppointment.StartDate.Add(Jobs.FirstOrDefault(x => x.JobId == NewMainAppointment.JobRefId).JobTimeSpan);
                NewMainAppointment.CustomerRefId = CustomerSelector.CustomerToSelect;
                
                this.Appointments.Add(NewMainAppointment);
                IcPartnersContext.SaveChanges();
                JobSelector.JobtoCreate = 0;

                UCAppointment happ = new UCAppointment();
                happ.MainScheduler.RefreshData();




                if (JobSelector.DependentJobs.Count > 0)
                {
                    foreach (var item in JobSelector.DependentJobs)
                    {
                        Appointment app = new Appointment();
                        app.StartDate = Appointments.LastOrDefault().EndDate;
                        app.JobRefId = Jobs.FirstOrDefault(x => x.JobId == item.DependentJob).JobId;
                        app.CustomerRefId = Appointments.LastOrDefault().CustomerRefId;
                        app.EndDate = app.StartDate.Add(Jobs.FirstOrDefault(x=>x.JobId==app.JobRefId).JobTimeSpan);
                        if (item.DefaultResource == 0)
                        {
                            app.ResourceRefID = Appointments.LastOrDefault().ResourceRefID;
                        }
                        else
                        {
                            app.ResourceRefID = item.DefaultResource;

                        }
                        Appointments.Add(app);
                       

                        IcPartnersContext.SaveChanges();
                     
                    }
                    JobSelector.DependentJobs = null;
                }

            }

            

           
        }



        #endregion

        #region #InitNewAppointment
    

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

            IcPartnersContext.DependentJobs.Load();
            DependentJobs = IcPartnersContext.DependentJobs.Local;

        }
        #endregion #filldata
        public static AppointmentViewModel Create()
        {
            return ViewModelSource.Create(() => new AppointmentViewModel());
        }
    }


}
