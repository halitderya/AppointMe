﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Logic.Appointment
{
    public class AppointmentSelector
    {
        public static Domains.Appointment AppointmentToEdit { get; set; }
        public static Domains.Appointment SelectedNewAppointment { get; set; }
        public static Domains.Appointment OriginalAppointment { get; set; }
        public  static int AppointmentToDelete { get; set; }
        public static int SelectedStatus { get; set; }
    }
}
