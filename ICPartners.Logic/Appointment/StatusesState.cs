using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Mvvm.POCO;
using System.Windows.Media;
using System.Threading.Tasks;

namespace ICPartners.Logic.Appointment
{
    public class StatusesState
    {

       
            public static StatusesState Create()
            {
                return ViewModelSource.Create(() => new StatusesState());
            }

            protected StatusesState() { }
            public virtual int Id { get; set; }
            public virtual string Caption { get; set; }
            public virtual Brush Brush { get; set; }
        }

    }
