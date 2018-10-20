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

        [HttpGet]
        public ActionResult ColorMixer(string firstColor, string secondColor)
        {
            return View();
        }


        [HttpPost]
        public ActionResult ColorMixerPost(string firstColor, string secondColor)
        {
            
            Debug.WriteLine(firstColor);
            Debug.WriteLine(secondColor);
            Color _firstColor = ColorTranslator.FromHtml(firstColor);
            Color _secondColor = ColorTranslator.FromHtml(secondColor);

            int thirdColorR = _firstColor.R + _secondColor.R;
            if (thirdColorR > 255) { thirdColorR = 255; }
            int thirdColorG = _firstColor.G + _secondColor.G;
            if (thirdColorG > 255) { thirdColorG = 212; }
            int thirdColorB = _firstColor.B + _secondColor.B;
            if (thirdColorB > 255) { thirdColorB = 255; }

            Color _thirdColor = Color.FromArgb(thirdColorR, thirdColorG, thirdColorB);
            string thirdColor = "#" + _thirdColor.R.ToString("X2") + _thirdColor.G.ToString("X2") + _thirdColor.B.ToString("X2");

            ViewBag.firstItem = firstColor;
            ViewBag.secondItem = secondColor;
            ViewBag.plusItem = "+";
            ViewBag.equalItem = "=";
            ViewBag.thirdItem = thirdColor;

            return View("ColorMixer");

        }
    }
}