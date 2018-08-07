using ICPartners.DAL.Repositories.Abstract;
using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DAL.Repositories.Concrete
{
    public class DependentRepository : Repository<DependentJobs>, IDependentRepository
    {
        public DependentRepository(DbContext context) : base(context)
        {

        }

        public ICPartnersContext Context { get { return _context as ICPartnersContext; } }

        public IQueryable GetDependentWithJob()
        {
            var temp = from d in Context.DependentJobs
                       join j in Context.Jobs
                       on d.DependentID equals j.JobId
                       select new 
                       {
                           d.DependentID,
                          j.JobName,
                          j.JobTimeSpan
                          
                          

                          
                       };
            return temp;
        }

      
    }
}