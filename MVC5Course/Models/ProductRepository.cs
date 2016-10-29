using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public Product Find(int id)
        {
            Product product = this.All().FirstOrDefault(p => p.ProductId == id);
            return product;
        }
	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}