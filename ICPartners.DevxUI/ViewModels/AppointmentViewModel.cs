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
using System.ComponentModel;

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
        //private ObservableCollection<Appointment> _Appointment;

        public virtual ObservableCollection<Appointment> Appointments
        {
            get;set;

        }
        //public virtual ObservableCollection<Job> Jobs { get; set; }
        public virtual ObservableCollection<DependentJobs> DependentJobs { get; set; }
        public virtual ObservableCollection<StatusesState> StatusState { get; set; }
        public static Appointment MasterAppointment { get; set; }
        Appointment NewAppointment;

        ICPartnersContext IcPartnersContext;


        
        
        #endregion

        #region #savechanges

        public void AppointmentsUpdated(Appointment[] appointment)
        {
            if (appointment != null)
            {
                //Edit appointment
            }
            if (this.Appointments.Any(x => x.AppointmentID == 0)) //New Appointment

            {
                Appointment oldAppointment = this.Appointments.FirstOrDefault(x => x.AppointmentID == 0);
                if (JobSelector.JobtoCreate > 0) //Bu if'te exception almamak için ikinci defa kontrol ediliyor.
                {
                    Job JobWillCreate = unitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate);



                    if (unitOfWork.DependentRepository.GetAll().Any(x => x.MainJob == JobWillCreate.JobId))
                    {
                        //Multi-Job

                        List<DependentJobs> DependentJobs = new List<DependentJobs>(unitOfWork.DependentRepository.GetAll().Where(x => x.MainJob == JobWillCreate.JobId).OrderBy(x => x.Sequence).ToList());
                        List<Job> JobList = new List<Job>();
                        List<Job> JobToRemove = new List<Job>();
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
                                    ResourceRefID=oldAppointment.ResourceRefID,
                                    AppointmentStatus = 0,
                                    StartDate = oldAppointment.StartDate,
                                    EndDate = oldAppointment.StartDate + item.JobTimeSpan,
                                    
                                    CustomerRefId = CustomerSelector.CustomerToSelect,
                                    
                                };
                                if (MasterAppointment == null)
                                {
                                    MasterAppointment = NewAppointment;
                                }
                                else
                                {
                                    var OffSet = JobToRemove.Sum(x => x.JobOffsetTime.TotalMinutes);

                                    NewAppointment.ParentID = MasterAppointment.AppointmentID;
                                    NewAppointment.StartDate = NewAppointment.StartDate.AddMinutes(OffSet);
                                }
                                JobToRemove.Add(item);
                                //NewAppointment.Jobs.Add(item);
                                CreateMultiOffset(NewAppointment, oldAppointment,item,null);


                            }



                            foreach (var item in JobToRemove)
                            {

                                JobList.Remove(item);
                            }

                        }
                        //Creating multi-job................................
                        if (JobList.Count > 0)
                        {

                            NewAppointment = new Appointment()
                            {
                                AppointmentID = 0,
                                AppointmentStatus = 0,
                                CustomerRefId= Logic.Customer.CustomerSelector.CustomerToSelect,
                                ResourceRefID = oldAppointment.ResourceRefID,
                                StartDate = oldAppointment.StartDate,
                                
                                
                            };

                            if (JobToRemove.Count>0)
                            {
                                //NewAppointment.ParentID = JobToRemove.LastOrDefault().Appointments.LastOrDefault().AppointmentID;
                            }


                            if (JobToRemove.Any(x => x.JobOffsetTime.TotalMinutes > 0))
                            {
                                var OffSet = JobToRemove.Sum(x => x.JobOffsetTime.TotalMinutes);
                                NewAppointment.StartDate = this.Appointments.LastOrDefault().EndDate.AddMinutes(OffSet);

                            }
                            NewAppointment.EndDate = NewAppointment.StartDate.AddMinutes(JobList.Sum(x => x.JobTimeSpan.Minutes));

                            JobSelector.JobtoCreate = 0;
                            JobWillCreate = null;
                            CreateMultiOffset(NewAppointment, oldAppointment,null,JobList);

                            //JobList.Clear();

                            //bool con1 = this.Appointments.Any(x => x.StartDate < NewAppointment.EndDate);
                            //bool con2 = this.Appointments.Any(x => x.StartDate > NewAppointment.StartDate);
                            //bool overlap =con1 && con2;
                            //if (overlap == true)
                            //{


                            //}


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
                            Customer = IcPartnersContext.Customers.Find(CustomerSelector.CustomerToSelect)
                    };
                        //List<Job> list = new List<Job>();
                        //list.Add(JobWillCreate);
                        
                        //NewAppointment.Jobs.Add(JobWillCreate);

                        CreateMultiOffset(NewAppointment, oldAppointment,JobWillCreate,null);


                        //var dw = IcPartnersContext.Jobs.ToList();
                        //var add = IcPartnersContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity.ToString() == "ICPartners.Domains.Job");
                     

                        //foreach (var item in add)
                        //{
                            

                        //    //item.State = EntityState.Modified;

                        //}
                      



                    }
                }

             


        
            }


            MasterAppointment = null;

        }
        //Check JobSelector 
        int CreateMultiOffset(Appointment NewAppointment, Appointment oldAppointment,Job JobWillCreate,List<Job> List)
        {
            if (List==null||List.Count==0)
            {

                this.Appointments.Remove(oldAppointment);
                var attach = IcPartnersContext.Jobs.Find(JobWillCreate.JobId);
                IcPartnersContext.Set<Job>().Attach(attach);
                NewAppointment.Jobs.Add(attach);
                IcPartnersContext.Entry(attach).State = EntityState.Unchanged;
                this.Appointments.Add(NewAppointment);
                var add = IcPartnersContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            }
            else if(List.Count>0)
            {

                foreach (var item in List)
                {
                    var Multiple = IcPartnersContext.Jobs.Find(item.JobId);

                    IcPartnersContext.Set<Job>().Attach(Multiple);
                    NewAppointment.Jobs.Add(Multiple);
                    IcPartnersContext.Entry(Multiple).State = EntityState.Unchanged;
                }
                this.Appointments.Remove(oldAppointment);

                this.Appointments.Add(NewAppointment);
                var add = IcPartnersContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);


            }






            //this.Appointments.ToList().ForEach(x => x.Jobs = null);
            //foreach (var item in add)
            //{
            //    //var attach = IcPartnersContext.Jobs.Find(JobWillCreate.JobId);
            //    //IcPartnersContext.Set<Job>().Attach(attach);
            //    ////NewAppointment.Jobs.Add(attach);
            //    //IcPartnersContext.Entry(attach).State = EntityState.Unchanged;
            //}
            //IcPartnersContext.SaveChanges();
            //this.Appointments.Add(NewAppointment);
            JobSelector.JobtoCreate = 0;

            return IcPartnersContext.SaveChanges();
        }



        





        #region #filldata
        public AppointmentViewModel()
        {
            IcPartnersContext = new ICPartnersContext();
            StatusState = CreateStatuses();
            IcPartnersContext.Resources.Load();
            Resources = IcPartnersContext.Resources.Local;
            //IcPartnersContext.Jobs.Load();
            //Jobs = IcPartnersContext.Jobs.Local;
            IcPartnersContext.DependentJobs.Load();
            DependentJobs = IcPartnersContext.DependentJobs.Local;
            IcPartnersContext.Appointments.Include("Jobs").Load();
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
