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
        public UCCustomerSelector()
        {

            customerlist = UnitOfWork.CustomerRepository.GetAll().ToList();
            InitializeComponent();
            CustomerList.ItemsSource = customerlist;
        



         }

        public TitleList TheEnumValue { get; set; }

        ObservableCollection<Appointment> _customerHistoryCollection { get; set; }
        
        public void CustomerList_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (CustomerList.SelectedIndex > -1)
            {

                fillcustomerdata();
                fillcustomerhistory();
            }
            
        }

        void fillcustomerdata()
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
        void fillcustomerhistory()
        {
            try
            {
                if (UnitOfWork.appointmentRepository.GetAppointmentByCustomer(CustomerSelector.CustomerToSelect).Any())
                {
                    CustomerHistory.ItemsSource = UnitOfWork.appointmentRepository.GetAppointmentByCustomer(CustomerSelector.CustomerToSelect).ToList();
                }
            }
            catch (Exception exception)
            {
                DXMessageBox.Show(exception.Message);
            }
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

        private void CustomerHistory_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            if(e.PropertyType == typeof(Boolean))
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "StartDate")
            {
                e.Cancel = true;
            }
               
        }
    }
}
