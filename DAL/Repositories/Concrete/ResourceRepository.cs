using ICPartners.DAL.Repositories.Abstract;
using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DAL.Repositories.Concrete
{
    public class ResourceRepository:Repository<Resource>,IResourceRepository
    {
        public ResourceRepository(ICPartnersContext context):base(context)
        {

        }

        public ICPartnersContext Context { get { return _context as ICPartnersContext; } }




    }
}
