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
        /// mile convert can change mile to the other unit
        /// </summary>
        /// <returns>
        /// result is double number and show a string when click button
        /// </returns>
        [HttpGet]
        public ActionResult MileConvert()
        {
            /// output the result in Debug
            Debug.WriteLine(Request.QueryString["miles"]);
            Debug.WriteLine(Request.QueryString["unit"]);

            /// get the input value of miles
            string mileValue = Request.QueryString["miles"];
            
            /// get what kind of unit the user want to change
            string unit = Request.QueryString["unit"];

            /// set the result as a double value
            double value = Convert.ToDouble(mileValue);

            if (mileValue != null)
            {
                /// initialize the string that will be input after click button
                string message = "non";

                /// convert mile to the other unit by calculation
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

            /// return ViewPage of this action
            return View();
        }

    }
}