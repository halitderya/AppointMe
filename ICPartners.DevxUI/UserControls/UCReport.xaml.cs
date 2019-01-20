using ICPartners.DevxUI.Reporting;
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
    /// Interaction logic for UCReport.xaml
    /// </summary>
    public partial class UCReport : UserControl
    {
        public UCReport()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DayEndReport report = new DayEndReport();


            report.ShowDialog();

        }

        private void Weekly_Click(object sender, RoutedEventArgs e)
        {
            WeekEndReport report = new WeekEndReport();
            report.ShowDialog();
        }
    }
}
