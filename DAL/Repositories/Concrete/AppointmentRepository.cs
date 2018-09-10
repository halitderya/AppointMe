using ICPartners.DAL.Repositories.Abstract;
using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DAL.Repositories.Concrete
{
    public class AppointmentRepository : Repository<Appointment>,IAppointmentRepository
    {
        public AppointmentRepository(ICPartnersContext context):base(context)
        {

        }

      

        public Appointment GetAppointmentById(int AppointmentID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAppointmentByResource(int ResourceID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAppointmentByCustomer(int customerID)
        {

            var temp = Context.Appointments.Include("Customer").Include("Resource").Where(x=>x.CustomerRefId==customerID);
            return temp;
        }



  

        public ICPartnersContext Context { get { return _context as ICPartnersContext; } }
    }
}
