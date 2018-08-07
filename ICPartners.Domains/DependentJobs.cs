using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Domains
{
    public class DependentJobs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DependentID { get; set; }


    
        public int MainJob { get; set; }

        public int DependentJob { get; set; }


   
        public int DefaultResource { get; set; }



    }
}
