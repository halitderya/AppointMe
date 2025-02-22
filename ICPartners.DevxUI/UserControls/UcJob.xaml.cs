﻿using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


            ComboBoxClass stylist = new ComboBoxClass() { Text = "Stylist", Value = 1 };
            ComboBoxClass beautician = new ComboBoxClass() { Text = "Beautician", Value = 2 };
            ObservableCollection<ComboBoxClass> jobowner = new ObservableCollection<ComboBoxClass>();
            jobowner.Add(stylist);
            jobowner.Add(beautician);

            ((ComboBoxEditSettings)TableViewJob.Columns["JobOwner"].EditSettings).ItemsSource = jobowner;


        }

        private void TableView_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                AffectedRows = context.SaveChanges();
                DXMessageBox.Show(AffectedRows.ToString() + " Record(s) updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveButton.IsEnabled = false;
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception.Message);
                DXMessageBox.Show("Update Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
        private void copyCellDataItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridCellMenuInfo menuInfo = tableview.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null)
            {
                string text = "" +
                    TableViewJob.GetCellValue(menuInfo.Row.RowHandle.Value, menuInfo.Column as GridColumn).ToString();
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

        private void tableview_ValidateRow(object sender, GridRowValidationEventArgs e)
        {
            var commited = e.Row as Domains.Job;
            if (commited.Color == null)
            e.IsValid = false;
            if (commited.JobTimeSpan < new TimeSpan(00, 05, 00))
                e.IsValid = false;
            if (commited.JobName == null || commited.JobName == "")
                e.IsValid = false;
            if (commited.JobPrice < 1)
                e.IsValid = false;
            e.ErrorContent = "Required Fields: \n *Name \n *Duration \n *Price \n *Color";

        }

        private void JobOwnerColumn_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tableview_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void tableview_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        private void GridColumn_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GridColumn_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tableview_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tableview_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void TableViewJob_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void TableViewJob_Unloaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
