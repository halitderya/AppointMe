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
    /// Interaction logic for UcJob.xaml
    /// </summary>
    public partial class UcJob : UserControl
    {
        ICPartners.DAL.ICPartnersContext context;
        int AffectedRows;
        public UcJob()
        {
            InitializeComponent();

            context = new DAL.ICPartnersContext();
            context.Jobs.Load();
            TableViewJob.ItemsSource = context.Jobs.Local;


        }

        private void TableView_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
            RevertButton.IsEnabled = true;
        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
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

        private void Revert_Clicked(object sender, RoutedEventArgs e)
        {
           
        }
        public class Converter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var str = value as string;
                if (string.IsNullOrWhiteSpace(str))
                {
                    return null;
                }
                return (Color)ColorConverter.ConvertFromString(str);
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return value == null ? null : value.ToString();
            }
        }
    }
}
