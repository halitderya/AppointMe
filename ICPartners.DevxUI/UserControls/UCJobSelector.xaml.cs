using ICPartners.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ICPartners.Domains;
using DevExpress.Xpf.LayoutControl;
using ICPartners.Logic.Appointment;
using System.Diagnostics;
using DevExpress.Xpf.Core;

namespace ICPartners.DevxUI.UserControls
{
    public partial class UCJobselector : UserControl
    {

        ICPartnersContext context = new ICPartnersContext();
        public static readonly DependencyProperty ReceivedJobsProperty =
       DependencyProperty.Register("ReceivedJobs", typeof(HashSet<Job>), typeof(UCJobselector));


        public HashSet<Job> ReceivedJobs
        {
            get
            {
                return (HashSet<Job>)GetValue(ReceivedJobsProperty);
            }
            set
            {
                SetValue(ReceivedJobsProperty, value);

            }
        }

        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
        Color OrginalTileColor = new Color();
        List<Job> AllJoblist= new List<Job>();
        List<CustomTile2> MainButtonList = new List<CustomTile2>();

        public UCJobselector()
        {
            
            InitializeComponent();
            
        }

        private void GenerateMainButtons()
        {

            AllJoblist = unitOfWork.jobRepository.GetAll().ToList();
            foreach (var item in AllJoblist)
            {
                if (ICPartners.Logic.Resource.ResourceSelector.SelectedResource!=null)
                {
                    if (item.JobOwner == ICPartners.Logic.Resource.ResourceSelector.SelectedResource.ResourceDuty)
                    {
                        CustomTile2 tile = new CustomTile2();
                        tile.Content = item.JobName;
                        tile.VerticalContentAlignment = VerticalAlignment.Center;
                        tile.HorizontalContentAlignment = HorizontalAlignment.Center;
                        tile.Width = AllJoblist.Where(x => x.JobOwner == Logic.Resource.ResourceSelector.SelectedResource.ResourceDuty).Count() > 18 ? 67 : 84;
                        tile.Height = tile.Width;
                        tile.JobID = item.JobId;
                        Color backtile = (Color)ColorConverter.ConvertFromString(item.Color.ToString());
                        tile.Background = new SolidColorBrush(backtile);
                        Color fronttile = (PerceivedBrightness(backtile) > 130 ? Color.FromRgb(20, 20, 20) : Color.FromRgb(230, 230, 230));
                        tile.Foreground = new SolidColorBrush(fronttile);
                        tile.Click += new EventHandler(button_click);
                        MainButtonList.Add(tile);
                        spmainservice1.Children.Add(tile);
                        //JobSelector.JobtoCreate = tile.JobID;
                    }
                }

            }
            if (MainButtonList.Count != 0)
            {
                OrginalTileColor = (Color)ColorConverter.ConvertFromString(MainButtonList[0].Background.ToString());
            }
        }
        void TriggerEvent(CustomTile2 tile)
        {
            foreach (var Window in App.Current.Windows)
            {
                if (Window is ICPartners.DevxUI.CustomAppointmentWindow)
                {
                    (Window as ICPartners.DevxUI.CustomAppointmentWindow).CustomerName_EditValueChanged(tile, null);
                }
            }
        }
        int PerceivedBrightness(Color c)
        {
            return (int)Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }

        private void button_click(object sender, EventArgs e)
        {

            CustomTile2 button = sender as CustomTile2;
            if (sender!=null)
            {
                if (button.IsClicked == false)
                {
                    //UnMarkMainButtons();
                    //JobSelector.JobtoCreate = AllJoblist.Find(x => x.JobId == button.JobID).JobId;
                    JobSelector.JobsToSelect.Add(AllJoblist.Find(x => x.JobId == button.JobID));
                    button.Width = button.Width - 10;
                    button.Height = button.Width;
                    button.IsClicked = true;
                    foreach (var Window in App.Current.Windows)

                    {

                        if (Window is ICPartners.DevxUI.CustomAppointmentWindow)
                        {
                            double Price = 0;
                            List<Job> AllJobs = new List<Job>();
                            AllJobs = context.Jobs.ToList();
                            Price= JobSelector.JobsToSelect.Sum(x => x.JobPrice);
                            (Window as ICPartners.DevxUI.CustomAppointmentWindow).TotalPriceTxt.Text = Price.ToString();
                        }


                    }
                    TriggerEvent(button);


                }
                else
                {
                    button.Width = button.Width + 10;
                    button.Height = button.Width;
                    if (JobSelector.JobsToSelect.Any(x => x.JobId == button.JobID))
                    {
                        JobSelector.JobsToSelect.Remove((JobSelector.JobsToSelect.FirstOrDefault(x => x.JobId == button.JobID)));
                    }
                    
                    button.IsClicked = false;
                    UnMarkMainButtons();
                    TriggerEvent(button);
                }
            }
            else
            {
                DXMessageBox.Show("The appointment which is you're trying to edit, assigned to a resource who hasn't have right to do it. Please assign an other resource.", "Wrong resource", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        void UnMarkMainButtons()
        {
            //foreach (var item in MainButtonList)
            //{
            //    item.IsClicked = false;
            //    RedrawButtons();
            //}
            //JobSelector.JobtoCreate = 0;
        }
        void RedrawButtons()
        {
            foreach (var item in MainButtonList)
            {
                try
                {
                    //item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(unitOfWork.jobRepository.GetByID(item.JobID).Color.ToString()));

                    item.Width = AllJoblist.Where(x => x.JobOwner == Logic.Resource.ResourceSelector.SelectedResource.ResourceDuty).Count() > 18 ? 67 : 84;
                    item.Height = item.Width;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            JobSelector.JobsToSelect.Clear();
            GenerateMainButtons();
            if (ReceivedJobs != null && ReceivedJobs.Count > 0)
            {
                Job job = new Job();
                ICPartnersContext context = new ICPartnersContext();
                Appointment AppointmentEdit = context.Appointments.Include("Jobs").FirstOrDefault(x => x.AppointmentID == AppointmentSelector.AppointmentToEdit.AppointmentID);
                if (AppointmentEdit.Jobs.Count > 1)
                {
                    foreach (var item in AppointmentEdit.Jobs)
                    {
                        CustomTile2 ClickedTile = MainButtonList.Find(x => x.JobID == item.JobId);
                        button_click(ClickedTile, null);

                    }
                }

                else
                {
                    CustomTile2 ClickedTile = MainButtonList.Find(x => x.JobID == AppointmentEdit.Jobs.FirstOrDefault().JobId);

                    button_click(ClickedTile, null);

                }





            }

        }

        private void spmainservice1_TileClick(object sender, TileClickEventArgs e)
        {
            Logic.Appointment.JobSelector.IsJobEdited = true;
        }
    }
}
