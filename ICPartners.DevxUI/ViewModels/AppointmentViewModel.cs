using ICPartners.Domains;
using System.Collections.ObjectModel;
using System.Data.Entity;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Scheduling;
using ICPartners.DAL;
using DevExpress.Mvvm.POCO;
using System.Windows;
using System.Linq;
using System;

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
            var dede= appointment[0];

            }

            if (this.Appointments.FirstOrDefault(x => x.AppointmentID == 0) != null)
            {
                Appointment oldAppointment = this.Appointments.FirstOrDefault(x => x.AppointmentID == 0);

                var oldap = from a in Appointments
                            join d in DependentJobs
                            on a.JobRefId equals d.MainJob
                            join j in Jobs on a.JobRefId equals j.JobId
                            where a.AppointmentID==oldAppointment.AppointmentID
                            select new
                            {

                                
                                d.MainJob,
                                d.DependentJob,
                                d.DefaultResource,
                                a.JobRefId,
                                a.ResourceRefID
                                
                                
                                

                                
                            };

                if (oldap.Count() > 0)
                {

                    foreach (var item in oldap.ToList())
                    {
                        Appointment newAppointment = new Appointment();
                        newAppointment.JobRefId = item.JobRefId;
                        newAppointment.StartDate = oldAppointment.EndDate;
                        newAppointment.EndDate = oldAppointment.EndDate+ Jobs.FirstOrDefault(x=>x.JobId==item.DependentJob).JobTimeSpan;
                        if(item.DefaultResource!=0)
                        {
                            newAppointment.ResourceRefID = item.DefaultResource;


                        }
                        else
                        {
                            newAppointment.ResourceRefID = oldAppointment.ResourceRefID;
                        }
                        Appointments.Add(newAppointment);
                        IcPartnersContext.SaveChanges();


                    }
                }
                           
                    
                  






            }


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
