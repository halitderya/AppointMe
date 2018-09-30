using ICPartners.Domains;
using System.Collections.ObjectModel;
using System.Data.Entity;
using DevExpress.Mvvm.DataAnnotations;
using ICPartners.DAL;
using DevExpress.Mvvm.POCO;
using System.Linq;
using ICPartners.Logic.Customer;
using System;
using ICPartners.Logic.Appointment;
using System.Windows.Media;
using ICPartners.DevxUI.Models;
using System.Collections.Generic;
using DevExpress.Xpf.Core;
using System.Windows;

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
                //Edit appointment
            }
            else if (this.Appointments.Any(x => x.AppointmentID == 0)) //New Appointment

            {

                Appointment NewAppointment;
                Appointment oldAppointment = this.Appointments.FirstOrDefault(x => x.AppointmentID == 0);
                if (JobSelector.JobtoCreate > 0) //Bu if'te exception almamak için ikinci defa kontrol ediliyor.
                {
                    Job JobWillCreate = unitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate);



                    if (unitOfWork.DependentRepository.GetAll().Any(x => x.MainJob == JobWillCreate.JobId))
                    {
                        //Multi-Job

                        List<DependentJobs> DependentJobs = new List<DependentJobs>(unitOfWork.DependentRepository.GetAll().Where(x => x.MainJob == JobWillCreate.JobId).OrderBy(x => x.Sequence).ToList());
                        List<Job> JobList = new List<Job>();
                        JobList.Add(JobWillCreate);
                        foreach (var item in DependentJobs)
                        {
                            JobList.Add(unitOfWork.jobRepository.GetByID(item.DependentJob));
                        }
                        if (JobList.Any(x => x.JobOffsetTime.TotalMinutes > 0))

                        {
                            foreach (var item in JobList.Where(x => x.JobOffsetTime.TotalMinutes > 0))
                            {
                                //Creating offset appointments.........................
                                NewAppointment = new Appointment()
                                {
                                    AppointmentID = 0,
                                    Resource = oldAppointment.Resource,
                                    AppointmentStatus = 0,
                                    StartDate = oldAppointment.StartDate,
                                    EndDate = oldAppointment.StartDate + item.JobTimeSpan,
                                    ResourceRefID = oldAppointment.ResourceRefID,
                                    CustomerRefId = CustomerSelector.CustomerToSelect,
                                    Job = new Collection<Job>()

                                };
                                
                                //NewAppointment.Job.Add(item);
                                this.Appointments.Add(NewAppointment);

                            }
                            //JobList.RemoveAll(x => x.JobOffsetTime.TotalMinutes > 0);
                          
                        }
                        //Creating multi-job if exists................................
                        if (JobList.Count > 0)
                        {
                            
                            NewAppointment = new Appointment()
                            {
                                AppointmentID = 0,
                                Resource = oldAppointment.Resource,
                                AppointmentStatus = 0,
                                ResourceRefID = oldAppointment.ResourceRefID,
                                CustomerRefId = CustomerSelector.CustomerToSelect,
                                Job = new List<Job>()

                            };
                            if (JobList.Any(x => x.JobOffsetTime.TotalMinutes > 0))
                            {
                                var OffSet = JobList.Sum(x => x.JobOffsetTime.TotalMinutes);
                                NewAppointment.StartDate = this.Appointments.LastOrDefault().EndDate.AddMinutes(OffSet);


                            }

                            NewAppointment.EndDate = NewAppointment.StartDate.AddMinutes(JobList.Sum(x => x.JobTimeSpan.Minutes));
                            NewAppointment.Job = JobList;
                            JobList.Clear();

                            //bool con1 = this.Appointments.Any(x => x.StartDate < NewAppointment.EndDate);
                            //bool con2 = this.Appointments.Any(x => x.StartDate > NewAppointment.StartDate);
                            //bool overlap =con1 && con2;
                            //if (overlap == true)
                            //{
                                

                            //}

                            this.Appointments.Add(NewAppointment);
                        }


                    }



                    #endregion
                    else //Single Appointment
                    {

                        
                        NewAppointment = new Appointment()
                        {
                            AppointmentID = 0,
                            Resource = oldAppointment.Resource,
                            AppointmentStatus = 0,
                            StartDate = oldAppointment.StartDate,
                            EndDate = oldAppointment.EndDate,
                            ResourceRefID = oldAppointment.ResourceRefID,
                            CustomerRefId = CustomerSelector.CustomerToSelect,
                           
                        };
                        NewAppointment.Job = new Collection<Job>
                        {
                            JobWillCreate
                        };
                        //IcPartnersContext.Entry(NewAppointment.Job).State = EntityState.Detached;

                        this.Appointments.Add(NewAppointment);
                        

                        //DECIDE- Single Job.
                    }
                }
                this.Appointments.Remove(oldAppointment);
                JobSelector.JobtoCreate = 0;
                IcPartnersContext.SaveChanges();
            }


        

        }
        //Check JobSelector 








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
