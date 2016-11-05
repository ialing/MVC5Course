namespace MVC5Course.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OrderLineMetaData))]
    public partial class OrderLine
    {
    }
    
    public partial class OrderLineMetaData
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int LineNumber { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal Qty { get; set; }
        [Required]
        public decimal LineTotal { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
             [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
