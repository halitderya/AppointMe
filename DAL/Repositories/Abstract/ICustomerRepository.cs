using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DAL.Repositories.Abstract
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        int AddCustomerWithId(Customer customer);
    }
}
