using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.Domains
{
    public class Appointment
    {
        public Appointment()
        {
            this.Jobs = new HashSet<Job>();

            //if (this.Jobs == null)
            //{
            //    this.Jobs = new Collection<Job>();
            //}
        }
        #region body
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AppointmentID { get; set; }
        public int AppointmentStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double? ChargedAmount { get; set; }

        #endregion

        #region log
        private DateTime _currentdate = DateTime.Now;
        public DateTime CreateDate {

            get

            {
                return _currentdate;
            }
            set
            {
                if(AppointmentID == 0)
                {
                    _currentdate = value;
                }
            }


        }
        public DateTime UpdateDate
        {


            get

            {
                return _currentdate;
            }
            set
            {
                if (AppointmentID == 0)
                {
                    _currentdate = value;
                }
            }

        }

        
        public string UpdatedBy { get; set; }
        #endregion
        public int ParentID { get; set; }
        public string ColorBrand { get; set; }
        public string ColorCode { get; set; }

        public string ColorQuantity { get; set; }
        public string ColorActivator { get; set; }
        public string Remarks { get; set; }

        
        #region relation
 

        [ForeignKey("Customer")]
        public int CustomerRefId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual HashSet<Job> Jobs {get; set; }


        [ForeignKey("Resource")]
        public int ResourceRefID { get; set; }
        public virtual Resource Resource { get; set; }


        #endregion
    }
}
