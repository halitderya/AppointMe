using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using ICPartners.Domains;
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
            var row = e.Row as DependentJobs;
            if(row.MainJob!=0 && row.DependentJob!=0)
            {
                SaveButton.IsEnabled = true;
                RevertButton.IsEnabled = true;
            }
            
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
                DXMessageBox.Show("Update Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                Debug.WriteLine(exception.Message);
            }
            
        }

        private void copyCellDataItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridCellMenuInfo menuInfo = tableview.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null)
            {
                string text = "" +
                    TableViewDependent.GetCellValue(menuInfo.Row.RowHandle.Value, menuInfo.Column as GridColumn).ToString();
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

    

        private void sequenceedit_DefaultButtonClick(object sender, RoutedEventArgs e)
        {

            DependentJobs selecteditem = TableViewDependent.SelectedItem as ICPartners.Domains.DependentJobs;
            if (selecteditem != null)
            {
                int visibleitems = TableViewDependent.VisibleItems.Cast<DependentJobs>().Where(x => x.MainJob == selecteditem.MainJob).Count();
                List<int> itemstoused = TableViewDependent.VisibleItems.Cast<DependentJobs>().Where(x => x.MainJob == selecteditem.MainJob).Select(x => x.Sequence).ToList();
                List<int> values = new List<int>();
                


                sequenceedit.Items.Clear();
                values.Clear();

                for (int i = 0; i < visibleitems; i++)
                {
                    values.Add(i);
                }
            sequenceedit.ItemsSource = values;
            }
        }

        private void tableview_ValidateRow(object sender, GridRowValidationEventArgs e)
        {
            
            var fe = e.Source as DevExpress.Xpf.Grid.GridControl;



            List<DependentJobs> dependentJobs = new List<DependentJobs>(fe.ItemsSource as IList<DependentJobs>);

            if (dependentJobs.Count != 0)
            {
                var row = e.Row as DependentJobs;
                dependentJobs.Remove(row);
                var currentorders = fe.VisibleItems.Cast<DependentJobs>().ToList();
                if (row.MainJob == row.DependentJob)
                {
                    e.IsValid = false;
                    e.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
                    e.SetError("Main job and dependent job can't be same!");
                }

                else if (dependentJobs.Any(x => x.MainJob == row.MainJob && x.DependentJob == row.DependentJob))
                {
                    e.IsValid = false;
                    e.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
                    e.SetError("This order already defined in this scope!");
                }
                else if (dependentJobs.Any(x => x.DependentJob == row.MainJob))
                {
                    e.IsValid = false;
                    e.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
                    e.SetError("MainJob already defined as dependent in this scope!");
                }
                else
                {

                    DependentJobs lastsequence = dependentJobs.OrderBy(x=>x.Sequence).LastOrDefault(x => x.MainJob == row.MainJob);
                    row.Sequence = lastsequence != null? lastsequence.Sequence+1 : row.Sequence=0 ;




                }

            }
        }
        }
    }

