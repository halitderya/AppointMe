﻿using System;
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
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<DependentJobs> DependentJobs { get; set; }
        public DbSet<OffDay> OffDays { get; set; }

        public override int SaveChanges()
        {

            var add = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);

            return base.SaveChanges();
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

  
        }



    }
}

