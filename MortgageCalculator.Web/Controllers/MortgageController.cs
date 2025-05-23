using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Web.Controllers
{
    public class MortgageController : Controller
    {
        // GET: /Mortgage/GetMortgageTypes
        public JsonResult GetMortgageTypes()
        {
            var types = Enum.GetNames(typeof(MortgageType)).ToList();
            return Json(types, JsonRequestBehavior.AllowGet);
        }
    }
}
