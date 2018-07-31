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
using System.Windows.Shapes;
using DevExpress.Xpf.Ribbon;
using ICPartners.DAL;
using ICPartners.Domains;

namespace ICPartners.DevxUI
{
    /// <summary>
    /// Interaction logic for CustomAppointmentWindow1.xaml
    /// </summary>
    /// 
    public partial class CustomAppointmentWindow1 : DXRibbonWindow

    {
        Button[] MainButtonSerie;
        CheckBox[] TaskButtonSerie;

        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
        public CustomAppointmentWindow1()
        {

            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {


            GenerateMainButtons();
            GenerateSubButtons();





        }







        private void GenerateMainButtons()
        {
            List<Job> joblist = unitOfWork.jobRepository.GetAll().ToList();
            MainButtonSerie = new Button[joblist.Count()];

            for (int i = 0; i < joblist.Count(); i++)

            {


                MainButtonSerie[i] = new Button
                {
                    Content = joblist[i].JobName,
                    Name = "JobBtn" + i.ToString(),
                    Uid =joblist[i].JobId.ToString(),
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(2, 0, 2, 0),
                    

                };
                spmainservice.Children.Add(MainButtonSerie[i]);
                MainButtonSerie[i].Click += new RoutedEventHandler(button_click);

            }


            
           

        }
        void GenerateSubButtons()
        {

            TaskButtonSerie = new CheckBox[4];



            for (int i = 0; i < 4; i++)
            {

                TaskButtonSerie[i] = new CheckBox
                {
                    Name = "taskcb"+i.ToString(),
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(2, 0, 2, 0),

                };
                spsubservices.Children.Add(TaskButtonSerie[i]);






            }


        }
        void button_click(object sender, EventArgs e)
        {
            Button button = sender as Button;


            var sayi = unitOfWork.jobRepository.JobTaskCount(Convert.ToInt16(button.Uid));

            
            
            



            MessageBox.Show(button.Uid + " Clicked");
            




        }
    }
}