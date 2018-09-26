using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Logic.CustomerFactory
{
    public interface ICustomer
    {
      int CreateCustomerForAppointment(Domains.Customer customer);
    }
}
