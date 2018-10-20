using DevExpress.Xpf.Core;
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
using System.Windows.Shapes;

namespace ICPartners.DevxUI.Windows
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        UnitOfWork work = new UnitOfWork(new ICPartnersContext());
        private void buttoncancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void buttonsave_Click(object sender, RoutedEventArgs e)
        {
            if (pwbox.Password != null)
            {
                try
                {
                    work.resourceRepository.GetByID(Logic.UserManagement.CurrentUser.LoggedUser.ResourceID).Password = pwbox.Password;
                    work.Complete();
                    DXMessageBox.Show("Password Changed Succesfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
                catch (Exception ex)
                {

                    DXMessageBox.Show("An error occured while password changing attempt. :"+ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
            else
            {
                DXMessageBox.Show("Please enter a password", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }
    }
}
