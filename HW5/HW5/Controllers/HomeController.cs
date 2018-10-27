using System.Linq;
using HW5.DAL;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using HW5.Models;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        private RequestContext db = new RequestContext();

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(db.request.OrderByDescending(model => model.DateValue).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestForm requestForm = db.request.Find(id);
            if (requestForm == null)
            {
                return HttpNotFound();
            }
            return View(requestForm);
        }

        public ActionResult ThanksPage()
        {
            return View();
        }

        // GET: RequestForms/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,ApartmentName,UnitNumber,Description,Permission")] RequestForm requestForm)
        {
            if (ModelState.IsValid)
            {
                db.request.Add(requestForm);
                db.SaveChanges();
                return RedirectToAction("ThanksPage");
            }

            return View(requestForm);
        }

        // GET: RequestForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestForm requestForm = db.request.Find(id);
            if (requestForm == null)
            {
                return HttpNotFound();
            }
            return View(requestForm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,PhoneNumber,ApartmentName,UnitNumber,Description,Permission")] RequestForm requestForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requestForm);
        }

        // GET: RequestForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestForm requestForm = db.request.Find(id);
            if (requestForm == null)
            {
                return HttpNotFound();
            }
            return View(requestForm);
        }

        // POST: RequestForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestForm requestForm = db.request.Find(id);
            db.request.Remove(requestForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}