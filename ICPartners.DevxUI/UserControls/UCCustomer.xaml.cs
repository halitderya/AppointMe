using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
    /// Interaction logic for UCCustomer.xaml
    /// </summary>

    public partial class UCCustomer : UserControl
    {
        int AffectedRows;
        ICPartners.DAL.ICPartnersContext context;

        public UCCustomer()
        {
            InitializeComponent();
            context = new DAL.ICPartnersContext();

            context.Customers.Load();
            TableViewCustomer.ItemsSource = context.Customers.Local;

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
                DXMessageBox.Show(AffectedRows.ToString() + " Record(s) updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveButton.IsEnabled = false;
                RevertButton.IsEnabled = false;
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception.Message);
                DXMessageBox.Show("Update Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void copyCellDataItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridCellMenuInfo menuInfo = tableview.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null)
            {
                string text = "" +
                    TableViewCustomer.GetCellValue(menuInfo.Row.RowHandle.Value, menuInfo.Column as GridColumn).ToString();
                Clipboard.SetText(text);
            }
        }

        private void deleteRowItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridCellMenuInfo menuInfo = tableview.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null)
            {
                tableview.DeleteRow(menuInfo.Row.RowHandle.Value);
                SaveButton.IsEnabled = true;

            }
        }
    }
}
