using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tab30.Models
{
    public class User
    {
        public int ID { get; set; }

        [DisplayName("Import ID")]
        [StringLength(50, ErrorMessage = "Import ID can't exceed 50 characters")]
        [Index(IsUnique = true)]
        public string ImportID { get; set; }

        [DisplayName("First Name")]
        [StringLength(50, ErrorMessage = "First Name can't exceed 50 characters")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50, ErrorMessage = "Last Name can't exceed 50 characters")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("User Name")]
        [StringLength(20, ErrorMessage = "First Name can't exceed 20 characters")]
        [Required]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [DisplayName("Class Of")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public int? ClassOf { get; set; }

        [DisplayName("Created On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Updated On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedOn { get; set; }

        [DisplayName("Assigned User:")]
        [DisplayFormat(NullDisplayText = "(not assigned)")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public virtual ICollection<Tablet> Tablets { get; set; }

    }
}