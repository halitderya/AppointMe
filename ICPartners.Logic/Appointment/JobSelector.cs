using ICPartners.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Logic.Appointment
{
    public class JobSelector

    {

        static JobSelector()
        {
            if (JobsToSelect == null)
                JobsToSelect = new HashSet<Job>();
        }
        public static int JobtoCreate { get; set; }
        public static List<DependentJobs> DependentJobs;
        private static HashSet<Job> _JobToSelect;
        public static bool IsJobEdited { get; set; }
        public static HashSet<Job> JobsToSelect
        {
            get { return _JobToSelect; }
            set { _JobToSelect = value; }
        }

    }
}
