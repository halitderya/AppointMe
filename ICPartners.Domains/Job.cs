﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ICPartners.Domains
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public string JobName { get; set; }
        public string JobDescription { get; set; }


        public double JobPrice { get; set; }

        public short JobMode { get; set; }
        public int JobOwner { get; set; }


        public short JobResponsible { get; set; }
        public TimeSpan JobTimeSpan { get; set; }

        public TimeSpan JobOffsetTime { get; set; }

        public string Color { get; set; }



        public virtual ICollection<Appointment> Appointments { get; set; }

        public ICollection<DependentJobs> DependentJobs { get; set; }
    }
}
