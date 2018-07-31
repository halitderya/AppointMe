using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Domains
{
    public class Task
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public TimeSpan TaskTimeSpan { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
