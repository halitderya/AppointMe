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
using System;
using ICPartners.DAL;
using ICPartners.DevxUI.Windows;

namespace ICPartners.DevxUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        UnitOfWork work = new UnitOfWork(new ICPartnersContext());
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

            if (ICPartners.Logic.UserManagement.CurrentUser.LoggedUser.Role < 3)
            {
                btnresources.Visibility = Visibility.Hidden;
                btnconnected.Visibility = Visibility.Hidden;
                btnreports.Visibility = Visibility.Hidden;
                BtnMaintainence.Visibility = Visibility.Hidden;
                btnjobs.Visibility = Visibility.Hidden;
            }
            if (ICPartners.Logic.UserManagement.CurrentUser.LoggedUser.Role < 2)
            {
                
                BtnCustomers.Visibility = Visibility.Hidden;
            }
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

      

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            //if (this.WindowState == WindowState.Maximized)
            //{
            //    this.WindowState = WindowState.Normal;
            //    Resize.IsChecked = false;
                
            //}
            //else if(this.WindowState== WindowState.Normal){
            //    this.WindowState = WindowState.Maximized;
                
            //}
               


        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Password_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword password = new ChangePassword();
            password.ShowDialog();
        }
    }
}
