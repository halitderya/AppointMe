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
using System.Data.Entity.Migrations;
using System.Diagnostics;

namespace ICPartners.DevxUI.ViewModels
{
    [POCOViewModel]
    #region declarations
    public class AppointmentViewModel
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
        public static string[] StatusLabels = { "Open",  "Cancelled", "Completed - Waiting Payment", "Completed - Payment Made" };
        public static Brush[] StatusBrushes = { new SolidColorBrush(Colors.Yellow), new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Orange), new SolidColorBrush(Colors.Green) };
        public int JobSeq { get; set; }
        public virtual ObservableCollection<Resource> Resources { get; set; }
        private ObservableCollection<Appointment> _Appointment;
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public virtual ObservableCollection<Appointment> Appointments
        { get { return _Appointment; } set { _Appointment = value;}}
        public virtual ObservableCollection<DependentJobs> DependentJobs { get; set; }
        public virtual ObservableCollection<Customer> Customers {
            get;
            set;
        }
        public virtual ObservableCollection<OffDay> OffDays { get; set; }
        public virtual ObservableCollection<StatusesState> StatusState { get; set; }
        public static int MasterAppointment { get; set; }
        public static bool Offset { get; set; }
        Appointment NewAppointment;

        ICPartnersContext IcPartnersContext;
        public virtual void RaisePropertyChanged(string propertyName) { }




        #endregion

        #region #savechanges

        public void AppointmentsUpdated(Appointment[] appointment)

        {
            var appofefe= this.Appointments;
            var add = IcPartnersContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted);

            if (AppointmentSelector.AppointmentToDelete > 0)
            {
                List<Domains.Appointment> AppointmentsToDelete = new List<Domains.Appointment>();
                AppointmentsToDelete = unitOfWork.appointmentRepository.GetAppointmentByParent(Logic.Appointment.AppointmentSelector.AppointmentToDelete).ToList();
                //AppointmentsToDelete.Add(unitOfWork.appointmentRepository.GetByID(Logic.Appointment.AppointmentSelector.AppointmentToDelete));
                foreach (var item in AppointmentsToDelete)
                {
                    var itemtodelete = this.Appointments.FirstOrDefault(x=>x.AppointmentID==item.AppointmentID);
                    this.Appointments.Remove(itemtodelete);
                }
                Logic.Appointment.AppointmentSelector.AppointmentToDelete = 0;

            }


            var soo = this.Appointments.Count;
            Appointment oldAppointment= new Appointment();
            oldAppointment = null;

            if (this.Appointments.Any(x => x.AppointmentID == 0)) //New Appointment
                oldAppointment = this.Appointments.FirstOrDefault(x => x.AppointmentID == 0);


            if (AppointmentSelector.AppointmentToEdit != null && JobSelector.IsJobEdited)
            {
                oldAppointment = this.Appointments.FirstOrDefault(x=>x.AppointmentID==AppointmentSelector.AppointmentToEdit.AppointmentID);

            }

            if (oldAppointment != null)
            { 
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
                                    ResourceRefID = oldAppointment.ResourceRefID,
                                    Remarks = oldAppointment.Remarks,
                                    ColorActivator = oldAppointment.ColorActivator,
                                    ColorCode = oldAppointment.ColorCode,
                                    ColorBrand = oldAppointment.ColorBrand,
                                    ColorQuantity = oldAppointment.ColorQuantity,
                                    ChargedAmount = oldAppointment.ChargedAmount,
                                    CreateDate = oldAppointment.CreateDate,
                                    AppointmentStatus = Logic.Appointment.AppointmentSelector.SelectedStatus,
                                    StartDate = oldAppointment.StartDate,
                                    EndDate = oldAppointment.StartDate + item.JobTimeSpan,
                                    UpdateDate=oldAppointment.UpdateDate,


                                };
                                NewAppointment.CreateDate = oldAppointment.CreateDate != default(DateTime) ? oldAppointment.CreateDate : NewAppointment.CreateDate = DateTime.Now;
                                NewAppointment.UpdateDate = oldAppointment.UpdateDate != default(DateTime) ? oldAppointment.UpdateDate : NewAppointment.UpdateDate = DateTime.Now;
                                NewAppointment.CustomerRefId = Logic.Customer.CustomerSelector.CreateCustomerWithAppointment==true ? NewAppointment.CustomerRefId= Logic.Customer.CustomerSelector.CustomerToSelect : NewAppointment.CustomerRefId = oldAppointment.CustomerRefId;
                                NewAppointment.UpdatedBy = Logic.UserManagement.CurrentUser.LoggedUser != null ? NewAppointment.UpdatedBy = Logic.UserManagement.CurrentUser.LoggedUser.ResourceName : NewAppointment.UpdatedBy = "N/A";

                                Offset = true;
                                if (MasterAppointment != 0 )
                                {
                                    var OffSet = JobToRemove.Sum(x => x.JobOffsetTime.TotalMinutes);

                                    //NewAppointment.StartDate = NewAppointment.StartDate.AddMinutes(OffSet);
                                }

                                JobToRemove.Add(item);
                                CreateMultiOffset(NewAppointment, oldAppointment, item, null,true);


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

                                ResourceRefID = oldAppointment.ResourceRefID,
                                Remarks = oldAppointment.Remarks,
                                ColorActivator = oldAppointment.ColorActivator,
                                ColorCode = oldAppointment.ColorCode,
                                ColorBrand = oldAppointment.ColorBrand,
                                ColorQuantity = oldAppointment.ColorQuantity,
                                ChargedAmount = oldAppointment.ChargedAmount,
                                CreateDate = oldAppointment.CreateDate,
                                AppointmentStatus = Logic.Appointment.AppointmentSelector.SelectedStatus,
                                StartDate = oldAppointment.StartDate,
                                UpdateDate = oldAppointment.UpdateDate,


                            };


                            NewAppointment.CustomerRefId = Logic.Customer.CustomerSelector.CreateCustomerWithAppointment == true ? NewAppointment.CustomerRefId = Logic.Customer.CustomerSelector.CustomerToSelect : NewAppointment.CustomerRefId = oldAppointment.CustomerRefId;

                            NewAppointment.CreateDate = oldAppointment.CreateDate != default(DateTime) ? oldAppointment.CreateDate : NewAppointment.CreateDate = DateTime.Now;
                            NewAppointment.UpdatedBy = Logic.UserManagement.CurrentUser.LoggedUser != null ? NewAppointment.UpdatedBy = Logic.UserManagement.CurrentUser.LoggedUser.ResourceName : NewAppointment.UpdatedBy = "N/A";

                            if (JobToRemove.Any(x => x.JobOffsetTime.TotalMinutes > 0))
                            {
                                var OffSet = JobToRemove.Sum(x => x.JobOffsetTime.TotalMinutes);
                                NewAppointment.StartDate = this.Appointments.LastOrDefault().EndDate.AddMinutes(OffSet);

                            }
                            NewAppointment.EndDate = NewAppointment.StartDate.AddMinutes(JobList.Sum(x => x.JobTimeSpan.Minutes));

                            JobSelector.JobtoCreate = 0;
                            JobWillCreate = null;
                            CreateMultiOffset(NewAppointment, oldAppointment, null, JobList,false);



                        }





                    }

                    #endregion
                    else //Single Appointment
                    {


                        NewAppointment = new Appointment()
                        {
                            ResourceRefID = oldAppointment.ResourceRefID,
                            Remarks = oldAppointment.Remarks,
                            ColorActivator = oldAppointment.ColorActivator,
                            ColorCode = oldAppointment.ColorCode,
                            ColorBrand = oldAppointment.ColorBrand,
                            ColorQuantity = oldAppointment.ColorQuantity,
                            ChargedAmount = oldAppointment.ChargedAmount,
                            CreateDate = oldAppointment.CreateDate,
                            AppointmentStatus = Logic.Appointment.AppointmentSelector.SelectedStatus,
                            StartDate = oldAppointment.StartDate,
                            UpdateDate = oldAppointment.UpdateDate,
                            UpdatedBy = oldAppointment.UpdatedBy
                            
                            


                        };
                        NewAppointment.CustomerRefId = Logic.Customer.CustomerSelector.CreateCustomerWithAppointment == true ? NewAppointment.CustomerRefId = Logic.Customer.CustomerSelector.CustomerToSelect : NewAppointment.CustomerRefId = oldAppointment.CustomerRefId;
                        NewAppointment.UpdatedBy = Logic.UserManagement.CurrentUser.LoggedUser != null ? NewAppointment.UpdatedBy = Logic.UserManagement.CurrentUser.LoggedUser.ResourceName : NewAppointment.UpdatedBy = "N/A";

                        NewAppointment.CreateDate = oldAppointment.CreateDate != default(DateTime) ? oldAppointment.CreateDate : NewAppointment.CreateDate = DateTime.Now;
                        NewAppointment.EndDate = NewAppointment.StartDate + JobWillCreate.JobTimeSpan;
                        CreateMultiOffset(NewAppointment, oldAppointment, JobWillCreate, null,false);

                    }
                    





                }

            }

            var add123 = IcPartnersContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted);
            IcPartnersContext.SaveChanges();
        }
        //Check JobSelector 
        void CreateMultiOffset(Appointment NewAppointment, Appointment oldAppointment,Job JobWillCreate,List<Job> List,bool offset)
        {
            if (List == null || List.Count == 0)
            {

                if(oldAppointment.AppointmentID != 0)
                {
                    IcPartnersContext.Appointments.Where(x => x.ParentID == oldAppointment.AppointmentID).ToList().ForEach(
                    e => this.Appointments.Remove(e)


                    );
                }
                
                this.Appointments.Remove(oldAppointment);

                var attach = IcPartnersContext.Jobs.Find(JobWillCreate.JobId);
                IcPartnersContext.Set<Job>().Attach(attach);
                NewAppointment.Jobs.Add(attach);
                IcPartnersContext.Entry(attach).State = EntityState.Unchanged;

            

                decimal lastid = IcPartnersContext.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT ('Appointments') AS Current_Identity").FirstOrDefault();
                NewAppointment.AppointmentID = (int)lastid+1;

                if (Offset==true)
                {
                    MasterAppointment = NewAppointment.AppointmentID;
                }


                this.Appointments.Add(NewAppointment);
                Logic.Appointment.AppointmentSelector.AppointmentToEdit = null;
                IcPartnersContext.SaveChanges();
               

                //this.Appointments.FirstOrDefault(x => x.AppointmentID == 0).AppointmentID = last;

            }
            else if (List.Count > 0)
            {

                foreach (var item in List)
                {
                    var Multiple = IcPartnersContext.Jobs.Find(item.JobId);
                    IcPartnersContext.Set<Job>().Attach(Multiple);
                    NewAppointment.Jobs.Add(Multiple);
                    IcPartnersContext.Entry(Multiple).State = EntityState.Unchanged;
                }
                this.Appointments.Remove(oldAppointment);

                decimal lastid = IcPartnersContext.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT ('Appointments') AS Current_Identity").FirstOrDefault();

                NewAppointment.AppointmentID = (int)lastid+1;

                if (Offset == true)
                {
                    NewAppointment.ParentID=MasterAppointment;

                }
                this.Appointments.Add(NewAppointment);
                IcPartnersContext.SaveChanges();
                MasterAppointment = 0;

            }






            JobSelector.JobtoCreate = 0;
            
            
        }



        





        #region #filldata
        public AppointmentViewModel()
        {
            IcPartnersContext = new ICPartnersContext();
            StatusState = CreateStatuses();
            IcPartnersContext.Resources.Load();
            Resources = IcPartnersContext.Resources.Local;
            IcPartnersContext.Customers.Load();
            Customers = IcPartnersContext.Customers.Local;
            IcPartnersContext.DependentJobs.Load();
            DependentJobs = IcPartnersContext.DependentJobs.Local;
            IcPartnersContext.Appointments.Include("Jobs").Load();
            Appointments = IcPartnersContext.Appointments.Local;
            IcPartnersContext.OffDays.Load();
            OffDays = IcPartnersContext.OffDays.Local;
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
