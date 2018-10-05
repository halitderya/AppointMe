using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICPartners.Domains;

namespace ICPartners.Logic.Resource
{
    public class ResourceSelector
    {
        public static ICPartners.Domains.Resource SelectedResource  { get; set; }
        public static int DroppedResource { get; set; }
    }
}
