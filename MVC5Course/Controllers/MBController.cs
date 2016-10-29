using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
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
    }
}