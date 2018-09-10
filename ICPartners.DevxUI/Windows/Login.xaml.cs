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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(tbName.Text!=""&& tbPassword.Password!="")
            {

                UnitOfWork work = new UnitOfWork(new ICPartnersContext());

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
            else
            { InfoBox.Text = "*All fields must be completed."; }
        }
    }
}
