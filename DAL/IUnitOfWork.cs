using ICPartners.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DAL
{
    interface IUnitOfWork:IDisposable
    {
        IAppointmentRepository appointmentRepository { get; }
        IResourceRepository resourceRepository { get; }

        IJobRepository jobRepository { get; }
        ICustomerRepository CustomerRepository { get; }

        IDependentRepository DependentRepository { get; }
        int Complete();
    }
}
