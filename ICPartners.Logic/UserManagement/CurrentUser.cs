using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Logic.UserManagement
{
    public class CurrentUser
    {
        public static ICPartners.Domains.Resource LoggedUser { get; set; }
    }
}
