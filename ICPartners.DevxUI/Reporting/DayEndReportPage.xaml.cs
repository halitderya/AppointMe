using ICPartners.DAL;
using ICPartners.Domains;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Words.NET;

namespace ICPartners.DevxUI.Reporting
{
    /// <summary>
    /// Interaction logic for DayEndReportPage.xaml
    /// </summary>
    public partial class DayEndReportPage : System.Windows.Controls.Page
    {
        ICPartners.DAL.ICPartnersContext context = new DAL.ICPartnersContext();


        private string _Path;

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }

        private DateTime myVar;

        public DateTime Date
        {
            get { return myVar; }
            set { myVar = value; }
        }
        List<Appointment> AllJobsWithResources = new List<Appointment>();
        UnitOfWork work = new UnitOfWork(new ICPartnersContext());

        public DayEndReportPage(DateTime Date, string path)
        {
            this.Path = path;
            this.Date = Date;
            var ItemsSource = context.Appointments.Include("Jobs").Include("Resource").Include("Customer").Where(x => EntityFunctions.TruncateTime(x.StartDate) == Date.Date && EntityFunctions.TruncateTime(x.EndDate) == Date.Date).ToList();


            CreateDocument();

            InitializeComponent();
        }
        private void CreateDocument()
        {
            try
            {

                List<int> DistinctResRefID = new List<int>();
                DistinctResRefID= context.Appointments.Where(x => EntityFunctions.TruncateTime(x.StartDate) == Date.Date && EntityFunctions.TruncateTime(x.EndDate) == Date.Date).Select(x => x.ResourceRefID).Distinct().ToList();

                AllJobsWithResources = context.Appointments.Include("Jobs").Include("Resource").Where(x => EntityFunctions.TruncateTime(x.StartDate) == Date.Date && EntityFunctions.TruncateTime(x.EndDate) == Date.Date).ToList();
               
                #region one




                string fileName = Path;
                var doc = DocX.Create(fileName);
               
                #endregion

                #region two
                //Formatting Title  
                string title = "ICPartners Day-End Report: "+Date.ToShortDateString();

                //Formatting Title  
                // like using this we can set font family, font size, position, font color etc

                Formatting titleFormat = new Formatting();
                //Specify font family  
                titleFormat.FontFamily = new Xceed.Words.NET.Font("Verdana");
                //Specify font size  
                titleFormat.Size = 20D;
                titleFormat.Position = 0;
                titleFormat.FontColor = System.Drawing.Color.CornflowerBlue;
                doc.InsertParagraph(title, false, titleFormat);
                #endregion
                doc.InsertParagraph(Environment.NewLine);
                #region four
                //Create Table with 2 rows and 4 columns.  
                Xceed.Words.NET.Table t = doc.AddTable(DistinctResRefID.Capacity,4);
                t.Alignment = Alignment.center;
                t.Design = TableDesign.LightGridAccent1;
                // Fill cells by adding text.  
                // First row
                t.Rows[0].Cells[0].Paragraphs.First().Append("Name");
                t.Rows[0].Cells[1].Paragraphs.First().Append("Job Done");
                t.Rows[0].Cells[2].Paragraphs.First().Append("Appointment Done");
                t.Rows[0].Cells[3].Paragraphs.First().Append("Total Charged");

                int i = 1;

                foreach (var item in DistinctResRefID)
                {
                    t.Rows[i].Cells[0].Paragraphs.First().Append(AllJobsWithResources.Where(x=>x.ResourceRefID==item).FirstOrDefault().Resource.ResourceName);
                    t.Rows[i].Cells[1].Paragraphs.First().Append(AllJobsWithResources.Where(x => x.ResourceRefID == item).FirstOrDefault().Jobs.Count().ToString());
                    t.Rows[i].Cells[2].Paragraphs.First().Append(AllJobsWithResources.Where(x => x.ResourceRefID == item).Count().ToString());
                    t.Rows[i].Cells[3].Paragraphs.First().Append(AllJobsWithResources.Where(x => x.ResourceRefID == item).Sum(c => c.ChargedAmount).ToString()+ "£");
                    i++;





                }
                    doc.InsertTable(t);
                doc.InsertParagraph(Environment.NewLine);

                Xceed.Words.NET.Paragraph p1 = doc.InsertParagraph();
                p1.InsertHorizontalLine(HorizontalBorderPosition.top);
             


                Formatting totalformat = new Formatting();
                //Specify font family  
                totalformat.FontFamily = new Xceed.Words.NET.Font("Verdana");

                string TotalText = AllJobsWithResources.Sum(x => x.ChargedAmount).ToString();
                totalformat.Size = 14D;
                totalformat.Bold = true;
                totalformat.Position = 0;
                totalformat.FontColor = System.Drawing.Color.Black;

                doc.InsertParagraph("Total Income: ", false, totalformat);
                doc.InsertParagraph("£"+TotalText, false, totalformat);

                #endregion
                #region four
                // Second row details

                #endregion

                // Hyperlink


                #region part of one
                doc.Save();
                Process.Start("WINWORD.EXE", fileName);
                #endregion
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
