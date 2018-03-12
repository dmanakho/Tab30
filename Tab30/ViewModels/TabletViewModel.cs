using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tab30.DAL;
using Tab30.Models;
using Tab30.Models.Helpers;


namespace Tab30.ViewModels
{
    //TabletViewModel implements IValidatableObject interface to provide with the additional custom validation.
    public class TabletViewModel: IValidatableObject // validation explained here: https://youtu.be/0NqLCHAuMHE
    {
        private TabDBContext db = new TabDBContext();
        public TabletViewModel()
        {

            Locations = new SelectList(db.Locations.OrderBy(p => p.ShortDescription), "ID", "ShortDescription");
            Users = new SelectList(db.Users.ToList().OrderBy(t => t.FullName), "ID", "FullName");
        }
        public int ID { get; set; }

        [DisplayName("Tablet Name")]
        [StringLength(50, MinimumLength = 8)]
        [Required]
        public string TabletName { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(50)]
        public string Make { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(50)]
        public string Model { get; set; }

        [DisplayName("Serial Number")]
        [StringLength(20)]
        [Required]
        public string SerialNo { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [DisplayName("Asset Tag")]
        [StringLength(20)]
        public string AssetTag { get; set; }

        [DisplayName("Warranty Expiration")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "N/A")]
        public DateTime? WarrantyExpiresOn { get; set; }

        [DisplayName("ADP")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public bool ADPEnabled { get; set; }

        [DisplayName("Out of Circulation")]
        public bool IsOutOfCirculation { get; set; } = false;

        [DisplayName("Created On")]
        [DisplayFormat(NullDisplayText = "(not set)")]
        public DateTime? CreatedOn { get; set; }

        [DisplayName("Updated On")]
        [DisplayFormat(NullDisplayText = "(not set)")]
        public DateTime? UpdatedOn { get; set; }

        [DisplayName("Created By:")]
        [DisplayFormat(NullDisplayText = "(not assigned)")]
        public string CreatedBy { get; set; }

        [DisplayName("Updated By:")]
        [DisplayFormat(NullDisplayText = "(not assigned)")]
        public string UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        [Timestamp]
        public Byte[] RowVersion { get; set; } //added for future councurrency check.


        [DisplayFormat(NullDisplayText = "N/A")]
        public int? LocationID { get; set; }

        public IEnumerable<SelectListItem> Locations { get; set; }

        [DisplayFormat(NullDisplayText = "(not assigned)")]
        public int? UserID { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }

        public ICollection<Repair> Repairs { get; set; }
        public User User { get; set; }
        public Location Location { get; set; }

        //the method below implements IValidatableobject interface and allows for an easy way to provide validations.
        //see this video for detailed explanation: https://youtu.be/0NqLCHAuMHE

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (WarrantyExpiresOn.HasValue && WarrantyExpiresOn.GetValueOrDefault() < DateTime.Now)
            {
                yield return new ValidationResult("Warranty Expiration can't be in the past", new[] { "WarrantyExpiresOn" });
            }
            
        }

        public static implicit operator TabletViewModel(Tablet tablet)
        {
            return new TabletViewModel
            {
                ID = tablet.ID,
                TabletName = tablet.TabletName,
                Make = tablet.Make,
                Model = tablet.Model,
                AssetTag = tablet.AssetTag,
                ADPEnabled = tablet.ADPEnabled.HasValue ? (bool)tablet.ADPEnabled : false,
                LocationID = tablet.LocationID,
                IsOutOfCirculation = tablet.OutOfCirculation.HasValue ? (bool)tablet.OutOfCirculation : false,
                SerialNo = tablet.SerialNo,
                UserID = tablet.UserID,
                WarrantyExpiresOn = tablet.WarrantyExpiresOn,
                //converting to local time, since we store these values in UTC time in the database.
                CreatedOn = Helpers.ConvertToLocalTime(tablet.CreatedOn),
                UpdatedOn = Helpers.ConvertToLocalTime(tablet.UpdatedOn),
                CreatedBy = tablet.CreatedBy,
                UpdatedBy = tablet.UpdatedBy,
                Repairs = tablet.Repairs,
                User = tablet.User,
                Location = tablet.Location,
                RowVersion = tablet.RowVersion

            };
        }

        public static implicit operator Tablet(TabletViewModel tabletViewModel)
        {
            return new Tablet
            {
                ID = tabletViewModel.ID,
                TabletName = tabletViewModel.TabletName,
                Make = tabletViewModel.Make,
                Model = tabletViewModel.Model,
                AssetTag = tabletViewModel.AssetTag,
                ADPEnabled = tabletViewModel.ADPEnabled,
                LocationID = tabletViewModel.LocationID,
                OutOfCirculation = tabletViewModel.IsOutOfCirculation,
                SerialNo = tabletViewModel.SerialNo,
                UserID = tabletViewModel.UserID,
                WarrantyExpiresOn = tabletViewModel.WarrantyExpiresOn,
                CreatedOn = Helpers.ConvertToUTCTime(tabletViewModel.CreatedOn),
                UpdatedOn = Helpers.ConvertToUTCTime(tabletViewModel.UpdatedOn),
                CreatedBy = tabletViewModel.CreatedBy,
                UpdatedBy = tabletViewModel.UpdatedBy,
                RowVersion = tabletViewModel.RowVersion
            };
        }
    }
}

