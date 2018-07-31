using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Domains
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string  CustomerTitle { get; set; }
        public string CustomerName { get; set; }
        public string  CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPostCode { get; set; }
        public string CustomerCity { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
