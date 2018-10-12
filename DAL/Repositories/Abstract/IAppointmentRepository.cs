using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICPartners.Domains;

namespace ICPartners.DAL.Repositories.Abstract
{
    public interface IAppointmentRepository:IRepository<Appointment>
    {
      
        Appointment GetAppointmentById(int AppointmentID);

        IEnumerable<Appointment> GetAppointmentByCustomer(int customerID);

        IEnumerable<Appointment> GetAppointmentByResource(int ResourceID);

        IEnumerable<Appointment> GetAppointmentByParent(int ParentID);

        
    }
}
