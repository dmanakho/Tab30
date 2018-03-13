using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tab30.Models
{
    public class ProblemArea
    {
        public int ID { get; set; }

        [Required, StringLength(75), DisplayName("Description")]
        public string Description { get; set; }
       public virtual ICollection<Repair> Repairs { get; set; }
        

    }
}