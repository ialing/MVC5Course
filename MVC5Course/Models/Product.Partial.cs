namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Price >= 1000 && this.Stock >= 1000)
            {
                yield return new ValidationResult("本商品價格與庫存不合理", new string[] { "Price", "Stock" });
            }
            if (this.ProductName == "will")
            {
                yield return new ValidationResult("為註冊商標", new string[] { "ProductName" });
            }
        }
    }
    
    public partial class ProductMetaData
    {
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Required]
        public string ProductName { get; set; }
        [Range(0,99999)]
        [Required]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
