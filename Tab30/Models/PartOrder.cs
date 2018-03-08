using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tab30.Models
{
    public class PartOrder
    {
        public int ID { get; set; }

        [DisplayName("Ordered On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderedOn { get; set; }

        [DisplayName("Part Received")]
        public bool IsPartReceived { get; set; } = false;

        [DisplayName("Received On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReceivedOn { get; set; }

        [ForeignKey("Repair")]
        public int RepairID { get; set; }
        public virtual Repair Repair { get; set; }

        [ForeignKey("Part")]
        public int PartID { get; set; }
        public virtual Part Part { get; set; }
    }
}