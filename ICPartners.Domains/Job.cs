using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Domains
{
    public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }


        public double JobPrice { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
