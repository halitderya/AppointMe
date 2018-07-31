using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICPartners.DAL.Repositories.Abstract;
using ICPartners.DAL.Repositories.Concrete;

namespace ICPartners.DAL
{
    public class UnitOfWork : IUnitOfWork


    {
        private ICPartnersContext _context;

        public UnitOfWork(ICPartnersContext context)
        {
            _context = context;
            appointmentRepository = new AppointmentRepository(_context);
            taskRepository = new TaskRepository(_context);
            resourceRepository = new ResourceRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
            jobRepository = new JobRepository(_context);
        }
        public IAppointmentRepository appointmentRepository { get; private set; }

        public ITaskRepository taskRepository { get; private set; }

        public IResourceRepository resourceRepository { get; private set; }

        public IJobRepository jobRepository { get; private set; }

        

        public ICustomerRepository CustomerRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
             _context.Dispose();

        }
    }
}
