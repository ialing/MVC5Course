using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FileTestDownload()
        {
            var filePath = Server.MapPath("~/Content/cake.jpg");

            return File(filePath, "image/jpeg","cakedownload.jpg");
        }
        public ActionResult FileTest()
        {
            var filePath = Server.MapPath("~/Content/cake.jpg");
            return File(filePath, "image/jpeg");
        }
    }
}