using System.Windows;
using DevExpress.Xpf.Core;
using System.Windows.Controls;
using ICPartners.DevxUI.ViewModels;
using DevExpress.Xpf.Grid;
using System.Data;
using DevExpress.Data.Linq;
using ICPartners.Domains;
using System.Data.Entity;
using System.Windows.Media.Imaging;

namespace ICPartners.DevxUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           

            InitializeComponent();
           


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

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

             
        }

        private void ThemeDropDown_Click(object sender, RoutedEventArgs e)
        {
            Preferences.ApplyThemeSettings.ApplyTheme("fef");
        }

        private void HamburgerMenuBottomBarRadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;

        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        
        }
    }
}
