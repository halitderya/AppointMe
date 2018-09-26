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
using System.Collections.Generic;

namespace ICPartners.DevxUI.ViewModels
{
[POCOViewModel]
#region declarations
    public class AppointmentViewModel
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
        public static string[] StatusLabels = { "Open", "In Progress", "Cancelled", "Waiting For Update", "Completed - Waiting Payment", "Completed - Payment Made" };
        public static Brush[] StatusBrushes = { new SolidColorBrush(Colors.Yellow), new SolidColorBrush(Colors.Blue), new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Orange), new SolidColorBrush(Colors.GreenYellow), new SolidColorBrush(Colors.Green) };
        
        public virtual ObservableCollection<Resource> Resources { get; set; }
        private ObservableCollection<Appointment> _appointment;
        public virtual ObservableCollection<Appointment> Appointments {

            get
            {
                //if (_appointment.LastOrDefault().Job == null)
                //{
                //    _appointment.LastOrDefault().Job = new List<Job>();
                //}
                return this._appointment;
            }
            set
            {

                this._appointment = value;

            }

        }
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
                //Edit appointment
            }
            List<Domains.DependentJobs> DependentJobs = new List<Domains.DependentJobs>();
            List<Domains.Job> JobList = new List<Domains.Job>();
            Appointment oldAppointment = this.Appointments.FirstOrDefault(x => x.AppointmentID == 0);
            if (this.Appointments.Any(x => x.AppointmentID == 0))
                if (JobSelector.JobtoCreate > 0)
                {
                    Appointment NewMainAppointment = new Appointment()
                    {
                        AppointmentID = 0,
                        Resource = oldAppointment.Resource,
                        AppointmentStatus = 0,
                        StartDate = oldAppointment.StartDate,
                        EndDate = oldAppointment.EndDate,
                        ResourceRefID = oldAppointment.ResourceRefID,
                        CustomerRefId = CustomerSelector.CustomerToSelect,
                        Job = new List<Job>()
                        

                    };
                        

                    
                    
                    
                    this.Appointments.Remove(oldAppointment);
                    //NewMainAppointment.CustomerRefId = CustomerSelector.CustomerToSelect;
                    Job JobWillCreate = unitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate);
                   
                    if (unitOfWork.DependentRepository.GetAll().Any(x => x.MainJob == JobWillCreate.JobId))
                    {
                        DependentJobs = unitOfWork.DependentRepository.GetAll().Where(x => x.MainJob == JobWillCreate.JobId).OrderBy(x => x.Sequence).ToList();

                        foreach (var item in DependentJobs)
                        {
                            JobList.Add(unitOfWork.jobRepository.GetByID(item.MainJob));
                        }

                        //Is the any offset job in the list?
                        if (JobList.Any(x => x.JobOffsetTime.TotalSeconds > 0))
                        {
                            //DECIDE- Multi-job with offset.
                        }
                        else
                        {
                         

                            //DECIDE- Multi-job without offset



                        }


                    }
                    else

                    {



                        NewMainAppointment.Job.Add(IcPartnersContext.Jobs.FirstOrDefault(x=>x.JobId==JobSelector.JobtoCreate));
                       
                        //List<Job> job= new List<Job>();
                        //job.Add(unitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate));
                        //NewMainAppointment.Job= job;

                        

                        //DECIDE- Single Job.

                    }



                    this.Appointments.Add(NewMainAppointment);


                 
                }
            JobSelector.JobtoCreate = 0;

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
            IcPartnersContext.Appointments.Include("Job").Load();
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
