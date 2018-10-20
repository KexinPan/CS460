using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult MileConvert()
        {
            Debug.WriteLine(Request.QueryString["miles"]);
            Debug.WriteLine(Request.QueryString["unit"]);

            string mileValue = Request.QueryString["miles"];
            //string unit = String.Format("{0}", Request.QueryString["unit"]);
            string unit = Request.QueryString["unit"];
            double value = Convert.ToDouble(mileValue);

            if (mileValue != null)
            {
                string message = "non";

                if (unit.Equals("millimeters"))
                {
                    message = value + " miles is equal to " + value * 1609344 + " millimeters";
                }
                if (unit.Equals("centimeters"))
                {
                    message = value + " miles is equal to " + value * 160934.4 + " centimeters";
                }
                if (unit.Equals("meters"))
                {
                    message = value + " miles is equal to " + value * 1609.344 + " meters";
                }
                if (unit.Equals("kilometers"))
                {
                    message = value + " miles is equal to " + value * 1.609344 + " kilometers";
                }
                ViewBag.message = message;
            }

            return View();
        }

    }
}