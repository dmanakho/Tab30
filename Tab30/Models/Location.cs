using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tab30.Models
{
    public class Location
    {
        public int ID { get; set; }

        [Display(Name = "Location")]
        [Required]
        [StringLength(5, ErrorMessage = "Short Location Description can't exceed 5 characters")]
        [DisplayFormat(NullDisplayText = "(not set)")]
        [Index(IsUnique = true)]
        public string ShortDescription { get; set; }

        [Display(Name = "Location Description")]
        [Required]
        [StringLength(50, ErrorMessage = "Long Location Description can't exceed 50 characters")]
        [DisplayFormat(NullDisplayText = "not set")]
        public string LongDescription { get; set; }

        public virtual ICollection<Tablet> Tablets { get; set; }
    }
}