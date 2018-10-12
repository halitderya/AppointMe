using ICPartners.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ICPartners.Domains;
using System.Windows.Controls.Primitives;
using DevExpress.Xpf.LayoutControl;
using ICPartners.Logic.Appointment;
using System.Diagnostics;
using System.ComponentModel;

namespace ICPartners.DevxUI.UserControls
{
    public partial class UCJobselector : UserControl
    {

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
                        tile.Size = TileSize.ExtraSmall;
                        tile.VerticalContentAlignment = VerticalAlignment.Center;
                        tile.HorizontalContentAlignment = HorizontalAlignment.Center;
                        tile.JobID = item.JobId;
                        Color backtile = (Color)ColorConverter.ConvertFromString(item.Color.ToString());
                        tile.Background = new SolidColorBrush(backtile);
                        Color fronttile = (PerceivedBrightness(backtile) > 130 ? Color.FromRgb(20, 20, 20) : Color.FromRgb(230, 230, 230));
                        tile.Foreground = new SolidColorBrush(fronttile);
                        tile.Click += new EventHandler(button_click);
                        MainButtonList.Add(tile);
                        spmainservice1.Children.Add(tile);
                        JobSelector.JobtoCreate = tile.JobID;
                    }
                }

            }
            if (MainButtonList.Count != 0)
            {
                OrginalTileColor = (Color)ColorConverter.ConvertFromString(MainButtonList[0].Background.ToString());
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
            if (button.IsClicked == false)
            {
                UnMarkMainButtons();
                JobSelector.JobtoCreate = AllJoblist.Find(x => x.JobId == button.JobID).JobId;
                button.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                button.IsClicked = true;
              
                
                
            }
            else
            {
                button.Background = new SolidColorBrush(OrginalTileColor);
                button.IsClicked = false;
                UnMarkMainButtons();

            }

        }

        void UnMarkMainButtons()
        {
            foreach (var item in MainButtonList)
            {
                item.IsClicked = false;
                RedrawButtons();
            }
        }
        void RedrawButtons()
        {
            foreach (var item in MainButtonList)
            {
                try
                {
                    item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(unitOfWork.jobRepository.GetByID(item.JobID).Color.ToString()));
             
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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
                        if (context.DependentJobs.Any(x => x.MainJob == item.JobId))
                        {
                         job=  AppointmentEdit.Jobs.FirstOrDefault(j=>j.JobId==(context.DependentJobs.FirstOrDefault(x => x.MainJob == item.JobId).MainJob));

                        }

                    }
                }
                else
                {
                    job = AppointmentEdit.Jobs.FirstOrDefault();

                }
                CustomTile2 ClickedTile = MainButtonList.Find(x => x.JobID == job.JobId);



                button_click(ClickedTile, null);

            }

        }
    }
}
