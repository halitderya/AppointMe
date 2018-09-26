using DevExpress.Xpf.Editors;
using ICPartners.DAL;
using ICPartners.Domains;
using System.Data;
using ICPartners.Logic.Customer;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Core;

namespace ICPartners.DevxUI.UserControls
{

    public enum TitleList
    {
        Mr,Ms,Mrs,Miss
    }
    
    public partial class UCCustomerSelector : UserControl
    {
        public IList<string> TitleList; 
        UnitOfWork UnitOfWork = new UnitOfWork(new ICPartnersContext());
        public IList<Customer> customerlist;
        //UCCustomerHistory history;

        public UCCustomerSelector()
        {

            customerlist = UnitOfWork.CustomerRepository.GetAll().ToList();
            InitializeComponent();
            CustomerList.ItemsSource = customerlist;
        



         }

        public TitleList TheEnumValue { get; set; }

        public void CustomerList_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (CustomerList.SelectedIndex > -1)
            {

                Fillcustomerdata();
                //fillsecondhistory();
                fillhistory();
            }
            
        }
        public DataTable HistoryTable = new DataTable();

        void fillhistory()
        {
            foreach (Window window in Application.Current.Windows.OfType<CustomAppointmentWindow>())
                ((CustomAppointmentWindow)window).GenerateNewHistory(CustomerSelector.CustomerToSelect);

        }
        void fillsecondhistory()
        {
            //IEnumerable<Appointment> history = UnitOfWork.appointmentRepository.GetAppointmentByCustomer(CustomerSelector.CustomerToSelect).ToList();
            
            //if (HistoryTable.Columns.Count < 7)
            //{

            //    HistoryTable.Columns.Add("Date");
            //    HistoryTable.Columns.Add("Job");
            //    HistoryTable.Columns.Add("Resource");
            //    HistoryTable.Columns.Add("Color Brand");
            //    HistoryTable.Columns.Add("Color Activator");
            //    HistoryTable.Columns.Add("Color Quantity");
            //    HistoryTable.Columns.Add("Remarks");
            //}


            //foreach (var item in history)
            //{
            //    HistoryTable.Rows.Add(

            //    item.CreateDate.ToShortDateString().ToString(),
            //    item.Job.JobName.ToString(),
            //    item.Resource.ResourceName.ToString(),
            //    item.ColorBrand ?? "",
            //    item.ColorCode ?? " ",
            //    item.ColorQuantity ?? " ",
            //    item.Remarks ?? " "

            //    );

            //}
           
        }

    void Fillcustomerdata()
        {
            Customer selectedCustomer = customerlist.FirstOrDefault(x => x.CustomerID == (CustomerList.SelectedItem as Customer).CustomerID);
            CustomerName.Text = selectedCustomer.CustomerName;
            CustomerSurname.Text = selectedCustomer.CustomerSurname;
            CustomerPhone.Text = selectedCustomer.CustomerPhone;
            CustomerTitle.Text = selectedCustomer.CustomerTitle;
            CustomerAddress.Text = selectedCustomer.CustomerAddress;
            CustomerCity.Text = selectedCustomer.CustomerPostCode + " - " + selectedCustomer.CustomerCity;
            CustomerEMail.Text = selectedCustomer.CustomerEmail;
            CustomerSelector.CustomerToSelect = selectedCustomer.CustomerID;
        }
       
      
        private void CustomerList_ProcessNewValue(DependencyObject sender, ProcessNewValueEventArgs e)
        {
            CustomerDetailGrid.IsEnabled = true;
            CustomerSelector.CreateCustomerWithAppointment = true;
            CleanFields();
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

    }
}
