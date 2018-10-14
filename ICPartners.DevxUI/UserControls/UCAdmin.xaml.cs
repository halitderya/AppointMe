using ICPartners.DAL;
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
using Microsoft.Office.Interop.Excel;
using ICPartners.Domains;
using System.ComponentModel;

namespace ICPartners.DevxUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCAdmin.xaml
    /// </summary>
    public partial class UCAdmin : UserControl
    {
        ICPartnersContext context = new ICPartnersContext();

        public UCAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments= context.Appointments.ToList();


          
          




        }
      
    }
}
