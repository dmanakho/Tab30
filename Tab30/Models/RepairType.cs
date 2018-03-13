using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tab30.Models
{
    public class RepairType
    {
        public int ID { get; set; }

        [Required, StringLength(75), DisplayName("Repair Type")]
        public string Description { get; set; }

        //many-to-one to Repairs
        public virtual ICollection<Repair> Repairs { get; set; }
    }
}