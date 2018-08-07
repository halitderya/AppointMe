using ICPartners.Domains;
using System.Linq;
using System.Data.Entity;
using ICPartners.DAL;

namespace ICPartners.DevxUI.Automation
{
    class DependentAppointment
    {

        public DependentAppointment()
        {
           
        }
        Job Jobs;
        Appointment appointment;

        public Appointment CreateAppointment(Appointment oldAppointment)
        {
            


            appointment.JobRefId = Jobs.JobId;
            appointment.StartDate = oldAppointment.EndDate;
            appointment.EndDate = oldAppointment.EndDate.AddMinutes(30);
            appointment.Resource = oldAppointment.Resource;
            appointment.AppointmentStatus = 3;

            return appointment;

        }
    }
}
