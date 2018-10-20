using ICPartners.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ICPartners.Domains;
using OfficeOpenXml;
using System.IO;
using System;
using DevExpress.Xpf.Core;
using System.Windows.Forms;
using System.Diagnostics;

namespace ICPartners.DevxUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCAdmin.xaml


    /// </summary>
 

    public partial class UCAdmin : System.Windows.Controls.UserControl
    {
        ICPartnersContext context = new ICPartnersContext();
        public UCAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(File.Exists(System.AppDomain.CurrentDomain.BaseDirectory+ "BackupAndRestore.exe"))
            {
                MessageBoxResult result = DXMessageBox.Show("The Following process can cause irreversable data loss! Please do not proceed if you're not trained.", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.OK)
                {
                    MessageBoxResult Confirm = DXMessageBox.Show("Scheduler will terminated and Backup Tool going to start. Do you wanna proceed?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (Confirm == MessageBoxResult.OK)
                    {
                        Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "BackupAndRestore.exe");
                        System.Windows.Application.Current.Shutdown();
                    }
                }

            }
            else
            {
                MessageBoxResult result = DXMessageBox.Show("The recovery tool cannot found at directory : "+ System.AppDomain.CurrentDomain.BaseDirectory, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }



        }

        

            


        
    }
}
