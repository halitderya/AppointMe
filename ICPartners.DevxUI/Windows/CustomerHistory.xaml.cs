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
    /// Interaction logic for CustomerHistory.xaml
    /// </summary>
    public partial class CustomerHistory : Window
    {
        public CustomerHistory(int CustomerID)
        {
            InitializeComponent();

            if (CustomerID != 0)
            {
                UnitOfWork work = new UnitOfWork(new ICPartnersContext());
                var hist= work.appointmentRepository.GetAppointmentByCustomer(CustomerID).ToList();
                if (hist.Count > 0)
                {
                    try
                    {
                        GridHistory.ItemsSource = hist;
                        this.Show();
                }
                    catch (Exception ex)
                    {
                        DXMessageBox.Show("Some records found but following error occured while showing them: " + ex.Message);

                    }
                }
                else
                {
                    DXMessageBox.Show("Sorry, we couldn't find any records belong to this customer");
                }
               
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
