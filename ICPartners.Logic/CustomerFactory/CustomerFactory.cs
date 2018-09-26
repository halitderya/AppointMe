using ICPartners.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Logic.CustomerFactory
{
    public class CustomerFactory : ICustomer
    {
        public int CreateCustomerForAppointment(Domains.Customer customer)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());
            Customer.CustomerSelector.CreateCustomerWithAppointment = false;

            unitOfWork.Complete();
            return unitOfWork.CustomerRepository.AddCustomerWithId(customer);
          

        }
    }
}
