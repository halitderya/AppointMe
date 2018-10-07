using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using ICPartners.DAL;
using ICPartners.DevxUI.UserControls;
using ICPartners.Logic.Appointment;
using ICPartners.Logic.CustomerFactory;
using DevExpress.Xpf.Scheduling;
using System.Data.Entity;
using System.Collections.Generic;
using DevExpress.XtraScheduler;

namespace ICPartners.DevxUI
{
    /// <summary>
    /// Interaction logic for CustomAppointmentWindow.xaml
    /// </summary>
    /// 

    public enum TitleList
    {
        Mr, Ms, Mrs, Miss
    }
    public partial class CustomAppointmentWindow  {

        UnitOfWork UnitOfWork = new UnitOfWork(new ICPartnersContext());
        public IList<string> TitleList;


        public CustomAppointmentWindow() {
            InitializeComponent();
            UCCustomerHistory history = new UCCustomerHistory(0);
            AppointmentWindowMainGrid.Children.Add(history);
            Grid.SetRow(history, 2);
            Grid.SetColumnSpan(history, 2);

        }

        private void simpleButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        public void GenerateNewHistory(int customer)
        {

            UCCustomerHistory history = new UCCustomerHistory(customer);
            AppointmentWindowMainGrid.Children.Add(history);
            Grid.SetRow(history, 2);
            Grid.SetColumnSpan(history, 2);




        }
        private void window_Closed(object sender, EventArgs e)
        {
            AppointmentSelector.AppointmentToEdit = null;
        
            
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
        
            if(AppointmentSelector.AppointmentToEdit!=null)
            {
                //TbAppointmentID.Text = AppointmentSelector.AppointmentToEdit.AppointmentID.ToString();
                //UCCustomerSelector selector = new UCCustomerSelector();
                //CSelector.CustomerList.SelectedItem = UnitOfWork.CustomerRepository.GetByID(AppointmentSelector.AppointmentToEdit.CustomerRefId + 1);
                //CSelector.CustomerList.SelectedIndex = AppointmentSelector.AppointmentToEdit.CustomerRefId-1;
               
            }
            else
            {
                //TbAppointmentID.Text = "New";

            }
            ICPartners.DevxUI.UserControls.Jobselector jobselector = new Jobselector();
            AppointmentWindowMainGrid.Children.Add(jobselector);
            Grid.SetColumn(jobselector, 0);


        }
        //Create new customer when needed with text fields
        private int CreateCustomerWithID()
        {
            //Domains.Customer customerwithappointment = new Domains.Customer();
            //customerwithappointment.CustomerName = CSelector.CustomerName.Text;
            //customerwithappointment.CustomerAddress = CSelector.CustomerAddress.Text;
            //customerwithappointment.CustomerEmail = CSelector.CustomerEMail.Text;
            //customerwithappointment.CustomerSurname = CSelector.CustomerSurname.Text;
            //customerwithappointment.CustomerTitle = CSelector.CustomerTitle.Text;
            //customerwithappointment.CustomerPhone = CSelector.CustomerPhone.Text;
            //customerwithappointment.CustomerCity = CSelector.CustomerCity.Text;
            //CustomerFactory factory = new CustomerFactory();
            //return factory.CreateCustomerForAppointment(customerwithappointment);
            return 0;
        }

        //edits existing appointment 
        private void UpdateCustom()
        {
            //Determine which appointment going to edit.
            var appointmenttoedit = UnitOfWork.appointmentRepository.GetByID(AppointmentSelector.AppointmentToEdit.AppointmentID);
            //Check, if new customer button clicked, means new customer will created by
            //CreateCustomerWithAppointment() method.
            if (Logic.Customer.CustomerSelector.CreateCustomerWithAppointment == true)
            {
               
                //appointmenttoedit.CustomerRefId = CreateCustomerWithID();
                //Logic.Customer.CustomerSelector.CreateCustomerWithAppointment = false;
                //CSelector.CustomerList.SelectedItem = UnitOfWork.CustomerRepository.GetByID(appointmenttoedit.CustomerRefId);

            }
            else
            {
               //var selectedCustomer = CSelector.CustomerList.SelectedItem as Domains.Customer;
               // appointmenttoedit.CustomerRefId = selectedCustomer.CustomerID;
                
            }




            UnitOfWork.Complete();
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)



