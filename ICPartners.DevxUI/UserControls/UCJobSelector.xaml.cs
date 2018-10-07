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

namespace ICPartners.DevxUI.UserControls
{
    public partial class Jobselector : UserControl
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
        Color OrginalTileColor = new Color();

        List<Job> AllJoblist= new List<Job>();
        //List<DependentJobs> DistrictDependentJobs= new List<DependentJobs>();

        List<CustomTile2> MainButtonList = new List<CustomTile2>();
        //List<CustomTile2> SubbuttonList= new List<CustomTile2>();

        public Jobselector()
        {
            
            InitializeComponent();
            GenerateMainButtons();
            
        }

        private void GenerateMainButtons()
        {
            AllJoblist = unitOfWork.jobRepository.GetAll().ToList();
            //DistrictDependentJobs = unitOfWork.DependentRepository.GetAll().GroupBy(x => x.DependentJob).Select(g => g.First()).ToList();
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
                        spdependentservice.IsEnabled = false;
                        JobSelector.JobtoCreate = tile.JobID;
                    }
                }

            }
            if (MainButtonList.Count != 0)
            {
                OrginalTileColor = (Color)ColorConverter.ConvertFromString(MainButtonList[0].Background.ToString());
            }
            //GenerateSubButtons();
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
                //UnMarkSubButtons();
                JobSelector.JobtoCreate = AllJoblist.Find(x => x.JobId == button.JobID).JobId;
                button.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                //JobSelector.DependentJobs = DistrictDependentJobs.Where(x => x.MainJob == JobSelector.JobtoCreate).ToList();
                button.IsClicked = true;
                //spdependentservice.IsEnabled = true;
                //MarkSubbuttons();
            }
            else
            {
                button.Background = new SolidColorBrush(OrginalTileColor);
                button.IsClicked = false;
                spdependentservice.IsEnabled = false;
                //UnMarkSubButtons();
                UnMarkMainButtons();

            }

        }

        //void MarkSubbuttons()
        //{
         
        //    if(JobSelector.DependentJobs.Count!=0)
        //    {
        //        foreach (var item in JobSelector.DependentJobs)
        //        {
                    
         
        //            CustomTile2 tile = SubbuttonList.Find(x => x.DependentID== item.DependentJob);
        //            tile.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        //            SubbuttonList.Add(tile);
        //            tile.IsClicked = true;
                    
        //        }
        //    }
        //    else
        //    {
        //        foreach (var item in SubbuttonList)
        //        {
        //            item.Background = new SolidColorBrush(OrginalTileColor);
        //        }
        //    }
        //}
        //void UnMarkSubButtons()
        //{
        //    foreach (var item in SubbuttonList)
        //    {
        //        item.IsClicked = false;
        //        item.Background = new SolidColorBrush(OrginalTileColor);
                
        //    }
        //}
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
        //void GenerateSubButtons()
        //{
        //    int subbuttoncount = DistrictDependentJobs.Count; 
        //    //.GroupBy(a => a.DependentJob).Select(g => g.First()).ToList().Count;


        //    foreach (var item in DistrictDependentJobs)
        //    {

        //        CustomTile2 DependentTile= new CustomTile2();
        //        DependentTile.Content= AllJoblist.FirstOrDefault(x => x.JobId == item.DependentJob).JobName;
        //        DependentTile.Name = "dt"+item.DependentJob.ToString();
        //        DependentTile.VerticalAlignment = VerticalAlignment.Center;
        //        DependentTile.HorizontalAlignment = HorizontalAlignment.Center;
        //        DependentTile.Size = TileSize.ExtraSmall;
        //        DependentTile.DependentID = item.DependentJob;
        //        DependentTile.IsClicked = false;
        //        //DependentTile.Click += new EventHandler(subbutton_click);
        //        SubbuttonList.Add(DependentTile);
        //        spdependentservice.Children.Add(DependentTile);
        //    }



        //}

        //private void subbutton_click(object sender, EventArgs e)
        //{
        //    CustomTile2 ClickedTile = sender as CustomTile2;
        //    if (ClickedTile.IsClicked == true)
        //    {
        //        ClickedTile.IsClicked = false;
        //        ClickedTile.Background = new SolidColorBrush(OrginalTileColor);
        //        DependentJobs JobToRemove = JobSelector.DependentJobs.Find(x => x.DependentJob == ClickedTile.DependentID);
        //        JobSelector.DependentJobs.Remove(JobToRemove);
        //    }
        //    else
        //    {
        //        ClickedTile.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        //        ClickedTile.IsClicked = true;

        //        JobSelector.DependentJobs.Add(DistrictDependentJobs.FirstOrDefault(x=>x.DependentJob==ClickedTile.DependentID));
        //    }

        //}
    }
}
