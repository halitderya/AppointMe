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
          
            context.Customers.Load();
            CustomerTable.ItemsSource = context.Customers.Local;



        }

        private void SchedulerControl_BeforeAppointmentItemDelete(object sender, DevExpress.Xpf.Scheduling.AppointmentItemCancelEventArgs e)
        {



           
             





        }
        
        void test()
        {
        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
           
        }

        private void Revert_Clicked(object sender, RoutedEventArgs e)
        {
            
        }



        private void TableView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

           


        }
    }
}
