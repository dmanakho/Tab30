using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tab30.Models
{
    public class Repair
    {
        public Repair()
        {
            ProblemAreas = new List<ProblemArea>();
        }
        public int ID { get; set; }

        [DisplayName("Vendor Case#"), StringLength(50)]
        [Index(IsUnique = true)]
        public string VendorCaseNo { get; set; }

        [Required]
        [DisplayName("Description"), StringLength(250)]
        public string RepairDescription { get; set; }

        //[DataType(DataType.MultilineText)]
        //public string Comment { get; set; }

        [DisplayName("Closed")]
        public bool IsComplete { get; set; } = false;

        [DisplayName("Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime RepairCreated { get; set; }

        [DisplayName("Updated On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedOn { get; set; }


        [DisplayName("Closed On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "N/A")]
        public DateTime? RepairClosed { get; set; }

        public bool IsBoxRequested { get; set; } = false;

        [DisplayName("Requested On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? BoxRequestedOn { get; set; }

        public bool IsShipped { get; set; } = false;

        [DisplayName("Shipped Out On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? ShippedOn { get; set; }

        public bool IsUnitReturned { get; set; } = false;

        [DisplayName("Unit Returned On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnedOn { get; set; }

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