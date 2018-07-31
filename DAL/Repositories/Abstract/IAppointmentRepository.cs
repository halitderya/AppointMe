using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICPartners.Domains;

namespace ICPartners.DAL.Repositories.Abstract
{
    public interface IAppointmentRepository:IRepository<Appointment>
    {
      
        Appointment GetAppointmentById(int AppointmentID);

        IEnumerable<Appointment> GetAppointmentByResource(int ResourceID);

        
    }
}
