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
    
    public class TabletViewModel
    {
        public TabletViewModel()
        { }
        public TabletViewModel(TabDBContext db)
        {
            Locations = new SelectList(db.Locations.OrderBy(p => p.ShortDescription), "ID", "ShortDescription");
            Users = new SelectList(db.Users.ToList().OrderBy(t=>t.FullName), "ID", "FullName");
        }

        public int ID { get; set; }

        [DisplayName("Tablet Name")]
        [StringLength(50, ErrorMessage = "Tablet Name can't exceed 50 characters", MinimumLength = 8)]
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
        public bool OutOfCirculation { get; set; } = false;

        [DisplayFormat(NullDisplayText = "N/A")]
        public int? LocationID { get; set; }

        public IEnumerable<SelectListItem> Locations { get; set; }

        [DisplayFormat(NullDisplayText = "(not assigned)")]
        public int? UserID { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }

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
                OutOfCirculation = tablet.OutOfCirculation.HasValue? (bool) tablet.OutOfCirculation: false,
                SerialNo = tablet.SerialNo,
                UserID = tablet.UserID,
                WarrantyExpiresOn = tablet.WarrantyExpiresOn
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
                OutOfCirculation = tabletViewModel.OutOfCirculation,
                SerialNo = tabletViewModel.SerialNo,
                UserID = tabletViewModel.UserID,
                WarrantyExpiresOn = tabletViewModel.WarrantyExpiresOn
            };
        }
    }
}

