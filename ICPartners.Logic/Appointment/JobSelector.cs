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
                JobsToSelect = new Queue<Job>();
        }
        public static int JobtoCreate { get; set; }
        public static List<DependentJobs> DependentJobs;
        private static Queue<Job> _JobToSelect;
        public static bool IsJobEdited { get; set; }
        public static Queue<Job> JobsToSelect
        {
            get { return _JobToSelect; }
            set { _JobToSelect = value; }
        }

    }
}
