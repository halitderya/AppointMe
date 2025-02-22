﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ICPartners.Domains
{
    public class Resource
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceID { get; set; }
        public int Index { get; set; }
        public string ResourceName { get; set; }
        public string ResourceSurname { get; set; }
        public DateTime? ResourceStartDate { get; set; }
        public string ResourcePhone { get; set; }
        public string ResourceEmerphone { get; set; }
        public string EMail { get; set; }

        public byte[] ResourceImage { get; set; }

        public string ResourceAddress { get; set; }
        public string ResourcePostcode { get; set; }
        public string ResourceCity { get; set; }
        public bool ResourceVisibility { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public int ResourceDuty { get; set; }

        public string NIN { get; set; }

        public string BankAccount { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<OffDay> OffDays { get; set; }
    }
}
