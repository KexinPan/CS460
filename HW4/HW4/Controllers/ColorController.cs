using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.UI;

namespace HW4.Controllers
{
    public class ColorController : Controller
    {
        /// <summary>
        /// get the page format first by get method
        /// </summary>
        /// <param name="firstColor"></param>
        /// <param name="secondColor"></param>
        /// <returns>
        /// retunr the view page
        /// </returns>
        
        [HttpGet]
        public ActionResult ColorMixer(string firstColor, string secondColor)
        {
            return View();
        }

        /// <summary>
        /// use post method to do some calculations and give a response to users
        /// </summary>
        /// <param name="firstColor"></param>
        /// <param name="secondColor"></param>
        /// <returns>
        /// return color block in page and use viewbag to pass the value
        /// </returns>
        [HttpPost]
        public ActionResult ColorMixerPost(string firstColor, string secondColor)
        {
            /// output the value that get in the page in Debug 
            Debug.WriteLine(firstColor);
            Debug.WriteLine(secondColor);

            /// change the color string value into color RGB value 
            Color _firstColor = ColorTranslator.FromHtml(firstColor);
            Color _secondColor = ColorTranslator.FromHtml(secondColor);

            /// some calculation about mix color
            int thirdColorR = _firstColor.R + _secondColor.R;
            if (thirdColorR > 255) { thirdColorR = 255; }
            int thirdColorG = _firstColor.G + _secondColor.G;
            if (thirdColorG > 255) { thirdColorG = 212; }
            int thirdColorB = _firstColor.B + _secondColor.B;
            if (thirdColorB > 255) { thirdColorB = 255; }

            /// set a color value to accept the mix result
            Color _thirdColor = Color.FromArgb(thirdColorR, thirdColorG, thirdColorB);

            /// change the color type to string so it can output in page as a color block instead of color value
            string thirdColor = "#" + _thirdColor.R.ToString("X2") + _thirdColor.G.ToString("X2") + _thirdColor.B.ToString("X2");

            /// use ViewBag to convert values
            ViewBag.firstItem = firstColor;
            ViewBag.secondItem = secondColor;
            ViewBag.plusItem = "+";
            ViewBag.equalItem = "=";
            ViewBag.thirdItem = thirdColor;

            return View("ColorMixer");

        }
    }
}