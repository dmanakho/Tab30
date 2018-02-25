using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Tab30.TabDB_Code;

namespace Tab30.Models
{
    public class Repair
    {

        public int ID { get; set; }


        public TabDBEnums.RepairType RepairType { get; set; }


        [DisplayName("Vendor Case#"), StringLength(50)]
        public string VendorCaseNo { get; set; }

        [DisplayName("Description"), StringLength(250)]
        public string RepairDescription { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

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

        public int TechID { get; set; }
        public virtual Tech Tech { get; set; }

        public virtual ICollection<PartOrder> PartOrders { get; set; }


    }


}