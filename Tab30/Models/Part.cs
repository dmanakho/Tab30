using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tab30.Models
{
    public class Part
    {
        public int ID { get; set; }

        [DisplayName("Vendor Part#"), StringLength(50)]
        [Required]
        [Index(IsUnique = true)]
        public string PartNo { get; set; }

        [DisplayName("Part Description"), StringLength(250)]
        [Required]
        public string Description { get; set; }

        [DisplayName("Estimated Labor Refund"), DataType(DataType.Currency)]
        public decimal? RefundRate { get; set; } = 0;

        public string Summary
        {
            get {
                return $"{Description} - {PartNo}";
            }

        }

        public virtual ICollection<PartOrder> PartOrders { get; set; }
    }
}