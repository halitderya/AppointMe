using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ICPartners.DevxUI.UserControls
{
    /// </summary>
    public partial class UCResource : UserControl
    {

        int AffectedRows;
        ICPartners.DAL.ICPartnersContext context;
        //public ObservableCollection<RoleInfo> collection = new ObservableCollection<RoleInfo>(new List<RoleInfo> {

          
        //});
        public UCResource()
        {

            //RoleInfo info = new RoleInfo
            //{
            //    Text="test1",
            //    Value=1
            //};

            //collection.Add(info);
            InitializeComponent();

            ComboBoxClass user = new ComboBoxClass() { Text = "User", Value = 1 };
            ComboBoxClass operato = new ComboBoxClass() { Text = "Operator", Value = 2 };
            ComboBoxClass admin = new ComboBoxClass() { Text = "Administrator", Value = 3 };
            ObservableCollection<ComboBoxClass> colPersons = new ObservableCollection<ComboBoxClass>();
            colPersons.Add(user);
            colPersons.Add(operato);
            colPersons.Add(admin);

            ((ComboBoxEditSettings)TableViewResource.Columns["Role"].EditSettings).ItemsSource = colPersons;

            ComboBoxClass stylist = new ComboBoxClass() { Text = "Stylist", Value = 1 };
            ComboBoxClass beautician = new ComboBoxClass() { Text = "Beautician", Value = 2 };
            ObservableCollection<ComboBoxClass> colduty = new ObservableCollection<ComboBoxClass>();
            colduty.Add(stylist);
            colduty.Add(beautician);

            ((ComboBoxEditSettings)TableViewResource.Columns["ResourceDuty"].EditSettings).ItemsSource = colduty;






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
                DXMessageBox.Show(AffectedRows.ToString() + " Record(s) updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveButton.IsEnabled = false;
                RevertButton.IsEnabled = false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                DXMessageBox.Show("Update Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void copyCellDataItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridCellMenuInfo menuInfo = tableview.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null)
            {
                string text = "" +
                    TableViewResource.GetCellValue(menuInfo.Row.RowHandle.Value, menuInfo.Column as GridColumn).ToString();
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
