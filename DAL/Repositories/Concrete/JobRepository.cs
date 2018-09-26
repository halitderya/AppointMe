using ICPartners.DAL.Repositories.Abstract;
using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DAL.Repositories.Concrete
{
    public class JobRepository:Repository<Job>,IJobRepository
    {
        public JobRepository(ICPartnersContext context):base(context)
        {

        }

        //public int JobTaskCount(int JobID)
        //{
           
        //   return  Context.Jobs.Include("Tasks").FirstOrDefault(c => c.JobId == JobID).Tasks.Count();



        //}

        

        //public IEnumerable<Domains.Task> GetTasksByJobID(int JobID)
        //{
        //    return Context.Jobs.Include("Tasks").FirstOrDefault(c => c.JobId == JobID).Tasks;
        //}

        public ICPartnersContext Context { get { return _context as ICPartnersContext; } }


        public int JobTaskCount(int JobID)
        {
            return Context.DependentJobs.Select(x => x.MainJob == JobID).Count();
            
        }
    }
}
