﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using ICPartners.DAL;
using ICPartners.Logic.Appointment;
using ICPartners.Logic.CustomerFactory;
using DevExpress.Xpf.Scheduling;
using System.Collections.Generic;
using ICPartners.Domains;
using DevExpress.Xpf.Grid;
using ICPartners.DevxUI.ViewModels;
using System.Data;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Editors;
using ICPartners.Logic.Customer;
using ICPartners.DevxUI.Windows;
using ICPartners.DevxUI.UserControls;

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


        ICPartnersContext context = new ICPartnersContext();
        UnitOfWork UnitOfWork = new UnitOfWork(new ICPartnersContext());
        public IList<string> TitleList;
        public ObservableCollection<Domains.Appointment> AppEnumerable= new ObservableCollection<Domains.Appointment>();
        public TitleList TheEnumValue { get; set; }


        public CustomAppointmentWindow() {
            InitializeComponent();
            GridHistory.ItemsSource =AppEnumerable;

        }

        private void simpleButton2_Click(object sender, RoutedEventArgs e)
        {
            Logic.Appointment.AppointmentSelector.AppointmentToEdit = null;
            this.Close();
        }
        
        public void GenerateNewHistory(int customer)
        {


        }
        private void window_Closed(object sender, EventArgs e)
        {
            //AppointmentSelector.AppointmentToEdit = null;

            //ICPartners.Logic.Appointment.JobSelector.IsJobEdited = false;
            
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CustomerName.Text != "" && JobSelector.JobsToSelect.Count!=0)
            {
                BtnSave.IsEnabled = true;
            }
            ICPartnersContext context = new ICPartnersContext();
            if ((this.DataContext as AppointmentWindowViewModel).Appointment.Id !=null )
            {
                int SelectedValue= Convert.ToInt16((this.DataContext as AppointmentWindowViewModel).Appointment.Id);
                ICPartners.Logic.Appointment.AppointmentSelector.AppointmentToEdit = context.Appointments.FirstOrDefault(x => x.AppointmentID == SelectedValue);

            }


            context.SaveChanges();
            var ss = CustomerList;
            if (AppointmentSelector.AppointmentToEdit!=null)
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
            //ICPartners.DevxUI.UserControls.Jobselector jobselector = new Jobselector();
            //AppointmentWindowMainGrid.Children.Add(jobselector);
            //Grid.SetColumn(jobselector, 0);


        }
        //Create new customer when needed with text fields
        private int CreateCustomerWithID()
        {
            Domains.Customer customerwithappointment = new Domains.Customer();
            customerwithappointment.CustomerName = CustomerName.Text;
            customerwithappointment.CustomerAddress = CustomerAddress.Text;
            customerwithappointment.CustomerEmail = CustomerEMail.Text;
            customerwithappointment.CustomerSurname = CustomerSurname.Text;
            customerwithappointment.CustomerTitle = CustomerTitle.Text;
            customerwithappointment.CustomerPhone = CustomerPhone.Text;
            customerwithappointment.CustomerCity = CustomerCity.Text;
            CustomerFactory factory = new CustomerFactory();
            return factory.CreateCustomerForAppointment(customerwithappointment);
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

                appointmenttoedit.CustomerRefId = CreateCustomerWithID();
                Logic.Customer.CustomerSelector.CreateCustomerWithAppointment = false;
                CustomerList.SelectedItem = UnitOfWork.CustomerRepository.GetByID(appointmenttoedit.CustomerRefId);

            }
            else
            {
                var selectedCustomer = CustomerList.SelectedItem as Domains.Customer;
                appointmenttoedit.CustomerRefId = selectedCustomer.CustomerID;

            }




            UnitOfWork.Complete();
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            



            AppointmentViewModel model = new AppointmentViewModel();
            var buttontag = ((sender as Button).Tag as AppointmentItem);
            var buttontagApp = buttontag.SourceObject as Domains.Appointment;

            if (buttontagApp != null&& buttontagApp!=null)
            {
                buttontag.StatusId = Logic.Appointment.AppointmentSelector.SelectedStatus;
                Logic.Appointment.AppointmentSelector.AppointmentToEdit = buttontagApp;
                buttontagApp.UpdateDate = DateTime.Now;
                buttontag.End = buttontag.End.AddMilliseconds(-1);
                buttontag.End = buttontag.End.AddMilliseconds(1);
               
                foreach (var item in buttontag.CustomFields)
                {
                    var converted = (item as DevExpress.XtraScheduler.Native.CustomField);
                    if (converted.Name == "UpdateDate")
                    {
                        converted.Value = DateTime.Now;
                        //model.AppointmentsUpdated(null);
                        
                    }
                    if (converted.Name == "Jobs")
                    {
                        var jjo = converted.Value as HashSet<Job>;
                        //jjo.Clear();
                    }


                }
             

            }




            //SimpleButton button = (SimpleButton)sender;
            //AppointmentItem appointmentItem = button.Tag as AppointmentItem;
            //int id = Convert.ToInt16(appointmentItem.Id);

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
            this.Close();
        }

        private void Buttontag_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AppointmentWindowMainGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerList_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerList_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            int SelectedValue = (sender as ComboBoxEdit).EditValue== null ? 0 : (int)(sender as DevExpress.Xpf.Editors.ComboBoxEdit).EditValue;
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
                Remarks.Text = Customer.Remarks;
                //Remarks.Text = Customer.Remarks;
                DataTable table = new DataTable();
                AppEnumerable.ToList().ForEach(x => AppEnumerable.Remove(x));
                //UnitOfWork.appointmentRepository.GetAppointmentByCustomer(SelectedValue).ToList().ForEach(x=> AppEnumerable.Add(x));
                 context.Appointments.Include("Resource").Include("Jobs").Where(x => x.CustomerRefId == SelectedValue).ToList().ForEach(c => AppEnumerable.Add(c));
                jobnamecolumn.DisplayTextConverter = new JobNameConverter();
                var sa = AppEnumerable;
                Logic.Customer.CustomerSelector.CustomerToSelect = Customer.CustomerID;
            }







        }
        #region UCJOBSELECTOR
        //private void GenerateMainButtons()
        //{
        //    AllJoblist = unitOfWork.jobRepository.GetAll().ToList();
        //    //DistrictDependentJobs = unitOfWork.DependentRepository.GetAll().GroupBy(x => x.DependentJob).Select(g => g.First()).ToList();
        //    foreach (var item in AllJoblist)
        //    {
        //        if (ICPartners.Logic.Resource.ResourceSelector.SelectedResource != null)
        //        {
        //            if (item.JobOwner == ICPartners.Logic.Resource.ResourceSelector.SelectedResource.ResourceDuty)
        //            {
        //                CustomTile2 tile = new CustomTile2();

        //                tile.Content = item.JobName;
        //                tile.Size = TileSize.ExtraSmall;
        //                tile.VerticalContentAlignment = VerticalAlignment.Center;
        //                tile.HorizontalContentAlignment = HorizontalAlignment.Center;
        //                tile.JobID = item.JobId;
        //                Color backtile = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(item.Color.ToString());
        //                tile.Background = new SolidColorBrush(backtile);
        //                Color fronttile = (PerceivedBrightness(backtile) > 130 ? Color.FromRgb(20, 20, 20) : Color.FromRgb(230, 230, 230));
        //                tile.Foreground = new SolidColorBrush(fronttile);
        //                tile.Click += new EventHandler(button_click);
        //                MainButtonList.Add(tile);
        //                //spmainservice1.Children.Add(tile);
        //                JobSelector.JobtoCreate = tile.JobID;
        //            }
        //        }

        //    }
        //    if (MainButtonList.Count != 0)
        //    {
        //        OrginalTileColor = (Color)ColorConverter.ConvertFromString(MainButtonList[0].Background.ToString());
        //    }
        //    //GenerateSubButtons();
        //}

        //int PerceivedBrightness(Color c)
        //{
        //    return (int)Math.Sqrt(
        //       c.R * c.R * .241 +
        //       c.G * c.G * .691 +
        //       c.B * c.B * .068);
        //}

        //private void button_click(object sender, EventArgs e)
        //{

        //    CustomTile2 button = sender as CustomTile2;
        //    if (button.IsClicked == false)
        //    {
        //        CustomBind();
        //        UnMarkMainButtons();
        //        //UnMarkSubButtons();
        //        JobSelector.JobtoCreate = AllJoblist.Find(x => x.JobId == button.JobID).JobId;
        //        ICPartnersContext context = new ICPartnersContext();
        //        if (unitOfWork.DependentRepository.GetAll().Any(x => x.MainJob == JobSelector.JobtoCreate))
        //        {
        //            List<DependentJobs> DependentJobs = new List<DependentJobs>(unitOfWork.DependentRepository.GetAll().Where(x => x.MainJob == JobSelector.JobtoCreate).OrderBy(x => x.Sequence).ToList());
        //            foreach (var item in DependentJobs)
        //            {
        //                JobSelector.JobsToSelect.Add(unitOfWork.jobRepository.GetByID(item.DependentJob));
        //                //ReceivedJobs.Add(unitOfWork.jobRepository.GetByID(item.DependentJob));

        //            }
        //        }
        //        else
        //        {
        //            JobSelector.JobsToSelect.Add(unitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate));
        //            //if (ReceivedJobs == null)
        //            //    ReceivedJobs = new HashSet<Job>();
        //            //ReceivedJobs.Add(unitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate));

        //        }






        //        button.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));

        //        //JobSelector.DependentJobs = DistrictDependentJobs.Where(x => x.MainJob == JobSelector.JobtoCreate).ToList();
        //        button.IsClicked = true;
        //        //spdependentservice.IsEnabled = true;
        //        //MarkSubbuttons();
        //    }
        //    else
        //    {
        //        button.Background = new SolidColorBrush(OrginalTileColor);
        //        button.IsClicked = false;
        //        //UnMarkSubButtons();
        //        UnMarkMainButtons();

        //    }

        //}

        //void UnMarkMainButtons()
        //{
        //    foreach (var item in MainButtonList)
        //    {
        //        item.IsClicked = false;
        //        RedrawButtons();
        //    }
        //}
        //void RedrawButtons()
        //{
        //    foreach (var item in MainButtonList)
        //    {
        //        try
        //        {
        //            item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(unitOfWork.jobRepository.GetByID(item.JobID).Color.ToString()));

        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.Message);
        //        }
        //    }


        //}


        //void MarkExisting()
        //{
        //    //try
        //    //{

        //    //    if (ReceivedJobs != null)
        //    //    {
        //    //        ICPartners.Logic.Appointment.JobSelector.JobsToSelect = ReceivedJobs;
        //    //    }
        //    //    if (JobSelector.JobsToSelect != null)
        //    //        if (JobSelector.JobsToSelect.Count > 0)
        //    //        {
        //    //            if (MainButtonList.Count > 0)
        //    //                foreach (var Job in JobSelector.JobsToSelect)
        //    //                {
        //    //                    CustomTile2 Pressed = MainButtonList.Find(x => x.JobID == Job.JobId);
        //    //                    Pressed.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        //    //                    Pressed.IsClicked = true;


        //    //                }
        //    //        }
        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //}
        //}
        //void CustomBind()
        //{
         
        //    //Binding myBinding = new Binding();
        //    //myBinding.Source = ViewModel;
        //    //myBinding.Path = new PropertyPath("SomeString");
        //    //myBinding.Mode = BindingMode.TwoWay;
        //    //myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        //    //BindingOperations.SetBinding(txtText, TextBox.TextProperty, myBinding);
        //}


        #endregion UCJOBSELECTOR

        //private void deleteRowItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    GridCellMenuInfo menuInfo = tableview.GridMenu.MenuInfo as GridCellMenuInfo;
        //    if (menuInfo != null && menuInfo.Row != null)
        //    {
        //        tableview.DeleteRow(menuInfo.Row.RowHandle.Value);


        //    }

        //}

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Job remove= (((sender as Button).Tag) as HashSet<Job>).FirstOrDefault();
            (((sender as Button).Tag) as HashSet<Job>).Remove(remove);
            
            ICPartnersContext context = new ICPartnersContext();
            context.SaveChanges();
        }

        private void GridControl_ItemsSourceChanged(object sender, ItemsSourceChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void window_Activated(object sender, EventArgs e)
        {


        }

        private void window_Initialized(object sender, EventArgs e)
        {
            ICPartners.Logic.Appointment.JobSelector.IsJobEdited = false;

        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ICPartners.Logic.Appointment.AppointmentSelector.AppointmentToEdit = null;
        }

        private void CustomerList_ProcessNewValue(DependencyObject sender, DevExpress.Xpf.Editors.ProcessNewValueEventArgs e)
        {
            

            

        }
        void CleanFields()
        {
            if (CustomerList.SelectedIndex > -1)
            {
                CustomerList.SelectedIndex = -1;
                CustomerDetailGrid.IsEnabled = true;
                foreach (DependencyObject c in CustomerDetailGrid.Children)
                {
                    if (c.GetType().ToString() == "DevExpress.Xpf.Editors.TextEdit")
                    {
                        ((TextEdit)c).Text = "";
                    }
                }
                foreach (DependencyObject c in CustomerNameGrid.Children)
                {
                    if (c.GetType().ToString() == "DevExpress.Xpf.Editors.TextEdit")
                    {
                        ((TextEdit)c).Text = "";
                    }
                }
                CustomerTitle.SelectedIndex = -1;
            }
        }

        private void AddNewCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            CleanFields();

            CreateNewCustomer createNewCustomer = new CreateNewCustomer();
            createNewCustomer.ShowDialog();

            if (Logic.Customer.CustomerSelector.CreateCustomerWithAppointment == true)
            {
                var cuscurrent = UnitOfWork.CustomerRepository.GetByID(Logic.Customer.CustomerSelector.CustomerToSelect);
                CustomerName.Text = cuscurrent.CustomerName;
                CustomerSurname.Text = cuscurrent.CustomerSurname;
                CustomerEMail.Text = cuscurrent.CustomerEmail;
                CustomerAddress.Text = cuscurrent.CustomerAddress;
                CustomerPhone.Text = cuscurrent.CustomerPhone;
                CustomerCity.Text = cuscurrent.CustomerCity;
                CustomerTitle.Text = cuscurrent.CustomerTitle;




            }

        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
           
        }

        private void BtnSave_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = false;
        }

        internal void CustomerName_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            if(sender is CustomTile2)
            {
                if (CustomerName.Text != "" &&JobSelector.JobsToSelect.Count!=0)
                {
                    BtnSave.IsEnabled = true;
                    //CustomerSurname.Text = UnitOfWork.CustomerRepository.GetByID(CustomerSelector.CustomerToSelect).CustomerSurname;
                }
                else { BtnSave.IsEnabled = false; }
            }
            if(sender is TextEdit)
            {
                if ((sender as TextEdit).Text != "" && JobSelector.JobsToSelect.Count!=0)
                {
                    BtnSave.IsEnabled = true;
                }
                else
                {
                    BtnSave.IsEnabled = false;
                }
            }
            
                
        }

        private void Remarks_DefaultButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void Remarks_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void Remarks_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            if (Logic.Customer.CustomerSelector.CustomerToSelect != 0)
            {
                Customer temp = context.Customers.FirstOrDefault(x => x.CustomerID == Logic.Customer.CustomerSelector.CustomerToSelect);
                temp.Remarks = Remarks.Text;
                context.SaveChanges();


            }

        }
    }



}
