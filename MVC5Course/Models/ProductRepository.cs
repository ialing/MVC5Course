using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.IsDeleted == false);
        }
        public Product Find(int id)
        {
            Product product = this.All().FirstOrDefault(p => p.ProductId == id);
            return product;
        }
        public IQueryable<Product> Get_�ƧǸ��(int takesize)
        {
            return this.All().OrderByDescending(p => p.ProductId).Take(takesize);
        }
        public override void Delete(Product entity)
        {
            entity.IsDeleted = true;
        }
	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}