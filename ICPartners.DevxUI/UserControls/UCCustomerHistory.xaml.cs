using ICPartners.DAL;
using ICPartners.Domains;
using ICPartners.Logic.Customer;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Controls;

namespace ICPartners.DevxUI.UserControls
{
 
    public partial class UCCustomerHistory : UserControl
    {
        public static IEnumerable<Appointment> history;
        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
        public static DataTable HistoryTable= new DataTable();

        public UCCustomerHistory(int customer)
        {

            InitializeComponent();
            history = unitOfWork.appointmentRepository.GetAppointmentByCustomer(customer).ToList();
            Populatehistory();
        }

  


        public void Populatehistory()
        {
            HistoryTable.Clear();
            

            if (HistoryTable.Columns.Count < 7)
            {
                
                HistoryTable.Columns.Add("Date");
                HistoryTable.Columns.Add("Job");
                HistoryTable.Columns.Add("Resource");
                HistoryTable.Columns.Add("Color Brand");
                HistoryTable.Columns.Add("Color Activator");
                HistoryTable.Columns.Add("Color Quantity");
                HistoryTable.Columns.Add("Remarks");
            }


            foreach (var item in history)
            {
                string JobNameCombi=null;

                foreach (var ite in item.Job)
                {
                    JobNameCombi = JobNameCombi+" + " +  ite.JobName;
                }

                HistoryTable.Rows.Add
                (
                item.CreateDate.ToShortDateString().ToString(),
                JobNameCombi.ToString(),
                item.Resource.ResourceName.ToString(),
                item.ColorBrand ?? "",
                item.ColorCode ?? " ",
                item.ColorQuantity ?? " ",
                item.Remarks ?? " "
                );
            }
            CustomerHistoryGrid.ItemsSource = HistoryTable.AsDataView();
        }

        
     

    }
}
