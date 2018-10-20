using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Scheduler;
using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Services;
using ICPartners.DAL;
using ICPartners.Domains;
using System;
using System.Collections;
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
           (dayView1.TimeRulers.FirstOrDefault() as DevExpress.Xpf.Scheduling.TimeRuler).ShowMinutes=true;


        }

       

        private void SchedulerControl_BeforeAppointmentItemDelete(object sender, DevExpress.Xpf.Scheduling.AppointmentItemCancelEventArgs e)
        {
            if (Logic.UserManagement.CurrentUser.LoggedUser.Role > 1)
            {
                MessageBoxResult dialog = DXMessageBox.Show("Are you sure delete appointment?\n" + "This process isn't reversible!", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (dialog == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
                else
                {

                    unitOfWork.Complete();
                }

                Logic.Appointment.AppointmentSelector.AppointmentToDelete = (int)e.Appointment.Id;

            }
            else
            {
                DXMessageBox.Show("You don't have permission to delete appointment","Insufficient Authority", MessageBoxButton.OK, MessageBoxImage.Stop);
                e.Cancel = true;
            }


        }


        private void MainScheduler_ItemPropertyChanged(object sender, DevExpress.Xpf.Scheduling.ItemPropertyChangedEventArgs e)
        {




            //string[] Important = new string[] { "StatusId", "Start", "End" , "ResourceIds" };
            //var fe = e.PropertyName;
            ////unitOfWork.appointmentRepository.GetByID((int)ItemToChange.Id).AppointmentStatus = Convert.ToInt16(ItemToChange.StatusId);
            //if ((e.Item is AppointmentItem ItemToChange) && (Array.Exists(Important, x => x.Equals(e.PropertyName.ToString()))))
            //{
                
            //            Domains.Appointment appointment = unitOfWork.appointmentRepository.GetByID((ItemToChange.SourceObject as Domains.Appointment).AppointmentID);

            //    switch (e.PropertyName)
            //    {
            //        case "StatusId":
            //            appointment.AppointmentStatus = Convert.ToInt16(ItemToChange.StatusId);
            //            Console.WriteLine("statusid");
            //            break;
            //        case "Start":

            //            appointment.StartDate = ItemToChange.Start;
            //            appointment.EndDate = ItemToChange.Start + ItemToChange.Duration;
            //            Console.WriteLine("start+end");
            //            break;
            //        case "End":
            //            Console.WriteLine("end");
                        
            //            appointment.EndDate = ItemToChange.End;

            //            break;
            //        case "ResourceIds":
            //            Console.WriteLine("resource");
            //            //appointment.ResourceRefID = Logic.Resource.ResourceSelector.DroppedResource;
            //            break;

            //    }


            //    unitOfWork.Complete();
            //    ;
            //}



        }
        private void MainScheduler_InitNewAppointment(object sender, DevExpress.Xpf.Scheduling.AppointmentItemEventArgs e)
        {

           




          
            //ICPartners.Logic.Resource.ResourceSelector.SelectedResource = unitOfWork.resourceRepository.GetByID((int)(sender as DevExpress.Xpf.Scheduling.SchedulerControl).SelectedResource.Id);
            //ICPartners.Logic.Appointment.AppointmentSelector.SelectedNewAppointment = new Domains.Appointment {
            //    AppointmentID = 0,
            //    AppointmentStatus = 0,
            //    StartDate = e.Appointment.Start,
            //    Job = (e.Appointment.CustomFields[0])

               
            //};
            //e.Appointment.StatusId = 0;
        }


        private void MainScheduler_AppointmentWindowShowing(object sender, AppointmentWindowShowingEventArgs e)
        {

            if (Logic.UserManagement.CurrentUser.LoggedUser.Role > 1)
            {


                if (e.Appointment != null && e.Appointment.Id != null)
                {
                    ICPartners.Logic.Appointment.AppointmentSelector.AppointmentToEdit = unitOfWork.appointmentRepository.GetByID((int)e.Appointment.Id);
                }

                else
                {
                    if ((sender as DevExpress.Xpf.Scheduling.SchedulerControl).SelectedResource.Id != null)
                    {
                        int id = Convert.ToInt16((sender as DevExpress.Xpf.Scheduling.SchedulerControl).SelectedResource.Id);
                        List<OffDay> offdaylist = new List<OffDay>();
                        offdaylist = unitOfWork.OffDaysRepository.GetAll().ToList().Where(x => x.ResourceRefID == id).ToList();
                        bool WeekEnd = offdaylist.Any(x => x.OffWeekDay == (int)e.Appointment.Start.DayOfWeek);
                        bool Holiday = offdaylist.Any(x => x.OffDaysStart <= e.Appointment.Start && e.Appointment.Start < x.OffDaysEnd);

                        if (WeekEnd == true || Holiday == true)
                        {
                            MessageBoxResult result = DXMessageBox.Show("The resource you have selected out of work hours selected interval. Do you want to proceed anyway?", "Off-Day Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.No)
                            {
                                e.Cancel = true;
                            }

                        }

                    }


                }

                ViewModels.AppointmentViewModel model = new ViewModels.AppointmentViewModel();
                ICPartners.Logic.Resource.ResourceSelector.SelectedResource = unitOfWork.resourceRepository.GetByID((int)((e.Appointment as AppointmentItem).ResourceId));
            }
            else
            {
                DXMessageBox.Show("You don't have permission to create or change an appointment", "Insufficient Authority", MessageBoxButton.OK, MessageBoxImage.Stop);
                e.Cancel = true;
            }
        }




        private void MainScheduler_AppointmentDrop(object sender, AppointmentItemDragDropEventArgs e)
        {
            ICPartners.Logic.Resource.ResourceSelector.DroppedResource = (int)e.HitResource.Id ;
        }

        private void MainScheduler_AppointmentsUpdated(object sender, EventArgs e)
        {

        }

        private void MainScheduler_ItemsCollectionChanged(object sender, ItemsCollectionChangedEventArgs e)
        {
            
                
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            
        }

        private void MainScheduler_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            var mains = MainScheduler;

        }

        private void MainScheduler_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void MainScheduler_CustomWorkTime(object sender, CustomWorkTimeEventArgs e)
        {
        }

        private void MainScheduler_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
