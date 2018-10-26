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
using System.Windows.Input;
using System.Windows.Threading;

namespace ICPartners.DevxUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        UnitOfWork work = new UnitOfWork(new ICPartnersContext());
        private readonly DispatcherTimer _activityTimer;
        private Point _inactiveMousePosition = new Point(0, 0);

        public MainWindow()
        {
           

            InitializeComponent();

            InputManager.Current.PreProcessInput += OnActivity;
            _activityTimer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(10), IsEnabled = true };
            _activityTimer.Tick += OnInactivity;

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
        void OnInactivity(object sender, EventArgs e)
        {
            // remember mouse position
            _inactiveMousePosition = Mouse.GetPosition(this);
            Login login = new Login();


            foreach (var item in Application.Current.Windows)
            {
                if(item is MainWindow)
                {
                    this.Close();

                    login.Show();
                }
                else 
                {
                    
                }
            }


            // set UI on inactivity
            
        }

        void OnActivity(object sender, PreProcessInputEventArgs e)
        {
            InputEventArgs inputEventArgs = e.StagingItem.Input;

            if (inputEventArgs is MouseEventArgs || inputEventArgs is KeyboardEventArgs)
            {
                if (e.StagingItem.Input is MouseEventArgs)
                {
                    MouseEventArgs mouseEventArgs = (MouseEventArgs)e.StagingItem.Input;

                    // no button is pressed and the position is still the same as the application became inactive
                    if (mouseEventArgs.LeftButton == MouseButtonState.Released &&
                        mouseEventArgs.RightButton == MouseButtonState.Released &&
                        mouseEventArgs.MiddleButton == MouseButtonState.Released &&
                        mouseEventArgs.XButton1 == MouseButtonState.Released &&
                        mouseEventArgs.XButton2 == MouseButtonState.Released &&
                        _inactiveMousePosition == mouseEventArgs.GetPosition(this))
                        return;
                }

                // set UI on activity

             
                _activityTimer.Stop();
                _activityTimer.Start();
            }
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
            btnconnected.Visibility = Visibility.Hidden;
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
