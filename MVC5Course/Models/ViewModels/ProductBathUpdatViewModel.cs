using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels 
{
    public class ProductBathUpdatViewModel : IValidatableObject
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Price >= 1000 && this.Stock >= 1000)
            {
                yield return new ValidationResult("本商品價格與庫存不合理", new string[] { "Price", "Stock" });
            }
            
        }
    }
    
}