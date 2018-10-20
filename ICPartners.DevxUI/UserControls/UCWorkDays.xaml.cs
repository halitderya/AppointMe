using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using ICPartners.Domains;
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
    /// Interaction logic for UCWorkDays.xaml
    /// </summary>
    /// 
    public enum Days
    {
        Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday
    }
    

    public partial class UCWorkDays : UserControl
    {
        
        public IList<string> Days;
        public Days TheEnumValue { get; set; }

        int AffectedRows;
        ICPartners.DAL.ICPartnersContext context;

        ComboBoxClass Weekly = new ComboBoxClass() { Text = "Weekly", Value = 1 };
        ComboBoxClass Holiday = new ComboBoxClass() { Text = "Holiday", Value = 2 };
        ObservableCollection<ComboBoxClass> OffDaysType = new ObservableCollection<ComboBoxClass>();

        ComboBoxClass Monday = new ComboBoxClass() { Text = "Monday", Value = 1 };
        ComboBoxClass Tuesday = new ComboBoxClass() { Text = "Tuesday", Value = 2 };
        ComboBoxClass Wednesday = new ComboBoxClass() { Text = "Wednesday", Value = 3 };
        ComboBoxClass Thursday = new ComboBoxClass() { Text = "Thursday", Value = 4 };
        ComboBoxClass Friday = new ComboBoxClass() { Text = "Friday", Value = 5 };
        ComboBoxClass Saturday = new ComboBoxClass() { Text = "Saturday", Value = 6 };
        ComboBoxClass Sunday = new ComboBoxClass() { Text = "Sunday", Value = 7 };

        ObservableCollection<ComboBoxClass> WeekDays = new ObservableCollection<ComboBoxClass>();



        public UCWorkDays()
        {
            InitializeComponent();
            context = new DAL.ICPartnersContext();
            context.OffDays.Load();
            gridworkdays.ItemsSource = context.OffDays.Local;

            OffDaysType.Add(Weekly);
            OffDaysType.Add(Holiday);
            ((ComboBoxEditSettings)gridworkdays.Columns["OffDaysType"].EditSettings).ItemsSource = OffDaysType;
            WeekDays.Add(Monday);
            WeekDays.Add(Tuesday);
            WeekDays.Add(Wednesday);
            WeekDays.Add(Thursday);
            WeekDays.Add(Friday);
            WeekDays.Add(Saturday);
            WeekDays.Add(Sunday);
            ((ComboBoxEditSettings)gridworkdays.Columns["OffWeekDay"].EditSettings).ItemsSource = WeekDays;

        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            var add = context.ChangeTracker.Entries().Where(r => r.State == EntityState.Added);
            var add2 = context.ChangeTracker.Entries().Where(r => r.State == EntityState.Deleted);
            var add3 = context.ChangeTracker.Entries().Where(r => r.State == EntityState.Unchanged);
            var add4 = context.ChangeTracker.Entries().Where(r => r.State == EntityState.Detached);

            var add5 = context.ChangeTracker.Entries().Where(r => r.State == EntityState.Modified);
            var add6 = context.ChangeTracker.Entries().ToList();
            var iiiiiiiiiii = tableview;
            var ggggggggggg = gridworkdays;

            try
            {
                AffectedRows = context.SaveChanges();
                
                DXMessageBox.Show(AffectedRows.ToString() + " Record(s) updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveButton.IsEnabled = false;
            }
            catch (Exception exception)
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
                    gridworkdays.GetCellValue(menuInfo.Row.RowHandle.Value, menuInfo.Column as GridColumn).ToString();
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

        private void tableview_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }
    }
}
