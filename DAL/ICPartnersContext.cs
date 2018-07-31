using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICPartners.Domains;


namespace ICPartners.DAL
{
    public class ICPartnersContext:DbContext

    {

        public ICPartnersContext():base("ConStr")
        {
            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ICPartners.Domains.Task> Tasks { get; set; }

        public override int SaveChanges()
        {
            
            return base.SaveChanges();
        }
    }
}
