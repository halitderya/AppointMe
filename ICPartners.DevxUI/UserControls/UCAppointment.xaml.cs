using DevExpress.Xpf.Core;
using DevExpress.Xpf.Scheduler;
using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler;
using ICPartners.DAL;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UCAppointment.xaml
    /// </summary>

   
    public partial class UCAppointment : UserControl
    {




        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
        public UCAppointment()
        {

            InitializeComponent();


            dayView1.ResourcesPerPage = unitOfWork.resourceRepository.GetAll().Count();




        }

        private void SchedulerControl_BeforeAppointmentItemDelete(object sender, DevExpress.Xpf.Scheduling.AppointmentItemCancelEventArgs e)
        {
            MessageBoxResult dialog = DXMessageBox.Show("Are you sure delete appointment?\n"+"This process isn't reversible!" , "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialog == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void MainScheduler_AppointmentsUpdated(object sender, EventArgs e)
        {

            
            
        }

        private void MainScheduler_ItemPropertyChanged(object sender, DevExpress.Xpf.Scheduling.ItemPropertyChangedEventArgs e)
        {
            //if (e.PropertyName == "StatusId")
            //{
            //    var ItemToChange = e.Item as AppointmentItem;
            //    if (ItemToChange != null)
            //        try
            //        {

            //            unitOfWork.appointmentRepository.GetByID((int)ItemToChange.Id).AppointmentStatus = Convert.ToInt16(ItemToChange.StatusId);
            //            unitOfWork.Complete();
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.Write(ex.Message);

            //        }
            //}
        }
        public void RefreshScheduler(Domains.Appointment oldAppointment, Domains.Appointment newAppointment)
        {
            //MainScheduler.AppointmentItems.Remove(new AppointmentItem {

            //    Id = oldAppointment.AppointmentID

            //});
            //MainScheduler.AppointmentItems.Add(new AppointmentItem
            //{
            //    Id = oldAppointment.AppointmentID,
            //    StatusId=6
                
               
            //});
            //unitOfWork.Complete();

        }
        private void MainScheduler_InitNewAppointment(object sender, DevExpress.Xpf.Scheduling.AppointmentItemEventArgs e)
        {
            ICPartners.Logic.Resource.ResourceSelector.SelectedResource = unitOfWork.resourceRepository.GetByID((int)(sender as DevExpress.Xpf.Scheduling.SchedulerControl).SelectedResource.Id);
            //ICPartners.Logic.Appointment.AppointmentSelector.SelectedNewAppointment = new Domains.Appointment {
            //    AppointmentID = 0,
            //    AppointmentStatus = 0,
            //    StartDate = e.Appointment.Start,
            //    Job = (e.Appointment.CustomFields[0])

               
            //};
            //e.Appointment.StatusId = 0;
        }

        private void MainScheduler_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MainScheduler_AppointmentWindowShowing(object sender, AppointmentWindowShowingEventArgs e)
        {
            if (e.Appointment != null && e.Appointment.Id != null)
            {
                ICPartners.Logic.Appointment.AppointmentSelector.AppointmentToEdit = unitOfWork.appointmentRepository.GetByID((int)e.Appointment.Id);

            }

            

        }

        private void MainScheduler_AppointmentsUpdated_1(object sender, EventArgs e)
        {

        }

       
    }
}
