using HW8Two.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8Two.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StockContext db = new StockContext();
            var lastBid = db.Bids.OrderByDescending(b=>b.DateValue).Take(10).ToList();
            return View(lastBid);
        }
    }
}