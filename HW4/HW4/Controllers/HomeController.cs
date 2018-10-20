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
       /// <summary>
       /// mileconvert can convert miles to the other unit by calculation
       /// </summary>
       /// <returns>
       /// double number and string to show the result
       /// </returns>
        [HttpGet]
        public ActionResult MileConvert()
        {
            /// output the value that get in the page in Debug 
            Debug.WriteLine(Request.QueryString["miles"]);
            Debug.WriteLine(Request.QueryString["unit"]);

            /// get the value of miles in user input
            string mileValue = Request.QueryString["miles"];
            
            /// get the type of unit in user choose 
            string unit = Request.QueryString["unit"];
            double value = Convert.ToDouble(mileValue);

            if (mileValue != null)
            {
                /// initialize the result message 
                string message = "non";

                /// convert the mile to othe runit by calculation
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

                /// use View bag to pass the value from Controller to View
                ViewBag.message = message;
            }

            return View();
        }

    }
}