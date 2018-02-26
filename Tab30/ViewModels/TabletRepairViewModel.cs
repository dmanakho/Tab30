using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tab30.DAL;
using Tab30.Models;

namespace Tab30.ViewModels
{
    public class TabletRepairViewModel
    {
        private TabDBContext db = new TabDBContext();
        public TabletRepairViewModel()
        {
            Parts = db.Parts.OrderBy(p=>p.Description).ToList();
            PartOrders = new List<PartOrder>();
        }
        public Tab30.TabDB_Code.TabDBEnums.RepairType RepairType { get; set; }


        [DisplayName("Vendor Case#"), StringLength(50)]
        public string VendorCaseNo { get; set; }

        [DisplayName("Description"), StringLength(250)]
        public string RepairDescription { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [DisplayName("Closed")]
        public bool IsComplete { get; set; } = false;

        [DisplayName("Closed On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "N/A")]
        public DateTime? RepairClosed { get; set; }

        [DisplayName("Box Requested")]
        public bool IsBoxRequested { get; set; } = false;

        [DisplayName("Requested On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? BoxRequestedOn { get; set; }

        [DisplayName("Shipped Out")]
        public bool IsShipped { get; set; } = false;

        [DisplayName("Shipped Out On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? ShippedOn { get; set; }

        [DisplayName("Unit Returned")]
        public bool IsUnitReturned { get; set; } = false;

        [DisplayName("Returned On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnedOn { get; set; }

        [Required]
        public int TabletID { get; set; }
        public string TabletName { get; set; }

        [Required]
        public int TechID { get; set; }
        public string TechName { get; set; }

        public List<PartOrder> PartOrders { get; set; }

        public List<Part> Parts { get; set; }

        public static implicit operator TabletRepairViewModel(Repair repair)
        {
            return new TabletRepairViewModel
            {
                VendorCaseNo = repair.VendorCaseNo,
                RepairDescription = repair.RepairDescription,
                Comment = repair.Comment,
                IsComplete = repair.IsComplete,
                RepairClosed = repair.RepairClosed,
                IsBoxRequested = repair.IsBoxRequested,
                BoxRequestedOn = repair.BoxRequestedOn,
                IsShipped = repair.IsShipped,
                ShippedOn = repair.ShippedOn,
                ReturnedOn = repair.ReturnedOn,
                TabletID = repair.TabletID,
                TechID = repair.TechID,
                PartOrders = repair.PartOrders.ToList(),
                IsUnitReturned = repair.IsUnitReturned

            };
        }

        public static implicit operator Repair(TabletRepairViewModel repairTablet)
        {
            return new Repair
            {
                VendorCaseNo = repairTablet.VendorCaseNo,
                RepairDescription = repairTablet.RepairDescription,
                Comment = repairTablet.Comment,
                IsComplete = repairTablet.IsComplete,
                RepairClosed = repairTablet.RepairClosed,
                IsBoxRequested = repairTablet.IsBoxRequested,
                BoxRequestedOn = repairTablet.BoxRequestedOn,
                IsShipped = repairTablet.IsShipped,
                ShippedOn = repairTablet.ShippedOn,
                ReturnedOn = repairTablet.ReturnedOn,
                TabletID = repairTablet.TabletID,
                TechID = repairTablet.TechID,
                PartOrders = repairTablet.PartOrders,
                IsUnitReturned = repairTablet.IsUnitReturned
            };
        }
    }
}