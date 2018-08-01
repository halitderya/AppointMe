using System.Windows;
using DevExpress.Xpf.Core;
using System.Windows.Controls;
using ICPartners.DevxUI.ViewModels;
using DevExpress.Xpf.Grid;
using System.Data;
using DevExpress.Data.Linq;
using ICPartners.Domains;
using System.Data.Entity;

namespace ICPartners.DevxUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        int i;
        ICPartners.DAL.ICPartnersContext context;
        public MainWindow()
        {
           

            InitializeComponent();
            context= new DAL.ICPartnersContext();
            context.Jobs.Load();
            TableViewJob.ItemsSource = context.Jobs.Local;
            context.Customers.Load();
            CustomerTable.ItemsSource = context.Customers.Local;



        }

        private void SchedulerControl_BeforeAppointmentItemDelete(object sender, DevExpress.Xpf.Scheduling.AppointmentItemCancelEventArgs e)
        {



            MessageBoxResult result = MessageBox.Show("Are you sure delete this appointment?", "Delete an appointment", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

            }
            else
            {
                e.Cancel = true;

            }
             





        }
        
        void test()
        {
        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                i = context.SaveChanges();
                MessageBox.Show(i.ToString() + " Record(s) updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveButton.IsEnabled = false;
                RevertButton.IsEnabled = false;
            }
            catch
            {

                MessageBox.Show("Update Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Revert_Clicked(object sender, RoutedEventArgs e)
        {
            TableViewJob.ItemsSource = null;
            TableViewJob.ItemsSource = context.Jobs.Local;
            TableViewJob.RefreshData();
        }



        private void TableView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

             SaveButton.IsEnabled = true;
             RevertButton.IsEnabled = true;


        }
    }
}
