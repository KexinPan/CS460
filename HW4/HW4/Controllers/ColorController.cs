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
        /// <param name="FirstColor"></param>
        /// <param name="SecondColor"></param>
        /// <returns>
        /// retunr the view page
        /// </returns>
        
        [HttpGet]
        public ActionResult ColorMixer()
        {
            return View();
        }

        /// <summary>
        /// use post method to do some calculations and give a response to users
        /// </summary>
        /// <param name="FirstColor"></param>
        /// <param name="SecondColor"></param>
        /// <returns>
        /// return color block in page and use viewbag to pass the value
        /// </returns>
        [HttpPost]
        public ActionResult ColorMixer(string FirstColor, string SecondColor)
        {
            /// output the value that get in the page in Debug 
            Debug.WriteLine(FirstColor);
            Debug.WriteLine(SecondColor);

            /// change the color string value into color RGB value 
            Color _firstColor = ColorTranslator.FromHtml(FirstColor);
            Color _secondColor = ColorTranslator.FromHtml(SecondColor);

            /// some calculation about mix color
            int ThirdColorR = _firstColor.R + _secondColor.R;
            if (ThirdColorR > 255) { ThirdColorR = 255; }
            int ThirdColorG = _firstColor.G + _secondColor.G;
            if (ThirdColorG > 255) { ThirdColorG = 212; }
            int ThirdColorB = _firstColor.B + _secondColor.B;
            if (ThirdColorB > 255) { ThirdColorB = 255; }

            /// set a color value to accept the mix result
            Color _thirdColor = Color.FromArgb(ThirdColorR, ThirdColorG, ThirdColorB);

            /// change the color type to string so it can output in page as a color block instead of color value
            string ThirdColor = "#" + _thirdColor.R.ToString("X2") + _thirdColor.G.ToString("X2") + _thirdColor.B.ToString("X2");

            /// use ViewBag to convert values
            ViewBag.firstItem = FirstColor;
            ViewBag.secondItem = SecondColor;
            ViewBag.plusItem = "+";
            ViewBag.equalItem = "=";
            ViewBag.thirdItem = ThirdColor;

            return View();

        }
    }
}