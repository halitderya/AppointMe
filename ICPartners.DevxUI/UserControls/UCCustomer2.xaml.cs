using DevExpress.Xpf.Core;
using ICPartners.DAL;
using ICPartners.DevxUI.ViewModels;
using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// <summary>
    /// Interaction logic for UCCustomer2.xaml
    /// </summary>
    public partial class UCCustomer2 : UserControl
    {
        ICPartnersContext context = new ICPartnersContext();

        public UCCustomer2()
        {
            InitializeComponent();
        }

  

        private void NewCard_Click(object sender, RoutedEventArgs e)
        {

            AppointmentViewModel.Customers.Add(new Domains.Customer()
            {
                CustomerName="",
                CustomerSurname=""
            });
            CardView.MoveLastRow();

            
        }

        private void CardView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void CardView_RowUpdated(object sender, DevExpress.Xpf.Grid.RowEventArgs e)
        {
            try
            {
                var selectedCustomer = e.Row as ICPartners.Domains.Customer;
                if (selectedCustomer.CustomerID == 0)
                {
                    context.Customers.Add(selectedCustomer);
                }
                else
                {
                    var currentcustomer = context.Customers.Find(selectedCustomer.CustomerID);
                    currentcustomer.CustomerAddress = selectedCustomer.CustomerAddress;
                    currentcustomer.CustomerCity = selectedCustomer.CustomerCity;
                    currentcustomer.CustomerEmail = selectedCustomer.CustomerEmail;
                    currentcustomer.CustomerName = selectedCustomer.CustomerName;
                    currentcustomer.CustomerPhone = selectedCustomer.CustomerPhone;
                    currentcustomer.CustomerPostCode = selectedCustomer.CustomerPostCode;
                    currentcustomer.CustomerSurname = selectedCustomer.CustomerSurname;
                    currentcustomer.CustomerTitle = selectedCustomer.CustomerTitle;
                    
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show("Update Error : " + ex.Message.ToString());
            }

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
          
                int ID = (Int32)(sender as Button).Tag;
                if (ID == 0)
            {
                try
                {
                    var customerwithnoID = AppointmentViewModel.Customers.FirstOrDefault(x => x.CustomerID == 0);
                    AppointmentViewModel.Customers.Remove(customerwithnoID);
                }
                catch (Exception ex)
                {
                    DXMessageBox.Show("An error occured due to " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
                else
                {
                    MessageBoxResult result = DXMessageBox.Show("Are you sure to delete this record?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                        Customer customertoremove = context.Customers.FirstOrDefault(x => x.CustomerID == ID);
                        var idx = AppointmentViewModel.Customers.FirstOrDefault(x => x.CustomerID == ID);
                        var index = AppointmentViewModel.Customers.IndexOf(idx);
                            AppointmentViewModel.Customers.RemoveAt(index);
                            context.Customers.Remove(customertoremove);
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            DXMessageBox.Show("An error occured due to " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }
                }
              
          

        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            DXWindow window = new DXWindow();
            
        }
    }
}
