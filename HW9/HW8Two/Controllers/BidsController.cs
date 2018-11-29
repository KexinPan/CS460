using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8Two.Models;
using HW8Two.Models.ViewModel;

namespace HW8Two.Controllers
{
    public class BidsController : Controller
    {
        private StockContext db = new StockContext();

        public ActionResult ThanksPage()
        { 
            return View();
        }

        // GET: Bids/Details/5
        public JsonResult Details(int? id)
        {
            BidList bidlist = new BidList();
            bidlist.Bid = db.Bids.Where(b => b.ItemID==id).ToList();

            if (bidlist.Bid.Count() > 0)
            {
                var list = bidlist.Bid.Select(b=>new { b.BuyerName,b.Price}).OrderByDescending(b=>b.Price).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json("",JsonRequestBehavior.AllowGet);
        }

        // GET: Bids/Create
        public ActionResult Create()
        {
            ViewBag.BuyerName = new SelectList(db.Buyers, "BuyerName", "BuyerName");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidID,ItemID,BuyerName,Price,DateValue")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("ThanksPage");
            }

            ViewBag.BuyerName = new SelectList(db.Buyers, "BuyerName", "BuyerName", bid.BuyerName);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", bid.ItemID);
            return View(bid);
        }
    }
}
