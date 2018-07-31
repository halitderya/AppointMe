using ICPartners.Domains;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DAL.Repositories.Abstract
{
    public interface IJobRepository:IRepository<Job>
    {
        int JobTaskCount(int JobID);

        //IEnumerable<Domains.Task> GetTasksByJobID(int JobID);

    }
}
