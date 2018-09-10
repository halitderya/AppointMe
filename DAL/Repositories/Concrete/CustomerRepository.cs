using ICPartners.DAL.Repositories.Abstract;
using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DAL.Repositories.Concrete
{
    public class CustomerRepository:Repository<Customer>,ICustomerRepository
    {
        public CustomerRepository(ICPartnersContext context):base(context)
        {

        }
        public ICPartnersContext Context { get { return _context as ICPartnersContext; } }

        public int AddCustomerWithId(Customer customer)
        {
            Context.Customers.Add(customer);
            Context.SaveChanges();
            return customer.CustomerID;
        }
    }
}
