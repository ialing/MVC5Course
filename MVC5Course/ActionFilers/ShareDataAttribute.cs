using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class Share頁面上常用的ViewBag變數資料Attribute : ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext filterContext)
{
            filterContext.Controller.ViewData["Temp1"] = "暫存資料Temp1"; 
}
           

    }
}
