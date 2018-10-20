using DevExpress.Xpf.Core;
using ICPartners.DAL;
using ICPartners.Domains;
using System;
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
using System.Windows.Shapes;

namespace ICPartners.DevxUI.Windows
{
    /// <summary>
    /// Interaction logic for CreateNewCustomer.xaml
    /// </summary>
    /// 
    
    public enum TitleList
    {
        Mr, Ms, Mrs, Miss
    }

    public partial class CreateNewCustomer : Window
    {
        ICPartnersContext context = new ICPartnersContext();
        public IList<string> TitleList;

        public TitleList TheEnumValue { get; set; }




        public CreateNewCustomer()
        {

            InitializeComponent();

    }

    private void buttoncancel_Click(object sender, RoutedEventArgs e)
        {
            Logic.Customer.CustomerSelector.CreateCustomerWithAppointment = false;

            this.Close();
        }

        private void buttonsave_Click(object sender, RoutedEventArgs e)
        {
            if(Name.Text!="")
            {
                Customer customer = new Customer()
                {
                    CustomerName = Name.Text,
                    CustomerSurname = Surname.Text,
                    CustomerPhone = Phone.Text,
                    CustomerTitle = Title.Text,
                    CustomerAddress = Adress.Text,
                    CustomerCity = City.Text,
                    CustomerEmail = Email.Text,
                    CustomerPostCode = Postcode.Text,
                };
                Logic.CustomerFactory.CustomerFactory factory = new Logic.CustomerFactory.CustomerFactory();
                Logic.Customer.CustomerSelector.CustomerToSelect = factory.CreateCustomerForAppointment(customer);

               
                Logic.Customer.CustomerSelector.CreateCustomerWithAppointment = true;
                this.Close();
            }
            else
            {
                DXMessageBox.Show("Name and Surname are mandatory.", "Please complete required fields.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                e.Handled = false;

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }
    }
}
