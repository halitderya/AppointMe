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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AutoUpdaterDotNET;
using DevExpress.Xpf.Core;
using System.Reflection;

namespace ICPartners.DevxUI.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
          
        }
        UnitOfWork work = new UnitOfWork(new ICPartnersContext());
        ICPartnersContext context = new ICPartnersContext();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!context.Resources.Any(x => x.Role == 3))
            {
                DXMessageBox.Show("Creating Admin");
                try
                {
                    context.Resources.Add(new Domains.Resource()
                    {
                        ResourceName = "admin",
                        ResourceSurname = "",
                        Password = "1234",
                        Role = 3
                    });
                    context.SaveChanges();
                    
                }
                catch (Exception ex)
                {
                    DXMessageBox.Show("Admin Creation Failed: " + ex.Message);
                }
            }

            if(tbName.Text!=""&& tbPassword.Password!="")
            {


                try
                {
                    var sfdfs = work.resourceRepository.GetAll().FirstOrDefault();
                    Domains.Resource Login = work.resourceRepository.GetAll().FirstOrDefault(x => x.ResourceName.ToLower() + x.ResourceSurname.ToLower() == tbName.Text.ToLower() && x.Password == tbPassword.Password);
                    if (Login != null)
                    {
                        Logic.UserManagement.CurrentUser.LoggedUser = Login;
                        MainWindow main = new MainWindow();
                        App.Current.MainWindow = main;
                        this.Close();
                        main.Show();

                    }
                    else
                    {
                        InfoBox.Text = "*Login information is incorrect.";
                        Storyboard sb = this.FindResource("ShakeScreen") as Storyboard;
                        Storyboard.SetTarget(sb, this);

                        sb.Begin();
                        tbPassword.Password = null;
                    }
                }
                catch (Exception ex)
                {
                    DXMessageBox.Show(ex.Message);
                }
            }




            else
            { InfoBox.Text = "*All fields must be completed."; }





        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
               AutoUpdater.Start("http://update.anislon.co.uk/ICPartners.xml");
            }
            catch
            {

            }
        }
    }
}
