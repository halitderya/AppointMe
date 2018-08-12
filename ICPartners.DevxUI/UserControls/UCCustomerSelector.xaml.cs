using DevExpress.Xpf.Editors;
using ICPartners.DAL;
using ICPartners.Domains;
using System;
using ICPartners.Logic.Customer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        ICollection<Customer> customerlist;
        public UCCustomerSelector()
        {
          
            customerlist = UnitOfWork.CustomerRepository.GetAll().ToList();
            InitializeComponent();
            CustomerList.ItemsSource = customerlist;




         }

        public TitleList TheEnumValue { get; set; }

        private void CustomerList_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (CustomerList.SelectedIndex > -1)
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
            
        }

        private void CustomerList_ProcessNewValue(DependencyObject sender, ProcessNewValueEventArgs e)
        {
            CustomerDetailGrid.IsEnabled = true;
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
