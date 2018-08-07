using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for UCDependent.xaml
    /// </summary>
    public partial class UCDependent : UserControl
    {
        DAL.ICPartnersContext context;
            int AffectedRows;

        public UCDependent()
        {
            InitializeComponent();
         

            context = new DAL.ICPartnersContext();
            context.DependentJobs.Load();
            TableViewDependent.ItemsSource = context.DependentJobs.Local;
            

        }

        private void TableView_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
            RevertButton.IsEnabled = true;
        }

        private void RevertButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            AffectedRows = context.SaveChanges();
            MessageBox.Show(AffectedRows.ToString() + " Record(s) updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            SaveButton.IsEnabled = false;
            RevertButton.IsEnabled = false;
        }
    }
}
