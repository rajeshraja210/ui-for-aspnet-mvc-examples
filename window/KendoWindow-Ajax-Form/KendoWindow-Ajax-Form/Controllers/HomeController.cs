using KendoWindow_Ajax_Form.Helpers;
using KendoWindow_Ajax_Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoWindow_Ajax_Form.Controllers
{
    public class HomeController : Controller
    {
       
        public HomeController()
            :base()
        {
            try
            {
                IEnumerable<SRViewModel> testResult = SRBinderHelper.RetrunListOfOrders();
            }
            catch (Exception)
            {
                SRBinderHelper.WriteListOfOrders(new List<SRViewModel>()
                {
                    new SRViewModel() { ContactName = "Charles", CustomerID="1", SRDate= DateTime.Now.AddDays(-1), SRID=1,ShippedDate = DateTime.Now },
                    new SRViewModel() { ContactName = "John", CustomerID="2", SRDate= DateTime.Now.AddDays(-2), SRID=2,ShippedDate = DateTime.Now },
                });
            }
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult OrderCreatePartial()
        {
            return PartialView("_OrderCreate");
        }
    }
}
