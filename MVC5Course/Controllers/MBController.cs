﻿using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData["Temp1"] = "暫存資料Temp1";
            var b = new ClientLoginViewModel()
            {
                FirstName = "Fname",
                LastName = "Lee"
            };
            ViewData["Temp2"] = b;
            ViewBag.Temp3 = b;
            return View();
        }

        public ActionResult MyForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyForm(ClientLoginViewModel cm)
        {
            if (ModelState.IsValid)
            {
                TempData["MyFormData"] = cm;
                return RedirectToAction("MyFormResult");
            }
            return View();
        } 
        public ActionResult MyFormResult()
        {
            return View();
        }
         
        public ActionResult ProductList()
        {
           var data = db.Product.OrderByDescending(p => p.ProductId).Take(10);
          
            return View(data);
        }
        [HttpPost]
        public ActionResult BatchUpdate(ProductBathUpdatViewModel[] items)
        {
            //public ActionResult BatchUpdate(ProductBathUpdatViewModel[] items) --> IList<ProductBathUpdatViewModel> items
            //原本 item.PorductId==>items[0].ProductId  , 一定要命名為items
            if (ModelState.IsValid){
                for (var i=0;i<items.Length ;i++){
                    var prod = db.Product.Find(items[i].ProductId); 
                    prod.ProductName = items[i].ProductName;
                    prod.Stock = items[i].Stock;
                    prod.Price = items[i].Price;
                    prod.Active = items[i].Active;
                }
            }
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}