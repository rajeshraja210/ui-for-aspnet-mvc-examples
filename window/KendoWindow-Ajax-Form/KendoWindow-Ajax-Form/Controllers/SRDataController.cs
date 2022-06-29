using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoWindow_Ajax_Form.Helpers;
using KendoWindow_Ajax_Form.Models;
using System.IO;
using System.Net;

namespace KendoWindow_Ajax_Form.Controllers
{
    public class SRDataController : Controller
    {
        // GET: SRData
        public ActionResult GetOrders([DataSourceRequest]DataSourceRequest request)
        {
            var result = SRBinderHelper.RetrunListOfOrders();
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult Create(SRViewModel model)
        {
            if (ModelState.IsValid)
            {
                SRBinderHelper.AddOrder(model);
            }

            return PartialView("_OrderCreate", model);
        }
    }
}