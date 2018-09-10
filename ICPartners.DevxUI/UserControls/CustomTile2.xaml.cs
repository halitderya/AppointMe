using DevExpress.Xpf.LayoutControl;
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
    /// Interaction logic for CustomTile2.xaml
    /// </summary>
    public partial class CustomTile2 : Tile
    {
        public CustomTile2()
        {


            InitializeComponent();
        }


        public bool IsClicked { get; set; }
        public int JobID { get; set; }
        public int DependentID { get; set; }
    }
}
