using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new  FabricsEntities();
        // GET: EF
        public ActionResult Index()
        {
            //var db = new  FabricsEntities();
            var data = db.Product.Where(p => p.ProductName.Contains("White"));

            return View(data);
        }
        public ActionResult Create()
        {
            var product = new Product()
            {
                Active=false,
                Price=100,
                ProductName="white cat",
                Stock=5                
            };
            db.Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);
            //有關連資料表時，先刪除
            //db.OrderLine.RemoveRange(product.OrderLine);

            //db.Product.Remove(product);
            product.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public ActionResult Details(int id)
        {
            var product = db.Product.Find(id);

            return View(product);
        }
        public ActionResult Update(int id)
        {
            var product = db.Product.Find(id);
            product.ProductName += "!";
            try
            {
                db.SaveChanges(); 
            }
            catch (DbEntityValidationException Ex )
            { 
                foreach (var entityErrors in Ex.EntityValidationErrors)
                {
                    foreach (var vErrors in entityErrors.ValidationErrors)
                    {
                        throw new Exception(vErrors.PropertyName +" Error:" + vErrors.ErrorMessage.ToString());
                    }
                }
                throw;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Add20Percent()
        {
            //var data = db.Product.Where(p => p.ProductName.Contains("White"));

            //foreach (var d in data)
            //{
            //    if (d.Price.HasValue)
            //    {
            //        d.Price = d.Price.Value * 1.2m;
            //    }
            //}
            //db.SaveChanges();
            //--ExecuteSqlCommand--
            string sWhere = "%white%";
            db.Database.ExecuteSqlCommand("Update  Product Set price=price*1.2 where ProductName Like @p0 ",sWhere);
            return RedirectToAction("Index");
 
        }
        public ActionResult Edit(int id)
        {
            var product = db.Product.FirstOrDefault(p => p.ProductId == id);
            return View();
        }
        public ActionResult ClientContribution()
        {
            var data = db.vw_ClientContribution.Take(10);
            return View(data);
        }
        public ActionResult ClientContribution2(string keyword= "Mary")
        {
            var data = db.Database.SqlQuery<ClientContributionViewModel>(@"
                SELECT
		                 c.ClientId,
		                 c.FirstName,
		                 c.LastName,
		                 (SELECT SUM(o.OrderTotal) 
		                  FROM [dbo].[Order] o 
		                  WHERE o.ClientId = c.ClientId) as OrderTotal
	                FROM 
		                [dbo].[Client] as c where c.FirstName like @p0 ","%" +keyword +"%");

            return View(data);
        } 
        public ActionResult ClientContribution3(string keyword)
        {
            var data = db.usp_GetClientContribution(keyword);
            return View(data);  
        }
    }
}