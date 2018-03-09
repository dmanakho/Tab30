using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tab30.Models
{
    public class Repair : Auditable
    {
        public Repair()
        {
            ProblemAreas = new HashSet<ProblemArea>();
            PartOrders = new HashSet<PartOrder>();
        }
        public int ID { get; set; }

        [DisplayName("Vendor Case#"), StringLength(50)]
        [Index(IsUnique = true)]
        [Required(ErrorMessage ="Vendor Case Number is Required and it must be unique")]
        public string VendorCaseNo { get; set; }

        [Required]
        [DisplayName("Description"), StringLength(250)]
        public string Description { get; set; }

        
        #region Boolean and DataTime Fields
        [DisplayName("Closed")]
        public bool IsClosed { get; set; } = false;

        [DisplayName("Closed On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "N/A")]
        public DateTime? ClosedOn { get; set; }

        public bool IsBoxRequested { get; set; } = false;

        [DisplayName("Requested On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BoxRequestedOn { get; set; }

        public bool IsShipped { get; set; } = false;

        [DisplayName("Shipped Out On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShippedOn { get; set; }

        public bool IsUnitReturned { get; set; } = false;

        [DisplayName("Unit Returned On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnedOn { get; set; }
        #endregion

        [Required]
        public int TabletID { get; set; }
        public virtual Tablet Tablet { get; set; }

        
        public int RepairTypeID { get; set; }
        public virtual RepairType RepairType { get; set; }

        public int TechID { get; set; }
        public virtual Tech Tech { get; set; }

        public virtual ICollection<PartOrder> PartOrders { get; set; }

        public virtual ICollection<ProblemArea> ProblemAreas { get; set; }

    }


}