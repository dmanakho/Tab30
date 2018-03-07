using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tab30.Models
{
    public class Tablet
    {
        public Tablet()
        {
            Repairs = new HashSet<Repair>();
        }
        public int ID { get; set; }

        [DisplayName("Tablet Name")]
        [StringLength(50,ErrorMessage = "Tablet Name can't exceed 50 characters", MinimumLength = 8)]
        [Required]
        [Index(IsUnique = true)]
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
        [Index(IsUnique = true)]
        public string SerialNo { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [DisplayName("Asset Tag")]
        [StringLength(20)]
        [Index(IsUnique = true)]
        public string AssetTag { get; set; }

        [DisplayName("Warranty Expiration")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "N/A")]
        public DateTime? WarrantyExpiresOn { get; set; }

        [DisplayName("ADP")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public bool? ADPEnabled { get; set; }

        [DisplayName("Created On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Updated On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedOn { get; set; }

        [DisplayName("Out of Circulation")]
        public bool? OutOfCirculation { get; set; } = false;

        [DisplayFormat(NullDisplayText = "N/A")]
        public int? LocationID { get; set; }
        [DisplayFormat(NullDisplayText = "N/A")]
        public virtual Location Location { get; set; }

        [DisplayFormat(NullDisplayText = "(not assigned)")]
        public int?   UserID { get; set; }
        [DisplayFormat(NullDisplayText = "(not assigned)")]
        public virtual User User { get; set; }

        public virtual ICollection<Repair> Repairs { get; set; }
    }
}