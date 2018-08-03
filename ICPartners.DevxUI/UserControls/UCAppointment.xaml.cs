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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ICPartners.DevxUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCAppointment.xaml
    /// </summary>
    public partial class UCAppointment : UserControl
    {
        public UCAppointment()
        {

            InitializeComponent();
        }

        private void SchedulerControl_BeforeAppointmentItemDelete(object sender, DevExpress.Xpf.Scheduling.AppointmentItemCancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure delete this appointment?", "Delete an appointment", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

            }
            else
            {
                e.Cancel = true;

            }
        }
    }
}
