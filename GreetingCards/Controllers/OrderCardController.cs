using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreetingCards.Models;

namespace GreetingCards.Controllers
{
    public class OrderCardController : Controller
    {
        private SamCardsDb db = new SamCardsDb();

        // GET: OrderCard
        public ActionResult Index()
        {
            var cardInfos = db.CardInfos.Include(c => c.CardCategory);
            return View(cardInfos.ToList());
        }

        // GET: OrderCard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardInfo cardInfo = db.CardInfos.Find(id);
            if (cardInfo == null)
            {
                return HttpNotFound();
            }
            return View(cardInfo);
        }

        // GET: OrderCard/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.CardCategories, "Id", "Description");
            return View();
        }

        // POST: OrderCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Description,ImageFront,ImageBack")] CardInfo cardInfo)
        {
            if (ModelState.IsValid)
            {
                db.CardInfos.Add(cardInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(db.CardCategories, "Id", "Description", cardInfo.Category);
            return View(cardInfo);
        }

        // GET: OrderCard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardInfo cardInfo = db.CardInfos.Find(id);
            if (cardInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.CardCategories, "Id", "Description", cardInfo.Category);
            return View(cardInfo);
        }

        // POST: OrderCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Description,ImageFront,ImageBack")] CardInfo cardInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.CardCategories, "Id", "Description", cardInfo.Category);
            return View(cardInfo);
        }

        // GET: OrderCard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardInfo cardInfo = db.CardInfos.Find(id);
            if (cardInfo == null)
            {
                return HttpNotFound();
            }
            return View(cardInfo);
        }

        // POST: OrderCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardInfo cardInfo = db.CardInfos.Find(id);
            db.CardInfos.Remove(cardInfo);
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
