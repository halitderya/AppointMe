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
    /// Interaction logic for UCStatusSelector.xaml
    /// </summary>
    public partial class UCStatusSelector : UserControl
    {
        public static readonly DependencyProperty StatusProperty =
     DependencyProperty.Register("Status", typeof(int), typeof(UserControl));


        public int Status
        {
            get
            {
                return (int)GetValue(StatusProperty);
            }
            set
            {
                SetValue(StatusProperty, value);

            }
        }


        public UCStatusSelector()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            switch (Status)
            {
                case 0:
                    ButtonOpen.IsClicked = true;
                    ButtonOpen.Margin = new Thickness(3);
                    break;
                case 1:
                    ButtonCancelled.IsClicked = true;
                    ButtonCancelled.Margin = new Thickness(3);

                    break;
                case 2:
                    ButtonCompletedNoPayment.IsClicked = true;
                    ButtonCompletedNoPayment.Margin = new Thickness(3);
                    break;
                case 3:
                    ButtonCompleted.IsClicked = true;
                    ButtonCompleted.Margin = new Thickness(3);
                    break;

            }


        }
        void Button_Click(object sender, EventArgs e)
            {
            foreach (CustomTile2 item in StackPanelStatus.Children )
            {
                item.IsClicked = false;
                item.Margin = new Thickness(1);
            }
            var send = sender as CustomTile2;
            switch (send.Name)
            {
                case "ButtonOpen":
                    ButtonOpen.IsClicked = true;
                    ButtonOpen.Margin = new Thickness(3);
                    Logic.Appointment.AppointmentSelector.SelectedStatus = 0;
                    break;
                case "ButtonCancelled" :
                    ButtonCancelled.IsClicked = true;
                    ButtonCancelled.Margin = new Thickness(3);
                    Logic.Appointment.AppointmentSelector.SelectedStatus = 1;
                break;
          
                case "ButtonCompletedNoPayment":
                    ButtonCompletedNoPayment.IsClicked = true;
                    ButtonCompletedNoPayment.Margin = new Thickness(3);
                    Logic.Appointment.AppointmentSelector.SelectedStatus = 2;

                    break;
                case "ButtonCompleted":
                    ButtonCompleted.IsClicked = true;
                    ButtonCompleted.Margin = new Thickness(3);
                    Logic.Appointment.AppointmentSelector.SelectedStatus = 3;
                    break;
       
            }



        }
    }
}
