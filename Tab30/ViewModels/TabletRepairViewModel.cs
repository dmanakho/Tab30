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
    public class TabletRepairViewModel : IValidatableObject
    {
        private TabDBContext db = new TabDBContext();

        public TabletRepairViewModel()
        {

            TechID = 2; //Kevin - magic number. In the future to be replaced with ASP.Identity info.
            TechName = db.Teches.Find(TechID).FullName;
            //used in a drop down box to populate repair types in the view.
            RepairTypesDropDownList = new SelectList(db.RepairTypes.OrderBy(p => p.Description).ToList(), "ID", "Description");

            //used to populate problem areas in the view
            ProblemsDropDownList = new MultiSelectList(db.ProblemAreas.OrderBy(p => p.Description), "ID", "Description", AssignedProblems);

            //used to populate parts table in the View
            Parts = db.Parts.OrderBy(p => p.Description).ToList();

            //not sure - i forgot what this is for.
            OrderedPartsDropDownList = new MultiSelectList(db.Parts.OrderBy(p => p.Description), "ID", "Description", OrderedPartIDs);

            //list of Ints to store actually ordered part IDs.
            OrderedPartIDs = new List<int>();
            PartOrders = new List<PartOrder>();
        }

        public TabletRepairViewModel(int? tabletID = null) : this()
        {
            Tablet = db.Tablets.Find(tabletID);
        }

        public int ID { get; set; }

        [DisplayName("Vendor Case#"), StringLength(50)]
        public string VendorCaseNo { get; set; }

        [Required]
        [DisplayName("Description"), StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        #region Boolean and DataTime Fields

        [DisplayName("Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }


        [DisplayName("Updated On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedOn { get; set; }

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

        [Timestamp]
        public Byte[] RowVersion { get; set; } //added for future councurrency check.

        public Tablet Tablet { get; set; }
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
        public IEnumerable<SelectListItem> OrderedPartsDropDownList { get; set; }

        public List<Part> Parts { get; set; }

        [DisplayName("Repair Type: ")]
        public int RepairTypeID { get; set; }
        public IEnumerable<SelectListItem> RepairTypesDropDownList { get; set; }

        //I set line below for the drop down box.
        //found a better solution here : https://stackoverflow.com/questions/11509831/values-of-dropdown-lists-are-not-passed-back-to-the-controller
        //public IList<RepairType> RepairTypes { get; set; }

        //I'd like to display problems in multi-select listbox with Select2 JS library applied. added MultiSelect property to generate list of 
        //problem areas
        //public IList<AssignedProblemAreas> Problems { get; set; }

        [DisplayName("Problems")]
        public IList<int> AssignedProblems { get; set; }

        public IEnumerable<SelectListItem> ProblemsDropDownList { get; set; }

        public List<PartOrder> PartOrders { get; set; }

        public ICollection<ProblemArea> ProblemAreas { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ClosedOn.HasValue && ClosedOn.GetValueOrDefault() <= CreatedOn)
            {
                yield return new ValidationResult("Case closure date can't happen before case create date", new[] { "ClosedOn" });
            }
            if (ShippedOn.HasValue && ShippedOn.GetValueOrDefault() <= CreatedOn)
            {
                yield return new ValidationResult("Shipping date can't happen before case create date", new[] { "ShippedOn" });
            }
            if (BoxRequestedOn.HasValue && BoxRequestedOn.GetValueOrDefault() <= CreatedOn)
            {
                yield return new ValidationResult("Box request date can't happen before case create date", new[] { "BoxRequestedOn" });
            }
            if (ReturnedOn.HasValue && ReturnedOn.GetValueOrDefault() <= CreatedOn)
            {
                yield return new ValidationResult("Unit return date can't happen before case create date", new[] { "ReturnedOn" });
            }
        }

        public static implicit operator TabletRepairViewModel(Repair repair)
        {
            return new TabletRepairViewModel
            {
                ID = repair.ID,
                VendorCaseNo = repair.VendorCaseNo,
                Description = repair.Description,
                IsClosed = repair.IsClosed,
                CreatedOn = ConvertToLocalTime(repair.CreatedOn),
                UpdatedOn = ConvertToLocalTime(repair.UpdatedOn),
                RowVersion = repair.RowVersion,
                ClosedOn = ConvertToLocalTime(repair.ClosedOn),
                IsBoxRequested = repair.IsBoxRequested,
                BoxRequestedOn = ConvertToLocalTime(repair.BoxRequestedOn),
                IsShipped = repair.IsShipped,
                ShippedOn = repair.ShippedOn,
                ReturnedOn = ConvertToLocalTime(repair.ReturnedOn),
                Tablet = repair.Tablet,
                TabletID = repair.TabletID,
                TechID = repair.TechID,
                //PartOrders = repair.PartOrders.ToList(),
                IsUnitReturned = repair.IsUnitReturned,
                RepairTypeID = repair.RepairTypeID,
                TechName = repair.Tech.FullName,
                AssignedProblems = repair.ProblemAreas.Select(n => n.ID).ToList(),
                OrderedPartIDs = repair.PartOrders.Select(d => d.PartID).ToList(),
                OrderedParts = repair.PartOrders.Select(d => d.Part).ToList(),
                PartOrders = repair.PartOrders.ToList(),
                ProblemAreas = repair.ProblemAreas
            };
        }

        public static implicit operator Repair(TabletRepairViewModel repairTablet)
        {
            return new Repair{
                ID = repairTablet.ID,
                VendorCaseNo = repairTablet.VendorCaseNo,
                Description = repairTablet.Description,
                RowVersion = repairTablet.RowVersion,
                IsClosed = repairTablet.IsClosed,
                ClosedOn = ConvertToUTCTime(repairTablet.ClosedOn),
                IsBoxRequested = repairTablet.IsBoxRequested,
                BoxRequestedOn = ConvertToUTCTime(repairTablet.BoxRequestedOn),
                IsShipped = repairTablet.IsShipped,
                ShippedOn = ConvertToUTCTime(repairTablet.ShippedOn),
                ReturnedOn = ConvertToUTCTime(repairTablet.ReturnedOn),
                Tablet = repairTablet.Tablet,
                TabletID = repairTablet.TabletID,
                TechID = repairTablet.TechID,
                //PartOrders = repairTablet.PartOrders,
                IsUnitReturned = repairTablet.IsUnitReturned,
                RepairTypeID = repairTablet.RepairTypeID,
                ProblemAreas = repairTablet.ProblemAreas

            };

        }

        private static DateTime? ConvertToUTCTime(DateTime? localTime)
        {
            DateTime? _UTCTime = null;
            if (localTime.HasValue)
            {
                _UTCTime = localTime.Value.ToUniversalTime();
            }
            return _UTCTime;
        }
        private static DateTime? ConvertToLocalTime(DateTime? _UTCTime)
        {
            DateTime? _localTime = null;
            if (_UTCTime.HasValue)
            {
                _localTime = _UTCTime.Value.ToLocalTime();
            }
            return _localTime;
        }

    }
}