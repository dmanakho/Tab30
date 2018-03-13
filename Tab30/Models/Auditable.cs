using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tab30.Models
{
    public class Auditable : IAuditable
    {
        [ScaffoldColumn(false)]
        [StringLength(256)]
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Created On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(256)]
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Updated On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedOn { get; set; }

        [ScaffoldColumn(false)]
        [Timestamp]
        public Byte[] RowVersion { get; set; } //added for future councurrency check.

        public string CreatedByUserName
        {
            get
            {
                if (!String.IsNullOrEmpty(CreatedBy))
                {
                    return CreatedBy.Contains("@") ? CreatedBy.Substring(0, CreatedBy.IndexOf('@')) : CreatedBy; ; ;
                }
                else
                {
                    return CreatedBy;
                }

            }
        }

        public string UpdatedByUserName
        {
            get
            {
                if (!String.IsNullOrEmpty(UpdatedBy))
                {
                    return UpdatedBy.Contains("@") ? UpdatedBy.Substring(0, UpdatedBy.IndexOf('@')) : UpdatedBy; ; ;
                }
                else
                {
                    return UpdatedBy;
                }
            }
        }
    }
}