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
using DevExpress.Xpf.Ribbon;
using ICPartners.DAL;
using ICPartners.DevxUI.UserControls;

namespace ICPartners.DevxUI {
    /// <summary>
    /// Interaction logic for CustomAppointmentWindow.xaml
    /// </summary>
    public partial class CustomAppointmentWindow  {
        public CustomAppointmentWindow() {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void window_Closed(object sender, EventArgs e)
        {
            //UCAppointment ucAppointment = new UCAppointment();
            //ucAppointment.MainScheduler.RefreshData();
        }
    }
}
