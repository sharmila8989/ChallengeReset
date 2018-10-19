using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackModWebApp.Models;

namespace TrackModWebApp.Controllers
{
    [Authorize]
    public class WirelessModulesController : Controller
    {
        private DatabaseSwinSSLEntities db = new DatabaseSwinSSLEntities();

        // GET: WirelessModules
        public ActionResult Index()
        {
            var wirelessModules = db.WirelessModules.Include(w => w.Student);
            return View(wirelessModules.ToList());
        }

        // GET: WirelessModules/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WirelessModule wirelessModule = db.WirelessModules.Find(id);
            if (wirelessModule == null)
            {
                return HttpNotFound();
            }
            return View(wirelessModule);
        }

        // GET: WirelessModules/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Students, "Id", "studentFname");
            return View();
        }

        // POST: WirelessModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MacAddress,IssueDate,Id")] WirelessModule wirelessModule)
        {
            if (ModelState.IsValid)
            {
                db.WirelessModules.Add(wirelessModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Students, "Id", "studentFname", wirelessModule.Id);
            return View(wirelessModule);
        }

        // GET: WirelessModules/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WirelessModule wirelessModule = db.WirelessModules.Find(id);
            if (wirelessModule == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Students, "Id", "studentFname", wirelessModule.Id);
            return View(wirelessModule);
        }

        // POST: WirelessModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MacAddress,IssueDate,Id")] WirelessModule wirelessModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wirelessModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Students, "Id", "studentFname", wirelessModule.Id);
            return View(wirelessModule);
        }

        // GET: WirelessModules/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WirelessModule wirelessModule = db.WirelessModules.Find(id);
            if (wirelessModule == null)
            {
                return HttpNotFound();
            }
            return View(wirelessModule);
        }

        // POST: WirelessModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WirelessModule wirelessModule = db.WirelessModules.Find(id);
            db.WirelessModules.Remove(wirelessModule);
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
