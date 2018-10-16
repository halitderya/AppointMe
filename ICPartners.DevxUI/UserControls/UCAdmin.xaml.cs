using ICPartners.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ICPartners.Domains;
using OfficeOpenXml;
using System.IO;
using System;
using DevExpress.Xpf.Core;

namespace ICPartners.DevxUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCAdmin.xaml


    /// </summary>
 

    public partial class UCAdmin : System.Windows.Controls.UserControl
    {
        ICPartnersContext context = new ICPartnersContext();
        int SuccessfulRows = 0;
        int FailedRows = 0;
        public UCAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Appointment> AppointmentsList = new List<Appointment>();
            AppointmentsList = context.Appointments.Include("Jobs").ToList();
            List<Resource> ResourcesList = new List<Resource>();
            ResourcesList = context.Resources.ToList();
            List<Job> JobList = new List<Job>();
            JobList = context.Jobs.ToList();
            List<DependentJobs> DependentJobsList = new List<DependentJobs>();
            DependentJobsList = context.DependentJobs.ToList();
            List<OffDay> OffDaysList = new List<OffDay>();
            OffDaysList = context.OffDays.ToList();
            List<Customer> CustomersList = new List<Customer>();
            CustomersList = context.Customers.ToList();
            
            string ExcelPath = "";

            var saveFileDialog = new Microsoft.Win32.SaveFileDialog()
            {
                DefaultExt = "*.xlxs",
                Filter = "Excel Files (*.xlsx)|*.xlsx",
            };

            var result = saveFileDialog.ShowDialog();
            if (result != null && result == true)
            {
                ExcelPath = saveFileDialog.FileName;
                ListToExcel(AppointmentsList,ResourcesList,JobList, ExcelPath);
            }


            //ListToExcel(list);



        }

        public void ListToExcel(List<Appointment> AppointmentsList,List<Resource> ResourcesList,List<Job> JobList, string location)
        {

            using (ExcelPackage pck = new ExcelPackage(new System.IO.FileInfo(location)))
            {
                ExcelWorksheet AppointmExcelWorksheet = pck.Workbook.Worksheets.Add("Appointments");
                AppointmExcelWorksheet.Cells[1,3, AppointmentsList.Capacity,4].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                AppointmExcelWorksheet.Cells[1, 6, AppointmentsList.Capacity, 7].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                AppointmExcelWorksheet.Cells["A1"].LoadFromCollection(AppointmentsList, true);

                ExcelWorksheet ResourcExcelWorksheet = pck.Workbook.Worksheets.Add("Resources");
                ResourcExcelWorksheet.Cells[1, 4, ResourcesList.Capacity, 4].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                ResourcExcelWorksheet.Cells["A1"].LoadFromCollection(ResourcesList, true);





                ExcelWorksheet JobListExcelWorksheet = pck.Workbook.Worksheets.Add("Jobs");
                JobListExcelWorksheet.Cells[1, 8, JobList.Capacity, 8].Style.Numberformat.Format = "HH:mm:ss";
                JobListExcelWorksheet.Cells[1, 9, JobList.Capacity, 9].Style.Numberformat.Format = "HH:mm:ss";


                JobListExcelWorksheet.Cells["A1"].LoadFromCollection(JobList, true);






                pck.Save();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string excelpath = "";
            var OpenFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                DefaultExt = "*.xlxs",
                Filter = "Excel Files (*.xlsx)|*.xlsx",
            };

            var result = OpenFileDialog.ShowDialog();
            if (result != null && result == true)
            {
                excelpath = OpenFileDialog.FileName;
                ExcelToList(excelpath);
            }
        }


        public void ExcelToList(string excelpath)
        {

            var package = new ExcelPackage(new FileInfo(excelpath));

            ExcelWorksheet appointmExcelWorksheet = package.Workbook.Worksheets["Appointments"];
            if (appointmExcelWorksheet != null)
            {
                for (int i = appointmExcelWorksheet.Dimension.Start.Row + 1; i <= appointmExcelWorksheet.Dimension.End.Row - 1; i++)
                {
                    try
                    {
                        Appointment appointment = new Appointment
                        {
                            AppointmentStatus = Convert.ToInt32((appointmExcelWorksheet.Cells[i, 2].Text)),
                            StartDate = Convert.ToDateTime((appointmExcelWorksheet.Cells[i, 3].Text)),
                            EndDate = Convert.ToDateTime((appointmExcelWorksheet.Cells[i, 4].Text)),
                            ChargedAmount = appointmExcelWorksheet.Cells[i, 5].Value == null ? 0 : Convert.ToDouble((appointmExcelWorksheet.Cells[i, 5]).Text),
                            CreateDate = Convert.ToDateTime((appointmExcelWorksheet.Cells[i, 6].Text)),
                            UpdateDate = Convert.ToDateTime((appointmExcelWorksheet.Cells[i, 7].Text)),
                            UpdatedBy = (appointmExcelWorksheet.Cells[i, 8].Text),
                            ParentID = Convert.ToInt32((appointmExcelWorksheet.Cells[i, 9].Text)),
                            ColorBrand = (appointmExcelWorksheet.Cells[i, 10].Text),
                            ColorCode = (appointmExcelWorksheet.Cells[i, 11].Text),
                            ColorQuantity = (appointmExcelWorksheet.Cells[i, 12].Text),
                            ColorActivator = (appointmExcelWorksheet.Cells[i, 13].Text),
                            Remarks = (appointmExcelWorksheet.Cells[i, 14].Text),
                            CustomerRefId = Convert.ToInt32((appointmExcelWorksheet.Cells[i, 15].Text)),
                            ResourceRefID = Convert.ToInt32((appointmExcelWorksheet.Cells[i, 18].Text))
                        };
                        context.Appointments.Add(appointment);
                        context.SaveChanges();
                        SuccessfulRows++;
                    }




                    catch (Exception ex)
                    {
                        FailedRows++;
                    }

                }
                DXMessageBox.Show(SuccessfulRows.ToString() + " Rows succesfully inserted. " + FailedRows.ToString() + " Rows to failed to insert", "Result", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                DXMessageBox.Show("'Appointments' sheet not found on source file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            


        }
    }
}
