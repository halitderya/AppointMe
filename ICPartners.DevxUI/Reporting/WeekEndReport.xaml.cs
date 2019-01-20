using DevExpress.Xpf.Grid;
using ICPartners.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace ICPartners.DevxUI.Reporting
{
    /// <summary>
    /// Interaction logic for DayEndReport.xaml
    /// </summary>
    public partial class WeekEndReport : Window
    {
        ICPartnersContext context = new ICPartnersContext();
        
        public WeekEndReport()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime EndDateTime = DateEdit.DateTime.AddDays(7);
            var itemsource = context.Appointments.Include("Jobs")
                    .Include("Resource").Include("Customer")
                    .Where(x => x.StartDate >= DateEdit.DateTime
                    &&
                    x.EndDate <=
                    EndDateTime).ToList();

            GridControl grid = new GridControl
            {
                ItemsSource = itemsource
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
                WeekEndReportPage page = new WeekEndReportPage(DateEdit.DateTime,saveFileDialog1.FileName);
            }
            



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
