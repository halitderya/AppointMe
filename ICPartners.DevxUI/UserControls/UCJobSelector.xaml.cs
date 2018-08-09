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

namespace ICPartners.DevxUI.UserControls
{
    public partial class UCJobSelector : UserControl
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
        Color OrginalTileColor = new Color();

        List<Job> AllJoblist= new List<Job>();
        List<DependentJobs> DistrictDependentJobs= new List<DependentJobs>();

        List<CustomTile> MainButtonList = new List<CustomTile>();
        List<CustomTile> SubbuttonList= new List<CustomTile>();

        public UCJobSelector()
        {
            
            InitializeComponent();
            GenerateMainButtons();
            
        }

        private void GenerateMainButtons()
        {
            AllJoblist = unitOfWork.jobRepository.GetAll().ToList();
            DistrictDependentJobs = unitOfWork.DependentRepository.GetAll().GroupBy(x => x.DependentJob).Select(g => g.First()).ToList();

            foreach (var item in AllJoblist)
            {
                CustomTile tile = new CustomTile();
                
                tile.Content = item.JobName;
                tile.Size = TileSize.ExtraSmall;
                tile.VerticalContentAlignment = VerticalAlignment.Center;
                tile.HorizontalContentAlignment = HorizontalAlignment.Center;
                tile.JobID = item.JobId;
                
                tile.Click += new EventHandler(button_click);
                MainButtonList.Add(tile);
                spmainservice1.Children.Add(tile);
                spdependentservice.IsEnabled = false;
                JobSelector.JobtoCreate = tile.JobID;
            }
            if (MainButtonList.Count != 0)
            {
                OrginalTileColor = (Color)ColorConverter.ConvertFromString(MainButtonList[0].Background.ToString());
            }
            GenerateSubButtons();
        }

        private void button_click(object sender, EventArgs e)
        {

            CustomTile button = sender as CustomTile;
            if (button.IsClicked == false)
            {
                UnMarkMainButtons();
                UnMarkSubButtons();
                JobSelector.JobtoCreate = AllJoblist.Find(x => x.JobId == button.JobID).JobId;
                button.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                JobSelector.DependentJobs = DistrictDependentJobs.Where(x => x.MainJob == JobSelector.JobtoCreate).ToList();
                button.IsClicked = true;
                spdependentservice.IsEnabled = true;
                MarkSubbuttons();
            }
            else
            {
                button.Background = new SolidColorBrush(OrginalTileColor);
                button.IsClicked = false;
                spdependentservice.IsEnabled = false;
                UnMarkSubButtons();
                UnMarkMainButtons();

            }

        }

        void MarkSubbuttons()
        {
         
            if(JobSelector.DependentJobs.Count!=0)
            {
                foreach (var item in JobSelector.DependentJobs)
                {
                    
         
                    CustomTile tile = SubbuttonList.Find(x => x.DependentID== item.DependentJob);
                    tile.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    SubbuttonList.Add(tile);
                    tile.IsClicked = true;
                    
                }
            }
            else
            {
                foreach (var item in SubbuttonList)
                {
                    item.Background = new SolidColorBrush(OrginalTileColor);
                }
            }
        }
        void UnMarkSubButtons()
        {
            foreach (var item in SubbuttonList)
            {
                item.IsClicked = false;
                item.Background = new SolidColorBrush(OrginalTileColor);
                
            }
        }
        void UnMarkMainButtons()
        {
            foreach (var item in MainButtonList)
            {
                item.IsClicked = false;
                item.Background = new SolidColorBrush(OrginalTileColor);
            }
        }
        void GenerateSubButtons()
        {
            int subbuttoncount = DistrictDependentJobs.Count; 
            //.GroupBy(a => a.DependentJob).Select(g => g.First()).ToList().Count;


            foreach (var item in DistrictDependentJobs)
            {

                CustomTile DependentTile= new CustomTile();
                DependentTile.Content= AllJoblist.FirstOrDefault(x => x.JobId == item.DependentJob).JobName;
                DependentTile.Name = "dt"+item.DependentJob.ToString();
                DependentTile.VerticalAlignment = VerticalAlignment.Center;
                DependentTile.HorizontalAlignment = HorizontalAlignment.Center;
                DependentTile.Size = TileSize.ExtraSmall;
                DependentTile.DependentID = item.DependentJob;
                DependentTile.IsClicked = false;
                DependentTile.Click += new EventHandler(subbutton_click);
                SubbuttonList.Add(DependentTile);
                spdependentservice.Children.Add(DependentTile);
            }



        }

        private void subbutton_click(object sender, EventArgs e)
        {
            CustomTile ClickedTile = sender as CustomTile;
            if (ClickedTile.IsClicked == true)
            {
                ClickedTile.IsClicked = false;
                ClickedTile.Background = new SolidColorBrush(OrginalTileColor);
                DependentJobs JobToRemove = JobSelector.DependentJobs.Find(x => x.DependentJob == ClickedTile.DependentID);
                JobSelector.DependentJobs.Remove(JobToRemove);
            }
            else
            {
                ClickedTile.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                ClickedTile.IsClicked = true;

                JobSelector.DependentJobs.Add(DistrictDependentJobs.FirstOrDefault(x=>x.DependentJob==ClickedTile.DependentID));
            }

        }
    }
}