        {

            
            
            
            //ICPartnersContext IcPartnersContext = new ICPartnersContext();
            //SimpleButton button = (SimpleButton)sender;
            //AppointmentItem appointmentItem = button.Tag as AppointmentItem;
            //int id = Convert.ToInt16(appointmentItem.Id);
            //var add = IcPartnersContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            //var remo = IcPartnersContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);
            //var det = IcPartnersContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Detached);
            //var mod = IcPartnersContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);


            ////List<Domains.DependentJobs> DependentJobs = new List<Domains.DependentJobs>();
            ////List<Domains.Job> JobList = new List<Domains.Job>();
            ////Customer will be created on runtime
            //SimpleButton button = (SimpleButton)sender;
            //AppointmentItem appointmentItem = button.Tag as AppointmentItem;
            //int id = Convert.ToInt16(appointmentItem.Id);
            //if(appointmentItem.Id==null||id==0)
            //{
            //    //new appointment

            //}
            //else
            //{
            //    //edit appointment

            //    ICPartnersContext context = new ICPartnersContext();

            //    Appointment AppointmentToChange = context.Appointments.Include("Jobs").FirstOrDefault(x => x.AppointmentID == id);
            //    AppointmentToChange.CustomerRefId = ICPartners.Logic.Customer.CustomerSelector.CustomerToSelect;
            //    Appointment[] AppointmentArray = new Appointment[] {
            //        AppointmentToChange
            //    };

            //         ;


            //    ViewModels.AppointmentViewModel appointmentViewModel= new AppointmentViewModel();
            //    appointmentViewModel.AppointmentsUpdated(AppointmentArray);
            //}

            //if (Logic.Customer.CustomerSelector.CreateCustomerWithAppointment == true)
            //{
            //    CustomerSelector.CustomerToSelect = CreateCustomerWithID();
            //}

            //Domains.Appointment appointment = new Domains.Appointment();
            //Domains.Job job2 = new Domains.Job();
            //job2 = UnitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate);
            //appointment.Job = new Collection<Domains.Job>();
            //appointment.Job.Add(job2);
            //appointment.CustomerRefId = CustomerSelector.CustomerToSelect;
            //appointment.ResourceRefID = ResourceSelector.SelectedResource.ResourceID;
            //UnitOfWork.Complete();
            //Domains.Job Job = UnitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate);


            //    ////AppointmentFactory factory = new AppointmentFactory(new SingleAppointment(ICustomer));

            //    //int job = Logic.Appointment.JobSelector.JobtoCreate;

            //    //var existingcustomer =Logic.Customer.CustomerSelector.CustomerToSelect;
            //    //var newcustomer = Logic.Customer.CustomerSelector.CreateCustomerWithAppointment;
            //    //var senderob = sender;
            //    //var eob = e;
            //    //Domains.Appointment newAppointment = new Domains.Appointment();
            //    //if (AppointmentSelector.AppointmentToEdit == null)
            //    //{
            //    //    //decide customer
            //    //    if (Logic.Customer.CustomerSelector.CreateCustomerWithAppointment == true)
            //    //    {
            //    //        //new customer
            //    //        newAppointment.CustomerRefId = CreateCustomerWithID();
            //    //    }
            //    //    else
            //    //    {
            //    //        //old customer
            //    //        newAppointment.StartDate = editorStartDate.DateTime;

            //    //    }
            //    //    //appointment data

            //    //    var array = editorStartTime.EditValue.ToString().Split(new string[] { ":", " " }, StringSplitOptions.RemoveEmptyEntries);
            //    //    newAppointment.Job.Add(UnitOfWork.jobRepository.GetByID(job));
            //    //    newAppointment.StartDate = new DateTime(editorStartDate.DateTime.Year,
            //    //        editorStartDate.DateTime.Month,
            //    //        editorStartDate.DateTime.Day,
            //    //        Convert.ToInt16(array[1]),
            //    //        Convert.ToInt16(array[2]),
            //    //        Convert.ToInt16(array[3]));





            //    //    UnitOfWork.appointmentRepository.Add(newAppointment);
            //    //    UnitOfWork.Complete();
            //    //    this.Close();



            //    //}
            //    //else
            //    //{
            //    //    //edit appointment
            //    //    UpdateCustom();
            //    //}
            //    ////saveandclose
            //    //UnitOfWork.Complete();
            //    //this.Close();
        }

        private void AppointmentWindowMainGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerList_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerList_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            int SelectedValue = (int)(sender as DevExpress.Xpf.Editors.ComboBoxEdit).EditValue;
            if (SelectedValue>0)
            {
               Domains.Customer Customer=  UnitOfWork.CustomerRepository.GetByID(SelectedValue);
                CustomerName.Text = Customer.CustomerName;
                CustomerSurname.Text = Customer.CustomerSurname;
                CustomerPhone.Text = Customer.CustomerPhone;
                CustomerTitle.Text = Customer.CustomerTitle;
                CustomerAddress.Text = Customer.CustomerAddress;
                CustomerCity.Text = Customer.CustomerPostCode + " - " + Customer.CustomerCity;
                CustomerEMail.Text = Customer.CustomerEmail;



            }







        }
    }

  
    
}
