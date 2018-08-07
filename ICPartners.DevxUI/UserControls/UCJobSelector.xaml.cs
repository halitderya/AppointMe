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
using System.Data.Entity;
using ICPartners.Domains;
using System.Windows.Controls.Primitives;

namespace ICPartners.DevxUI.UserControls
{
    public partial class UCJobSelector : UserControl
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
        Button[] MainJobSerie;
        List<Job> Joblist;
        string name;
        IEnumerable<DependentJobs> DependentJobs;
        public UCJobSelector()
        {
            InitializeComponent();
            Joblist = unitOfWork.jobRepository.GetAll().ToList();
            DependentJobs = unitOfWork.DependentRepository.GetAll().GroupBy(x=>x.DependentJob).Select(g=>g.First()).ToList();
            GenerateMainButtons();
            GenerateSubButtons();
        }

        private void GenerateMainButtons()
        {
            MainJobSerie = new Button[Joblist.Count()];

            for (int i = 0; i < Joblist.Count(); i++)
            {
                MainJobSerie[i] = new Button
                {
                    Content = Joblist[i].JobName,
                    Name = "JobBtn" + i.ToString(),
                    Uid = Joblist[i].JobId.ToString(),
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(2, 0, 2, 0),
                };
                spmainservice1.Children.Add(MainJobSerie[i]);
                MainJobSerie[i].Click += new RoutedEventHandler(button_click);
            }
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ButtonClick(Convert.ToInt16(button.Name.Substring(6)));
        }

        void GenerateSubButtons()
        {
            int subbuttoncount = DependentJobs.GroupBy(a => a.DependentJob).Select(g => g.First()).ToList().Count;

            foreach (var item in DependentJobs)
            {

                ToggleButton tb = new ToggleButton();
                tb.Content= Joblist.FirstOrDefault(x => x.JobId == item.DependentJob).JobName;
                tb.Margin = new Thickness(2, 0, 2, 0);
                tb.Name = "tb"+item.DependentJob.ToString();
                tb.VerticalAlignment = VerticalAlignment.Stretch;
                spdependentservice.Children.Add(tb);
                
                
            }

        }

        void ButtonClick(int ButtonID)
        {
            ToggleButton button = new ToggleButton();
            LogicalTreeHelper.FindLogicalNode(button, "tb4");
            button.IsEnabled = false;
                //var sdaa= (ToggleButton) this.FindName("tb"+ButtonID.ToString());
                //sdaa.IsChecked = true;
            

        }
    }
}
