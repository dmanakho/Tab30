using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tab30.DAL;
using Tab30.Models;

namespace Tab30.ViewModels
{
    public class TabletRepairViewModel
    {
        private TabDBContext db = new TabDBContext();

        public TabletRepairViewModel()
        {
            //used in a drop down box to populate repair types in the view.
            RepairTypes = new SelectList(db.RepairTypes.OrderBy(p => p.Description).ToList(), "ID", "Description");

            //used to populate parts table in the View
            Parts = db.Parts.OrderBy(p => p.Description).ToList();

            //used to populate problem areas in the view
            Problems = new MultiSelectList(db.ProblemAreas.OrderBy(p => p.Description), "ID", "Description", this.AssignedProblems);

            OrderedPartsSelectList = new MultiSelectList(db.Parts.OrderBy(p => p.Description), "ID", "Description", this.OrderedPartIDs);

            OrderedPartIDs = new List<int>();
        }

        public int ID { get; set; }

        [DisplayName("Vendor Case#"), StringLength(50)]
        public string VendorCaseNo { get; set; }

        [Required]
        [DisplayName("Description"), StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //[DataType(DataType.MultilineText)]
        //public string Comment { get; set; }

        #region Boolean and DataTime Fields

        [DisplayName("Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Closed")]
        public bool IsClosed { get; set; } = false;

        [DisplayName("Closed On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "N/A")]
        public DateTime? ClosedOn { get; set; }

        [DisplayName("Box Requested")]
        public bool IsBoxRequested { get; set; } = false;

        [DisplayName("Requested On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BoxRequestedOn { get; set; }

        [DisplayName("Shipped Out")]
        public bool IsShipped { get; set; } = false;

        [DisplayName("Shipped Out On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShippedOn { get; set; }

        [DisplayName("Unit Returned")]
        public bool IsUnitReturned { get; set; } = false;

        [DisplayName("Returned On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnedOn { get; set; }
        #endregion 

        [Required]
        public int TabletID { get; set; }
        public string TabletName { get; set; }

        [Required]
        public int TechID { get; set; }
        public string TechName { get; set; }

        // public List<PartOrder> PartOrders { get; set; }

        [DisplayName("Parts Ordered: ")]
        public List<int> OrderedPartIDs { get; set; }
        public IEnumerable<Part> OrderedParts { get; set; }
        public IEnumerable<SelectListItem> OrderedPartsSelectList { get; set; }

        public List<Part> Parts { get; set; }

        [DisplayName("Repair Type: ")]
        public int RepairTypeID { get; set; }
        public IEnumerable<SelectListItem> RepairTypes { get; set; }

        //I set line below for the drop down box.
        //found a better solution here : https://stackoverflow.com/questions/11509831/values-of-dropdown-lists-are-not-passed-back-to-the-controller
        //public IList<RepairType> RepairTypes { get; set; }

        //I'd like to display problems in multi-select listbox with Select2 JS library applied. added MultiSelect property to generate list of 
        //problem areas
        //public IList<AssignedProblemAreas> Problems { get; set; }

        [DisplayName("Problems")]
        public IList<int> AssignedProblems { get; set; }
       
        public IEnumerable<SelectListItem> Problems { get; set; }

        public IList<PartOrder> PartOrders { get; set; }


        public static implicit operator TabletRepairViewModel(Repair repair)
        {
            return new TabletRepairViewModel
            {
                ID = repair.ID,
                VendorCaseNo = repair.VendorCaseNo,
                Description = repair.Description,
                IsClosed = repair.IsClosed,
                CreatedOn = repair.CreatedOn,
                ClosedOn = repair.ClosedOn,
                IsBoxRequested = repair.IsBoxRequested,
                BoxRequestedOn = repair.BoxRequestedOn,
                IsShipped = repair.IsShipped,
                ShippedOn = repair.ShippedOn,
                ReturnedOn = repair.ReturnedOn,
                TabletID = repair.TabletID,
                TechID = repair.TechID,
                //PartOrders = repair.PartOrders.ToList(),
                IsUnitReturned = repair.IsUnitReturned,
                RepairTypeID = repair.RepairTypeID,
                TechName = repair.Tech.FullName,
                TabletName = repair.Tablet.TabletName,
                AssignedProblems = repair.ProblemAreas.Select(n => n.ID).ToList(),
                OrderedPartIDs = repair.PartOrders.Select(d => d.PartID).ToList(),
                OrderedParts = repair.PartOrders.Select(d => d.Part).ToList(),
                PartOrders = repair.PartOrders.ToList()
            };
        }

        public static implicit operator Repair(TabletRepairViewModel repairTablet)
        {
            return new Repair
            {
                ID = repairTablet.ID,
                VendorCaseNo = repairTablet.VendorCaseNo,
                Description = repairTablet.Description,
                //Comment = repairTablet.Comment,
                CreatedOn = repairTablet.CreatedOn,
                IsClosed = repairTablet.IsClosed,
                ClosedOn = repairTablet.ClosedOn,
                IsBoxRequested = repairTablet.IsBoxRequested,
                BoxRequestedOn = repairTablet.BoxRequestedOn,
                IsShipped = repairTablet.IsShipped,
                ShippedOn = repairTablet.ShippedOn,
                ReturnedOn = repairTablet.ReturnedOn,
                TabletID = repairTablet.TabletID,
                TechID = repairTablet.TechID,
                //PartOrders = repairTablet.PartOrders,
                IsUnitReturned = repairTablet.IsUnitReturned,
                RepairTypeID = repairTablet.RepairTypeID
            };
        }
    }
}