using System.Windows;
using DevExpress.Xpf.Core;

namespace ICPartners.DevxUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
           

            InitializeComponent();
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

      
    }
}
