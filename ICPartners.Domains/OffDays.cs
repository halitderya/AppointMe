using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Domains
{
    public class OffDay
    {

        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int OffDaysID { get; set; }
        public int OffDaysType { get; set; }
        public int OffWeekDay { get; set; }
        public DateTime? OffDaysStart { get; set; }
        public DateTime? OffDaysEnd { get; set; }
        [ForeignKey("Resource")]
        public int ResourceRefID { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
