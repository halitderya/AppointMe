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
    /// Interaction logic for UCResource.xaml
    /// </summary>
    public partial class UCResource : UserControl
    {
        int AffectedRows;
        ICPartners.DAL.ICPartnersContext context;

        public UCResource()
        {
            InitializeComponent();
            context = new DAL.ICPartnersContext();

            context.Resources.Load();
            TableViewResource.ItemsSource = context.Resources.Local;
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
            try
            {
                AffectedRows = context.SaveChanges();
                MessageBox.Show(AffectedRows.ToString() + " Record(s) updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveButton.IsEnabled = false;
                RevertButton.IsEnabled = false;
            }
            catch
            {

                MessageBox.Show("Update Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
