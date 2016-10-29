using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
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
        public ActionResult JsonTest()
        {
            db.Configuration.LazyLoadingEnabled = false;//停用延遲載入就不會有遁環載入的問題
            var data = db.Product.OrderBy(p => p.ProductId).Take(10);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}