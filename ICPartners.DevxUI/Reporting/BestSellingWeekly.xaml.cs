using DevExpress.Xpf.Grid;
using ICPartners.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ICPartners.DevxUI.Reporting
{
    /// <summary>
    /// Interaction logic for BestSellingWeekly.xaml
    /// </summary>
    public partial class BestSellingWeekly : Page
    {
        public BestSellingWeekly()
        {
            InitializeComponent();
        }
        ICPartnersContext context = new ICPartnersContext();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridControl grid = new GridControl
            {
                ItemsSource = context.Appointments.Include("Jobs").Include("Resource").Include("Customer").Where(x => EntityFunctions.TruncateTime(x.StartDate) == DateEdit.DateTime.Date && EntityFunctions.TruncateTime(x.EndDate) == DateEdit.DateTime.Date).ToList()
            };
            grid.View = new TableView();
            ((TableView)grid.View).IsColumnMenuEnabled = false;
            ((TableView)grid.View).ShowGroupPanel = false;
            grid.AutoGenerateColumns = AutoGenerateColumnsMode.RemoveOld;
            grid.PopulateColumns();
            ReportMainGrid.Children.Add(grid);
            Grid.SetColumnSpan(grid, 4);
            Grid.SetRow(grid, 1);
            Grid.SetColumn(grid, 0);







            BtnPrint.IsEnabled = true;

        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            CreateDocument();
        }
        private void CreateDocument()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "docx file|*.docx";
            saveFileDialog1.Title = "Save an word document";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DayEndReportPage page = new DayEndReportPage(DateEdit.DateTime, saveFileDialog1.FileName);
            }




        }
    }
}
