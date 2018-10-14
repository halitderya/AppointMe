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
    public class OffDayRepository: Repository<OffDay>,IOffDaysRepository
    {
        public OffDayRepository(DbContext context) : base(context)
        {

        }
        public ICPartnersContext Context { get { return _context as ICPartnersContext; } }


    }
}
